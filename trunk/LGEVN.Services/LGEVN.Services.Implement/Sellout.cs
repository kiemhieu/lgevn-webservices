using LGEVN.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LGEVN.Services.Implement
{
    public sealed class Sellout:ISellout
    {
        //public string Cid { get; set; }
        //public string CustKey { get; set; }
        //public string SellDate { get; set; }
        //public string SerialNo { get; set; }
        //public string Model { get; set; }
        //public string CustPhone { get; set; }
        //public string CustName { get; set; }
        //public string CustAdd { get; set; }
        //public string ResqTime { get; set; }

        public string SERIAL_NO { get; set; }
        public DateTime? SELLIN_DATE { get; set; }
        public DateTime? SELLOUT_DATE { get; set; }
        public DateTime? WT_START_DATE { get; set; }
        public DateTime? WT_END_DATE { get; set; }
        public string SHOP_CODE { get; set; }
        public string SHOP_CELL { get; set; }
        public string SELLOUT_RESP_MSG { get; set; }
        public string POINT { get; set; }
        public string AMT { get; set; }
        public string SELLOUT_RESP_TYPE { get; set; }
        public string SELLOUT_TIME { get; set; }
        public string INCENTIVE_CFM_FLAG { get; set; }
        public DateTime? INCENTIVE_CFM_DATE { get; set; }
        public string MODEL { get; set; }
        public string SUFFIX { get; set; }
        public string CLOSE_FLAG { get; set; }
        public string CLOSE_PERIOD { get; set; }
        public string SMS_YN { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string INCENTIVE_CFM_USER { get; set; }
        public string CLOSE_USER { get; set; }
        public string INCENTIVE_CFM_PERIOD { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public string END_USER_CELL { get; set; }
        public string TRANSFER_FLAG { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
    }
}
