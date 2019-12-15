using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixTest
{
    class Matrix4x4
    {
        private double[,] pts;

        public Matrix4x4()
        {
            pts = new double[4, 4];
        }

        public Matrix4x4(Vector4 v4):this()
        {
            pts[0, 0] = v4.x;
            pts[1, 0] = v4.y;
            pts[2, 0] = v4.z;
            pts[3, 0] = v4.w;

        }

        public double this[int i, int j]
        {
            get { return pts[i, j]; }
            set { pts[i, j] = value; }
        }

        public Matrix4x4 Mul(Matrix4x4 m4)
        {
            Matrix4x4 newM = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        newM[i, j] += pts[i, k] * m4[k, j];
                    }
                }
            }

            return newM;
        }

        public Vector4 Mul(Vector4 v4)
        {
            //  Matrix4x4 ret = new Matrix4x4(v4);
            //  ret = Mul(ret);
            //  Vector4 tmp = new Vector4(ret[0, 0], ret[1, 0], ret[2, 0], ret[3, 0]);

            Vector4 retvVector4 = new Vector4();
            retvVector4.x = v4.x * pts[0, 0] + v4.y * pts[1, 0] + v4.z * pts[2, 0] + v4.w * pts[3, 0];
            retvVector4.y = v4.x * pts[0, 1] + v4.y * pts[1, 1] + v4.z * pts[2, 1] + v4.w * pts[3, 1];
            retvVector4.z = v4.x * pts[0, 2] + v4.y * pts[1, 2] + v4.z * pts[2, 2] + v4.w * pts[3, 2];
            retvVector4.w = v4.x * pts[0, 3] + v4.y * pts[1, 3] + v4.z * pts[2, 3] + v4.w * pts[3, 3];



            return retvVector4;


        }
        //得到转置矩阵
        public Matrix4x4 Transpose()
        {
            Matrix4x4 ret = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ret[i, j] = pts[j, i];
                }
            }

            return ret;
        }
    }
}