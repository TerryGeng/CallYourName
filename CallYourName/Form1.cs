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
        const int LABEL_MAX_SPEED = 3000; //(positive, px/s)
        const int LABEL_ACC = 100;  //(positive, px^2/s)
        const int DEFAULT_WINDOW_H = 226;

        private Random rand;
        private SoundPlayer player;

        private string[] nameList;
        private List<Label> labels;
        private List<Animation1D> anis;
        private AnimationController aniCtrl;
        private List<Animation1D> anis2;
        private AnimationController aniCtrl2;

        private Label tail;
        private int select;

        private bool stop;
        private object stopLock;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            if (!File.Exists(FILE_NAME))
            {
                MessageBox.Show("没有找到名单！\r\n\r\n请把名单存为list.txt，与本程序放在同一目录下。", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }

            nameList = File.ReadAllLines(FILE_NAME, Encoding.Unicode);
            rand = new Random();
            labels = new List<Label>(new[] { label1, label2, label3, label4 });
            player = new SoundPlayer(Properties.Resources.MySound);
            aniCtrl = new AnimationController();
            anis = new List<Animation1D>();

            stopLock = new object();


            for (int i = 0; i < labels.Count; ++i)
            {
                if (i > 0)
                    labels[i].Left = labels[i - 1].Left + labels[i - 1].Width + 10;
                else
                    labels[i].Left = panel1.Width;

                labels[i].Text = RandomName();
                labels[i].ForeColor = RandomColor();
                labels[i].Visible = true;

                var an = new Animation1D(labels[i], null, i.ToString());

                anis.Add(an);
                aniCtrl.AddAnimation(an);
            }

            tail = labels[labels.Count - 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop = false;
            labels[select].ForeColor = RandomColor();

            foreach (Animation1D an in anis)
            {
                an.Motion = (new ActionSet())
                    .WithMoveAction(0, -LABEL_ACC, 0, 0, null, null, "Init")
                    .WithMoveAction(null, -LABEL_ACC, -LABEL_MAX_SPEED, -an.AniObject.Width, null, onReachL, "Acc1")
                    .WithMoveAction(null, 0, null, null, null, onReachL, "Mov1")
                    .WithMoveAction(null, LABEL_ACC, 0, null, onStop, onReachL, "Stop"); // On Stopping.
                an.EventTrigger 
            }

            aniCtrl.Start();

            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            foreach (Animation1D an in anis)
            {
                an.Motion.ToLastAction();
                an.NextAction();
            }
        }

        private void onReachL(MoveAction caller, ActionSet motion, Animation1D an)
        {
            an.AniObject.Left = tail.Left + tail.Width + 10;

            if (an.AniObject.Left < panel1.Width) an.AniObject.Left = panel1.Width;

            //an.Item.Text = RandomName();
            an.AniObject.ForeColor = RandomColor();

            tail = an.AniObject as Label;

            an.Motion.ToPreviousAction();
        }

        private void onStop(MoveAction caller, ActionSet motion, Animation1D animation)
        {
            lock (stopLock)
            {
                if (stop) return;
                stop = true;

                Debug.WriteLine("Stop was called.");

                aniCtrl.Stop();

                int last = labels.IndexOf(tail) + 1;
                while (true)
                {
                    if (last >= labels.Count) last = 0;

                    if (labels[last].Left > 0 && labels[last].Left < panel1.Width)
                    {
                        labels[last].ForeColor = Color.Red;
                        select = last;

                        int mid = (int)(0.5 * (panel1.Width - labels[last].Width));
                        int v = (labels[last].Left > mid) ? -100 : 100;

                        //int x = labels[last].Left - mid;
                        //int acc = 10;
                        //double maxV = Math.Sqrt(2 * LABEL_ACC * 0.5 * x);

                        //if (mid < labels[last].Left)
                        //{ 
                        //    maxV = -maxV;
                        //    acc = -acc;
                        //}

                        //aniCtrl2 = new AnimationController();

                        //for (int i = 0; i < labels.Count; ++i)
                        //{
                        //    var an = new Animation1D(labels[i], null);
                        //    an.Motion = (new Motion())
                        //    .WithMoveAction(v, 0, null, mid, null, null, "xAcc1")
                        //    .WithCallAction(onRealStop, "xCallStop");

                        //    aniCtrl2.AddAnimation(an);
                        //}

                        //aniCtrl2.Start();

                        //player.Play();
                        break;
                    }
                    else
                        last++;
                }


                button1.Visible = true;
                button2.Visible = false;
                button2.Enabled = true;

            }
        }

        private void onRealStop(MoveAction caller, ActionSet motion, Animation1D animation)
        {
            aniCtrl2.Stop();
        }


        private string RandomName()
        {
            return nameList[rand.Next(0, nameList.Length)];
        }

        private Color RandomColor()
        {
            return Color.FromArgb(rand.Next(50, 150), rand.Next(50, 150), rand.Next(50, 150));
        }

    }
}
