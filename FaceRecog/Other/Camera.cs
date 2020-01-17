using System;
using MetriCam;
using System.Drawing;
using System.Threading;

namespace FaceRecog
{
    class Camera
    {
        /*
        * Note:
        * Capture class is only available in windows form apps,
        * therefore im using the MetriCam lib.
        */
        public static void TakePhoto()
        {
            try
            {
                WebCam camera = new WebCam();
                camera.SetSerialNumberToConnect(Globals.CamSerials[Globals.Settings.CameraToUse]);

                CConsole.Write("Connecting to camera", Color.SpringGreen);
                camera.Connect();

                CConsole.Write("Taking test image", Color.SpringGreen);

                // Throw exeption erly
                // make output look good/normal
                // resolve any first time image issues
                Globals.ImageBitmap = camera.GetBitmap();

                CConsole.Write("Letting camera calibrate itself", Color.SpringGreen);

                // Let camera controller calibrate itself (exposure, color, sharnpess.. etc)
                // added an extra 500 - 1000 ms for slower machines
                Thread.Sleep(2500);

                CConsole.Write("Taking main image", Color.SpringGreen);

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

        public static void DetectCameras()
        {
            try
            {
                CConsole.Write("Scanning for cameras", Color.SpringGreen);

                // Will throw an exception if return is null or empty(sometimes)
                Globals.CamSerials.AddRange(WebCam.ScanForCameras());

                // Doubble check list size, catch anything that AddRange dosnt and throw exception
                if (Globals.CamSerials.Count == 0)
                {
                    throw new Exception("Failed to detect camera(s)");
                }

                // Check all items in list, just incase the two methods above didnt catch anything
                // if camera serial size is unresonable, throw exception 
                foreach (string CamSerial in Globals.CamSerials)
                {
                    if (CamSerial.Length < 2)
                    {
                        throw new Exception("Failed to detect camera(s)");
                    }
                }

                // Make sure the serials are always in the same order
                Globals.CamSerials.Sort();
            }
            catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to detect camera(s)", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
            }
        }
    }
}
