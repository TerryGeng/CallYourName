using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


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
        MotionAttri MotionAttri { get; set; }
        void MoveLeft(double x);
        void MoveRight(double x);
        void MoveUp(double x);
        void MoveDown(double x);
        void Move();
    }

    class ObjectWrapper : IAniObject
    {
        public Control Object;
        public MotionAttri MotionAttri { get; set; }

        public ObjectWrapper(Control obj)
        {
            Object = obj;
            MotionAttri = new MotionAttri(obj.Left, obj.Top, 0);
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
            Debug.WriteLine("a: {0} b: {1}", MotionAttri.x, Object.Left);
        }
    }
}
