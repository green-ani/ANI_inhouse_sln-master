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
    


    public partial class Frm_med_img_view : Form

{
        public event Action<string> Button1;
    
        public Frm_med_img_view()
        {
            InitializeComponent();
        }

        public void AddImage(Image thisimage)
        {
            pictureBox1.Image = thisimage;
            this.Show();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
