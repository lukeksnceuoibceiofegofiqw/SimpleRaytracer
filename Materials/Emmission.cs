using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer;

internal class Emmission : Material
{
    public Emmission(col3 c)
    {
        this.c = c;
    }

    public override col3 GetCol(Intersection i, Raytracer r, int recursioncap)
    {
        return c;
    }
}
