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
        public IAniObject AniObject { get; private set; }
        public AnimationStatus Status;

        private List<IAction> actionSeq;
        private IAction currentAction;
        private int cur;

        private IAction curAction;

        private bool running;


        public Animation1D(IAniObject item, string ID = "Default")
        {
            this.AniObject = item;
            this.Status = AnimationStatus.Uninitialized;
            this.ID = ID;

            actionSeq = new List<IAction>();
            cur = -1;
        }

        public void Initialize()
        {
            running = true;
            loadNextAction();
        }

        private void loadNextAction()
        {
            if (!running) return;

            if ((curAction = NextAction()) == null)
            {
                Stop();
                return;
            }
            
            Debug.WriteLine("[{0}] Get Action: {1}", ID, curAction.ActionName);
        }

        public void LoopEvent(int timeInterval)
        {
            if (!running) return; 

            if (!curAction.DoAction(timeInterval))
            {
                loadNextAction();
            }
        }

        public void Stop()
        {
            Status = AnimationStatus.Stop;
            running = false;
        }

        #region Add Action
        public Animation1D WithMoveAction(double? initV, double accele, double? finalV, double? finalLoc, string name = null)
        {
            actionSeq.Add(new MoveAction(AniObject, initV, accele, finalV, finalLoc, name));

            return this;
        }

        public Animation1D WithCallAction(CallAction.CallActionDelegate callDelegate, string name = null)
        {
            actionSeq.Add(new CallAction(callDelegate, this, name));

            return this;
        }

        public void Add(IAction action)
        {
            actionSeq.Add(action);
        }

        #endregion

        public IAction NextAction()
        {
            ++cur;
            if (cur > actionSeq.Count) return null;

            currentAction = actionSeq[cur];
            return currentAction;
        }

        public Animation1D ToLastAction()
        {
            cur = actionSeq.Count - 2;
            currentAction = actionSeq[cur];
            return this;
        }

        public Animation1D ToFirstAction()
        {
            cur = -1;
            currentAction = actionSeq[cur];
            return this;
        }

        public Animation1D ToPreviousAction()
        {
            cur -= 2;
            currentAction = actionSeq[cur];
            return this;
        }

    }
}
