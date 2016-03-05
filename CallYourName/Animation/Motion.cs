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
        private List<IAction> actionSeq;
        private IAction currentAction;
        private int cur;

        public ActionSet(Animation1D ani)
        {
            actionSeq = new List<IAction>();
            Animation = ani;
            cur = -1;
        }

        #region Add Action
        public ActionSet WithMoveAction(double? initV, double accele, double? finalV, double? finalLoc, string name = null)
        {
            actionSeq.Add(new MoveAction(Animation.AniObject, initV, accele, finalV, finalLoc, name));

            return this;
        }

        public ActionSet WithCallAction(CallAction.CallActionDelegate callDelegate, string name = null)
        {
            actionSeq.Add(new CallAction(callDelegate, this, Animation, name));

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

        public ActionSet ToLastAction()
        {
            cur = actionSeq.Count - 2;
            return this;
        }

        public ActionSet ToFirstAction()
        {
            cur = -1;
            return this;
        }

        public ActionSet ToPreviousAction()
        {
            cur -= 2;
            return this;
        }
    }
}
