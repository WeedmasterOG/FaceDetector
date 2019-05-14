using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace FaceRecog
{
    class ImgBrightness
    {
        /*
         * This class isnt used and its only here so that i can easely use it in the future
         * without needing to re-do the work
         */
        public static double Calc(Bitmap bm)
        {
            try
            {
                double lum = 0;

                using (Bitmap tmpBmp = new Bitmap(bm))
                {
                    int bppModifier = bm.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;

                    var srcData = tmpBmp.LockBits(
                        new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);

                    unsafe
                    {
                        byte* p = (byte*)(void*)srcData.Scan0;

                        for (int y = 0; y < bm.Height; y++)
                        {
                            for (int x = 0; x < bm.Width; x++)
                            {
                                int idx = (y * srcData.Stride) + x * bppModifier;
                                lum += (0.299 * p[idx + 2] + 0.587 * p[idx + 1] + 0.114 * p[idx]);
                            }
                        }
                    }

                    tmpBmp.UnlockBits(srcData);
                    double avgLum = lum / (bm.Width * bm.Height);

                    return avgLum / 255.0;
                }
            } catch(Exception ex)
            {
                CConsole.Write("ERROR: Failed get image brightness", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
                return 0.0;
            }
        }
    }
}
