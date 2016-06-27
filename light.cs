using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Template_P3
{
    public class Light
    {   
        Vector3 location /*color, direction*/;
        float intensity;
        public Light(Vector3 locatie, float intensiteit)
        {
            location = locatie;
            //color = kleur;
           // direction = richting;
            intensity = intensiteit;
            
            
        }
        // hier sla je de informatie van de lichtbronnen in op.
        // je wilt verschillende lichtbronnen in je scenegraph kunnen plaatsen
        // maar om de opdracht te halen is één lichtbron genoeg
        //kleur, positie, richting, intensiteit
    }
}
