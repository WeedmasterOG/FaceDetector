using System;
using MetriCam;
using System.Drawing;
using System.Threading;

namespace FaceRecog
{
    class Camera
    {
        public static void TakePhoto()
        {
            try
            {
                CConsole.Write("Connecting to camera", Color.SpringGreen);
                WebCam camera = new WebCam();
                camera.Connect();

                // Throw exeption erly
                // make output look good/normal
                // resolve any first time image issues
                // under the hood, dont need to output whats going on
                Globals.ImageBitmap = camera.GetBitmap();

                CConsole.Write("Letting camera calibrate itself", Color.SpringGreen);

                // Let camera controller calibrate itself (exposure, color, sharnpess.. etc)
                Thread.Sleep(2000);

                CConsole.Write("Taking image", Color.SpringGreen);

                // take image a second time, write to same bitmap
                Globals.ImageBitmap = camera.GetBitmap();

                CConsole.Write("Disconnecting", Color.SpringGreen);

                // Disconnects and disposes
                camera.Disconnect();
            }
            catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to connect/take image from camera", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
            }
        }
    }
}
