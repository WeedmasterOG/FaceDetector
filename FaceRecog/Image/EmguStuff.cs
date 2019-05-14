using System;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using System.Collections.Generic;

namespace FaceRecog
{
    class EmguStuff
    {
        public static bool DetectAndCrop()
        {
            try
            {
                List<Rectangle> faces = new List<Rectangle>();
                Random Rand = new Random();

                using (Image<Bgr, byte> imgInput = new Image<Bgr, byte>(Globals.ImageBitmap))
                {
                    CConsole.Write("Loading haar file", Color.SpringGreen);
                    using (CascadeClassifier classifierFace = new CascadeClassifier(@"other\haarcascade_frontalface_default.xml"))
                    {
                        CConsole.Write("Finding face", Color.SpringGreen);
                        faces.AddRange(classifierFace.DetectMultiScale(
                            imgInput.Convert<Gray, byte>().Clone(), 1.1, 4));
                    }

                    if (faces.Count != 0)
                    {
                        CConsole.Write("Face(es) found", Color.SpringGreen);

                        if (faces.Count >= 2)
                        {
                            CConsole.Write("NOTE: Choosing random face", Color.Yellow);
                        }

                        int FaceToUse = Rand.Next(0, faces.Count);

                        CConsole.Write("Cropping image", Color.SpringGreen);

                        Globals.ImageBitmap = imgInput.Bitmap.Clone(
                            new Rectangle(faces[FaceToUse].X, faces[FaceToUse].Y, // Set rect X, Y
                            faces[FaceToUse].Size.Height, faces[FaceToUse].Size.Width), // Set rect Height, width
                            imgInput.Bitmap.PixelFormat); // Set format

                        return true;
                    }
                    else
                    {
                        CConsole.Write("No face(es) found", Color.Yellow);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to run face detection/cropping", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
                return false;
            }
        }
    }
}

/*foreach (var face in faces)
{
    imgInput.Draw(face, new Bgr(0, 0, 255), 2);


    imgGray.ROI = face;
}*/

// https://github.com/halanch599/Emgucv/blob/master/EmguCV%20-28%20Face%20Detection%20-Haar%20or%20LBP/FormFaceDetection.cs