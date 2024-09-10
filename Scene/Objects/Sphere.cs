using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRaytracer;
internal class Sphere : Object
{
    public Sphere(G4 loc, float radius, Material mat)
    {
        this.loc = loc;
        this.radius = radius;
        this.mat = mat;
    }

    public G4 loc;
    public float radius;
    G4 down = new(0, -1, 0, 1);

    public override Intersection Intersect(Ray r, Intersection i)
    {

        float a = r.dir % r.dir;
        float b = 2 * (r.dir % (r.st - loc));
        float c = ((r.st - loc) % (r.st - loc)) - radius * radius;
        float d = b * b - 4 * a * c;
        if (d < 0)
            return i;
        float f1 = (0 - b - (float)Math.Sqrt(d)) / (2 * a);
        float f2 = (0 - b + (float)Math.Sqrt(d)) / (2 * a);

        
        G4 p = (r.dir * f1) + r.st;
        G4 normal = G4.Normalize(p - loc);
        i = Replace(i, intersectNormal(new Intersection(r.dir, p, normal, f1, mat)));
        
        p = (r.dir * f2) + r.st;
        normal = G4.Normalize(p - loc);
        i = Replace(i, intersectNormal(new Intersection(r.dir, p, normal, f1, mat)));

        return i;
    }


}

