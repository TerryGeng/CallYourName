using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallYourName.Animation;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace CallYourName
{

    public partial class Form1 : Form
    {

        const string FILE_NAME = "list.txt";
        const string SETTING_FILE = "setting.ini";
        const int DEFAULT_WINDOW_H = 253;
        const int OPTION_WINDOW_H = 545;

        double labelMaxSpeed = 2; //(positive, px/ms)
        double labelAcc = 0.01;  //(positive, px^2/ms)


        private Random rand;
        private SoundPlayer player;

        private List<string> nameList;
        private List<Label> labels;
        private List<Animation1D> anis;
        private AnimationController aniCtrl;

        private Label tail;
        private Label candidate;

        private Color candidateColor = Color.Red;

        private bool isOptionOpen;

        private int timeCount = 0;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            if (!File.Exists(FILE_NAME))
            {
                MessageBox.Show("没有找到名单！\r\n\r\n请把名单存为list.txt，与本程序放在同一目录下。", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }

            //readSetting();

            try
            {
                readSetting();
            }
            catch
            {
                MessageBox.Show("配置文件损坏！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            nameList = File.ReadAllLines(FILE_NAME, Encoding.Unicode).ToList();
            rand = new Random();
            labels = new List<Label>(new[] { label1, label2, label3, label4 });
            player = new SoundPlayer(Properties.Resources.MySound);

            anis = new List<Animation1D>();


            for (int i = 0; i < labels.Count; ++i)
            {
                if (i > 0)
                    labels[i].Left = labels[i - 1].Left + labels[i - 1].Width + 10;
                else
                    labels[i].Left = panel1.Width;

                labels[i].Text = RandomName();
                labels[i].ForeColor = GetColor();
                labels[i].Visible = true;

                var an = new Animation1D(new ObjectWrapper(labels[i]), i.ToString());

                anis.Add(an);
            }

            aniCtrl = new AnimationController(anis);

            tail = labels[labels.Count - 1];

            FPSTimer.Enabled = true;
        }

        #region Start

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (candidate != null)
            {
                candidate.ForeColor = GetColor();
                candidate = null;
            }

            lock (aniCtrl)
            {
                foreach (Animation1D an in anis)
                {
                    var item = an.AniObject as ObjectWrapper;
                    an.Reset();
                    an.WithMoveAction(0, -labelAcc, -labelMaxSpeed, -item.Object.Width, "Acc1")
                      .WithCallAction(onAcc1Call, "ReachL");
                    an.ToFirstAction();
                }
            }

            aniCtrl.Start();

            if (!autoStopCheckbox.Checked)
            {
                Startbutton.Visible = false;
                StopButton.Visible = true;
            }
            else
            {
                Startbutton.Enabled = false;
                autoTimer.Enabled = true;
            }
        }

        #endregion

        #region Animation Event Control
        private void reachLeft(CallAction caller, Animation1D an)
        {
            var aniObj = an.AniObject as ObjectWrapper;
            var label = aniObj.Object as Label;
            aniObj.MotionAttri.x = tail.Left + tail.Width + 10;

            if (aniObj.MotionAttri.x < panel1.Width) aniObj.MotionAttri.x = panel1.Width;

            aniObj.Move();

            label.Text = RandomName();
            label.ForeColor = GetColor();

            tail = (an.AniObject as ObjectWrapper).Object as Label;

            an.ToPreviousAction();
        }

        private bool onAcc1Call(CallAction caller, Animation1D an)
        {
            reachLeft(caller, an);

            return true;
        }

        private bool onAcc3Call(CallAction caller, Animation1D an)
        {
            var aniObj = an.AniObject as ObjectWrapper;
            var label = aniObj.Object as Label;

            Debug.WriteLine("Left: {0} {1}", label.Left  , -label.Width);
            if (label.Left < -label.Width)
            {
                reachLeft(caller, an);
            }
            else //Stop.
            {
                aniCtrl.Stop();

                candidate.ForeColor = candidateColor;

                if (soundCheckBox.Checked)
                    player.Play();

                if (noRepeatCheckBox.Checked)
                {
                    RemoveCandName();
                }

                Debug.WriteLine("Cand pos:{0}", candidate.Left);

                if (!autoStopCheckbox.Checked)
                {
                    Startbutton.Visible = true;
                    StopButton.Visible = false;
                    StopButton.Enabled = true;
                }
                else
                {
                    Startbutton.Enabled = true;
                }
            }

            return true;
        }
        #endregion

        #region Stop
        private void StopAtCandidate()
        {
            Debug.WriteLine("--Calculate--");
            double acc = FindStopAcc();
            foreach (Animation1D an in anis)
            {
                var item = an.AniObject as ObjectWrapper;
                an.Reset();
                an.WithMoveAction(null, acc, 0, -item.Object.Width, "Acc3")
                .WithCallAction(onAcc3Call, "ReachLS");
                an.ToFirstAction();
            }
        }

        private double FindStopAcc() // return acc;
        {
            int midpos = (int)(0.5 * panel1.Width);

            Label cand = null;
            double diff = 0;

            foreach (Animation1D ani in anis)
            {
                var label = ani.AniObject as ObjectWrapper;

                double ldiff = label.MotionAttri.x - midpos;
                Debug.WriteLine("Left:{0}", label.MotionAttri.x);
                if (ldiff > 0)
                {
                    if (cand == null || ldiff < diff)
                    {
                        cand = label.Object as Label;
                        diff = ldiff;
                    }
                }
            }

            int finalPos = (int)(midpos - 0.5 * cand.Width);

            Debug.WriteLine("Cand Pos Cur:{0} Fin:{1}", cand.Left, finalPos);
            Debug.WriteLine("Cand Name:{0}", cand.Text);

            candidate = cand;

            double acc = (labelMaxSpeed * labelMaxSpeed) / (2 * (cand.Left - finalPos)); // a = (0.1v)^2/(2x)
            Debug.WriteLine("Acc:{0}", acc);

            return acc;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Stop was called.");
            StopButton.Enabled = false;

            lock (aniCtrl)
            {
                Debug.WriteLine("Stop is doing.");
                StopAtCandidate();
                Debug.WriteLine("Stop has done.");
            }
        }
        #endregion

        private void RemoveCandName()
        {
            nameList.Remove(candidate.Text);

            if (nameList.Count == 0)
            {
                MessageBox.Show("所有人都已点过。现在重新开始。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameList = File.ReadAllLines(FILE_NAME, Encoding.Unicode).ToList();
            }
        }

        private string RandomName()
        {
            return nameList[rand.Next(0, nameList.Count-1)];
        }

        private Color GetColor()
        {
            if (randomColorCheckbox.Checked)
                return Color.FromArgb(rand.Next(50, 150), rand.Next(50, 150), rand.Next(50, 150));
            else
                return colorPanel1.BackColor;
        }

        private void FPSTimer_Tick(object sender, EventArgs e)
        {
            FPSlabel.Text = aniCtrl.FPS.ToString();
        }


        private void autoTimer_Tick(object sender, EventArgs e)
        {
            ++timeCount;
            if (timeCount > autoTime.Value)
            {
                autoTimer.Enabled = false;
                StopButton_Click(sender, e);
            }
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorPanel1.BackColor = colorDialog1.Color;
        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorPanel2.BackColor = colorDialog1.Color;
            candidateColor = colorDialog1.Color;
        }

        private void randomColorCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            colorButton1.Enabled = !randomColorCheckbox.Checked;
        }

        private void speedBar_ValueChanged(object sender, EventArgs e)
        {
            labelMaxSpeed = 0.5 * speedBar.Value;
        }

        private void accBar_ValueChanged(object sender, EventArgs e)
        {
            labelAcc = 0.002 * accBar.Value;
        }

        private void readSetting()
        {
            if (!File.Exists(SETTING_FILE)) return;

            IniFile ini = new IniFile(Directory.GetCurrentDirectory() + "/" + SETTING_FILE);
            Debug.WriteLine(Directory.GetCurrentDirectory() + "/" + SETTING_FILE);
            if (ini.IniReadValue("settings", "NoRepeat") == "True")
                noRepeatCheckBox.Checked = true;

            if (ini.IniReadValue("settings", "AutoStop") == "True")
                autoStopCheckbox.Checked = true;

            if (ini.IniReadValue("settings", "RandomColor") == "False")
                randomColorCheckbox.Checked = false;

            if (ini.IniReadValue("settings", "Sound") == "False")
                soundCheckBox.Checked = false;

            string colorStr;

            if (!string.IsNullOrEmpty(colorStr = (ini.IniReadValue("settings", "Color"))))
            {
                colorPanel1.BackColor = Color.FromArgb(int.Parse(colorStr));
            }

            if (!string.IsNullOrEmpty(colorStr = (ini.IniReadValue("settings", "SelectedColor"))))
            {
                colorPanel2.BackColor = Color.FromArgb(int.Parse(colorStr));
                candidateColor = colorPanel2.BackColor;
            }

            string num;
            int i;
            if (!string.IsNullOrEmpty(num = ini.IniReadValue("settings", "Speed")))
            {
                i = int.Parse(num);
                speedBar.Value = (i <= 20 && i >= 1) ? i : 10;
            }
            if (!string.IsNullOrEmpty(num = ini.IniReadValue("settings", "Acceleration")))
            {
                i = int.Parse(num);
                accBar.Value = (i <= 10 && i >= 1) ? i : 4;
            }
            if (!string.IsNullOrEmpty(num = ini.IniReadValue("settings", "AutoStopSec")))
            {
                i = int.Parse(num);
                autoTime.Value = (i <= 100 && i >= 1) ? i : 1;
            }
        }

        private void writeSetting()
        {
            IniFile ini = new IniFile(Directory.GetCurrentDirectory() + "/" + SETTING_FILE);
            ini.IniWriteValue("settings", "NoRepeat", noRepeatCheckBox.Checked.ToString());
            ini.IniWriteValue("settings", "AutoStop", autoStopCheckbox.Checked.ToString());
            ini.IniWriteValue("settings", "AutoStopSec", autoTime.Value.ToString());
            ini.IniWriteValue("settings", "RandomColor", randomColorCheckbox.Checked.ToString());
            ini.IniWriteValue("settings", "Color", colorPanel1.BackColor.ToArgb().ToString());
            ini.IniWriteValue("settings", "SelectedColor", colorPanel2.BackColor.ToArgb().ToString());
            ini.IniWriteValue("settings", "Speed", speedBar.Value.ToString());
            ini.IniWriteValue("settings", "Acceleration", accBar.Value.ToString());
            ini.IniWriteValue("settings", "Sound",soundCheckBox.Checked .ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            writeSetting();
        }

        private void openOption_Click(object sender, EventArgs e)
        {
            if (!isOptionOpen)
            {
                this.Height = OPTION_WINDOW_H;
                openOption.Text = "收起选项";
            }else
            {
                this.Height = DEFAULT_WINDOW_H;
                openOption.Text  = "选项";
            }

            isOptionOpen = !isOptionOpen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources .About , "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
