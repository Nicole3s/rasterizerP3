using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace Template_P3
{
    class Camera
    {
        int[] positie = new int[] { 0, 0, 0 };
        public Matrix4 cameramatrix = Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.3f, 0.01f, 1000);
        float stapgrootte = 0.05f;

        public Camera() { }

        public void onKeypress()
        {
            var keypressed = OpenTK.Input.Keyboard.GetState();

            // beweeg door de wereld met de pijltoetsen
            if(keypressed[Key.Up])// ga naar voren
                cameramatrix = Matrix4.CreateTranslation(0, 0, stapgrootte) * cameramatrix;
            if (keypressed[Key.Down])// ga naar achter
                cameramatrix = Matrix4.CreateTranslation(0, 0, -stapgrootte) * cameramatrix;
            if (keypressed[Key.Left])// ga naar links
                cameramatrix = Matrix4.CreateTranslation(stapgrootte, 0, 0) * cameramatrix;
            if (keypressed[Key.Right])// ga naar rechts
                cameramatrix = Matrix4.CreateTranslation(-stapgrootte, 0, 0) * cameramatrix;
            // met pageup en pagedown beweeg je naar boven en naar beneden
            if (keypressed[Key.PageUp])
                cameramatrix = Matrix4.CreateTranslation(0, -stapgrootte, 0) * cameramatrix;
            if (keypressed[Key.PageDown])
                cameramatrix = Matrix4.CreateTranslation(0, stapgrootte, 0) * cameramatrix;

            // met backspace reset je de camera
            if (keypressed[Key.BackSpace])
                cameramatrix = Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.3f, 0.01f, 1000);

            // bekijk de wereld vanuit een ander perspectief met ASDWZX
            if (keypressed[Key.D])
                cameramatrix = Matrix4.CreateRotationY(0.02f) * cameramatrix;
            if (keypressed[Key.A])
                cameramatrix = Matrix4.CreateRotationY(-0.02f) * cameramatrix;
            if (keypressed[Key.S])
                cameramatrix = Matrix4.CreateRotationX(0.02f) * cameramatrix;
            if (keypressed[Key.W])
                cameramatrix = Matrix4.CreateRotationX(-0.02f) * cameramatrix;
            if (keypressed[Key.X])
                cameramatrix = Matrix4.CreateRotationZ(0.02f) * cameramatrix;
            if (keypressed[Key.Z])
                cameramatrix = Matrix4.CreateRotationZ(-0.02f) * cameramatrix;
        }
    }
}
