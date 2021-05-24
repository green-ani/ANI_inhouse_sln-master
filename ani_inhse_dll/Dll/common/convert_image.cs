using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ani_inhse.Dll
{
    public static class convert_image
    {
        public static byte[] bitmapToByte(Bitmap thisbitmap)
        {
            byte[] imagedata = default(byte[]);

            using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())

            {
                //save to stream.

                thisbitmap.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Bmp);

                //the byte array

                imagedata = sampleStream.ToArray();
            }
            return imagedata;
        }

        public static byte[] imageToByte(Image img)//@
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static Image ThumbNailImage(Image originalimage, int thumbnailsize)
        {
            Image destimage = new Bitmap(thumbnailsize, thumbnailsize);

            //create brush and Image 
            var brush = new SolidBrush(Color.White);

            Graphics graph = Graphics.FromImage(destimage);
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            graph.FillRectangle(brush, new RectangleF(0, 0, thumbnailsize, thumbnailsize));
            graph.DrawImage(originalimage, new Rectangle(0, 0, thumbnailsize, thumbnailsize));

            return destimage;
        }
    }
}
