namespace Gravitáció
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPB = new System.Windows.Forms.PictureBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.centerButton = new System.Windows.Forms.Button();
            this.gameLoopTypeLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.massLabel = new System.Windows.Forms.Label();
            this.massTB = new System.Windows.Forms.TextBox();
            this.loopTypeCB = new System.Windows.Forms.ComboBox();
            this.deltaTimeExplanationLabel = new System.Windows.Forms.Label();
            this.targetFrameTimeExplanationLabel = new System.Windows.Forms.Label();
            this.timeStepTB = new System.Windows.Forms.TextBox();
            this.frameTimeTB = new System.Windows.Forms.TextBox();
            this.deltaTimeLabel = new System.Windows.Forms.Label();
            this.frameTimeLabel = new System.Windows.Forms.Label();
            this.advanceButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.ySpeedLabel = new System.Windows.Forms.Label();
            this.ySpeedTB = new System.Windows.Forms.TextBox();
            this.xSpeedLabel = new System.Windows.Forms.Label();
            this.xSpeedTB = new System.Windows.Forms.TextBox();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.yPosTB = new System.Windows.Forms.TextBox();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.xPosTB = new System.Windows.Forms.TextBox();
            this.HideSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).BeginInit();
            this.SettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPB
            // 
            this.MainPB.Location = new System.Drawing.Point(0, 0);
            this.MainPB.Margin = new System.Windows.Forms.Padding(0);
            this.MainPB.Name = "MainPB";
            this.MainPB.Size = new System.Drawing.Size(0, 0);
            this.MainPB.TabIndex = 0;
            this.MainPB.TabStop = false;
            this.MainPB.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MainPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPB_MouseDown);
            this.MainPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPB_MouseUp);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.centerButton);
            this.SettingsPanel.Controls.Add(this.gameLoopTypeLabel);
            this.SettingsPanel.Controls.Add(this.resetButton);
            this.SettingsPanel.Controls.Add(this.massLabel);
            this.SettingsPanel.Controls.Add(this.massTB);
            this.SettingsPanel.Controls.Add(this.loopTypeCB);
            this.SettingsPanel.Controls.Add(this.deltaTimeExplanationLabel);
            this.SettingsPanel.Controls.Add(this.targetFrameTimeExplanationLabel);
            this.SettingsPanel.Controls.Add(this.timeStepTB);
            this.SettingsPanel.Controls.Add(this.frameTimeTB);
            this.SettingsPanel.Controls.Add(this.deltaTimeLabel);
            this.SettingsPanel.Controls.Add(this.frameTimeLabel);
            this.SettingsPanel.Controls.Add(this.advanceButton);
            this.SettingsPanel.Controls.Add(this.pauseButton);
            this.SettingsPanel.Controls.Add(this.addButton);
            this.SettingsPanel.Controls.Add(this.colorPickerButton);
            this.SettingsPanel.Controls.Add(this.ySpeedLabel);
            this.SettingsPanel.Controls.Add(this.ySpeedTB);
            this.SettingsPanel.Controls.Add(this.xSpeedLabel);
            this.SettingsPanel.Controls.Add(this.xSpeedTB);
            this.SettingsPanel.Controls.Add(this.yPosLabel);
            this.SettingsPanel.Controls.Add(this.yPosTB);
            this.SettingsPanel.Controls.Add(this.xPosLabel);
            this.SettingsPanel.Controls.Add(this.xPosTB);
            this.SettingsPanel.Location = new System.Drawing.Point(1592, 42);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(180, 471);
            this.SettingsPanel.TabIndex = 1;
            // 
            // centerButton
            // 
            this.centerButton.Location = new System.Drawing.Point(0, 273);
            this.centerButton.Name = "centerButton";
            this.centerButton.Size = new System.Drawing.Size(180, 23);
            this.centerButton.TabIndex = 23;
            this.centerButton.Text = "center";
            this.centerButton.UseVisualStyleBackColor = true;
            this.centerButton.Click += new System.EventHandler(this.centerButton_Click);
            // 
            // gameLoopTypeLabel
            // 
            this.gameLoopTypeLabel.AutoSize = true;
            this.gameLoopTypeLabel.Location = new System.Drawing.Point(3, 433);
            this.gameLoopTypeLabel.Name = "gameLoopTypeLabel";
            this.gameLoopTypeLabel.Size = new System.Drawing.Size(79, 13);
            this.gameLoopTypeLabel.TabIndex = 22;
            this.gameLoopTypeLabel.Text = "game loop type";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(0, 243);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(180, 23);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // massLabel
            // 
            this.massLabel.AutoSize = true;
            this.massLabel.Location = new System.Drawing.Point(77, 78);
            this.massLabel.Name = "massLabel";
            this.massLabel.Size = new System.Drawing.Size(31, 13);
            this.massLabel.TabIndex = 20;
            this.massLabel.Text = "mass";
            // 
            // massTB
            // 
            this.massTB.Location = new System.Drawing.Point(0, 94);
            this.massTB.Name = "massTB";
            this.massTB.Size = new System.Drawing.Size(180, 20);
            this.massTB.TabIndex = 19;
            this.massTB.TextChanged += new System.EventHandler(this.massTB_TextChanged);
            // 
            // loopTypeCB
            // 
            this.loopTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loopTypeCB.FormattingEnabled = true;
            this.loopTypeCB.Location = new System.Drawing.Point(0, 449);
            this.loopTypeCB.Name = "loopTypeCB";
            this.loopTypeCB.Size = new System.Drawing.Size(121, 21);
            this.loopTypeCB.TabIndex = 18;
            this.loopTypeCB.SelectedIndexChanged += new System.EventHandler(this.loopTypeCB_SelectedIndexChanged);
            // 
            // deltaTimeExplanationLabel
            // 
            this.deltaTimeExplanationLabel.AutoSize = true;
            this.deltaTimeExplanationLabel.Location = new System.Drawing.Point(96, 370);
            this.deltaTimeExplanationLabel.MaximumSize = new System.Drawing.Size(80, 0);
            this.deltaTimeExplanationLabel.Name = "deltaTimeExplanationLabel";
            this.deltaTimeExplanationLabel.Size = new System.Drawing.Size(73, 52);
            this.deltaTimeExplanationLabel.TabIndex = 17;
            this.deltaTimeExplanationLabel.Text = "If 0, time step length will be based on last frame time";
            // 
            // targetFrameTimeExplanationLabel
            // 
            this.targetFrameTimeExplanationLabel.AutoSize = true;
            this.targetFrameTimeExplanationLabel.Location = new System.Drawing.Point(5, 370);
            this.targetFrameTimeExplanationLabel.MaximumSize = new System.Drawing.Size(80, 0);
            this.targetFrameTimeExplanationLabel.Name = "targetFrameTimeExplanationLabel";
            this.targetFrameTimeExplanationLabel.Size = new System.Drawing.Size(80, 39);
            this.targetFrameTimeExplanationLabel.TabIndex = 16;
            this.targetFrameTimeExplanationLabel.Text = "If thread based and 0, as small as possible";
            // 
            // timeStepTB
            // 
            this.timeStepTB.Location = new System.Drawing.Point(90, 343);
            this.timeStepTB.Name = "timeStepTB";
            this.timeStepTB.Size = new System.Drawing.Size(90, 20);
            this.timeStepTB.TabIndex = 15;
            this.timeStepTB.TextChanged += new System.EventHandler(this.timeStepTB_TextChanged);
            // 
            // frameTimeTB
            // 
            this.frameTimeTB.Location = new System.Drawing.Point(0, 343);
            this.frameTimeTB.Name = "frameTimeTB";
            this.frameTimeTB.Size = new System.Drawing.Size(90, 20);
            this.frameTimeTB.TabIndex = 14;
            this.frameTimeTB.TextChanged += new System.EventHandler(this.frameTimeTB_TextChanged);
            // 
            // deltaTimeLabel
            // 
            this.deltaTimeLabel.AutoSize = true;
            this.deltaTimeLabel.Location = new System.Drawing.Point(96, 327);
            this.deltaTimeLabel.Name = "deltaTimeLabel";
            this.deltaTimeLabel.Size = new System.Drawing.Size(81, 13);
            this.deltaTimeLabel.TabIndex = 13;
            this.deltaTimeLabel.Text = "time step length";
            // 
            // frameTimeLabel
            // 
            this.frameTimeLabel.AutoSize = true;
            this.frameTimeLabel.Location = new System.Drawing.Point(5, 327);
            this.frameTimeLabel.Name = "frameTimeLabel";
            this.frameTimeLabel.Size = new System.Drawing.Size(85, 13);
            this.frameTimeLabel.TabIndex = 12;
            this.frameTimeLabel.Text = "target frame time";
            // 
            // advanceButton
            // 
            this.advanceButton.Location = new System.Drawing.Point(90, 213);
            this.advanceButton.Name = "advanceButton";
            this.advanceButton.Size = new System.Drawing.Size(90, 23);
            this.advanceButton.TabIndex = 11;
            this.advanceButton.Text = "advance";
            this.advanceButton.UseVisualStyleBackColor = true;
            this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(0, 213);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(90, 23);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 149);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(180, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "add planet";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.Location = new System.Drawing.Point(0, 120);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(180, 23);
            this.colorPickerButton.TabIndex = 8;
            this.colorPickerButton.Text = "pick color";
            this.colorPickerButton.UseVisualStyleBackColor = true;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // ySpeedLabel
            // 
            this.ySpeedLabel.AutoSize = true;
            this.ySpeedLabel.Location = new System.Drawing.Point(112, 39);
            this.ySpeedLabel.Name = "ySpeedLabel";
            this.ySpeedLabel.Size = new System.Drawing.Size(44, 13);
            this.ySpeedLabel.TabIndex = 7;
            this.ySpeedLabel.Text = "y speed";
            // 
            // ySpeedTB
            // 
            this.ySpeedTB.Location = new System.Drawing.Point(90, 55);
            this.ySpeedTB.Name = "ySpeedTB";
            this.ySpeedTB.Size = new System.Drawing.Size(90, 20);
            this.ySpeedTB.TabIndex = 6;
            this.ySpeedTB.TextChanged += new System.EventHandler(this.ySpeedTB_TextChanged);
            // 
            // xSpeedLabel
            // 
            this.xSpeedLabel.AutoSize = true;
            this.xSpeedLabel.Location = new System.Drawing.Point(22, 39);
            this.xSpeedLabel.Name = "xSpeedLabel";
            this.xSpeedLabel.Size = new System.Drawing.Size(44, 13);
            this.xSpeedLabel.TabIndex = 5;
            this.xSpeedLabel.Text = "x speed";
            // 
            // xSpeedTB
            // 
            this.xSpeedTB.Location = new System.Drawing.Point(0, 55);
            this.xSpeedTB.Name = "xSpeedTB";
            this.xSpeedTB.Size = new System.Drawing.Size(90, 20);
            this.xSpeedTB.TabIndex = 4;
            this.xSpeedTB.TextChanged += new System.EventHandler(this.xSpeedTB_TextChanged);
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(105, 0);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(51, 13);
            this.yPosLabel.TabIndex = 3;
            this.yPosLabel.Text = "y position";
            // 
            // yPosTB
            // 
            this.yPosTB.Location = new System.Drawing.Point(90, 16);
            this.yPosTB.Name = "yPosTB";
            this.yPosTB.Size = new System.Drawing.Size(90, 20);
            this.yPosTB.TabIndex = 2;
            this.yPosTB.TextChanged += new System.EventHandler(this.yPosTB_TextChanged);
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(22, 0);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(51, 13);
            this.xPosLabel.TabIndex = 1;
            this.xPosLabel.Text = "x position";
            // 
            // xPosTB
            // 
            this.xPosTB.Location = new System.Drawing.Point(0, 16);
            this.xPosTB.Name = "xPosTB";
            this.xPosTB.Size = new System.Drawing.Size(90, 20);
            this.xPosTB.TabIndex = 0;
            this.xPosTB.TextChanged += new System.EventHandler(this.xPosTB_TextChanged);
            // 
            // HideSettings
            // 
            this.HideSettings.Location = new System.Drawing.Point(1592, 13);
            this.HideSettings.Name = "HideSettings";
            this.HideSettings.Size = new System.Drawing.Size(180, 23);
            this.HideSettings.TabIndex = 2;
            this.HideSettings.Text = "hide settings";
            this.HideSettings.UseVisualStyleBackColor = true;
            this.HideSettings.Click += new System.EventHandler(this.HideSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 861);
            this.Controls.Add(this.HideSettings);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.MainPB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MainPB)).EndInit();
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPB;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.TextBox timeStepTB;
        private System.Windows.Forms.TextBox frameTimeTB;
        private System.Windows.Forms.Label deltaTimeLabel;
        private System.Windows.Forms.Label frameTimeLabel;
        private System.Windows.Forms.Button advanceButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Label ySpeedLabel;
        private System.Windows.Forms.TextBox ySpeedTB;
        private System.Windows.Forms.Label xSpeedLabel;
        private System.Windows.Forms.TextBox xSpeedTB;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.TextBox yPosTB;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.TextBox xPosTB;
        private System.Windows.Forms.Button HideSettings;
        private System.Windows.Forms.Label deltaTimeExplanationLabel;
        private System.Windows.Forms.Label targetFrameTimeExplanationLabel;
        private System.Windows.Forms.ComboBox loopTypeCB;
        private System.Windows.Forms.Label massLabel;
        private System.Windows.Forms.TextBox massTB;
        private System.Windows.Forms.Label gameLoopTypeLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button centerButton;
    }
}

