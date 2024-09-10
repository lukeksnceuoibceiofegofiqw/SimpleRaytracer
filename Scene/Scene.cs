using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer;
internal class Scene
{
    public List<Object> objects = new();
    public List<Light> lights = new();
    public Material skyMat = new Emmission(new col3(100, 150, 220));

    public Scene()
    {
        objects.Add(new Sphere(new(0,-4,0,1), 2, new Diffuse(new(255,200,200))));
        objects.Add(new Sphere(new(2, 2, 0, 1), 2, new Diffuse(new(100, 255, 150))));
        objects.Add(new Sphere(new(-4, 0, 2, 1), 2, new Gloss(new(150, 150, 200))));
        objects.Add(new Sphere(new(-8, 1, 1, 1), 2, new Gloss(new(150, 150, 200))));
        objects.Add(new Sphere(new(0, -1, -5, 1), 1, new Refraction(new(240, 130, 100), 1.1f)));

        objects.Add(new Plane(new(0, -4, 0, 1), new G4(0,1,0,1), new Diffuse(new(200, 200, 200))));
        lights.Add(new Light(new(0,10,0,1), 10, new col3(25500,25500,25500)));
    }



}

