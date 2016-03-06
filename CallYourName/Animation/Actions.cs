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

        public bool acc_ing;


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

            acc_ing = (Accele != 0) ? true : false;
        }

        public bool DoAction(int time){
            MotionAttri attr = this.AniObject.MotionAttri;
            double delta = attr.v * time;

            if (acc_ing == true)
            {
                attr.v += Acceleration * time;
                if (this.FinalVelocity.HasValue)
                {
                    if (!(Acceleration < 0 && attr.v > this.FinalVelocity
                        || Acceleration > 0 && attr.v < this.FinalVelocity))
                    {
                        if (attr.v != this.FinalVelocity)
                        {
                            attr.v = this.FinalVelocity.Value;
                            acc_ing = false;
                        }

                        if (attr.v == 0) return false;
                    }
                }
                delta += 0.5 * Acceleration * time * time;
            }

            if (delta != 0)
            {
                attr.x += delta;
                AniObject.Move();
                if (this.FinalLocation.HasValue)
                {
                    if (attr.v < 0 && attr.x > this.FinalLocation
                        || attr.v > 0 && attr.x < this.FinalLocation)
                    {
                        //Debug.WriteLine("d: {0} t: {1}", attr.v * time, time);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    class CallAction : IAction
    {
        public delegate bool CallActionDelegate(CallAction caller, Animation1D animation);

        public string ActionName { get; private set; }

        public CallActionDelegate CallDelegate;

        private Animation1D animation;

        public CallAction(CallActionDelegate callDelegate, Animation1D ani, string ActionName = null)
        {
            CallDelegate = callDelegate;
            this.ActionName = ActionName;
            this.animation = ani;
        }

        public bool DoAction(int time)
        {
            return CallDelegate(this, animation);
        }
    }
}
