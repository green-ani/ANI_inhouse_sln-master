using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ani_inhse.Model
{
    public class MedThumbnails : Button
    {
        public string Imageuid { get; set; }
        public Image MedImage { get; set; }


        public MedThumbnails(byte[] thisbytemap, string imageuid, byte[] thisimagebytemap)
        {
            Imageuid = imageuid;
            this.Width = 100;
            this.Height = 100;

            this.BackgroundImage = returnImageFromJepgBytes(thisbytemap);
            this.Margin = new Padding(4, 4, 4, 4);
            this.MedImage = returnImageFromJepgBytes(thisimagebytemap);
        }

        public Image returnImageFromJepgBytes(byte[] thisbytes)
        {
            Image returnimage = null;
            returnimage = (Bitmap)((new ImageConverter()).ConvertFrom(thisbytes));

            return returnimage;

        }
    }
}
