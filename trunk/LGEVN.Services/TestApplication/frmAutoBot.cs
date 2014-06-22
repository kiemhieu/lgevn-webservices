﻿using LGEVN.ClientServices;
using System;
using System.Threading;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class frmAutoBot : Form
    {

        public frmAutoBot()
        {
            InitializeComponent();
        }

        //"Data Source=42.112.29.8:1521/lg;User Id=System;Password=1QAZxsw2;";
        private float minute = 0.1f;
        private void btnStart_Click(object sender, EventArgs e)
        {
            StatusChecker statusChecker = new StatusChecker();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 0);
            autoEvent.WaitOne((int)(minute * 60000), false);
            stateTimer.Change(0, (int)(minute * 60000)); // (X) *  1 Minute  
        }
    } 
}