using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ani_inhse_app
{
    public partial class Frm_med_img_cropping : Form
    {
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        Frm_med_img_photo parentform;

        public string pill_imprint_str { get; set; }
        public Frm_med_img_cropping(Frm_med_img_photo imagingform)
        {
            InitializeComponent();
            parentform = imagingform;
            this.FormBorderStyle = FormBorderStyle.None;
            this.btn_accept.Click += new System.EventHandler(this.ConfirmButton_Click);
            this.btn_cancel.Click += new System.EventHandler(this.Reject_Click);
        }
        public class UpdateEventArgs : EventArgs
        {
            public bool imageaccept { get; set; }
        }
        public void set_crop_img(Image image)
        {
            this.pictureBox_confirm.Image = image;
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //Button thisbutton = (Button)sender;
            this.DialogResult = DialogResult.OK;
            pill_imprint_str = txt_pill_imprint.Text.Trim();

            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void Reject_Click(object sender, EventArgs e)
        {
            //Button thisbutton = (Button)sender;
            this.DialogResult = DialogResult.Cancel;


            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
    }
}
