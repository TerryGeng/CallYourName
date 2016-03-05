using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallYourName.Animation
{
    interface IAction
    {
        string ActionName { get; }

        bool DoAction(int time);
    }

    class MoveAction : IAction
    {
        public delegate void EventDelegate(MoveAction caller, ActionSet motion, Animation1D animation);

        public IAniObject AniObject;
        public string ActionName { get; private set; }

        public double InitalVelocity;
        public double Acceleration;
        public double FinalVelocity;
        public double FinalLocation;
        public EventDelegate ReachedFinalLocation;
        private IAniObject aniObj;
        private double? initV;
        private double? accele;
        private double? finalV;
        private double? finalLoc;
        private EventDelegate reachL;
        private string name;


        public MoveAction(IAniObject AniObj, double? InitV, double Accele, double FinalV, double FinalLoc, EventDelegate ReachL = null , string ActionName = null)
        {
            this.AniObject = AniObj;
            this.Acceleration = Accele;
            this.FinalVelocity = FinalV;
            this.FinalLocation = FinalLoc;

            if (InitV.HasValue)
                this.InitalVelocity = InitV.Value;
            else
                this.InitalVelocity = AniObj.MotionAttri.v;

            this.ReachedFinalLocation = ReachL;

            this.ActionName = ActionName;
        }

        public bool DoAction(int time){
            MotionAttri attr = this.AniObject.MotionAttri;
            if (Acceleration < 0 && attr.v > this.FinalVelocity
                || Acceleration > 0 && attr.v < this.FinalVelocity)
            {
                attr.v += Acceleration;
            }

            if (attr.v < 0 && attr.x > this.FinalLocation
                || attr.v > 0 && attr.x < this.FinalLocation)
            {
                AniObject.MoveLeft(attr.v * time);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class CallAction : IAction
    {
        public delegate void CallActionDelegate(CallAction caller, ActionSet set, Animation1D animation);

        public string ActionName { get; private set; }

        public CallActionDelegate CallDelegate;

        private ActionSet actionSet;
        private Animation1D animation;

        public CallAction(CallActionDelegate callDelegate, ActionSet actionSet, Animation1D ani, string ActionName = null)
        {
            CallDelegate = callDelegate;
            this.ActionName = ActionName;
            this.animation = ani;
            this.actionSet = actionSet;
        }

        public bool DoAction(int time)
        {
            CallDelegate(this, actionSet, animation);

            return false;
        }
    }
}
