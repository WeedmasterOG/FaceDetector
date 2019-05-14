using System;
using System.IO;

namespace FaceRecog
{
    class NeededFiles
    {
        public static bool Check()
        {
            // Not using ColorfulConsole to make sure the program
            // dosnt throw an exception if DLL is missing

            bool FilesMissing = false;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            foreach (string FileName in Globals.FileNames)
            {
                if(!File.Exists(FileName))
                {
                    FilesMissing = true;

                    // not using the lib due to not want the [+] infront
                    Console.WriteLine($"ERROR: {FileName} not found");
                }
            }

            // Incase any other method calls Console instead of CConsole
            Console.ForegroundColor = ConsoleColor.Gray;

            return FilesMissing;
        }
    }
}
