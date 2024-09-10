

namespace SimpleRaytracer;


internal class Diffuse : Material
{
    float spec = 10;
    float a = 100;
    float diff = 1;
    float amb = 0.5f;

    public Diffuse(col3 c)
    {
        this.c = c;
    }

    public override col3 GetCol(Intersection i, Raytracer r, int recursioncap)
    {
        col3 diffuse = new();

        col3 specular = new();

        foreach (Light l in r.scene.lights)
        {
            if (!l.InHemisphere(i.pos, i.normal))
            {
                continue;
            }

            Ray shadowray = l.shadowRay(i.pos);

            Intersection shadowintersect = r.Intersect(shadowray);

            if (!l.shadowRayHitCheck(shadowintersect))
            {
                continue;
            }

            float dir = (i.normal % G4.Normalize(shadowray.dir));

            diffuse = diffuse + l.light(i.pos, dir * diff);


            G4 lightdir = - G4.Normalize(l.shadowRay(i.pos).dir);


            G4 reflectionDir = lightdir - (i.normal * 2 * (lightdir % i.normal));

            float specularDot = (reflectionDir % (- G4.Normalize(i.incoming)));

            if (specularDot < 0)
            {
                continue;
            }

            float specularFactor = MathF.Pow(specularDot, a);

            specular = specular + l.light(i.pos, specularFactor * spec);
        }

        col3 ambient = col3.fac(r.scene.skyMat.c, amb);


        //use actual normal for texturing to avoid inconsistencies
        return c * (diffuse + ambient) + specular;

    }



}


