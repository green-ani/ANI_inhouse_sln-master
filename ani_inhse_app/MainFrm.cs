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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            this.Load += MainFrm_Load;
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            load_login();
        }
        private bool load_login()
        {
            LoginFrm login = new LoginFrm(this);
            DialogResult dialog = login.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                return true;
            }
            else 
            {
                Application.Exit();
                return false;
            }
        }

        private void medicinePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem btn = (ToolStripItem)sender;
            string tagStr = btn.Tag != null ? btn.Tag.ToString() : "";
            switch (tagStr)
            {
                case "med.take_photo":
                        Frm_med_img_photo med_photo = new Frm_med_img_photo();
                        med_photo.ShowDialog();

                    break;
                case "med.photo_grid":
                    Frm_med_img_edit med_edit = new Frm_med_img_edit();
                    med_edit.ShowDialog();
                    break;
            }

        }

        private void convertAccountNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_hkidToAccNum hkidConvert = new Frm_hkidToAccNum();
            hkidConvert.ShowDialog();
        }
    }
}
