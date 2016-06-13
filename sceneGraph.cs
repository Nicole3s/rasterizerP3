using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Template_P3
{
    class sceneGraph
    {
        Mesh current, parent;
        //LinkedList<M>

        // bestaat uit hierarchie van meshes
        // wikipedia zei: linked lists
        // takenlijstje zegt: datastructuur implementeren, dus linked list is zeker
        // een mogelijkheid

        // EISEN: er mogen geen restricties staan op de diepte of op het aantal meshes.

            /*
        public void Render(Matrix4 cameramatrix)
        {
            if (parent != null)
            {
                cameramatrix *= parent;
            }
        } */

        // render hier alle meshes in de hierarchie RECURSIEF:
            // Add a Render method to the scene graph class that 
            // recursively processes the nodes in the tree, 
            // while combining matrices, so that each mesh is drawn, 
            // using the correct combined matrix. 
    }
}
