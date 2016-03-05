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
        public Motion Motion;
        public Control Item { get; private set; }
        public AnimationStatus Status;

        private IAction curAction;
        private EventTrigger eventTrigger;

        private int interval;

        private bool running;
        private bool move;

        private double? curV;
        private double? acc;

        private object motionLock;
        private object nextActionLock;

        public Animation1D(Control item, Motion motion, string ID = "Default")
        {
            this.Item = item;
            this.Motion = motion;
            this.Status = AnimationStatus.Uninitialized;
            this.ID = ID;

            motionLock = new object();
            nextActionLock = new object();
        }

        public void Initialize(int _interval)
        {
            curV = null;
            acc = null;

            interval = _interval;

            running = true;
            loadNextAction();
        }

        private void loadNextAction()
        {
            lock (nextActionLock)
            {
                if (move) return;

                while (true)
                {
                    bool exitLoop = false;
                    if (!running) return;
                    curAction = Motion.NextAction();
                    Debug.WriteLine("[{0}] Get Action: {1}", ID, curAction.ActionName);

                    switch (curAction.ActionType)
                    {
                        case ActionType.MoveAction:
                            {
                                var moveAction = curAction as MoveAction;
                                curV = (moveAction.InitalVelocity.HasValue) ? UnitConvert(moveAction.InitalVelocity.Value) : curV;
                                acc = (moveAction.Acceleration.HasValue) ? UnitConvert(moveAction.Acceleration.Value) : acc;

                                if (moveAction.EventTrigger != null)
                                {
                                    eventTrigger = moveAction.EventTrigger;
                                    eventTrigger.Initialize(this);
                                }

                                if (curV != 0 || acc != 0) { move = true; Status = AnimationStatus.Moving; }
                                else { Status = AnimationStatus.Stop; }

                                exitLoop = true;
                                break;
                            }
                        case ActionType.CallAction:
                            {
                                var callAction = curAction as CallAction;
                                callAction.CallDelegate(callAction, Motion, this);
                                break;
                            }
                    }

                    if (exitLoop) break;
                }
            }
        }

        public void MoveOnce()
        {
            lock (motionLock)
            {
                if (!move) { return; }

                // Accelerate
                if (acc != 0)
                {
                    curV += acc;
                }

                // Move
                // Item.BeginInvoke(new Action(delegate() { Item.Left = (int)(curV + Item.Left); }));
                Item.Left = (int)(curV + Item.Left);

                if(eventTrigger != null) eventTrigger.Judge(curV.Value, Item.Left);
            }
        }

        public void NextAction()
        {
            move = false;
            loadNextAction();
        }

        public void Stop()
        {
            lock (motionLock)
            {
                move = false;
                Status = AnimationStatus.Stop;
                running = false;
            }
        }

        public double UnitConvert(double x)
        {
            return x / 1000 * interval;
        }
    }
}
