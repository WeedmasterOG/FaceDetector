using System;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace FaceRecog
{
    class Wallpaper
    {
        // Import dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public static void Change(string PicName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                {
                    switch (Globals.Settings.WallpaperFormat.ToLower())
                    {
                        case "fill":
                            key.SetValue(@"WallpaperStyle", 10.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;

                        case "fit":
                            key.SetValue(@"WallpaperStyle", 6.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;

                        case "span":
                            key.SetValue(@"WallpaperStyle", 22.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;

                        case "stretch":
                            key.SetValue(@"WallpaperStyle", 2.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;
                        case "tile":
                            key.SetValue(@"WallpaperStyle", 0.ToString());
                            key.SetValue(@"TileWallpaper", 1.ToString());
                            break;

                        case "center":
                            key.SetValue(@"WallpaperStyle", 0.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;
                        default:
                            key.SetValue(@"WallpaperStyle", 2.ToString());
                            key.SetValue(@"TileWallpaper", 0.ToString());
                            break;
                    }
                }

                SystemParametersInfo(20, 0, Directory.GetCurrentDirectory() + @"\" + PicName, 0x01 | 0x02);
            } catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to set wallpaper", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
            }
        }
    }
}
