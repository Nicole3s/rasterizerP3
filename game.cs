﻿using System.Diagnostics;
using OpenTK;

// minimal OpenTK rendering framework for UU/INFOGR
// Jacco Bikker, 2016

namespace Template_P3 {

class Game
{
	// member variables
	public Surface screen;					// background surface for printing etc.
	Mesh mesh, floor, ding, klok_basis;						// a mesh to draw using OpenGL
	const float PI = 3.1415926535f;			// PI
	float a = 0, b = 0;							// teapot rotation angle
	Stopwatch timer;						// timer for measuring frame duration
	Shader shader;							// shader to use for rendering
	Texture wood, paint, wol;							// texture to use for rendering

	// initialize
	public void Init()
	{
		// load teapot
		mesh = new Mesh( "../../assets/teapot.obj" );
		floor = new Mesh( "../../assets/floortest2.obj" );
        ding = new Mesh("../../assets/objectje.obj");
        klok_basis = new Mesh("../../assets/klok_basis.obj");

		// initialize stopwatch
		timer = new Stopwatch();
		timer.Reset();
		timer.Start();
		// create shaders
		shader = new Shader( "../../shaders/vs.glsl", "../../shaders/fs.glsl" );
		// load a texture
		wood = new Texture( "../../assets/wood.jpg" );
        paint = new Texture("../../assets/paint.jpg");
        wol = new Texture("../../assets/wol.jpg");
	}

	// tick for background surface
	public void Tick()
	{
		screen.Clear( 0 );
	}

	// tick for OpenGL rendering code
	public void RenderGL()
	{
		// measure frame duration
		float frameDuration = timer.ElapsedMilliseconds;
		timer.Reset();
		timer.Start();
	
		// prepare matrix for vertex shader
		Matrix4 transform = Matrix4.CreateFromAxisAngle( new Vector3( 0, 1, 0 ), a );
        Matrix4 transformfloor = Matrix4.CreateFromAxisAngle(new Vector3(1, 0, 0), a);

            transformfloor *= transform;

        transform *= Matrix4.CreateTranslation(0, -4, -15); // BEPAAL DE LOCATIE van het midden van het object
        transform *= Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.3f, .1f, 1000);

        transformfloor *= Matrix4.CreateTranslation(0, -4, -35);
        transformfloor *= Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.3f, .1f, 1000);
            

            // update rotation
            a += 0.001f * frameDuration; 
		if (a > 2 * PI) a -= 2 * PI;
            // render scene
        klok_basis.Render( shader, transform, wol );        
		floor.Render( shader, transformfloor, paint );
        //ding.Render(shader, transform, paint);

        // roep hier de sceneGraph aan met de door userinput aangepaste cameramatrix!
	}
}

} // namespace Template_P3