using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixTest
{
    class Triangle3D
    {
        public Vector4 A, B, C; // 原始点
        private Vector4 al, bl, cl; //变化后的点
        private bool isCulling;

        private double dot;
        public Triangle3D(Vector4 a, Vector4 b, Vector4 c)
        {
            A = al = new Vector4(a);
            B = bl = new Vector4(b);
            C = cl =  new Vector4(c);
            
        }

        public Triangle3D()
        {
        }


        public void Transform(Matrix4x4 m4)
        {
            al = m4.Mul(A);
            bl = m4.Mul(B);
            cl = m4.Mul(C);
        }

        public void CalNormalLighting(Matrix4x4 m,Vector4 lightDir)
        {
            this.Transform(m);
            Vector4 u = this.bl - this.al;
            Vector4 v = this.cl - this.al;
            Vector4 nor = u.Cross(v);
            dot = Math.Max(nor.Normalized.Dot(lightDir.Normalized),0) ;
            Vector4 e = new Vector4(0,0,-1,0);
            isCulling = !(nor.Normalized.Dot(e.Normalized) > 0);

        }

        private PointF Get2DPointF(Vector4 v)
        {
            PointF ret = new PointF();
            ret.X = (float)(v.x / v.w);
            ret.Y = (float)-(v.y / v.w);
            return ret;
        }

        private PointF[] getTrangle3DPointFs()
        {
            PointF[] pointFs = new PointF[4];
            pointFs[0] = Get2DPointF(al);
            pointFs[1] = Get2DPointF(bl);
            pointFs[2] = Get2DPointF(cl);
            pointFs[3] = pointFs[0];
            return pointFs;


        }

        public void Draw(Graphics g,bool isLine)
        {
            Pen pen = new Pen(Color.Black, 5);
            PointF[] pointFs = getTrangle3DPointFs();
            if (isLine)
            {
                g.DrawLines(pen, pointFs);

            }
            else
            {
                if (!isCulling)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(pointFs);
                    int col = (int)(255 * dot);
                    Brush brush = new SolidBrush(Color.FromArgb(col, col, col));
                    g.FillPath(brush, path);
                }
            }
            
            
        }
    }
}
