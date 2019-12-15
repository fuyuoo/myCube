using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixTest
{
    class Cube
    {
        Vector4 A = new Vector4(-0.5, 0.5, 0.5, 1);
        Vector4 B = new Vector4(0.5, 0.5, 0.5, 1);
        Vector4 C = new Vector4(0.5, 0.5, -0.5, 1);
        Vector4 D = new Vector4(-0.5, 0.5, -0.5, 1);

        Vector4 E = new Vector4(-0.5, -0.5, 0.5, 1);
        Vector4 F = new Vector4(0.5, -0.5, 0.5, 1);
        Vector4 G = new Vector4(0.5, -0.5, -0.5, 1);
        Vector4 H = new Vector4(-0.5, -0.5, -0.5, 1);
        private Triangle3D[] triangle3Ds;

        public Cube()
        {
            triangle3Ds = new Triangle3D[12];
            // TOP
            triangle3Ds[0] = new Triangle3D(A, B, C);
            triangle3Ds[1] = new Triangle3D(D, A, C);

            

            //FRONT
            triangle3Ds[2] = new Triangle3D(D, C, G);
            triangle3Ds[3] = new Triangle3D(D, G, H);

            //Right
            triangle3Ds[4] = new Triangle3D(C, B, F);
            triangle3Ds[5] = new Triangle3D(C, F, G);

            //LEFT
            triangle3Ds[6] = new Triangle3D(A,D,E);
            triangle3Ds[7] = new Triangle3D(D,H,E);

            // BOTTOM
            triangle3Ds[8] = new Triangle3D(H,G,E);
            triangle3Ds[9] = new Triangle3D(G,F,E);

            //BACK
            triangle3Ds[10] = new Triangle3D(B,A,E);
            triangle3Ds[11] = new Triangle3D(B,E,F);
        }

        public void transform(Matrix4x4 m)
        {
            for (int i = 0; i < triangle3Ds.Length; i++)
                triangle3Ds[i].Transform(m);


        }
        public void CalNormalLighting(Matrix4x4 m, Vector4 lightDir)
        {
            for (int i = 0; i < triangle3Ds.Length; i++)
                triangle3Ds[i].CalNormalLighting(m,lightDir);
        }
        public void Draw(Graphics g,bool isLine)
        {

            for (int i = 0; i < triangle3Ds.Length; i++)
                triangle3Ds[i].Draw(g, isLine);
        }

    }
}