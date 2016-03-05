using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallYourName.Animation
{
    //abstract class EventTrigger
    //{
    //    public delegate void TriggerFunction(Animation1D animation);

    //    public abstract void Judge(double currentV, int currentP)
    //    {
    //        return;
    //    }

    //    public abstract void Initialize(Animation1D animation)
    //    {
    //        return;
    //    }
    //}

    //enum Direction
    //{
    //    Left,
    //    Right
    //}

    //class EventTrigger1D
    //{
    //    public Animation1D Animation;

    //    public int? InitPosition;
    //    public int? FinalPosition;
    //    public double? InitVelocity;
    //    public double? FinalVelocity;

    //    public EventTrigger.TriggerFunction MaxVFunction;
    //    public EventTrigger.TriggerFunction MaxPFunction;

    //    int initP;
    //    int finalP;
    //    double initV;
    //    double finalV;

    //    Direction? pDirect;
    //    Direction? vDirect;

    //    bool freeze;

    //    public EventTrigger1D(int? initPosition, int? finalPosition, double? initVelocity, double? finalVelocity,
    //        EventTrigger.TriggerFunction maxPFunc, EventTrigger.TriggerFunction maxVFunc)
    //    {
    //        this.InitPosition = initPosition;
    //        this.FinalPosition = finalPosition;
    //        this.InitVelocity = initVelocity;
    //        this.FinalVelocity = finalVelocity;
    //        this.MaxPFunction = maxPFunc;
    //        this.MaxVFunction = maxVFunc;

    //        if (initPosition != null && finalPosition != null)
    //            pDirect = (initPosition >= finalPosition) ? Direction.Left : Direction.Right;
    //        if (initVelocity != null && finalVelocity != null)
    //            vDirect = (initVelocity >= finalVelocity) ? Direction.Left : Direction.Right;

    //        freeze = true;
    //    }

    //    public override void Initialize(Animation1D animation)
    //    {
    //        this.Animation = animation;

    //        if (vDirect != null)
    //        {
    //            initV = animation.UnitConvert(InitVelocity.Value);
    //            finalV = animation.UnitConvert(FinalVelocity.Value);
    //        }

    //        Unfreeze();
    //    }

    //    public override void Judge(double currentV, int currentP)
    //    {
    //        if (freeze) return;

    //        if (pDirect == Direction.Right && currentP > FinalPosition
    //            || pDirect == Direction.Left && currentP < FinalPosition)
    //        {
    //            freeze = true;
    //            MaxPFunction(Animation);
    //            return;
    //        }

    //        if(vDirect == Direction.Right && currentV> FinalVelocity
    //            || vDirect == Direction.Left && currentV < FinalVelocity)
    //        {
    //            freeze = true;
    //            MaxVFunction(Animation);
    //            return;
    //        }

    //    }

    //    public void Freeze()
    //    {
    //        freeze = true;
    //    }

    //    public void Unfreeze()
    //    {
    //        freeze = false;
    //    }
    //}
}
