using LGEVN.ClientServices;
using LGEVN.Services.Implement.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Text;
using System.Linq;
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
        private string constr = "Data Source=123.30.208.199:1521/KTNET2E;User Id=TEST_NET2E;Password=vdcnet2e_123;";
        //"Data Source=42.112.29.8:1521/lg;User Id=System;Password=1QAZxsw2;";
        private int minute = 10;
        private void btnStart_Click(object sender, EventArgs e)
        {
            StatusChecker statusChecker = new StatusChecker();
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 250);
            //autoEvent.WaitOne(10000, true);
            stateTimer.Change(0, minute * 60000); //1 Minute  
            //autoEvent.Dispose();
        }


    }

    public class StatusChecker
    {
        int i = 1;
        /// <summary>
        /// Do this when timer check & fire
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            //100 minute
            //1. Get All uncheck Client
            var tests = OracleDataHelper.GetNoTransfer<HIEUNK_TEST>("HIEUNK_TEST", "FLAG");
            //OracleDataHelper.ExecuteProcedure<HIEUNK_TEST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST",
            //new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor});
            if (tests == null && tests.Count() <= 0) return;

            i++;

            foreach (var item in tests)
            {
                //2. Insert to server (with checked existing)
                OracleParameterCollection colllection = new OracleParameterCollection();
                colllection.Add(new OracleParameter("p_serial_no", item.ID));
                colllection.Add(new OracleParameter("p_sellin_date", item.NAME));
                colllection.Add(new OracleParameter("p_sellout_date", item.DESCRIPTION));
                colllection.Add(new OracleParameter("p_wt_start_date", item.FLAG));
                //int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_HIEUNK_TEST", colllection);


                //3. Update flag to Client
                OracleDataHelper.ExecuteFlag<HIEUNK_TEST>(item, "HIEUNK_TEST", "FLAG", "ID");
            }
        }
    }
}
