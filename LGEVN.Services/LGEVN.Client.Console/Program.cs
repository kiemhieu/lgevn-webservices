using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LGEVN.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("********************************************************************************");
            System.Console.WriteLine("*********************** BEGIN SYNCHRONIZE APPLICATION **************************");
            System.Console.WriteLine("\n\n\n\n\n\n");
            System.Console.WriteLine("********************************************************************************");
            System.Console.WriteLine("***********************  BEGIN SYNCHRONIZE TB_CM_MRP  **************************");


            StatusChecker statusChecker = new StatusChecker();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 0);
            autoEvent.WaitOne((int)(minute * 60000), false);
            stateTimer.Change(0, (int)(minute * 60000)); // (X) *  1 Minute  
            System.Console.ReadKey();
        }
    }
}
