using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRaytracer;

internal class Light
{
    public G4 pos; 
    public float intensity;
    public col3 col;

    public Light (G4 pos, float intensity, col3 col)
    {
        this.pos = pos;
        this.intensity = intensity;
        this.col = col;
    }

    public virtual bool InHemisphere(G4 p, G4 normal)
    {
        return ((pos - p) % normal) > 0;
    }

    public virtual Ray shadowRay(G4 p)
    {
        return new Ray(p, pos - p);
    }

    /// <summary>
    /// gives the color of the light as seen from the location
    /// </summary>
    /// <param name="location"></param>
    /// <param name="fac"></param>
    /// <returns></returns>
    public virtual col3 light(G4 p, float fac)
    {
        return col3.fac(col, fac / ((pos - p) % (pos - p)));
    }

    public virtual bool shadowRayHitCheck(Intersection i)
    {
        return (i.pos % i.incoming) > (pos % i.incoming);
    }


}

