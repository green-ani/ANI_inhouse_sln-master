using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ani_inhse
{
    public static class AppSetting
    {
        public static string animedConn
        {
            get
            {
                return "server=192.168.0.10;uid=aniani;pwd=ani123456;database=animed; Port=3366; SslMode = none";
            }
        }
        public static string alpineConn { get { return "server=192.168.0.10;uid=aniani;pwd=ani123456;database=alpine; Port=3366; SslMode = none"; } }
        public static string anidemo2Conn { get { return "server=database-server-02.cyplnzjfey2i.ap-east-1.rds.amazonaws.com;uid=anidemo2;pwd=nfc11590;database=anidemo2; Port=3306; SslMode = none"; } }
        public static string ani_developerConn { get { return "server=database-server-02.cyplnzjfey2i.ap-east-1.rds.amazonaws.com;uid=ani_developer;pwd=nfc24033;database=ani_developer; Port=3306; SslMode = none"; } }

        public static string ani_developer2Conn { get { return "server=database-1.cvdmxygtrgja.ap-southeast-1.rds.amazonaws.com;uid=ani_developer2;pwd=nfc24034;database=ani_developer2; Port=3306; SslMode = none"; } }

        public static string forwardlivingConn { get { return "server=10.10.180.5;uid=forwardliving;pwd=nfc35271;database=forwardliving; Port=3366; SslMode = none"; } }
        public static string forwardlivingdemoConn { get { return "server=database-server-01.cyplnzjfey2i.ap-east-1.rds.amazonaws.com;uid=forwardlivingdemo;pwd=nfc24035;database=forwardlivingdemo; Port=3306; SslMode = none"; } }


        public static string nwdConn
        {
            get
            {
                return "Server=elderlyhomedb.ca4fjqhhzwgv.ap-southeast-1.rds.amazonaws.com;port=3306;Database=autoupdate;Uid=ani_autoupdate;Pwd=Nwd55673;CharSet=utf8;";
            }
        }
        public static string App_user { get; set; }
    }
}
