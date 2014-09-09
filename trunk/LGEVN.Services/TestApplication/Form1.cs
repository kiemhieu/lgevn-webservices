using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
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
            string connectionString = "Data Source=42.112.29.8:1521/VNPCSOM;User Id=vnwtsom;Password=vnwtsom;";


            string filePath = @"D:\DESKTOP&DOWNLOAD\TB_SN_SO_WT_MST\TB_SN_SO_WT_MST_DATA_TABLE.sql";
            string filePath2 = @"D:\DESKTOP&DOWNLOAD\TB_SN_SO_WT_MST\TB_SN_SO_WT_MST_DATA_TABLE";
            if (!string.IsNullOrEmpty(filePath))
            {
                List<string> list_text = new List<string>();
                int count = 0, index = 0;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line;
                    string oldLine = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        index++;
                        line = line.Replace("VNWTSOM.", "");
                        if (line[line.Length - 1] != ';')
                        {
                            oldLine = line;
                            continue;
                        }

                        string sql_text = oldLine + line;
                        oldLine = string.Empty;
                        list_text.Add(sql_text);
                        if (index % 100000 == 0)
                        {
                            count++;
                            File.WriteAllLines(filePath2 + "_" + count + ".sql", list_text);
                            list_text.Clear();
                            lblMsg.Text = count.ToString();
                            Application.DoEvents();
                        }
                    }


                    //Last list
                    if (list_text.Count > 0)
                    {
                        count++;
                        File.WriteAllLines(filePath2 + "_" + count + ".sql", list_text);
                        list_text.Clear();
                        Application.DoEvents();
                    }
                }

                MessageBox.Show(count.ToString());
            }
        }
    }
}
