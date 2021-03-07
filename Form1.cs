using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Timer = System.Windows.Forms.Timer;

namespace Gravitáció
{

    public partial class Form1 : Form
    {
        Button b = new Button();
        Timer t = new Timer();
        bool continueThread = true;
        int targetFrameTime = 0;
        int deltaTime = -1;
        Thread gameLoopThread = null;
        bool paused = true;
        Stopwatch globalStopwatch = new Stopwatch();
        double renderScale = 1;

        PointD toAddVel = new PointD();
        PointD toAddPos = new PointD();
        double toAddMass = 0;
        Color toAddColor = Color.Black;

        PointD midPoint = new PointD();

        enum runType
        {
            Thread,
            Timer
        }
        runType rt = runType.Thread;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();

            b.Text = "Start";
            b.Location = new Point(100, 200);
            Controls.Add(b);

            b.Click += Start_Click;

            t.Interval = 1;
            t.Tick += Tikk;

            Bolygó pirosbolygó = new Bolygó(new PointD(300, 200), new PointD(0, 0), Color.Red, 100);
            Bolygó kékbolygó = new Bolygó(new PointD(500, 200), new PointD(0, 10), Color.Blue, 20000);

            MainPB.Size = ClientRectangle.Size;
            Resize += Form1_Resize;

            loopTypeCB.DataSource = Enum.GetValues(typeof(runType));
            globalStopwatch.Start();
            MainPB.MouseWheel += MainPB_MouseWheel;
            setToolTips();
            midPoint.X = MainPB.Width / 2;
            midPoint.Y = MainPB.Height / 2;
            //TogglePause();
        }

        private void setToolTips()
        {

            ToolTip to = new ToolTip();
            to.SetToolTip(xPosTB, "You can also set this by right clicking somewhere");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
            to = new ToolTip();
            to.SetToolTip(yPosTB, "You can also set this by right clicking somewhere");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
            to = new ToolTip();
            to.SetToolTip(xSpeedTB, "You can also set this by dragging with rmb on the form");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
            to = new ToolTip();
            to.SetToolTip(ySpeedTB, "You can also set this by by dragging with rmb on the form");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
            to = new ToolTip();
            to.SetToolTip(massTB, "You can also set this with mouse roller");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
            to.SetToolTip(addButton, "You can also add by clicking with mmb");
            to.Active = true;
            to.InitialDelay = 100;
            to.ShowAlways = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            MainPB.Size = ClientRectangle.Size;
            midPoint.X = MainPB.Width / 2;
            midPoint.Y = MainPB.Height / 2;
        }

        long lastRenderBegunAt = 0;
        private void Render()
        {
            long thisRenderBegunAt = globalStopwatch.ElapsedTicks;
            Text = ((thisRenderBegunAt - lastRenderBegunAt) * 1000D / Stopwatch.Frequency).ToString() + ", renderScale: " + renderScale.ToString();
            lastRenderBegunAt = thisRenderBegunAt;
            MainPB.Invalidate();
        }

        private static void gameLoop(object form)
        {
            long lastFrameAt = 0;
            Form1 thisForm1 = (Form1)form;
            int targetFrameTime;
            int deltaTime;
            int frameCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (thisForm1.continueThread)
            {
                targetFrameTime = thisForm1.targetFrameTime;
                deltaTime = thisForm1.deltaTime;
                try
                {
                    //IAsyncResult renderTask = thisForm1.BeginInvoke((MethodInvoker)(() => thisForm1.Render()));//mildly dangerous (e.g. foreach and linq), but in theory fine as planets don't get removed
                    thisForm1.Invoke( (MethodInvoker)(() => thisForm1.Render()));
                    long thisFrameAt = sw.ElapsedTicks;
                    int dt = deltaTime > 0 ? deltaTime : (targetFrameTime == 0 ? (int)Math.Round((thisFrameAt - lastFrameAt) / (Stopwatch.Frequency / 1000D)) : targetFrameTime);
                    lastFrameAt = thisFrameAt;
                    doIteration(dt);
                    //thisForm1.EndInvoke(renderTask);
                    ++frameCount;
                    while (sw.ElapsedTicks * 1000 <= targetFrameTime * frameCount * Stopwatch.Frequency) ;
                }
                catch (ObjectDisposedException)
                {
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    if (thisForm1.Disposing || thisForm1.IsDisposed) Environment.Exit(0);
                    else throw;
                }
            }
        }

        private void TogglePause()
        {
            if (paused)
            {
                switch (rt)
                {
                    case runType.Thread:
                        {
                            continueThread = true;
                            gameLoopThread = new Thread(gameLoop);
                            gameLoopThread.Start(this);
                            break;
                        }
                    case runType.Timer:
                        {
                            if (targetFrameTime <= 0) t.Interval = 1;
                            else t.Interval = targetFrameTime;
                            lastTikkBegunAt = globalStopwatch.ElapsedTicks;
                            t.Start();
                            break;
                        }

                }
                paused = false;
            }
            else
            {

                switch (rt)
                {
                    case runType.Thread:
                        {
                            continueThread = false;
                            if (!gameLoopThread.Join(100))//probably overflowed or way too big frametime was given
                            {
                                gameLoopThread.Abort();
                                gameLoopThread.Join();
                            }
                            break;
                        }
                    case runType.Timer:
                        {
                            t.Stop();
                            break;
                        }

                }
                paused = true;
            }
        }

