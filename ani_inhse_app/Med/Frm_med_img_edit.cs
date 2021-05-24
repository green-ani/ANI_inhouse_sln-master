using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ani_inhse;
using ani_inhse.Dll;
using ani_inhse.Model;

namespace ani_inhse_app
{
    public partial class Frm_med_img_edit : Form
    {
        med_img_dll imgLib = new med_img_dll();
        public Frm_med_img_edit()
        {
            InitializeComponent();
        }
        public DataTable dgv_med_grid_view(string cond="")
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select a.medicine_code, med_photo_id, img
from animed.med_photo_brief a
left join animed.med_photo_details b on a.medicine_id = b.medicine_id
where b.valid = 'Y'
{0}
order by a.medicine_code", cond);//string.Format("SELECT med_photo_id, img, thum_img, valid FROM med_photo_details where medicine_id = '{0}' and  valid = 'Y'", selected_code);
            return  mysql.excuteSQLToDataTable(AppSetting.animedConn, sql);
        }
        public void dgv_row_insert(DataTable dt)
        {
            dgv_med_img.Rows.Clear();
            dgv_med_img.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            for (int i=0; i<dt.Rows.Count; i++)
            {
                object[] val = new object[dgv_med_img.ColumnCount];
                int k = 0;
                val[k++] = false;
                val[k++] = dt.Rows[i][0].ToString();
                val[k++] = dt.Rows[i][1].ToString();
                byte[] imgbyte = dt.Rows[i].Field<byte[]>("img");
                val[k++] = returnImageFromJepgBytes(imgbyte);
                dgv_med_img.Rows.Add(val);
            }
            
        }
        public Image returnImageFromJepgBytes(byte[] thisbytes)
        {
            Image returnimage = null;
            returnimage = (Bitmap)((new ImageConverter()).ConvertFrom(thisbytes));

            return returnimage;

        }
        public void grid_refresh()
        {
            string cond = string.IsNullOrWhiteSpace(txt_search.Text) ? "" : string.Format(" and a.medicine_code like '%{0}%' ", txt_search.Text);
            dgv_row_insert(dgv_med_grid_view(cond));
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            grid_refresh();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            List<string> med_photo_arr = new List<string>();
            string msg = "";
            for(int i=0; i<dgv_med_img.Rows.Count; i++)
            {
                bool isChk = (dgv_med_img.Rows[i].Cells[0].ValueType == typeof(System.Boolean)&& dgv_med_img.Rows[i].Cells[0].Value!= null) ? (bool) dgv_med_img.Rows[i].Cells[0].Value: false;
                if (isChk == true)
                {
                    med_photo_arr.Add(dgv_med_img.Rows[i].Cells[2].Value.ToString());

                }
            }

            if(med_photo_arr.Count>=1)
            {
                DialogResult dialogResult = MessageBox.Show("Warning", "Are you sure to delete?", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    imgLib.delete_med_img(med_photo_arr);
                    grid_refresh();
                }
            }
        }

        private void dgv_med_img_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv_med_img != null && dgv_med_img.Rows.Count >0)
            {
                int rowIdx = e.RowIndex;
                if(dgv_med_img.Rows[rowIdx].Cells[0].Value == null|| dgv_med_img.Rows[rowIdx].Cells[0].ValueType != typeof(System.Boolean))
                {
                    dgv_med_img.Rows[rowIdx].Cells[0].Value = false;
                }
                else
                dgv_med_img.Rows[rowIdx].Cells[0].Value = !((bool)dgv_med_img.Rows[rowIdx].Cells[0].Value);
            }
        }
    }
}
