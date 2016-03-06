﻿using System;
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
        const double LABEL_MAX_SPEED = 2; //(positive, px/ms)
        const double LABEL_ACC = 0.01;  //(positive, px^2/ms)
        const int DEFAULT_WINDOW_H = 226;

        private Random rand;
        private SoundPlayer player;

        private string[] nameList;
        private List<Label> labels;
        private List<Animation1D> anis;
        private AnimationController aniCtrl;

        private Label tail;
        private Label candidate;

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

            anis = new List<Animation1D>();


            for (int i = 0; i < labels.Count; ++i)
            {
                if (i > 0)
                    labels[i].Left = labels[i - 1].Left + labels[i - 1].Width + 10;
                else
                    labels[i].Left = panel1.Width;

                labels[i].Text = RandomName();
                labels[i].ForeColor = RandomColor();
                labels[i].Visible = true;

                var an = new Animation1D(new ObjectWrapper(labels[i]), i.ToString());

                anis.Add(an);
            }

            aniCtrl = new AnimationController(anis);

            tail = labels[labels.Count - 1];
        }

        #region Start

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (candidate != null)
            {
                candidate.ForeColor = RandomColor();
                candidate = null;
            }

            lock (aniCtrl)
            {
                foreach (Animation1D an in anis)
                {
                    var item = an.AniObject as ObjectWrapper;
                    an.Reset();
                    an.WithMoveAction(0, -LABEL_ACC, 0, 0, "Init")
                        .WithMoveAction(null, -LABEL_ACC, -LABEL_MAX_SPEED, -item.Object.Width, "Acc1")
                        .WithCallAction(onAcc1Call, "ReachL");
                }
            }

            aniCtrl.Start();

            Startbutton.Visible = false;
            StopButton.Visible = true;
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
            label.ForeColor = RandomColor();

            tail = (an.AniObject as ObjectWrapper).Object as Label;

            an.ToPreviousAction();
        }

        private void onAcc1Call(CallAction caller, Animation1D an)
        {
            reachLeft(caller, an);
        }

        private void onAcc2Call(CallAction caller, Animation1D an)
        {
            var aniObj = an.AniObject as ObjectWrapper;
            var label = aniObj.Object as Label;

            if (label.Left < -label.Width)
            {
                reachLeft(caller, an);
            }
            else //Speed has reached 10%v.
            {
                StopAtCandidate();
            }
        }

        private void onAcc3Call(CallAction caller, Animation1D an)
        {
            var aniObj = an.AniObject as ObjectWrapper;
            var label = aniObj.Object as Label;

            if (label.Left < -label.Width)
            {
                reachLeft(caller, an);
            }
            else //Stop.
            {
                aniCtrl.Stop();

                candidate.ForeColor = Color.Red;
                player.Play();

                Startbutton.Visible = true;
                StopButton.Visible = false;
                StopButton.Enabled = true;
            }

        }
        #endregion

        #region Stop
        private void StopAtCandidate()
        {
            lock (aniCtrl)
            {
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
        }

        private double FindStopAcc() // return acc;
        {
            int midpos = (int)(0.5 * panel1.Width);

            Label cand = null;
            int diff = 0;

            foreach (Label la in labels)
            {
                int ldiff = la.Left - midpos;
                if (ldiff > 100)
                {
                    if (cand == null || ldiff < diff)
                    {
                        cand = la;
                        diff = ldiff;
                    }
                }
            }

            int finalPos = diff - (int)0.5 * cand.Width;
            candidate = cand;

            double acc = (0.01 * LABEL_MAX_SPEED * LABEL_MAX_SPEED) / (2 * finalPos); // a = (0.1v)^2/(2x)

            return acc;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Stop was called.");
            StopButton.Enabled = false;

            double maxV = 0.1 * LABEL_MAX_SPEED;

            lock (aniCtrl)
            {
                Debug.WriteLine("Stop is doing.");
                foreach (Animation1D an in anis)
                {
                    var item = an.AniObject as ObjectWrapper;
                    an.Reset();
                    an.WithMoveAction(null, LABEL_ACC, maxV, -item.Object.Width, "Acc2")
                    .WithCallAction(onAcc2Call, "ReachLV");
                    an.ToFirstAction();
                }
                Debug.WriteLine("Stop has done.");
            }
        }
        #endregion

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
