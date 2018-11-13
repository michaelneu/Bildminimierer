using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Bildminimierer.Util
{
    class Image
    {
        private const double threshold = 0.1;
        public static void Resize(FileInfo source, FileInfo destination, int filesize)
        {
            const double decrease = 0.05;
            double factor = 1;
            long currentSize = 0;

            // convert kB to B
            filesize *= 1024;

            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            using (System.Drawing.Image image = Bitmap.FromFile(source.FullName))
            {
                Size originalSize = image.Size;

                while (true)
                {
                    int width = (int)(originalSize.Width * factor),
                        height = (int)(originalSize.Height * factor);

                    Size size = new Size(width, height);
                    factor -= decrease;

                    using (Bitmap resized = new Bitmap(image, size))
                    {
                        using (EncoderParameters eps = new EncoderParameters(1))
                        {
                            long quality = (long)(factor * 100);
                            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                            using (MemoryStream stream = new MemoryStream())
                            {
                                resized.Save(stream, ici, eps);
                                currentSize = stream.Length;

                                if (currentSize <= filesize || factor < Image.threshold)
                                {
                                    byte[] data = stream.ToArray();
                                    stream.Close();

                                    File.WriteAllBytes(destination.FullName, data);
                                    Array.Clear(data, 0, data.Length);

                                    break;
                                }
                                else
                                {
                                    stream.Close();
                                }
                            }
                        }
                    }
                    
                    GC.Collect();
                }
            }

            GC.Collect();
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            foreach (var item in ImageCodecInfo.GetImageEncoders())
            {
                if (item.MimeType == mimeType)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
