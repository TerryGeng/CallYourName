using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using Timer = System.Timers.Timer;
using System.Windows.Forms;

namespace CallYourName.Animation
{
    enum AnimationStatus
    {
        Uninitialized,
        Moving,
        Stop,
    }


    class Animation1D
    {
        public string ID;
        public ActionSet ActionSet;
        public IAniObject AniObject { get; private set; }
        public AnimationStatus Status;

        private IAction curAction;

        private bool running;


        public Animation1D(IAniObject item, ActionSet motion, string ID = "Default")
        {
            this.AniObject = item;
            this.ActionSet = motion;
            this.Status = AnimationStatus.Uninitialized;
            this.ID = ID;
        }

        public void Initialize()
        {
            running = true;
            loadNextAction();
        }

        private void loadNextAction()
        {
            if (!running) return;

            curAction = ActionSet.NextAction();
            Debug.WriteLine("[{0}] Get Action: {1}", ID, curAction.ActionName);
        }

        public void LoopEvent(int timeInterval)
        {
            if (!curAction.DoAction(timeInterval))
            {
                loadNextAction();
            }
        }

        public void NextAction()
        {
            loadNextAction();
        }

        public void Stop()
        {
            Status = AnimationStatus.Stop;
            running = false;
        }
    }
}
