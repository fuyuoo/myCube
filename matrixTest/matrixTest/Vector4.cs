using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixTest
{
    class Vector4
    {
        public double x, y, z, w;

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector4 v) : this(v.x, v.y, v.z, v.w)
        {

        }
        public Vector4() { }

        public static Vector4 operator -(Vector4 a,Vector4 b)
        {
            return new Vector4(a.x-b.x,a.y-b.y,a.z-b.z,a.w-b.w);
        }
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vector4 operator /(Vector4 a, double b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        public Vector4 Cross(Vector4 v)
        {
            double x = this.y * v.z - this.z * v.y;
//            double y = this.x * v.z - this.z * v.x;
            double y = this.z * v.x - this.z * v.x;

            double z = this.x * v.y - this.y * v.x;
            return new Vector4(x,y,z,0);
        }

        public double Dot(Vector4 other)
        {
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }

        public Vector4 Normalized
        {
            get
            {
                double mod =Math.Sqrt(x * x + y * y + z * z + w * w) ;
                return this / mod;
            }
        }

    }
}
