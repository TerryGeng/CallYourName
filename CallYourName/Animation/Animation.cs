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
        //public AnimationStatus Status;

        private List<IAction> actionSeq;
        private int cur;

        private bool running;


        public Animation1D(IAniObject item, string ID = "Default")
        {
            this.AniObject = item;
            //this.Status = AnimationStatus.Uninitialized;
            this.ID = ID;

            actionSeq = new List<IAction>();
            cur = 0;

        }

        public void Initialize()
        {
            running = true;
        }

        #region Running Loop Thread

        private void loadNextAction()
        {

            if (!running) return;

            if ((NextAction()) == null)
            {
                Stop();
                return;
            }

            //Debug.WriteLine("[{0}] Get: {1}", ID, actionSeq[cur].ActionName);

        }

        public void LoopEvent(int timeInterval)
        {
            if (!running) return;

            //Debug.WriteLine("[{0}]Try do {1}", ID, actionSeq[cur].ActionName);
            if (!actionSeq[cur].DoAction(timeInterval))
            {
                loadNextAction();
            }
        }

        public void Stop()
        {
            running = false;
        }

        #endregion

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

        public void Reset()
        {
            actionSeq = new List<IAction>();
        }

        #endregion

        #region Action Sequence Control
        public IAction NextAction()
        {
            ++cur;
            if (cur > actionSeq.Count) return null;

            return actionSeq[cur];
        }

        public Animation1D ToLastAction()
        {
            cur = actionSeq.Count - 1;
            return this;
        }

        public Animation1D ToFirstAction()
        {
            cur = 0;
            return this;
        }

        public Animation1D ToPreviousAction()
        {
            Debug.Assert(cur != 0);
            cur -= 1;
            //Debug.WriteLine("[{0}][To]Cur: {1}",this.ID , actionSeq[cur].ActionName);
            return this;
        }

        public Animation1D ToNextAction()
        {
            cur += 1;
            return this;
        }

        public bool ToAction(string ID)
        {
            IAction act;
            for (int i = 0; i < actionSeq.Count;++i )
            {
                act = actionSeq[i]; 
                if (act.ActionName != null && act.ActionName == ID)
                {
                    cur = i;
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}
