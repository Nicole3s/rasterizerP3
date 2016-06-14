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
        LinkedList<scenenode> objecten = new LinkedList<scenenode>();

        // elke mesh heeft zn eigen transformatie en rotatie
        // elke mesh krijgt een parent
        // bij het renderen pak je een mesh en de transformation en die vermenigvuldig je met de parent
        // extra class scenenode met mesh, parent,
        // list van scenenodes
        // mesh evt property transformatie en rotatie


        // bestaat uit hierarchie van meshes
        // wikipedia zei: linked lists
        // takenlijstje zegt: datastructuur implementeren, dus linked list is zeker
        // een mogelijkheid

        // EISEN: er mogen geen restricties staan op de diepte of op het aantal meshes,
        // dus listsysteem is geschikt

            
        public void Render(Matrix4 cameramatrix)
        {
            foreach(scenenode ding in objecten){

            }
        } 

        // render hier alle meshes in de hierarchie RECURSIEF:
            // Add a Render method to the scene graph class that 
            // recursively processes the nodes in the tree, 
            // while combining matrices, so that each mesh is drawn, 
            // using the correct combined matrix. 
    }
}
