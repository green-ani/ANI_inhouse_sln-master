using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ani_inhse.Dll
{
    public class med_img_dll
    {
        public bool insert_med_img_by_med_code(string med_code, Image img)
        {
            try
            {
                byte[] imgArr = convert_image.imageToByte(img);
                byte[] thum_imgArr = convert_image.imageToByte(convert_image.ThumbNailImage(img,100));
                string sql = string.Format("INSERT INTO med_photo_details(medicine_id, img, thum_img, created_by, created_datetime, valid) values ('{0}', @img, @thum_img, '{1}', now(), 'Y')", 
                    med_code, AppSetting.App_user);
               mysql.excuteSQL(AppSetting.animedConn, sql, new object[] { imgArr, thum_imgArr }, new string[] { "@img", "@thum_img" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        
    }
}
