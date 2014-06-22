using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
        private string constr="Data Source=42.112.29.8:1521/lg;User Id=System;Password=1QAZxsw2;";
        //private int minute = 
        private void btnStart_Click(object sender, EventArgs e)
        {
            StatusChecker statusChecker = new StatusChecker();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 250);
            stateTimer.Change(0, 10000); //1 Minute
        }

         
    }

    class StatusChecker
    {
        int i = 1;
        /// <summary>
        /// Do this when timer check & fire
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            //100 minute
            MessageBox.Show(i.ToString());
            i++;
        }
    }
}
