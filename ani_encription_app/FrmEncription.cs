using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ani_inhse.Dll;
using ani_inhse.Lib;
using ani_inhse.Model;

namespace ani_encription_app
{
    public partial class FrmEncription : Form
    {
        public FrmEncription()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Encription encr = string.IsNullOrWhiteSpace(txt_key.Text) 
                ? new Encription("ANIEncryptionLib")
                : new Encription(txt_key.Text.Trim()) ;
            if (string.IsNullOrWhiteSpace(txt_decrypt.Text.Trim()))
            {
                txt_decrypt.Text = encr.encrypt(txt_encrypt.Text.Trim());
            }
            else if(string.IsNullOrWhiteSpace(txt_encrypt.Text.Trim()))
            {
                txt_encrypt.Text = encr.decrypt(txt_decrypt.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_key.Clear();
            txt_encrypt.Clear();
            txt_decrypt.Clear();
        }
    }
}
