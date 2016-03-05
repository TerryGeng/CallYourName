using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace CallYourName.Animation
{
    interface IAction
    {
        string ActionName { get; }

        bool DoAction(int time);
    }

    class MoveAction : IAction
    {
        public IAniObject AniObject;
        public string ActionName { get; private set; }

        public double? InitalVelocity;
        public double Acceleration;
        public double? FinalVelocity;
        public double? FinalLocation;


        public MoveAction(IAniObject AniObj, double? InitV, double Accele, double? FinalV, double? FinalLoc, string ActionName = null)
        {
            this.AniObject = AniObj;
            this.Acceleration = Accele;
            this.FinalVelocity = FinalV;
            this.FinalLocation = FinalLoc;

            if (InitV.HasValue)
                this.InitalVelocity = InitV.Value;
            else
                this.InitalVelocity = AniObj.MotionAttri.v;

            this.ActionName = ActionName;
        }

        public bool DoAction(int time){
            MotionAttri attr = this.AniObject.MotionAttri;
            if (this.FinalVelocity.HasValue)
            {
                if (Acceleration < 0 && attr.v > this.FinalVelocity
                    || Acceleration > 0 && attr.v < this.FinalVelocity)
                {
                    attr.v += Acceleration;
                }
                else
                {
                    if (attr.v != this.FinalVelocity) attr.v = this.FinalVelocity.Value;
                    if (attr.v == 0) return false;
                }
            }


            if (this.FinalLocation.HasValue)
            {
                if (attr.v < 0 && attr.x > this.FinalLocation
                    || attr.v > 0 && attr.x < this.FinalLocation)
                {
                    AniObject.MoveRight(attr.v * time);
                    Debug.WriteLine("d: {0} t: {1}", attr.v * time, time);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
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
