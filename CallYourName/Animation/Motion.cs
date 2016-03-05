using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallYourName.Animation
{
    class Motion
    {
        private LinkedList<IAction> actionSeq;
        private LinkedListNode<IAction> currentAction;
        private LinkedListNode<IAction> nextAction;

        public Motion()
        {
            actionSeq = new LinkedList<IAction>();
        }

        #region Add Action
        public Motion WithMoveAction(double? initV, double? accele, double? finalV, double? finalLoc,
           MoveAction.EventDelegate reachV = null, MoveAction.EventDelegate reachL = null, string name = null)
        {
            actionSeq.AddLast(new MoveAction(initV, accele, finalV, finalLoc, reachV, reachL, name));

            return this;
        }

        public Motion WithCallAction(CallAction.CallActionDelegate callDelegate, string name = null)
        {
            actionSeq.AddLast(new CallAction(callDelegate, name));

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

        public Motion ToPreviousAction()
        {
            if (nextAction != null)
                nextAction = nextAction.Previous;
            else
                nextAction = actionSeq.Last;
            return this;
        }

        public Motion ToLastAction()
        {
            nextAction = actionSeq.Last;
            return this;
        }

        public Motion ToFirstAction()
        {
            nextAction = actionSeq.First;
            return this;
        }
    }
}
