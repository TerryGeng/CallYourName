using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;


namespace CallYourName.Animation
{
    class AnimationController
    {
        private Timer timer;
        private LinkedList<Animation1D> animationList;

        private bool running;

        public AnimationController(int interval = 20)
        {
            timer = new Timer(interval);
            animationList = new LinkedList<Animation1D>();
            running = false;
        }

        public void AddAnimation(Animation1D ani)
        {
            animationList.AddLast(ani);
        }

        public void RemoveAnimation(Animation1D ani)
        {
            animationList.Remove(ani);
        }

        public void Start()
        {
            if (running) return;

            running = true;

            foreach (Animation1D ani in animationList)
            {
                ani.Initialize((int)timer.Interval);
            }

            timer.Elapsed += onElapsedEvent;
            timer.Start();
        }

        public void Stop()
        {
            if (!running) return;

            timer.Elapsed -= onElapsedEvent;
            timer.Stop();

            foreach (Animation1D ani in animationList)
            {
                ani.Stop();
            }

            running = false;
        }

        public void onElapsedEvent(object o, ElapsedEventArgs args)
        {
            foreach (Animation1D ani in animationList)
            {
                ani.MoveOnce();
            }
        }

    }
}
