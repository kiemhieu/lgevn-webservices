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

        private void btnAddSellOut_Click(object sender, EventArgs e)
        {
            LGServices.Service1 ser = new LGServices.Service1();
            LGServices.Sellout sellout = new LGServices.Sellout
            {
                AMT = p_amt.Text,
                CLOSE_FLAG = p_close_flag.Text,
                CLOSE_PERIOD = p_close_period.Text,
                CLOSE_USER = p_close_user.Text,
                CREATE_DATE = DateTime.Now,//p_create_date.Text,
                END_USER_CELL = p_end_user_cell.Text,
                INCENTIVE_CFM_DATE =  DateTime.Now,//p_incentive_cfm_date.Text,
                INCENTIVE_CFM_FLAG = p_incentive_cfm_flag.Text ,
                INCENTIVE_CFM_PERIOD = p_incentive_cfm_period.Text,
                INCENTIVE_CFM_USER = p_incentive_cfm_user.Text ,
                LAST_UPDATE_DATE = DateTime.Now,//p_last_update_date.Text,
                MODEL = p_model.Text,
                POINT = p_point.Text,
                SELLIN_DATE = DateTime.Now,//p_sellin_date.Text,
                SELLOUT_DATE = DateTime.Now,//p_sellout_date.Text,
                SELLOUT_RESP_MSG = p_sellout_resp_msg.Text,
                SELLOUT_RESP_TYPE = p_sellout_resp_type.Text,
                SELLOUT_TIME = p_sellout_time.Text,
                SERIAL_NO = p_serial_no.Text ,
                SHOP_CELL = p_shop_cell.Text,
                SHOP_CODE = p_shop_code.Text,
                SMS_YN = p_sms_yn.Text,
                SUFFIX = p_suffix.Text,
                TRANSFER_DATE = DateTime.Now,//p_transfer_date.Text,
                TRANSFER_FLAG = p_transfer_flag.Text,
                WT_END_DATE =DateTime.Now,//p_wt_end_date.Text,
                WT_START_DATE =DateTime.Now,//p_wt_start_date.Text
            };
            ser.SendSelloutData(sellout);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LGServices.Service1 ser = new LGServices.Service1();
            LGServices.Sellout sellout = ser.GetSelloutData("1", "1");
            MessageBox.Show(sellout == null ? "" : sellout.CREATE_DATE.ToShortDateString());
        }
    }
}
