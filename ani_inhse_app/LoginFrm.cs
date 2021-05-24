using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ani_inhse.Lib;
using ani_inhse.Dll;
using ani_inhse;
namespace ani_inhse_app
{
    public partial class LoginFrm : Form
    {
        MainFrm frm;
        public LoginFrm(MainFrm parent)
        {
            frm = parent;
            InitializeComponent();
        }
        public void get_image()
            {
                string sql = "SELECT * FROM loginuser where LoginUserName = '100051'";
            var ds = mysql.GetDataset(sql, AppSetting.nwdConn );
            }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            string loginname = txt_login_name.Text.Trim();
            string loginpw = txt_login_pw.Text.Trim();
            Encription encr = new Encription("ANIEncryptionLib");
            string str = encr.encrypt("fe80::920e:b3ff:fe14:83b2%eth0");
            string str2 = encr.decrypt("733d23a9efd39f57a14071a969e615cd7528797f233147f15991dd08b30f2914");
            string en_str = encr.encrypt("anidemo");
            bool valid = new LoginDll().check_user_valid(loginname, encr.encrypt(loginpw));
            if (valid)
            {
                ani_inhse.AppSetting.App_user = loginname;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("User Name / Password is wrong, please try again");
                this.btn_clr_Click(this.btn_clr, null);
            }
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            txt_login_name.Text = "";
            txt_login_pw.Text = "";
        }

        private void txt_login_pw_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_submit.PerformClick();
            }
        }
    }
}
