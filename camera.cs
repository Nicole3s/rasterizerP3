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
        Vector3 positie = new Vector3(-1, 0, 0);
        Vector3 up = new Vector3(0, 1, 0);
        Vector3 kijkrichting = new Vector3(0, 0, -1);
        Vector3 right, target;

        public Matrix4 cameramatrix = Matrix4.CreatePerspectiveFieldOfView(1.3f, 1.3f, 0.01f, 1000);
        public Matrix4 lookat;
        float stapgrootte = 0.25f;

        // kijkrichting = (0,0,1)
        // target = pos + kijkrichting
        // right = up x kijkrichting
        // up = kijkrichting x right
            // naar rechts: target += 0.1 * right
        // lookat(pos, target, up)
        // cameramatrix vermenigvuldigen met lookat


        public Camera()
        {
            right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
            up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
            updatelookat();
        }

        void updatelookat()
        {
            target = positie + kijkrichting;
            lookat = Matrix4.LookAt(positie, target, up);
        }

        public void onKeypress()
        {
            var keypressed = Keyboard.GetState();

            // beweeg door de wereld met de pijltoetsen
            if (keypressed[Key.Up]) // ga naar voren
            {
                positie -= (stapgrootte * Vector3.Cross(up, right));
                updatelookat();
            }

            if (keypressed[Key.Down])// ga naar achter
            {
                positie += stapgrootte * Vector3.Cross(up, right);
                updatelookat();
            }
                
            if (keypressed[Key.Left])// ga naar links
            {
                positie += stapgrootte * right;
                updatelookat();
            }
            if (keypressed[Key.Right])// ga naar rechts
            {
                positie -= stapgrootte * right;
                updatelookat();
            }
            // met pageup en pagedown beweeg je naar boven en naar beneden
            if (keypressed[Key.PageUp])
            {
                positie += stapgrootte * up;
                updatelookat();
            }
            if (keypressed[Key.PageDown])
            {
                positie -= stapgrootte * up;
                updatelookat();
            }

            // met backspace reset je de camera
            if (keypressed[Key.BackSpace])
            {
                positie = new Vector3(-1, 0, 0);
                up = new Vector3(0, 1, 0);
                kijkrichting = new Vector3(0, 0, -1);
                right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
                up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
                updatelookat();
            }


            // bekijk de wereld vanuit een ander perspectief met ASDWZX
            if (keypressed[Key.D]) // kijk naar rechts
            {
                kijkrichting = Vector3.Normalize(kijkrichting - stapgrootte * right);
                right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
                up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
                updatelookat();
            }
            if (keypressed[Key.A]) // kijk naar links
            {
                kijkrichting = Vector3.Normalize(kijkrichting + stapgrootte * right);
                right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
                up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
                updatelookat();
            }
            if (keypressed[Key.S]) // kijk naar beneden
            {
                kijkrichting = Vector3.Normalize(kijkrichting - stapgrootte * up);
                right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
                up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
                updatelookat();
            }
            if (keypressed[Key.W]) // kijk naar boven
            {
                kijkrichting = Vector3.Normalize(kijkrichting + stapgrootte * up);
                right = Vector3.Normalize(Vector3.Cross(up, kijkrichting));
                up = Vector3.Normalize(Vector3.Cross(kijkrichting, right));
                updatelookat();
            }
        }
    }
}
