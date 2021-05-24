using ani_inhse.Dll;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ani_inhse.Lib
{
    public class CIot
    {

        IotDll iot_dll;
         string appSettingStr;

        private const string kitsense_url = "https://kitsense.knet.hk/api/getsensor";
        private const string kuju_url = "https://ssl.kujucloud.com/apps";
        private const string woofaa_url = "https://iot.woofaa.com/api/iaqrecord?device=";


        public void execute_anideveloper2()
        {
            iot_dll = new IotDll();
            appSettingStr = AppSetting.ani_developer2Conn;
            string login_str_kitsense = "username=forwardliving&password=21550860";
            string login_str_kuju = "{\"username\":\"futeielderlyhome\",\"password\":\"e10adc3949ba59abbe56e057f20f883e\", \"type\":\"token\"}";
            string home_name_kitsense = "Forward Living (Culture Homes)";

            get_iot_kitsense(login_str_kitsense, home_name_kitsense);
            get_iot_kuju(login_str_kuju);
            get_iot_woofaa();
        }

        public void execute_forwardlivingdemo()
        {
            iot_dll = new IotDll();
            appSettingStr = AppSetting.forwardlivingdemoConn;
            string login_str_kitsense = "username=forwardliving&password=21550860";
            string login_str_kuju = "{\"username\":\"futeielderlyhome\",\"password\":\"e10adc3949ba59abbe56e057f20f883e\", \"type\":\"token\"}";
            string home_name_kitsense = "Forward Living (Culture Homes)";

            Console.WriteLine("Forwardlivingdemo start");
            get_iot_kitsense(login_str_kitsense, home_name_kitsense);
            get_iot_kuju(login_str_kuju);
            get_iot_woofaa();
            Console.WriteLine("Forwardlivingdemo end");
        }

        public void execute_forwardliving()
        {
            iot_dll = new IotDll();
            appSettingStr = AppSetting.forwardlivingConn;
            string login_str_kitsense = "username=forwardliving&password=21550860";
            string login_str_kuju = "{\"username\":\"futeielderlyhome\",\"password\":\"e10adc3949ba59abbe56e057f20f883e\", \"type\":\"token\"}";
            string home_name_kitsense = "Forward Living (Culture Homes)";

            Console.WriteLine("Forwardliving start");
            get_iot_kitsense(login_str_kitsense, home_name_kitsense);
            get_iot_kuju(login_str_kuju);
            get_iot_woofaa();
            Console.WriteLine("Forwardliving end");
        }

        private void get_iot_kitsense(string login_str, string home_name)
        {
            var client = new RestClient(kitsense_url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "96df520c-747a-0fc2-c7fe-a420aa1f2ecf");
            request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("authorization", "Basic YW5pOjEyMzQ1Ng==");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            //request.AddParameter("application/x-www-form-urlencoded", "username=forwardliving&password=21550860", ParameterType.RequestBody);
            request.AddParameter("application/x-www-form-urlencoded", login_str, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic json = SimpleJson.DeserializeObject(response.Content);
            //json
            string jsonstr = "{" + string.Format("'Table1':{0}", Convert.ToString(json[home_name])) + "}";


            DataSet ds = mysql.GetDataset(IotDll.get_device_info_str(IotDll.enum_iot_type.Kitsense), appSettingStr);
            DataSet date_ds = mysql.GetDataset(IotDll.get_kitsense_datetime_str(), appSettingStr);
            //DataSet get_ds = JsonConvert.DeserializeObject<DataSet>(jsonstr);

            dynamic json_arr = json[0];

            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < json_arr.Count; i++)
                {
                    string device_name = json_arr[i].name;
                    string in_dt_str = json_arr[i].time;
                    string device_id = "";
                    string temperature = Convert.ToString( json_arr[i].temperature);
                    string humidity = Convert.ToString(json_arr[i].humidity);

                    //in_dt_str = (in_dt_str == "No Record") ? "" : in_dt_str;
                    temperature = (temperature == "No Record") ? "" : temperature;
                    humidity = (humidity == "No Record") ? "" : humidity;

                    if (in_dt_str != "No Record")
                    {
                        DateTime in_dt = Convert.ToDateTime(in_dt_str);

                        //in_dt
                        bool is_valid_device = false;
                        bool is_new_record = true;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            if (device_name == ds.Tables[0].Rows[j]["device_name"].ToString())
                            {
                                is_valid_device = true;
                                device_id = ds.Tables[0].Rows[j]["record_id"].ToString();
                                break;
                            }
                        }
                        if (is_valid_device)
                        {
                            for (int k = 0; k < date_ds.Tables[0].Rows.Count; k++)
                            {
                                if (device_name == date_ds.Tables[0].Rows[k]["device_name"].ToString())
                                {

                                    string dt_str = date_ds.Tables[0].Rows[k]["record_datetime"].ToString();
                                    DateTime dt = Convert.ToDateTime(dt_str);

                                    if (in_dt.ToString().CompareTo(dt.ToString()) == 0)
                                    {
                                        is_new_record = false;
                                        break;
                                    }
                                }

                            }

                            if (is_new_record)
                            {
                                string new_id = mysql.Get_mysql_database_MaxID(appSettingStr, "company_iot_kitsense", "record_id");
                                string[] vals = new string[] { new_id, in_dt.ToString("yyyy-MM-dd H:mm:ss"), device_id, temperature, humidity };
                                mysql.excuteSQL(appSettingStr, IotDll.get_insert_kitsense_record_str(vals));
                                Console.WriteLine("Kitsense record inserted. (record id:"+ new_id+")");
                            }
                        }
                    }
                }
                
            }
            //Console.WriteLine("Kitsense Result : " + response.Content);
        }

        private void get_iot_kuju(string login_str)
        {
            string kuju_token = "";
            bool is_valid_device = false;

            

            var client = new RestClient(kuju_url + "/user_token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", login_str, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);


            dynamic json_token = SimpleJson.DeserializeObject(response.Content);

            if(json_token.result == null || (string)json_token.result != "1")
            {
                Console.WriteLine("Calling Kuju token API fail.");
                return;
            }

            kuju_token = json_token.info.token;
            string token_str = "{\"token\":\"" + kuju_token + "\", \"type\":\"device_list\"}";
            var client2 = new RestClient(kuju_url + "/get_info");
            client2.Timeout = -1;
            var request2 = new RestRequest(Method.POST);
            request2.AddHeader("Content-Type", "application/json");
            request2.AddParameter("application/json", token_str, ParameterType.RequestBody);
            IRestResponse response2 = client2.Execute(request2);
            //Console.WriteLine(response2.Content);

            dynamic json_getdata = SimpleJson.DeserializeObject(response2.Content);

            if(json_getdata.result == null && (string)json_getdata.result!= "1")
            {
                Console.WriteLine("Calling Kuju getdata API fail.");
                return;
            }
            string data_str = "{"+string.Format("'Table1':{0}", Convert.ToString(json_getdata.info)) +"}";

            DataSet ds = mysql.GetDataset( IotDll.get_device_info_str(IotDll.enum_iot_type.Kuju), appSettingStr);
            DataSet get_ds = JsonConvert.DeserializeObject<DataSet>(data_str);
            if (get_ds != null && get_ds.Tables.Count > 0 && ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < get_ds.Tables[0].Rows.Count; i++)
                {
                    string gateway_sn = get_ds.Tables[0].Rows[i]["gateway_sn"].ToString();
                    string system_id = get_ds.Tables[0].Rows[i]["system_id"].ToString();
                    string device_id = "";
                    string power_value = "";
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (ds.Tables[0].Rows[j]["system_id"].ToString() == string.Format("{0}-{1}", gateway_sn, system_id))
                        {
                            is_valid_device = true;
                            device_id = ds.Tables[0].Rows[j]["record_id"].ToString();
                            power_value = get_ds.Tables[0].Rows[i]["value"].ToString();
                            break;
                        }
                    }
                    if (is_valid_device)
                    {
                        DateTime dt_now = DateTime.Now;

                        string new_id = mysql.Get_mysql_database_MaxID(appSettingStr, "company_iot_kuju", "record_id");
                        string[] vals = new string[] { new_id, dt_now.ToString("yyyy-MM-dd H:mm:ss"), device_id, power_value};
                        mysql.excuteSQL(appSettingStr, IotDll.get_insert_kuju_record_str(vals));
                        Console.WriteLine("Kuju record inserted. (record id:" + new_id + ")");
                    }
                }
            }
        }


        private void get_iot_woofaa()
        {
            DataSet ds = mysql.GetDataset(IotDll.get_device_info_str(IotDll.enum_iot_type.Woofaa), appSettingStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string device_name = row["device_name"].ToString();

                    var client = new RestClient(woofaa_url + device_name);
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);

                    dynamic json = SimpleJson.DeserializeObject(response.Content);
                    try
                    {
                            if (json.result.device == device_name)
                            {
                                string device_id = row["record_id"].ToString();
                            string pm2p5 = json.result.pm2p5;
                                string co2 = json.result.co2;
                            string tvoc = json.result.tvoc;
                            string humidity = json.result.humidity;
                            string temperature = json.result.temperature;
                            string pm10 = json.result.pm10;


                            DateTime utc_dt = DateTime.Parse(Convert.ToString(json.result.date_created));
                                DateTime local_dt = utc_dt.ToLocalTime();

                                string new_id = mysql.Get_mysql_database_MaxID(appSettingStr, "company_iot_woofaa", "record_id");
                                string[] vals = new string[] { new_id, local_dt.ToString("yyyy-MM-dd H:mm:ss"), device_id, pm2p5, co2, tvoc, humidity, temperature, pm10 };
                                mysql.excuteSQL(appSettingStr, IotDll.get_insert_woofaa_record_str(vals));

                                Console.WriteLine("Woofaa record inserted. (record id:" + new_id + ")");
                            }
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


            }
            //Console.WriteLine("Woofaa Result : " + response.Content);
        }
    }
}
