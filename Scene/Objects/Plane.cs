using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRaytracer;

internal class Plane : Object
{
    G4 pos;

    //needs to be normalised
    G4 normal;

    public Plane(G4 pos, G4 normal, Material mat)
    {
        this.pos = pos;
        this.normal = normal;
        this.mat = mat;

    }

    public override Intersection Intersect(Ray r, Intersection i)
    {
        float paralellism = (r.dir % normal);
        if (paralellism == 0)
        {
            return i;
        }

        float d = ((pos - r.st) % normal) / paralellism;

        if (d < 0)
            return i;


        i = Replace(i, intersectNormal(new Intersection(r.dir, (r.dir * d) + r.st, normal, d, mat)));
        return i;
    }

}

