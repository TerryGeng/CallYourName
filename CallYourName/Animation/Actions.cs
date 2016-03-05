using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallYourName.Animation
{
    enum ActionType
    {
        Undefined,
        MoveAction,
        CallAction
    }

    interface IAction
    {
        ActionType ActionType { get; }
        string ActionName { get; }
    }

    class MoveAction : IAction
    {
        public delegate void EventDelegate(MoveAction caller, Motion motion, Animation1D animation);

        public ActionType ActionType { get { return ActionType.MoveAction; } }
        public string ActionName { get; private set; }

        public double? InitalVelocity;
        public double? Acceleration;
        public double? FinalVelocity;
        public double? FinalLocation;
        public EventDelegate ReachedFinalVelocity;
        public EventDelegate ReachedFinalLocation;

        public EventTrigger EventTrigger;

        public MoveAction(double? InitV, double? Accele, double? FinalV, double? FinalLoc, EventDelegate ReachV = null, EventDelegate ReachL = null , string ActionName = null)
        {
            this.InitalVelocity = InitV;
            this.Acceleration = Accele;
            this.FinalVelocity = FinalV;
            this.FinalLocation = FinalLoc;

            this.ReachedFinalLocation = ReachL;
            this.ReachedFinalVelocity = ReachV;

            this.ActionName = ActionName;

            this.EventTrigger = new EventTrigger1D(); 
            // TODO: init position?!?!?! construct event respond in terms of TriggerFunction.
            // One animation one motion.
        }

        public void ReachMaxV(Animation1D animation)
        {

        }
    }

    class CallAction : IAction
    {
        public delegate void CallActionDelegate(CallAction caller, Motion motion, Animation1D animation);

        public ActionType ActionType { get { return ActionType.CallAction; } }
        public string ActionName { get; private set; }

        public CallActionDelegate CallDelegate;

        public CallAction(CallActionDelegate callDelegate, string ActionName = null)
        {
            CallDelegate = callDelegate;
            this.ActionName = ActionName;
        }
    }
}
