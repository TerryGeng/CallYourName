using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallYourName.Animation
{
    class MotionAttri
    {
        public double x;
        public double y;
        public double v;

        public MotionAttri(double _x,double _y,double _v)
        {
            x = _x;
            y = _y;
            v = _v;
        }
    };

    interface IAniObject
    {
        public MotionAttri MotionAttri;
        public void MoveLeft(double x);
        public void MoveRight(double x);
        public void MoveUp(double x);
        public void MoveDown(double x);
        public void Move();
    }

    class ObjectWrapper : IAniObject
    {
        public Control Object;
        public MotionAttri MotionAttri;

        public ObjectWrapper(Control obj)
        {
            Object = obj;
            MotionAttri.x = obj.Left;
            MotionAttri.y = obj.Top;
        }

        public void Move()
        {
            Object.Left = (int)MotionAttri.x;
            Object.Top = (int)MotionAttri.y;
        }

        public void MoveUp(double y)
        {
            MotionAttri.y -= y;
            Object.Top = (int)MotionAttri.x;
        }

        public void MoveDown(double y)
        {
            MotionAttri.y += y;
            Object.Top = (int)MotionAttri.x;
        }

        public void MoveRight(double x)
        {
            MotionAttri.x += x;
            Object.Left = (int)MotionAttri.x;
        }

        public void MoveLeft(double x)
        {
            MotionAttri.x -= x;
            Object.Left = (int)MotionAttri.x;
        }
    }
}
