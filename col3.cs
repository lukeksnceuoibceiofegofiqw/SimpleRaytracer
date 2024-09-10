

namespace SimpleRaytracer;

public struct col3
{
    public float r = 0;
    public float g = 0;
    public float b = 0;

    public col3(float r, float g, float b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }
    

    public col3(int r, int g, int b)
    {
        //devides by 255
        this.r = 0.00392156862745f * r;
        this.g = 0.00392156862745f * g;
        this.b = 0.00392156862745f * b;
    }


    public static col3 operator *(col3 c1, col3 c2) { return new col3(c1.r * c2.r, c1.g * c2.g, c1.b * c2.b); }

    public static col3 operator +(col3 c1, col3 c2) { return new col3(c1.r + c2.r, c1.g + c2.g, c1.b + c2.b); }

    public static col3 operator -(col3 c1, col3 c2) { return new col3(c1.r - c2.r, c1.g - c2.g, c1.b - c2.b); }

    public static col3 fac(col3 c, float f)
    {
        return new(c.r * f, c.g * f, c.b * f);
    }



}
