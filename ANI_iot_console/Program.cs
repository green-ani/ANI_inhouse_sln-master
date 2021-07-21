using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ani_inhse.Lib;

namespace ANI_iot_console
{
    class Program
    {
        static void Main(string[] args)
        {
            CIot ciot = new CIot();
            Timer timer = new Timer();
            timer.Interval = 30000;
            timer.Elapsed += OnTimedEvent;

            try
            {
                //ciot.execute_anideveloper2();
                ciot.execute_forwardlivingdemo();
                //ciot.execute_forwardliving();

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading Message = {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Console will close in 30s.");
                timer.Start();
                Console.ReadLine();
                Console.WriteLine("Press enter to close...");
                timer.Stop();
                Console.ReadLine();
            }
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(1);// exit

            throw new NotImplementedException();
        }
    }
}
