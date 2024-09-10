using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRaytracer;

internal class Refraction : Material
{
    internal float RefractionIndex;

    public Refraction(col3 col, float refractionIndex)
    {
        this.c = col;
        this.RefractionIndex = refractionIndex;
    }
    

    public override col3 GetCol(Intersection i, Raytracer r, int recursionCap)
    {
        G4 normal = i.normal;
        float vacuum = 1f;
        float RefractionIndex = this.RefractionIndex;

        //flips if exiting material
        if ((i.incoming % normal) > 0)
        {
            normal = -normal;
            (vacuum, RefractionIndex) = (RefractionIndex, vacuum);
        }

        float eta = vacuum / RefractionIndex;
        float cosThetaI = -(normal % i.incoming);
        float sinThetaT2 = eta * eta * (1 - cosThetaI * cosThetaI);

        if (sinThetaT2 > 1)
            return new col3(0, 0, 0); // Total internal reflection

        float cosThetaT = (float)Math.Sqrt(1 - sinThetaT2);
        G4 refracted = i.incoming * eta + normal * (cosThetaI * eta - cosThetaT);

        return c * r.cast(new Ray(i.pos, refracted), recursionCap - 1);
    }
}

