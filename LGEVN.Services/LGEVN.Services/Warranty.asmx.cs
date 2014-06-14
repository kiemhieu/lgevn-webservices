using LGEVN.Services.Implement;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Web;
using System.Web.Services;
using System.Linq;
namespace LGEVN.Services
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public bool SendSelloutData(Sellout sellout)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_serial_no", sellout.SERIAL_NO));
            colllection.Add(new OracleParameter("p_sellin_date", sellout.SELLIN_DATE));
            colllection.Add(new OracleParameter("p_sellout_date", sellout.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_wt_start_date", sellout.WT_START_DATE));
            colllection.Add(new OracleParameter("p_wt_end_date", sellout.WT_END_DATE));
            colllection.Add(new OracleParameter("p_shop_code", sellout.SHOP_CODE));
            colllection.Add(new OracleParameter("p_shop_cell", sellout.SHOP_CELL));
            colllection.Add(new OracleParameter("p_sellout_resp_msg", sellout.SELLOUT_RESP_MSG));
            colllection.Add(new OracleParameter("p_point", sellout.POINT));
            colllection.Add(new OracleParameter("p_amt", sellout.AMT));
            colllection.Add(new OracleParameter("p_sellout_resp_type", sellout.SELLOUT_RESP_TYPE));
            colllection.Add(new OracleParameter("p_sellout_time", sellout.SELLOUT_TIME));
            colllection.Add(new OracleParameter("p_incentive_cfm_flag", sellout.INCENTIVE_CFM_FLAG));
            colllection.Add(new OracleParameter("p_incentive_cfm_date", sellout.INCENTIVE_CFM_DATE));
            colllection.Add(new OracleParameter("p_model", sellout.MODEL));
            colllection.Add(new OracleParameter("p_suffix", sellout.SUFFIX));
            colllection.Add(new OracleParameter("p_close_flag", sellout.CLOSE_FLAG));
            colllection.Add(new OracleParameter("p_close_period", sellout.CLOSE_PERIOD));
            colllection.Add(new OracleParameter("p_sms_yn", sellout.SMS_YN));
            colllection.Add(new OracleParameter("p_create_date", sellout.CREATE_DATE));
            colllection.Add(new OracleParameter("p_incentive_cfm_user", sellout.INCENTIVE_CFM_USER));
            colllection.Add(new OracleParameter("p_close_user", sellout.CLOSE_USER));
            colllection.Add(new OracleParameter("p_incentive_cfm_period", sellout.INCENTIVE_CFM_PERIOD));
            colllection.Add(new OracleParameter("p_last_update_date", sellout.LAST_UPDATE_DATE));
            colllection.Add(new OracleParameter("p_end_user_cell", sellout.END_USER_CELL));
            colllection.Add(new OracleParameter("p_transfer_flag", sellout.TRANSFER_FLAG));
            colllection.Add(new OracleParameter("p_transfer_date", sellout.TRANSFER_DATE));
            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_MST", colllection);
            return id > -1;
        }

        [WebMethod]
        public Sellout GetSelloutData(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<Sellout>("PKG_WEBSERVICE.GET_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }
    }
}