using System;
using System.IO;
using ImageProcessor;
using System.Drawing;
using ImageProcessor.Imaging;
using System.Drawing.Imaging;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Imaging.Filters.Photo;

namespace FaceRecog
{
    class ImgProcessor
    {
        public static void AddEffects()
        {
            try
            {
                // Format
                ISupportedImageFormat format = new PngFormat { Quality = 100 };

                // Effects getting applied
                using (MemoryStream inStream = new MemoryStream(BitmapTobyte(Globals.ImageBitmap)))
                {
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                        {

                            switch (Globals.Settings.EffectMode.ToLower())
                            {
                                default:
                                case "normal":
                                    imageFactory.Load(inStream)
                                                .Format(format)
                                                .Flip(Globals.Settings.Flip)
                                                /*.Overlay(new ImageLayer()
                                                {
                                                    Image = Image.FromFile(@"other\Example.png"),
                                                    Opacity = 75
                                                })*/

                                                .GaussianSharpen(Globals.Settings.AddedSharpness)
                                                .Brightness(Globals.Settings.AddedBrightness)
                                                //.Filter(MatrixFilters.Lomograph)
                                                //.Tint()
                                                //.Vignette(Color.Red)
                                                .Save(outStream);
                                    break;
                                case "pedo":
                                    imageFactory.Load(inStream)
                                                .Format(format)
                                                .Flip(Globals.Settings.Flip)
                                                .GaussianSharpen(12)
                                                .Brightness(-10)
                                                .Save(outStream);
                                    break;
                                case "nazi":
                                    imageFactory.Load(inStream)
                                                .Format(format)
                                                .Flip(Globals.Settings.Flip)
                                                .Overlay(new ImageLayer()
                                                {
                                                    Image = Image.FromFile(@"other\Swastika.png"),
                                                    Opacity = 65
                                                })

                                                .GaussianSharpen(15)
                                                .Brightness(20)
                                                .Tint(Color.Red)
                                                .Save(outStream);
                                    break;
                            }
                        }

                        CConsole.Write("Saving image", Color.SpringGreen);

                        Save(outStream);
                    }
                }
            } catch (Exception ex)
            {
                CConsole.Write("ERROR: Failed to apply effects to image", Color.Red);
                VerboseExceptionOutput.WriteExep(ex);
            }
        }

        private static byte[] BitmapTobyte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static void Save(Stream stream)
        {
            using (Image image = Image.FromStream(stream))
            {
                image.Save("Image.png", ImageFormat.Png);
            }
        }
    }
}