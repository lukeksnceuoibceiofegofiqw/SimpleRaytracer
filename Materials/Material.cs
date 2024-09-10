using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer;

internal abstract class Material
{
    internal col3 c;

    public abstract col3 GetCol(Intersection i, Raytracer r, int recursioncap);

}

