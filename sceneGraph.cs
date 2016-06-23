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
        //float a = 0;
        const float PI = 3.1415926535f;         // PI
        Shader shader, postproc;

        // mesh evt transformatie en rotatie als property

        // scenegraph bestaat uit hierarchie van meshes
        // wikipedia zei: linked lists, wij gebruiken list
        // takenlijstje zegt: datastructuur implementeren, dus linked list is zeker
        // een mogelijkheid

        // EISEN: er mogen geen restricties staan op de diepte of op het aantal meshes,
        // dus listsysteem is geschikt

        public void Render(Matrix4 cameramatrix, float a, Shader shader, Shader postproc)
        {
            Matrix4 transform;
            foreach (Mesh ding in objecten){
                transform = ding.Transform(a);
                transform *= cameramatrix;
                ding.Render(shader, transform, ding.textuur);
            }            
        } 

        // render hier alle meshes in de hierarchie RECURSIEF:
            // Add a Render method to the scene graph class that 
            // recursively processes the nodes in the tree, 
            // while combining matrices, so that each mesh is drawn, 
            // using the correct combined matrix. 
    }
}
