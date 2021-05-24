using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ani_inhse.Lib;
namespace ani_inhse_app
{
    public partial class Frm_hkidToAccNum : Form
    {
        public Frm_hkidToAccNum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_hkid.Text.Length <= 0) return;
            List<string> list = new List<string>(Regex.Split(txt_hkid.Text.Trim(), Environment.NewLine));
            List<string> accNumList = new List<string>();

            foreach(string id in list)
            {
                CHKid_Cc thisid = new CHKid_Cc(id.ToUpper());
                accNumList.Add(thisid.AcctNr);
            }
            txt_acc_num.Text = string.Join(Environment.NewLine, accNumList);
        }
    }
}
