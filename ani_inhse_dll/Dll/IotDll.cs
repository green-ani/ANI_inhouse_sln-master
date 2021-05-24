using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ani_inhse.Dll
{
    class IotDll
    {
        public enum enum_iot_type
        {
            None = 0,
            Kitsense = 100001,
            Kuju = 100002,
            Woofaa = 100003
        }

        public static string get_device_info_str(enum_iot_type iot_type = enum_iot_type.None)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select record_id,system_id, device_name ");
            sql.Append(" from company_iot_device kit ");
            sql.Append(" Where valid = 'Y' ");
            if(iot_type != enum_iot_type.None)
            {
                sql.AppendFormat(" and iot_id = '{0}' ", (int)iot_type);
            }
            sql.Append(" ; ");
            return sql.ToString();
        }

        public static string get_kitsense_datetime_str()
        {
            DateTime dt_start = DateTime.Today;
            DateTime dt_end = dt_start.AddDays(1);

            StringBuilder sql = new StringBuilder();

            sql.Append(" select d.device_name, kit.record_datetime ");
            sql.Append(" from company_iot_kitsense kit ");
            sql.Append(" left Join company_iot_device d on kit.device_id = d.record_id and d.valid = 'Y' ");
            sql.AppendFormat(" Where kit.valid = 'Y'  and kit.record_datetime between '{0}' and '{1}' ", dt_start.ToString("yyyy-MM-dd H:mm:ss"), dt_end.ToString("yyyy-MM-dd H:mm:ss"));
            sql.AppendFormat(" order by kit.record_datetime desc ; ");

            return sql.ToString();
        }

        public static string get_insert_kitsense_record_str(String[] vals)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into company_iot_kitsense (record_id, record_datetime, device_id, temperature, humidity ) ");
            sql.Append(" values ('{0}', '{1}', '{2}', '{3}', '{4}' ) ; ");

            return string.Format(sql.ToString(), vals);
        }


        public static string get_insert_kuju_record_str(String[] vals)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into company_iot_kuju (record_id, record_datetime, device_id, power_value ) ");
            sql.Append(" values ('{0}', '{1}', '{2}', '{3}' ) ; ");

            return string.Format(sql.ToString(), vals);
        }
        //string[] vals = new string[] { new_id, local_dt.ToString("yyyy-MM-dd H:mm:ss"), device_id, pm2p5, co2, tvoc, humidity, temperature, pm10 };
        public static string get_insert_woofaa_record_str(String[] vals)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into company_iot_woofaa (record_id, record_datetime, device_id,  pm2p5, co2, tvoc, humidity, temperature, pm10 ) ");
            sql.Append(" values ('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}'  ) ; ");

            return string.Format(sql.ToString(), vals);
        }
    }
}
