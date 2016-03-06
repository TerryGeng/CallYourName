using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Diagnostics;



namespace CallYourName.Animation
{
    class AnimationController
    {
        private List<Animation1D> animationList;

        private bool running;
        private Thread aniThread;

        public AnimationController(List<Animation1D> aniList)
        {
            animationList = aniList;
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
                lock (this)
                {
                    int current = System.Environment.TickCount;
                    int delta = current - lastTime;

                    //Debug.WriteLine("-----");
                    foreach (Animation1D ani in animationList)
                    {
                        ani.LoopEvent(delta);
                        //Debug.WriteLine("[{0}] x: {1} v:{2}", ani.ID, ani.AniObject.MotionAttri.x, ani.AniObject.MotionAttri.v);
                    }

                    lastTime = current;
                }

                Thread.Sleep(5);
            }

            return;
        }

        public void Stop()
        {
            if (!running) return;
            running = false;

            Thread.Sleep(1);

            foreach (Animation1D ani in animationList)
            {
                ani.Stop();
            }
        }

    }
}
