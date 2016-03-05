using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallYourName.Animation
{
    class ActionSet
    {
        public Animation1D Animation;
        private LinkedList<IAction> actionSeq;
        private LinkedListNode<IAction> currentAction;
        private LinkedListNode<IAction> nextAction;

        public ActionSet(Animation1D ani)
        {
            actionSeq = new LinkedList<IAction>();
            Animation = ani;
        }

        #region Add Action
        public ActionSet WithMoveAction(double? initV, double accele, double finalV, double finalLoc,
            MoveAction.EventDelegate reachL = null, string name = null)
        {
            actionSeq.AddLast(new MoveAction(Animation.AniObject, initV, accele, finalV, finalLoc, reachL, name));

            return this;
        }

        public ActionSet WithCallAction(CallAction.CallActionDelegate callDelegate, string name = null)
        {
            actionSeq.AddLast(new CallAction(callDelegate, this, Animation, name));

            return this;
        }

        public void Add(IAction action)
        {
            actionSeq.AddLast(action);
        }

        #endregion

        public IAction NextAction()
        {
            if (nextAction == null)
            {
                nextAction = actionSeq.First;
            }

            currentAction = nextAction;
            nextAction = currentAction.Next;
            return currentAction.Value;
        }

        public ActionSet ToPreviousAction()
        {
            if (nextAction != null)
                nextAction = nextAction.Previous;
            else
                nextAction = actionSeq.Last;
            return this;
        }

        public ActionSet ToLastAction()
        {
            nextAction = actionSeq.Last;
            return this;
        }

        public ActionSet ToFirstAction()
        {
            nextAction = actionSeq.First;
            return this;
        }
    }
}
