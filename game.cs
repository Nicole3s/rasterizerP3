using System.Diagnostics;
using OpenTK;
using System.Windows;
using System;
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
        Camera camera;

        // initialize
        public void Init()
        {
            // load a texture
            wood = new Texture("../../assets/wood.jpg");
            paint = new Texture("../../assets/paint.jpg");
            wol = new Texture("../../assets/wol.jpg");

            // load teapot basis and floor
            // public Mesh(string fileName, Mesh ouder, float transx, float transy, float transz, float rotx, float roty, float rotz, Texture texture, float rotatiefactor)
            Mesh theepot_basis = new Mesh("../../assets/teapot.obj", null, 0, -3, -15, 0, 1, 0, paint, 0.5f);
            Mesh floor = new Mesh("../../assets/floor.obj", null, 0, -7, -15, 0, 1, 0, wood, 0);

            // create scenegraph and add meshes
            scenegraph = new sceneGraph();
            scenegraph.objecten.Add(theepot_basis);
            scenegraph.objecten.Add(floor);

            // create several teapots in layers 
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Mesh theepot_eerste_laag = new Mesh("../../assets/teapot_half.obj", theepot_basis, -3.5f + 7 * i, 6, -3.5f + 7 * j, 0, 1, 0, wood, -2 + (i+ j) * 0.3f);
                    scenegraph.objecten.Add(theepot_eerste_laag);

                    // maak de tweede laag bovenop de eerste laag
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < 2; l++)
                        {
                            Mesh theepot_tweede_laag = new Mesh("../../assets/teapot_kwart.obj", theepot_eerste_laag, -2.0f + 4 * k, 4, -2.0f + 4 * l, 0, 1, 0, wol, 2 + (k+l) * 0.4f);
                            scenegraph.objecten.Add(theepot_tweede_laag);
                        }
                    }
                }
            }

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

            camera = new Camera();
        }

        // tick for background surface
        public void Tick()
        {
            screen.Clear(0);
            camera.onKeypress();
        }

       /* void keyinput(object o, KeyPressEventArgs e)
        {
            if (e.keycode)
            {

            }
        }*/

        // tick for OpenGL rendering code
        public void RenderGL()
        {
            // measure frame duration
            float frameDuration = timer.ElapsedMilliseconds;
            timer.Reset();
            timer.Start();

            // update rotation
            a += 0.001f * frameDuration;
               if (a > 4 * PI) a -= 4 * PI;

            if (useRenderTarget)
            {
                // enable render target
                target.Bind();

                // render scene to render target
                scenegraph.Render(camera.cameramatrix, a, shader, postproc);

                // render quad
                target.Unbind();
                quad.Render(postproc, target.GetTextureID());
            }
            else
            {
                // render scene directly to the screen
                scenegraph.Render(camera.cameramatrix, a, shader, postproc);
            }
        }
    }

} // namespace Template_P3