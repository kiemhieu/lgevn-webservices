using System;
using System.Collections.Generic;
using System.Text;

namespace LGEVN.Services.Interface
{
    public interface ISellout
    {
        //string Cid { get; set; }
        //string CustKey { get; set; }
        //string SellDate { get; set; }
        //string SerialNo { get; set; }
        //string Model { get; set; }
        //string CustPhone { get; set; }
        //string CustName { get; set; }
        //string CustAdd { get; set; }
        //string ResqTime { get; set; }
        string SERIAL_NO { get; set; }
        DateTime? SELLIN_DATE { get; set; }
        DateTime? SELLOUT_DATE { get; set; }
        DateTime? WT_START_DATE { get; set; }
        DateTime? WT_END_DATE { get; set; }
        string SHOP_CODE { get; set; }
        string SHOP_CELL { get; set; }
        string SELLOUT_RESP_MSG { get; set; }
        string POINT { get; set; }
        string AMT { get; set; }
        string SELLOUT_RESP_TYPE { get; set; }
        string SELLOUT_TIME { get; set; }
        string INCENTIVE_CFM_FLAG { get; set; }
        string INCENTIVE_CFM_DATE { get; set; }
        string MODEL { get; set; }
        string SUFFIX { get; set; }
        string CLOSE_FLAG { get; set; }
        string CLOSE_PERIOD { get; set; }
        string SMS_YN { get; set; }
        DateTime CREATE_DATE { get; set; }
        string INCENTIVE_CFM_USER { get; set; }
        string CLOSE_USER { get; set; }
        string INCENTIVE_CFM_PERIOD { get; set; }
        DateTime? LAST_UPDATE_DATE { get; set; }
        string END_USER_CELL { get; set; }
        string TRANSFER_FLAG { get; set; }
        DateTime? TRANSFER_DATE { get; set; }

    }
}