        long lastTikkBegunAt = 0;
        private void Tikk(object sender, EventArgs e)
        {
            long thisTikkBegunAt = globalStopwatch.ElapsedTicks;
            int dt = deltaTime > 0 ? deltaTime : (targetFrameTime == 0 ? (int)Math.Round((thisTikkBegunAt - lastTikkBegunAt) / (Stopwatch.Frequency / 1000D)) : targetFrameTime);
            Bolygó.Léptetések(dt);
            lastTikkBegunAt = thisTikkBegunAt;
            Render();
        }
        private static void doIteration(int dt)
        {
            Bolygó.Léptetések(dt);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        SolidBrush br = new SolidBrush(Color.Red);
        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                /*e.Graphics.FillEllipse(br, (float)toAddPos.X - 20, (float)toAddPos.Y - 20, 40, 40);
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), (float)midPoint.X - 5, (float)midPoint.Y - 5, 10, 10);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), (float)(((toAddPos - midPoint) * renderScale) + midPoint).X - 20, (float)(((toAddPos - midPoint) * renderScale) + midPoint).Y - 20, 40, 40);*/
                Bolygó.EnterListLockRead();
                foreach (Bolygó bolygó in Bolygó.lista)
                {
                    bolygó.Rajz(e,renderScale,midPoint);
                }
            }
            finally
            {
                Bolygó.ExitListLockRead();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            MainPB.Size = ClientRectangle.Size;
        }

        private void HideSettings_Click(object sender, EventArgs e)
        {
            SettingsPanel.Visible = !SettingsPanel.Visible;
        }

        private void xPosTB_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!double.TryParse(text, out toAddPos.X))
            {
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void yPosTB_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!double.TryParse(text, out toAddPos.Y))
            {
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void xSpeedTB_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!double.TryParse(text, out toAddVel.X))
            {
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void ySpeedTB_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!double.TryParse(text, out toAddVel.Y))
            {
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void massTB_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!double.TryParse(text, out toAddMass))
            {
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = toAddColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toAddColor = cd.Color;
                (sender as Button).BackColor = toAddColor;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addBolygó();
        }
        private void addBolygó() => new Bolygó(toAddPos, toAddVel, toAddColor, toAddMass);

        private void pauseButton_Click(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void advanceButton_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                doIteration(16);
                (sender as Button).BackColor = SystemColors.Control;
            }
            else
            {
                (sender as Button).BackColor = Color.Red;
            }
            Render();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                Bolygó.EnterListLockModify();
                Bolygó.lista.Clear();
            }
            finally
            {
                Bolygó.ExitListLockModify();
            }
        }

        private void frameTimeTB_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (int.TryParse(tb.Text, out targetFrameTime))
            {
                tb.BackColor = SystemColors.Window;
            }
            else tb.BackColor = Color.Red;
        }

        private void timeStepTB_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = sender as TextBox;
            if (int.TryParse(tb.Text, out deltaTime)) tb.BackColor = SystemColors.Window;
            else tb.BackColor = Color.Red;
        }

        private void loopTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!paused)
            {
                TogglePause();
                paused = false;
            }
            rt = (runType)(sender as ComboBox).SelectedValue;
            if (!paused)
            {
                paused = true;
                TogglePause();
            }
        }

        Point leftDraggingStartedAt;
        Point rightDraggingStartedAt;
        private void MainPB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftDraggingStartedAt = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                rightDraggingStartedAt = e.Location;
                toAddPos = (new PointD(e.X, e.Y) - midPoint) / renderScale + midPoint;
                xPosTB.Text = toAddPos.X.ToString();
                yPosTB.Text = toAddPos.Y.ToString();
            }
        }

        private void MainPB_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        /*Point draggingVector = e.Location - (PointD)draggingStartedAt;

                        //hmpf. Awful, but at least a fun thing to do
                        System.Reflection.FieldInfo BPosition = typeof(Bolygó).GetField("Hely", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        lock (Bolygó.ModifyListElementsLock)
                        {
                            try 
                            {
                                Bolygó.EnterListLockRead();
                                foreach (Bolygó b in Bolygó.lista) BPosition.SetValue(b, (PointD)BPosition.GetValue(b) + draggingVector);
                            }
                            finally
                            {
                                Bolygó.ExitListLockModify();
                            }
                        }*/
                        Bolygó.MoveAll((e.Location - (PointD)leftDraggingStartedAt) / renderScale);
                        break;
                    }
                case MouseButtons.Right:
                    {
                        PointD p = (e.Location - (PointD)rightDraggingStartedAt) / (100 * renderScale);
                        toAddVel = p;
                        xSpeedTB.Text = p.X.ToString();
                        ySpeedTB.Text = p.Y.ToString();
                        break;
                    }
                case MouseButtons.Middle:
                    {
                        addBolygó();
                        break;
                    }
            }
        }

        private void MainPB_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                renderScale *= Math.Pow(1.1, e.Delta / SystemInformation.MouseWheelScrollDelta);
            }
            else
            {
                toAddMass += e.Delta;
                massTB.Text = toAddMass.ToString();
            }
        }

        private void centerButton_Click(object sender, EventArgs e)
        {
            Bolygó.RemoveSumMomentum();
            Bolygó.MoveAll((Bolygó.GetCoM() * -1) + midPoint);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            continueThread = false;
        }
    }
}

