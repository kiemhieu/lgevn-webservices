using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LGEVN.SMS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("---------------------- BEGIN SYNCHRONIZE APPLICATION ----------------------");
            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("\n\n");


            SendSMS statusChecker = new SendSMS();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckSMSStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 0);
            autoEvent.WaitOne((int)(5 * 60000), false);
            stateTimer.Change(0, (int)(5 * 60000)); // (X) *  1 Minute  
            System.Console.ReadKey();
        }


        static void Main2(string[] args)
        {

           
        }
    }
}
