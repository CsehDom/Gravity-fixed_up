using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravitáció
{
    class Bolygó
    {
        private PointD Hely;
        //public Point Location;
        private PointD Sebességvektor;
        public Color szín;
        public double Tömeg;
        public int Méret;
        private SolidBrush br;
        private List<PointD> gravitációvektorok;

        public static object ModifyListElementsLock { get; } = new object();
        public static List<Bolygó> lista = new List<Bolygó>();
        private static int listReaderCount = 0;
        private static object listModifyLock = new object();
        private static object FiddlingWithLocksLock = new object();//damn it... This is needed to avoid race condition where ExitListLockModify() may set noListReadersLeft after EnderListLockRead() just reset it (while exllr() was running)... I was hoping that I could do this without an additional lock with Interlocking.Increment..
        private static ManualResetEvent noListReadersLeft = new ManualResetEvent(true);
        public static void EnterListLockRead()
        {
            lock (listModifyLock)
            {
                lock (FiddlingWithLocksLock)
                {
                    ++listReaderCount;
                    noListReadersLeft.Reset();
                }
            }
        }

        public static void ExitListLockRead()
        {
            lock (FiddlingWithLocksLock)
            {
                --listReaderCount;
                if (listReaderCount == 0)
                    noListReadersLeft.Set();
            }
        }

        public static void EnterListLockModify()//use responsibly, quite dangerous (naked Monitor.Enter)
        {
            Monitor.Enter(listModifyLock);
            noListReadersLeft.WaitOne();
        }

        public static void ExitListLockModify()
        {
            Monitor.Exit(listModifyLock);
        }

        public Bolygó(PointD h, PointD v, Color sz, double m)
        {
            Hely = h;
            Sebességvektor = v;
            szín = sz;
            Tömeg = m;
            Méret = (int)Math.Round(Math.Sqrt(Tömeg / 10));
            br = new SolidBrush(sz);
            gravitációvektorok = new List<PointD>();
            try
            {
                EnterListLockModify();
                lista.Add(this);
            }
            finally
            {
                ExitListLockModify();
            }
        }

        private void GravitációsanKölcsönhat(Bolygó másik)
        {
            double dnégyzet = this.Hely.DistanceFromNégyzet(másik.Hely);
            PointD kettőköztivektor = this.Hely - másik.Hely;
            PointD kettőköztiegységvektor = (this.Hely - másik.Hely) / (Math.Sqrt(dnégyzet));

            this.gravitációvektorok.Add(-1 * másik.Tömeg * kettőköztiegységvektor / dnégyzet);// -1 azért van itt, mert a másik irányba hat!
            másik.gravitációvektorok.Add(this.Tömeg * kettőköztiegységvektor / dnégyzet);
        }

        // ITT TARTOTTUNK, még nem teszteltük, biztosan át kell még nézni.

        public void Lép(int dt)
        {
            Hely += Sebességvektor * (dt / 16D);
        }

        public void Rajz(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(br, Hely.intX() - (Méret / 2), Hely.intY() - (Méret / 2), Méret, Méret);
            //e.Graphics.FillEllipse(br, new Rectangle(Hely - new PointD(Méret / 2, Méret / 2), new Size(Méret, Méret)));
        }

        public static void Léptetések()
        {
            Léptetések(16);
        }

        public static void Léptetések(int dt)
        {
            lock (ModifyListElementsLock)
            {
                try
                {
                    EnterListLockRead();
                    // lenullázzuk a bolygókra ható gravitációs vonzásokat
                    foreach (Bolygó b in lista)
                    {
                        b.gravitációvektorok = new List<PointD>();
                    }

                    // kiszámoljuk az új helyzet alapján minden bolygóra, hogy milyen erők hatnak rájuk
                    Parallel.For(0, lista.Count, (i) =>
                    {

                        for (int j = i + 1; j < lista.Count; j++)
                        {
                            lista[i].GravitációsanKölcsönhat(lista[j]);
                        }
                    });

                    // A bolygóra ható erőket összegezzük (a régi sebességükhöz adjuk hozzá az új gravitációs vektorokat)
                    Parallel.ForEach(lista, (bolygó) =>
                     {
                         foreach (PointD gravitációvektor in bolygó.gravitációvektorok)
                         {
                             bolygó.Sebességvektor += gravitációvektor * (dt / 16D);
                         }
                     });

                    // Végrehajtjuk a mozgásokat.
                    Parallel.ForEach(lista, (bolygó) =>
                     {
                         bolygó.Lép(dt);
                     });
                }
                finally
                {
                    ExitListLockRead();
                }
            }
        }

        public static void RemoveSumMomentum()
        {
            PointD sumMomentum = new PointD();
            double sumMass = 0;
            lock (ModifyListElementsLock)
            {
                try
                {
                    EnterListLockRead();
                    foreach (Bolygó b in lista)
                    {
                        sumMass += b.Tömeg;
                        sumMomentum += b.Sebességvektor * b.Tömeg;
                    }

                    PointD SumCoMVel = sumMomentum / sumMass;

                    foreach (Bolygó b in lista)
                    {
                        b.Sebességvektor -= SumCoMVel;
                    }
                }
                finally
                {
                    ExitListLockRead();
                }
            }
        }

        public static PointD GetCoM()
        {
            try
            {
                EnterListLockRead();
                PointD CoM = new PointD();
                double sumMass = 0;
                foreach (Bolygó b in lista)
                {
                    CoM += b.Hely * b.Tömeg;
                    sumMass += b.Tömeg;
                }
                return CoM / sumMass;
            }
            finally
            {
                ExitListLockRead();
            }
        }

        public static void MoveAll(PointD vector)
        {
            lock (ModifyListElementsLock)
            {
                try
                {
                    EnterListLockRead();
                    foreach (Bolygó b in lista) b.Hely += vector;
                }
                finally
                {
                    ExitListLockRead();
                }
            }
        }
    }
}
