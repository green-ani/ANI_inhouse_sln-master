using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ani_inhse.Lib;

namespace ANI_iot_console
{
    class Program
    {
        static void Main(string[] args)
        {
            CIot ciot = new CIot();

            try
            {
                //ciot.execute_anideveloper2();
                ciot.execute_forwardlivingdemo();

            }
            finally
            {
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
        }
    }
}
