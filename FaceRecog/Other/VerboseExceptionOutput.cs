using System;
using System.Drawing;

namespace FaceRecog
{
    class VerboseExceptionOutput
    {
        public static void WriteExep(Exception ex)
        {
            if (Globals.Settings.VerboseErrorOutput)
            {
                Console.WriteLine();
                CConsole.Write(ex.ToString(), Color.Gray);
            }

            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
