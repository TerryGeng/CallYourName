﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;


namespace CallYourName.Animation
{
    class AnimationController
    {
        private List<Animation1D> animationList;

        private bool running;
        private Thread aniThread;

        public AnimationController()
        {
            animationList = new List<Animation1D>();
            running = false;
        }

        public void AddAnimation(Animation1D ani)
        {
            animationList.Add(ani);
        }

        public void RemoveAnimation(Animation1D ani)
        {
            animationList.Remove(ani);
        }

        public void Start()
        {
            if (running) return;
            running = true;

            aniThread = new Thread(Loop);
            aniThread.Name = "Animation";

            foreach (Animation1D ani in animationList)
            {
                ani.Initialize();
            }

            aniThread.Start();
        }

        public void Loop()
        {
            int lastTime = System.Environment.TickCount;

            while (running)
            {
                int current = System.Environment.TickCount;
                int delta = current - lastTime;

                foreach (Animation1D ani in animationList)
                {
                    ani.LoopEvent(delta);
                }

                lastTime = current;

                Thread.Sleep(1);
            }
        }

        public void Stop()
        {
            if (!running) return;
            running = false;

            while (aniThread.IsAlive)
                Thread.Sleep(1);

            foreach (Animation1D ani in animationList)
            {
                ani.Stop();
            }
        }

    }
}
