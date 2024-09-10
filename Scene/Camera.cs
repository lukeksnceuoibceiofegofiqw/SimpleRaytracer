using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRaytracer
{
    internal class Camera
    {
        internal G4 pos = new G4(0, 0, -10, 1);



        public Ray MakeRay(int x, int y, Size screen)
        {
            G4 dir = G4.Normalize(new G4(2*x / (float)screen.Width - 1, (-2*y+screen.Height)/(float)screen.Width, 1, 1));
             
            return new Ray(pos, dir);
        }



    }
}
