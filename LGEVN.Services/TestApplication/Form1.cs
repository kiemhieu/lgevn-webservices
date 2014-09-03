﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            //LGService.WS_RESP_PARS result = chanel.GET_WS_EDI("EASV0088", "0921200102", "212VNRG10590", null, "20140724", "0902216369", null, null, DateTime.Now.ToString("yyyyMMddHHmmss"));
            LGService.WS_RESP_PARS result1 = chanel.GET_WS_EDI("EASV0859", "3906643", "403VNGT0U879", "32LB582D", "20140830", "0984366755", "Công Ty TNHH Thiết Bị Điện ECO Minh Quân", "26 Lý Thường Kiệt, Phường Đức Nghĩa, TP Phan Thiết, Tỉnh Bình Thuận", DateTime.Now.ToString("yyyyMMddHHmmss"));

            if (result1 != null) MessageBox.Show(result1.RESP_MSG);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\DESKTOP&DOWNLOAD\TB_SN_RDC_HIST.sql"; 
            if (!string.IsNullOrEmpty(filePath))
            {
                int count = 0;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.ToUpper().StartsWith("INSERT INTO"))
                        {
                            count++;
                        }
                        //FormatData(line);
                    }
                }
                MessageBox.Show(count.ToString());
            }
        }
    }
}
