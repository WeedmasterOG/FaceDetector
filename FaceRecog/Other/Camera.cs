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
                WebCam camera = new WebCam();

                CConsole.Write("Scanning for cameras", Color.SpringGreen);
                camera.SetSerialNumberToConnect(
                    WebCam.ScanForCameras()[Globals.Settings.CameraToUse]);

                CConsole.Write("Connecting to camera", Color.SpringGreen);
                camera.Connect();

                // Throw exeption erly
                // make output look good/normal
                // resolve any first time image issues
                // under the hood, dont need to output whats going on
                Globals.ImageBitmap = camera.GetBitmap();

                CConsole.Write("Letting camera calibrate itself", Color.SpringGreen);

                // Let camera controller calibrate itself (exposure, color, sharnpess.. etc)
                // added an extra 500 - 1000 ms for slower machines
                Thread.Sleep(2500);

                CConsole.Write("Taking image", Color.SpringGreen);

                // take image a second time, write to same bitmap
                Globals.ImageBitmap = camera.GetBitmap();

                CConsole.Write("Disconnecting", Color.SpringGreen);

                // Disconnects and disposes
                camera.Disconnect();
            }
            catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to detect/connect/take image from camera", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
            }
        }
    }
}
