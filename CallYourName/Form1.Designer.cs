namespace CallYourName
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Startbutton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soundCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FPSlabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.accBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorPanel2 = new System.Windows.Forms.Panel();
            this.colorPanel1 = new System.Windows.Forms.Panel();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.colorButton1 = new System.Windows.Forms.Button();
            this.randomColorCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.autoTime = new System.Windows.Forms.NumericUpDown();
            this.autoStopCheckbox = new System.Windows.Forms.CheckBox();
            this.noRepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.FPSTimer = new System.Windows.Forms.Timer(this.components);
            this.autoTimer = new System.Windows.Forms.Timer(this.components);
            this.openOption = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 101);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(195, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 83);
            this.label4.TabIndex = 3;
            this.label4.Text = "测试";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(144, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 83);
            this.label3.TabIndex = 2;
            this.label3.Text = "测试";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(81, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 83);
            this.label2.TabIndex = 1;
            this.label2.Text = "测试";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "测试";
            this.label1.Visible = false;
            // 
            // Startbutton
            // 
            this.Startbutton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Startbutton.Location = new System.Drawing.Point(21, 134);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(359, 44);
            this.Startbutton.TabIndex = 1;
            this.Startbutton.Text = "开始！";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopButton.Location = new System.Drawing.Point(21, 134);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(359, 44);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "停止！";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soundCheckBox);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.autoTime);
            this.groupBox1.Controls.Add(this.autoStopCheckbox);
            this.groupBox1.Controls.Add(this.noRepeatCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(24, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 271);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // soundCheckBox
            // 
            this.soundCheckBox.AutoSize = true;
            this.soundCheckBox.Checked = true;
            this.soundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundCheckBox.Location = new System.Drawing.Point(16, 216);
            this.soundCheckBox.Name = "soundCheckBox";
            this.soundCheckBox.Size = new System.Drawing.Size(60, 16);
            this.soundCheckBox.TabIndex = 7;
            this.soundCheckBox.Text = "音效开";
            this.soundCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.FPSlabel);
            this.panel2.Location = new System.Drawing.Point(314, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 28);
            this.panel2.TabIndex = 6;
            // 
            // FPSlabel
            // 
            this.FPSlabel.Font = new System.Drawing.Font("DigifaceWide", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FPSlabel.ForeColor = System.Drawing.Color.Lime;
            this.FPSlabel.Location = new System.Drawing.Point(2, 5);
            this.FPSlabel.Name = "FPSlabel";
            this.FPSlabel.Size = new System.Drawing.Size(33, 20);
            this.FPSlabel.TabIndex = 0;
            this.FPSlabel.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.accBar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.speedBar);
            this.groupBox3.Location = new System.Drawing.Point(6, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 72);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "速度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "滚动加速度";
            // 
            // accBar
            // 
            this.accBar.AutoSize = false;
            this.accBar.Location = new System.Drawing.Point(173, 36);
            this.accBar.Maximum = 20;
            this.accBar.Minimum = 1;
            this.accBar.Name = "accBar";
            this.accBar.Size = new System.Drawing.Size(157, 24);
            this.accBar.TabIndex = 2;
            this.accBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.accBar.Value = 10;
            this.accBar.ValueChanged += new System.EventHandler(this.accBar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "滚动速度";
            // 
            // speedBar
            // 
            this.speedBar.AutoSize = false;
            this.speedBar.Location = new System.Drawing.Point(10, 36);
            this.speedBar.Minimum = 1;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(157, 24);
            this.speedBar.TabIndex = 0;
            this.speedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedBar.Value = 4;
            this.speedBar.ValueChanged += new System.EventHandler(this.speedBar_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorPanel2);
            this.groupBox2.Controls.Add(this.colorPanel1);
            this.groupBox2.Controls.Add(this.colorButton2);
            this.groupBox2.Controls.Add(this.colorButton1);
            this.groupBox2.Controls.Add(this.randomColorCheckbox);
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 75);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "颜色";
            // 
            // colorPanel2
            // 
            this.colorPanel2.BackColor = System.Drawing.Color.Red;
            this.colorPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel2.Location = new System.Drawing.Point(320, 47);
            this.colorPanel2.Name = "colorPanel2";
            this.colorPanel2.Size = new System.Drawing.Size(19, 20);
            this.colorPanel2.TabIndex = 4;
            // 
            // colorPanel1
            // 
            this.colorPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel1.Location = new System.Drawing.Point(320, 18);
            this.colorPanel1.Name = "colorPanel1";
            this.colorPanel1.Size = new System.Drawing.Size(19, 20);
            this.colorPanel1.TabIndex = 3;
            // 
            // colorButton2
            // 
            this.colorButton2.Location = new System.Drawing.Point(168, 45);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(149, 23);
            this.colorButton2.TabIndex = 2;
            this.colorButton2.Text = "选择选中者颜色";
            this.colorButton2.UseVisualStyleBackColor = true;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // colorButton1
            // 
            this.colorButton1.Enabled = false;
            this.colorButton1.Location = new System.Drawing.Point(168, 16);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(149, 23);
            this.colorButton1.TabIndex = 1;
            this.colorButton1.Text = "选择候选者颜色";
            this.colorButton1.UseVisualStyleBackColor = true;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // randomColorCheckbox
            // 
            this.randomColorCheckbox.AutoSize = true;
            this.randomColorCheckbox.Checked = true;
            this.randomColorCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomColorCheckbox.Location = new System.Drawing.Point(22, 34);
            this.randomColorCheckbox.Name = "randomColorCheckbox";
            this.randomColorCheckbox.Size = new System.Drawing.Size(108, 16);
            this.randomColorCheckbox.TabIndex = 0;
            this.randomColorCheckbox.Text = "随机候选者颜色";
            this.randomColorCheckbox.UseVisualStyleBackColor = true;
            this.randomColorCheckbox.CheckedChanged += new System.EventHandler(this.randomColorCheckbox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "当前FPS";
            // 
            // autoTime
            // 
            this.autoTime.Location = new System.Drawing.Point(239, 19);
            this.autoTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autoTime.Name = "autoTime";
            this.autoTime.Size = new System.Drawing.Size(29, 21);
            this.autoTime.TabIndex = 2;
            this.autoTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // autoStopCheckbox
            // 
            this.autoStopCheckbox.AutoSize = true;
            this.autoStopCheckbox.Location = new System.Drawing.Point(195, 20);
            this.autoStopCheckbox.Name = "autoStopCheckbox";
            this.autoStopCheckbox.Size = new System.Drawing.Size(156, 16);
            this.autoStopCheckbox.TabIndex = 1;
            this.autoStopCheckbox.Text = "滚动      s 后自动停止";
            this.autoStopCheckbox.UseVisualStyleBackColor = true;
            // 
            // noRepeatCheckBox
            // 
            this.noRepeatCheckBox.AutoSize = true;
            this.noRepeatCheckBox.Location = new System.Drawing.Point(16, 20);
            this.noRepeatCheckBox.Name = "noRepeatCheckBox";
            this.noRepeatCheckBox.Size = new System.Drawing.Size(120, 16);
            this.noRepeatCheckBox.TabIndex = 0;
            this.noRepeatCheckBox.Text = "不重复点一个名字";
            this.noRepeatCheckBox.UseVisualStyleBackColor = true;
            // 
            // FPSTimer
            // 
            this.FPSTimer.Interval = 10;
            this.FPSTimer.Tick += new System.EventHandler(this.FPSTimer_Tick);
            // 
            // autoTimer
            // 
            this.autoTimer.Interval = 1000;
            this.autoTimer.Tick += new System.EventHandler(this.autoTimer_Tick);
            // 
            // openOption
            // 
            this.openOption.Location = new System.Drawing.Point(312, 184);
            this.openOption.Name = "openOption";
            this.openOption.Size = new System.Drawing.Size(70, 21);
            this.openOption.TabIndex = 4;
            this.openOption.Text = "选项";
            this.openOption.UseVisualStyleBackColor = true;
            this.openOption.Click += new System.EventHandler(this.openOption_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "关于";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openOption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.Startbutton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "点名 Call Your Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown autoTime;
        private System.Windows.Forms.CheckBox autoStopCheckbox;
        private System.Windows.Forms.CheckBox noRepeatCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button colorButton1;
        private System.Windows.Forms.CheckBox randomColorCheckbox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel colorPanel2;
        private System.Windows.Forms.Panel colorPanel1;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label FPSlabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar accBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Timer FPSTimer;
        private System.Windows.Forms.Timer autoTimer;
        private System.Windows.Forms.Button openOption;
        private System.Windows.Forms.CheckBox soundCheckBox;
        private System.Windows.Forms.Button button1;
    }
}

