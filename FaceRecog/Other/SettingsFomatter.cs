using System;
using System.Drawing;
using Newtonsoft.Json;

namespace FaceRecog
{
    class SettingsFomatter
    {
        public SettingsFomatter DeserializeSettings(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<SettingsFomatter>(input);
            } catch
            {
                CConsole.Write("ERROR: Failed to load settings from json", Color.Red);

                // Manually wait
                Console.ReadLine();
                // Settings failed to load, no need to call VerboseExeptionOutput
                // Manually exit
                Environment.Exit(0);
                return null;
            }
        }

        public int AddedBrightness { get; set; }
        public int AddedSharpness { get; set; }
        public string Overlay { get; set; }
        public int OverlayOpacity { get; set; }
        public bool Flip { get; set; }
        public string EffectMode { get; set; }
        public string WallpaperFormat { get; set; }
        public bool KeepOutputImage { get; set; }
        public bool ExitAfterCompletion { get; set; }
        public bool VerboseErrorOutput { get; set; }
    }
}
