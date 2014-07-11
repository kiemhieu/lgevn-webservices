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
            LGService.WS_RESP_PARS result = chanel.GET_WS_EDI("EASV0088", null, null, null, null, null, null, null, null);

            if (result != null) MessageBox.Show(result.RESP_MSG);
        }
    }
}
