using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer;

internal abstract class Object
{


    public Material mat;

    public abstract Intersection Intersect(Ray r, Intersection i);

    public Intersection intersectNormal(Intersection i)
    {
        if ((i.incoming % i.normal) > 0)
        {
            i.normal = new G4() - i.normal;
        }
        return i;
    }

    protected Intersection Replace(Intersection i, Intersection ni)
    {
        if (ni.depth > Raytracer.margin && ni.depth < i.depth)
        {
            return ni;
        }
        return i;
    }



}

