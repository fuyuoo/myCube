using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixTest
{
    class Triangle
    {
        PointF A, B, C;

        public Triangle(PointF a, PointF b, PointF c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.BurlyWood,5);
            g.DrawLine(pen,A,B);
            g.DrawLine(pen,B,C);
            g.DrawLine(pen,C,A);
        }

        public void Rotate(int degrees)
        {
            float angle = (float)(degrees / 360.0f * Math.PI);
            A = transformRotate(angle, A);
            B = transformRotate(angle, B);
            C = transformRotate(angle, C);

        }

        private void transformRotate(float angle,ref PointF oldPointF)
        {
            float x = (float)(oldPointF.X * Math.Cos(angle) - oldPointF.X * Math.Sin(angle));
            float y = (float)(oldPointF.Y * Math.Sin(angle) + oldPointF.Y * Math.Cos(angle));
            oldPointF.X = x;
            oldPointF.Y = y;
        }
        private PointF transformRotate(float angle, PointF oldPointF)
        {
            float x = (float)(oldPointF.X * Math.Cos(angle) - oldPointF.Y * Math.Sin(angle));
            float y = (float)(oldPointF.X * Math.Sin(angle) + oldPointF.Y * Math.Cos(angle));
            return new PointF(x,y);
        }
    }
}
