using System;
using System.Drawing;
using Console = Colorful.Console;

namespace FaceRecog
{
    class CConsole
    {
        public static void Write(string text, Color color)
        {
            Console.WriteLineFormatted("{0} " + text, Color.Aqua, color, "[+]");
        }
    }
}
