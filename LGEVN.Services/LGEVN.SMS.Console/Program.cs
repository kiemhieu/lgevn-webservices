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
            System.Console.WriteLine("---------------------- BEGIN SMS CONSOLE APPLICATION ----------------------");
            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("\n\n");

            // Initial value of the timer.
            var _minutechkst = ConfigurationManager.AppSettings["minutesCk"];
            decimal _minutechk = 0;
            decimal.TryParse(_minutechkst, out _minutechk);
            if (_minutechk == 0) _minutechk = 1;

            SendSMS statusChecker = new SendSMS();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckSMSStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 0);
            autoEvent.WaitOne((int)(_minutechk * 60000), false); // (X) *  1 Minute  
            stateTimer.Change(0, (int)(_minutechk * 60000));

            System.Console.ReadKey();
        }
    }

    //class Program
    //{
    //    static Random rand = new Random();
    //    static void Main(string[] args)
    //    {
    //        // Wait for all tasks to complete.
    //        DateTime time0 = DateTime.Now;
    //        Task[] tasks = new Task[1000];
    //        for (int i = 0; i < 1000; i++)
    //        {
    //            int x = i;
    //            tasks[x] = Task.Factory.StartNew(() => DoSomeWork(x));
    //        }
    //        Task.WaitAll(tasks);
    //        DateTime time2 = DateTime.Now;
    //        var a =  time2 - time0;
    //        System.Console.WriteLine("Used {0} seconds for the process", a.TotalSeconds);
    //        System.Console.ReadKey();
    //    }


    //    private static void DoSomeWork(int val)
    //    {
    //        // Pretend to do something.
    //        System.Console.WriteLine(val.ToString());
    //        Thread.Sleep(1000);
    //    }
    //}
}
