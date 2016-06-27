using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenTK;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL;

namespace Template_P3
{
    class sceneGraph
    {
        public List<Mesh> objecten = new List<Mesh>();
        //Shader shader, postproc;

        // mesh evt transformatie en rotatie als property

        public void Render(Matrix4 cameramatrix, float frameDuration, Shader shader, Shader postproc)
        {
            Matrix4 transform;
            foreach (Mesh ding in objecten){
                transform = ding.Transform(frameDuration);
                transform *= cameramatrix;
                ding.Render(shader, transform, ding.textuur);
            }            
        } 
    }
}
