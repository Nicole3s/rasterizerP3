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
        Texture wol, paint, wood;


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

        public void Render(Matrix4 cameramatrix, float a)
        {

            // create shaders
            shader = new Shader("../../shaders/vs.glsl", "../../shaders/fs.glsl");
            postproc = new Shader("../../shaders/vs_post.glsl", "../../shaders/fs_post.glsl");
            // load a texture
            wood = new Texture("../../assets/wood.jpg");
            paint = new Texture("../../assets/paint.jpg");
            wol = new Texture("../../assets/wol.jpg");

            //Matrix4 transform = Matrix4.CreateFromAxisAngle(new Vector3(0, 1, 0), a);
            //transform *= Matrix4.CreateTranslation(0, -4, -15);
            //klok_basis.Render(shader, transform, wood);

            foreach (Mesh ding in objecten){
                if(ding.parent != null)
                {
                    // vermenigvuldig met de translatie en rotatie van de parent
                    // tel op bij locatie van de parent
                    Matrix4 transform = Vermenigvuldigparent(ding, a) * cameramatrix;
                    ding.Render(shader, transform, paint);
                    ding.a = a;
                }
                else
                {
                    Matrix4 transform = ding.Transform(a) * ding.locatie *  cameramatrix;
                    ding.Render(shader, transform, paint);
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
