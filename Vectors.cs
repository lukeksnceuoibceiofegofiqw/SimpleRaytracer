using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer;
/// <summary>
/// Graphics vector 4, 4d vector with 3d vector behaviour
/// </summary>
internal struct G4
{
    public float x;
    public float y;
    public float z;
    public float w;

    public G4 (float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static G4 operator + (G4 v1, G4 v2)
        { return new(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, 1); }
    public static G4 operator -(G4 v1, G4 v2)
    { return new(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, 1); }

    /// <summary>
    /// dot product
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static float operator %(G4 v1, G4 v2)
    { return v1.x * v2.x + v1.y * v2.y+ v1.z * v2.z; }

    /// <summary>
    /// cross product
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static G4 operator *(G4 v1, G4 v2)
    { return new(
        v1.y * v2.z - v1.z * v2.y, 
        v1.z * v2.x - v1.x * v2.z, 
        v1.x * v2.y - v1.y * v2.x, 
        1); }

    public static float Slength (G4 v)
    {
        return v % v;
    }

    public static float length (G4 v)
    {
        return MathF.Sqrt(Slength(v));
    }

    public static G4 Scale (G4 v, float f)
    {
        return new G4(v.x * f, v.y * f, v.z * f, 1);
    }

    public static G4 Normalize (G4 v)
    {
        return Scale(v, InvSqrt(Slength(v)));
    }

    /// <summary>
    /// fast inverse square root stolen from stack overflow.
    /// https://stackoverflow.com/questions/268853/is-it-possible-to-write-quakes-fast-invsqrt-function-in-c
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    static float InvSqrt(float x)
    {
        float xhalf = 0.5f * x;
        int i = BitConverter.SingleToInt32Bits(x);
        i = 0x5f3759df - (i >> 1);
        x = BitConverter.Int32BitsToSingle(i);
        x = x * (1.5f - xhalf * x * x);
        return x;
    }

}

/// <summary>
/// matrix 4
/// </summary>
internal struct M4
{
    public float a1; public float a2; public float a3; public float a4;
    public float b1; public float b2; public float b3; public float b4;
    public float c1; public float c2; public float c3; public float c4;
    public float d1; public float d2; public float d3; public float d4;

    public M4 (
        float a1, float a2, float a3, float a4,
        float b1, float b2, float b3, float b4,
        float c1, float c2, float c3, float c4,
        float d1, float d2, float d3, float d4)
    {
        this.a1 = a1; this.a2 = a2; this.a3 = a3; this.a4 = a4;
        this.b1 = b1; this.b2 = b2; this.b3 = b3; this.b4 = b4;
        this.c1 = c1; this.c2 = c2; this.c3 = c3; this.c4 = c4;
        this.d1 = d1; this.d2 = d2; this.d3 = d3; this.d4 = d4;
    }

    public static M4 operator *(M4 m1, M4 m2)
    {
        return new M4(
            m1.a1 * m2.a1 + 
            m1.b1 * m2.a2 + 
            m1.c1 * m2.a3 + 
            m1.d1 * m2.a4,
            m1.a2 * m2.a1 +
            m1.b2 * m2.a2 +
            m1.c2 * m2.a3 +
            m1.d2 * m2.a4,
            m1.a3 * m2.a1 +
            m1.b3 * m2.a2 +
            m1.c3 * m2.a3 +
            m1.d3 * m2.a4,
            m1.a4 * m2.a1 +
            m1.b4 * m2.a2 +
            m1.c4 * m2.a3 +
            m1.d4 * m2.a4,

            m1.a1 * m2.b1 +
            m1.b1 * m2.b2 +
            m1.c1 * m2.b3 +
            m1.d1 * m2.b4,
            m1.a2 * m2.b1 +
            m1.b2 * m2.b2 +
            m1.c2 * m2.b3 +
            m1.d2 * m2.b4,
            m1.a3 * m2.b1 +
            m1.b3 * m2.b2 +
            m1.c3 * m2.b3 +
            m1.d3 * m2.b4,
            m1.a4 * m2.b1 +
            m1.b4 * m2.b2 +
            m1.c4 * m2.b3 +
            m1.d4 * m2.b4,

            m1.a1 * m2.c1 +
            m1.b1 * m2.c2 +
            m1.c1 * m2.c3 +
            m1.d1 * m2.c4,
            m1.a2 * m2.c1 +
            m1.b2 * m2.c2 +
            m1.c2 * m2.c3 +
            m1.d2 * m2.c4,
            m1.a3 * m2.c1 +
            m1.b3 * m2.c2 +
            m1.c3 * m2.c3 +
            m1.d3 * m2.c4,
            m1.a4 * m2.c1 +
            m1.b4 * m2.c2 +
            m1.c4 * m2.c3 +
            m1.d4 * m2.c4,

            m1.a1 * m2.d1 +
            m1.b1 * m2.d2 +
            m1.c1 * m2.d3 +
            m1.d1 * m2.d4,
            m1.a2 * m2.d1 +
            m1.b2 * m2.d2 +
            m1.c2 * m2.d3 +
            m1.d2 * m2.d4,
            m1.a3 * m2.d1 +
            m1.b3 * m2.d2 +
            m1.c3 * m2.d3 +
            m1.d3 * m2.d4,
            m1.a4 * m2.d1 +
            m1.b4 * m2.d2 +
            m1.c4 * m2.d3 +
            m1.d4 * m2.d4
            );
    }

    public static G4 operator *(M4 m, G4 v)
    {
        return new G4(
            v.x * m.a1 +
            v.y * m.a2 +
            v.z * m.a3 +
            v.w * m.a4,

            v.x * m.b1 +
            v.y * m.b2 +
            v.z * m.b3 +
            v.w * m.b4,

            v.x * m.c1 +
            v.y * m.c2 +
            v.z * m.c3 +
            v.w * m.c4,

            v.x * m.d1 +
            v.y * m.d2 +
            v.z * m.d3 +
            v.w * m.d4
            );
    }


}



