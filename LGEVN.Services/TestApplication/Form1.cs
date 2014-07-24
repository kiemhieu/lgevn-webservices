using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPR_RESPONSE_WS_EDI_Click(object sender, EventArgs e)
        {
            LGService.MorderChanel chanel = new LGService.MorderChanel();
            LGService.WS_RESP_PARS result = chanel.GET_WS_EDI("EASV0088", "0921200102", "212VNRG10590", null, "20140724", "0902216369", null, null, DateTime.Now.ToString("yyyyMMddHHmmss"));

            if (result != null) MessageBox.Show(result.RESP_MSG);
        }
    }
}
