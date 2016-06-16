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
        


        // elke mesh heeft zn eigen transformatie en rotatie
        // elke mesh krijgt een parent
        // bij het renderen pak je een mesh en de transformation en die vermenigvuldig je met de parent
        // extra class scenenode met mesh, parent,??
        // list van scenenodes??
        // mesh evt transformatie en rotatie als property

        // scenegraph bestaat uit hierarchie van meshes
        // wikipedia zei: linked lists, wij gebruiken list
        // takenlijstje zegt: datastructuur implementeren, dus linked list is zeker
        // een mogelijkheid

        // EISEN: er mogen geen restricties staan op de diepte of op het aantal meshes,
        // dus listsysteem is geschikt

        Matrix4 Vermenigvuldigparent(Mesh mesh, float a)
        {
            Matrix4 output = mesh.locatie + mesh.parent.locatie;
            Matrix4 rotatie = mesh.Transform(a);
            output = mesh.parent.Transform(a) * output;
            if(mesh.parent.parent != null)
            {
                output *= Vermenigvuldigparent(mesh.parent, a);
            }
            return output;
        }

        public void Render(Matrix4 cameramatrix, float a, Shader shader, Shader postproc)
        {
            foreach (Mesh ding in objecten){
                if(ding.parent != null)
                {
                    // vermenigvuldig met de translatie en rotatie van de parent
                    // tel op bij locatie van de parent
                    Matrix4 transform = Vermenigvuldigparent(ding, a) * cameramatrix;
                    ding.Render(shader, transform, ding.textuur);
                    ding.a = a;
                }
                else
                {
                    Matrix4 transform = ding.Transform(a) * ding.locatie *  cameramatrix;
                    ding.Render(shader, transform, ding.textuur);
                    ding.a = a;
                }
            }            
        } 

        // render hier alle meshes in de hierarchie RECURSIEF:
            // Add a Render method to the scene graph class that 
            // recursively processes the nodes in the tree, 
            // while combining matrices, so that each mesh is drawn, 
            // using the correct combined matrix. 
    }
}
