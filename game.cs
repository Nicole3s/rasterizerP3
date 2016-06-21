using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

// minimal OpenTK rendering framework for UU/INFOGR
// Jacco Bikker, 2016

namespace Template_P3
{

    class Game
    {
        // member variables
        public Surface screen;                  // background surface for printing etc.
        //public Mesh mesh, floor, klok_basis;    // a mesh to draw using OpenGL
        const float PI = 3.1415926535f;         // PI
        float a = 0;                            // teapot rotation angle
        Stopwatch timer;                        // timer for measuring frame duration
        public Shader shader;                   // shader to use for rendering
        public Shader postproc;                 // shader to use for post processing
        public Texture wood, paint, wol;        // texture to use for rendering
        RenderTarget target;                    // intermediate render target
        ScreenQuad quad;                        // screen filling quad for post processing
        bool useRenderTarget = true;
        sceneGraph scenegraph;                  // game exists of a scenegraph

        // initialize
        public void Init()
        {
            // load a texture
            wood = new Texture("../../assets/wood.jpg");
            paint = new Texture("../../assets/paint.jpg");
            wol = new Texture("../../assets/wol.jpg");

            // load teapot
            // public Mesh(string fileName, Mesh ouder, float transx, float transy, float transz, float rotx, float roty, float rotz)
            Mesh mesh = new Mesh("../../assets/teapot.obj", null, 0, 0, -15, 0, 1, 0, paint, 1);
            Mesh floor = new Mesh("../../assets/floortest2.obj", mesh, -10, 0, -15, 0, 1, 0, wood, 2);
            Mesh klok_basis = new Mesh("../../assets/klok_basis.obj", mesh, 10, 0, 0, 0, 1, 0, wol, 2);

            // create scenegraph and add meshes
            scenegraph = new sceneGraph();
            scenegraph.objecten.Add(mesh);
            scenegraph.objecten.Add(floor);
            scenegraph.objecten.Add(klok_basis);

            // initialize stopwatch
            timer = new Stopwatch();
            timer.Reset();
            timer.Start();
            // create shaders
            shader = new Shader("../../shaders/vs.glsl", "../../shaders/fs.glsl");
            postproc = new Shader("../../shaders/vs_post.glsl", "../../shaders/fs_post.glsl");
            // load a texture
            wood = new Texture("../../assets/wood.jpg");
            paint = new Texture("../../assets/paint.jpg");
            wol = new Texture("../../assets/wol.jpg");
            // create the render target
            target = new RenderTarget(screen.width, screen.height);
            quad = new ScreenQuad();
        }

        // tick for background surface
        public void Tick()
        {
            screen.Clear(0);
        }

        // tick for OpenGL rendering code
        public void RenderGL()
        {
            /*   // measure frame duration
               float frameDuration = timer.ElapsedMilliseconds;
               timer.Reset();
               timer.Start();

               // prepare matrix for vertex shader
               Matrix4 transform = Matrix4.CreateFromAxisAngle(new Vector3(0, 1, 0), a);
               Matrix4 transformfloor = Matrix4.CreateFromAxisAngle(new Vector3(1, 0, 0), a);

               transform *= Matrix4.CreateTranslation(0, -4, -15);
               transform *= Matrix4.CreatePerspectiveFieldOfView(1.2f, 1.3f, .1f, 1000);

               transformfloor *= transform;*/

            // measure frame duration
            float frameDuration = timer.ElapsedMilliseconds;
            timer.Reset();
            timer.Start();

            // update rotation
            a += 0.001f * frameDuration;
               if (a > 2 * PI) a -= 2 * PI;
               

            Matrix4 camera = Matrix4.CreatePerspectiveFieldOfView(1.2f, 1.3f, .1f, 1000);

            if (useRenderTarget)
            {
                // enable render target
                target.Bind();

                // render scene to render target
                scenegraph.Render(camera, a, shader, postproc);

                // render quad
                target.Unbind();
                quad.Render(postproc, target.GetTextureID());
            }
            else
            {
                // render scene directly to the screen
                scenegraph.Render(camera, a, shader, postproc);
            }
        }
    }

} // namespace Template_P3