using System;
using System.Drawing;
using System.Collections.Generic;

namespace FaceRecog
{
    class Globals
    {
        public static Bitmap ImageBitmap;

        public static SettingsFomatter Settings = new SettingsFomatter();

        public static List<string> FileNames = new List<string>
        {
            @"de\MetriCam.resources.dll",
            @"en\MetriCam.resources.dll",
            @"other\haarcascade_frontalface_default.xml",
            @"other\Swastika.png",
            @"x64\concrt140.dll",
            @"x64\cvextern.dll",
            @"x64\msvcp140.dll",
            @"x64\opencv_ffmpeg401_64.dll",
            @"x64\vcruntime140.dll",
            @"x86\concrt140.dll",
            @"x86\cvextern.dll",
            @"x86\msvcp140.dll",
            @"x86\opencv_ffmpeg401.dll",
            @"x86\vcruntime140.dll",
            "Bluetechnix.dll",
            "Colorful.Console.dll",
            "Emgu.CV.UI.dll",
            "Emgu.CV.UI.xml",
            "Emgu.CV.World.dll",
            "Emgu.CV.World.xml",
            "Fotonic.dll",
            "ImageProcessor.dll",
            "ImageProcessor.xml",
            "MesaCamera.dll",
            "MetriCam.dll",
            "MetriCamSDK.dll",
            "MetriUEye.dll",
            "Newtonsoft.Json.dll",
            "Newtonsoft.Json.xml",
            "O3DCamera.dll",
            "PMDCamera.dll",
            "PrimeSense.dll",
            "Settings.json",
            "SoftKinetic.dll",
            "WebCam.dll"
        };
    }
}
