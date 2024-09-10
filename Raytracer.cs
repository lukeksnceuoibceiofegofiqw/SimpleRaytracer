
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleRaytracer; 
internal class Raytracer
{
    public static float margin = 0.001f;
    internal Scene scene = new();
    public Camera cam = new();


    public Color pixel(int x, int y, Size s)
    {
        col3 c = cast(cam.MakeRay(x, y, s), 4);

        return Color.FromArgb(ColCon(c.r), ColCon(c.g), ColCon(c.b));
    }

    int ColCon(float f)
    {
        return (int)(510 / (1 + MathF.Pow(10, -f))) - 255;
    }

    public col3 cast(Ray r, int recursioncap)
    {
        if (recursioncap < 0)
        {
            return new col3();
        }

        Intersection i = Intersect(r);


        return i.GetColor(this, recursioncap - 1);



    }

    public Intersection Intersect(Ray r)
    {

        float f1 = 100;

        G4 p;

        p = (r.dir * f1) + r.st;
        G4 normal = G4.Normalize(new G4() - r.dir);
        Intersection i = new Intersection(r.dir, p, normal, f1, scene.skyMat);

        for (int n = 0; n < scene.objects.Count; n++)
        {
            i = scene.objects[n].Intersect(r, i);
        }

        return i;
    }
}

internal class Intersection
{
    public G4 incoming;
    public G4 pos;
    public G4 normal;
    public float depth;
    public Material mat;

    public Intersection(G4 incoming,  G4 pos, G4 normal, float depth, Material mat)
    {
        this.incoming = incoming;
        this.pos = pos;
        this.normal = normal;
        this.depth = depth;
        this.mat = mat;
    }

    public col3 GetColor(Raytracer r, int recursioncap)
    {
        return mat.GetCol(this, r, recursioncap);
    }

    
}
