using LGEVN.Services.Implement;
using System.Data.OracleClient;
using System.Web.Services;

namespace LGEVN.Services
{
    /// <summary>
    /// Summary description for LgeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LgeService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool SendSelloutData(TB_SN_SO_WT_MST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_serial_no", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_sellin_date", entity.SELLIN_DATE));
            colllection.Add(new OracleParameter("p_sellout_date", entity.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_wt_start_date", entity.WT_START_DATE));
            colllection.Add(new OracleParameter("p_wt_end_date", entity.WT_END_DATE));
            colllection.Add(new OracleParameter("p_shop_code", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_shop_cell", entity.SHOP_CELL));
            colllection.Add(new OracleParameter("p_sellout_resp_msg", entity.SELLOUT_RESP_MSG));
            colllection.Add(new OracleParameter("p_point", entity.POINT));
            colllection.Add(new OracleParameter("p_amt", entity.AMT));
            colllection.Add(new OracleParameter("p_sellout_resp_type", entity.SELLOUT_RESP_TYPE));
            colllection.Add(new OracleParameter("p_sellout_time", entity.SELLOUT_TIME));
            colllection.Add(new OracleParameter("p_incentive_cfm_flag", entity.INCENTIVE_CFM_FLAG));
            colllection.Add(new OracleParameter("p_incentive_cfm_date", entity.INCENTIVE_CFM_DATE));
            colllection.Add(new OracleParameter("p_model", entity.MODEL));
            colllection.Add(new OracleParameter("p_suffix", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_close_flag", entity.CLOSE_FLAG));
            colllection.Add(new OracleParameter("p_close_period", entity.CLOSE_PERIOD));
            colllection.Add(new OracleParameter("p_sms_yn", entity.SMS_YN));
            colllection.Add(new OracleParameter("p_create_date", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_incentive_cfm_user", entity.INCENTIVE_CFM_USER));
            colllection.Add(new OracleParameter("p_close_user", entity.CLOSE_USER));
            colllection.Add(new OracleParameter("p_incentive_cfm_period", entity.INCENTIVE_CFM_PERIOD));
            colllection.Add(new OracleParameter("p_last_update_date", entity.LAST_UPDATE_DATE));
            colllection.Add(new OracleParameter("p_end_user_cell", entity.END_USER_CELL));
            colllection.Add(new OracleParameter("p_transfer_flag", entity.TRANSFER_FLAG));
            colllection.Add(new OracleParameter("p_transfer_date", entity.TRANSFER_DATE));
            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_MST", colllection);
            return id > -1;
        }
    }
}
