using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;

namespace FaceRecog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Resize and hide scroll bar
            Console.SetWindowSize(55, 25);
            Console.SetBufferSize(55, 25);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Not using ColorfulConsole to make sure the program
            // dosnt throw an exception if DLL is missing
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Checking files", Color.SpringGreen);

            if (NeededFiles.Check())
            {
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Replace wrong green color with Color.SpringGreen instead, keep same text
            Console.Clear();
            CConsole.Write("Checking files", Color.SpringGreen);

            CConsole.Write("Loading settings", Color.SpringGreen);

            // Load settings
            Globals.Settings = Globals.Settings.DeserializeSettings(File.ReadAllText("Settings.json"));

            bool IsFaceDetected = false;
            int Trys = 0;

            while (IsFaceDetected == false)
            {
                // Writes to ImageBitmap
                Camera.TakePhoto();

                // Writes to bitmap & saves image
                IsFaceDetected = EmguStuff.DetectAndCrop();

                if (IsFaceDetected == true)
                {
                    break;
                }

                if (Trys > 1) // 3 times
                {
                    Thread.Sleep(100);
                    CConsole.Write("ERROR: Too many tries", Color.Red);
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                }

                CConsole.Write("Trying again in 6 secs", Color.Yellow);

                Thread.Sleep(TimeSpan.FromSeconds(6));
                Trys++;
            }

            CConsole.Write("Applying effects", Color.SpringGreen);
            ImgProcessor.AddEffects();

            CConsole.Write("Settings wallpaper", Color.SpringGreen);
            Wallpaper.Change("image.png");

            if (!Globals.Settings.KeepOutputImage)
            {
                File.Delete("image.png");
            }

            stopwatch.Stop();

            CConsole.Write("Done", Color.Lime);
            CConsole.Write($"Time: {stopwatch.ElapsedMilliseconds} ms", Color.White);

            if (Globals.Settings.ExitAfterCompletion)
            {
                Thread.Sleep(800);
                Environment.Exit(0);
            } else
            {
                Console.ReadLine();
            }
        }
    }
}
