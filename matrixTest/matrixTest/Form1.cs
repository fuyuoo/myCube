using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrixTest
{
    public partial class Form1 : Form
    {
        private Triangle3D t;
        private Matrix4x4 scale;
        private Matrix4x4 rotateY;
        private Matrix4x4 rotateX;
        private Matrix4x4 rotateZ;
        private Matrix4x4 view;
        private Matrix4x4 projection;
        private int a;
        private Cube cube;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vector4 a = new Vector4(0, 0.5, 0, 1);
            Vector4 b = new Vector4(0.5, -0.5, 0, 1);
            Vector4 c = new Vector4(-0.5, -0.5, 0, 1);
//            Vector4 d = new Vector4(0,-0.5,0,1);
            t = new Triangle3D(a, b, c);
            scale = new Matrix4x4();
            rotateY = new Matrix4x4();
            rotateX = new Matrix4x4();
            rotateZ = new Matrix4x4();
            view = new Matrix4x4();
            projection = new Matrix4x4();
            cube = new Cube();


            scale[0, 0] = 150;
            scale[1, 1] = 150;
            scale[2, 2] = 150;
            scale[3, 3] = 1;

            view[0, 0] = 1;
            view[1, 1] = 1;
            view[2, 2] = 1;
            view[3, 3] = 1;
            view[3, 2] = 250;

            projection[0, 0] = 1;
            projection[1, 1] = 1;
            projection[2, 2] = 1;
            projection[2, 3] = 1.0 / 350;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(300, 300);
//            t.Draw(e.Graphics);
            cube.Draw(e.Graphics,false);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            a += 2;
            double angle = a / 360.0 * Math.PI;


            //Y =====
            rotateY[0, 0] = Math.Cos(angle);
            rotateY[0, 2] = Math.Sin(angle);
            rotateY[1, 1] = 1;
            rotateY[2, 0] = -Math.Sin(angle);
            rotateY[2, 2] = Math.Cos(angle);
            rotateY[3, 3] = 1;
            if (this.checkBox2.Checked)
            {
                Matrix4x4 tx = rotateY.Transpose();
                rotateY = rotateY.Mul(tx);
            }
            // X ===
            rotateX[0, 0] = 1;
            rotateX[1, 1] = Math.Cos(angle);
            rotateX[1, 2] = Math.Sin(angle);
            rotateX[2, 1] = -Math.Sin(angle);
            rotateX[2, 2] = Math.Cos(angle);
            rotateX[3, 3] = 1;

            if (this.checkBox1.Checked)
            {
                Matrix4x4 tx = rotateX.Transpose();
                rotateX = rotateX.Mul(tx);
            }

            // Z === 
            rotateZ[0, 0] = Math.Cos(angle);
            rotateZ[0, 1] = Math.Sin(angle);
            rotateZ[1, 0] = -Math.Sin(angle);
            rotateZ[1, 1] = Math.Cos(angle);
            rotateZ[2, 2] = 1;
            rotateZ[3, 3] = 1;
            if (this.checkBox3.Checked)
            {
                Matrix4x4 tx = rotateZ.Transpose();
                rotateZ = rotateZ.Mul(tx);
            }

            Matrix4x4 m = scale.Mul(rotateX);
            m = m.Mul(rotateY);
            m = m.Mul(rotateZ);

            cube.CalNormalLighting(m, new Vector4(-1, 1, -1, 0));
//            t.CalNormalLighting(m,new Vector4(-1,1,-1,0)); 

            Matrix4x4 mv = m.Mul(view);
            Matrix4x4 mvp = mv.Mul(projection);
            //            t.Transform(mvp);
            cube.transform(mvp);
            this.Invalidate();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            view[3, 2] = (sender as TrackBar).Value;
        }
    }
}