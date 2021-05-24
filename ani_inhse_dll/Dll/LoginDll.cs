using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ani_inhse;
namespace ani_inhse.Dll
{
    public class LoginDll
    {
        public bool check_user_valid(string user, string pw)
        {
            string sql = string.Format("select 1 from user_login where user_password = '{0}' and user_id = '{1}';", pw, user);
            if (mysql.excuteSQLToInt32(ani_inhse.AppSetting.anidemo2Conn, sql) == 1)
                return true;
            else
                return false;

        }
    }
}
