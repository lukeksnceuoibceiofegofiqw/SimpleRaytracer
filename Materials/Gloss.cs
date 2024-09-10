using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRaytracer;

internal class Gloss : Material
{

    public Gloss(col3 col)
    {
        this.c = col;
    }

    public override col3 GetCol(Intersection i, Raytracer r, int recursionCap)
    {
        return c * r.cast(
                new Ray(i.pos, i.incoming - (i.normal * 2 * (i.incoming % i.normal))),
                recursionCap - 1
           );

    }


}
