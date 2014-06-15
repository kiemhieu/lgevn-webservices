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

        // ===========================================================TB_APP_ERROR=========================================================
        [WebMethod]
        public bool INSERT_SAPP_ERROR(TB_APP_ERROR entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_APP_ERROR", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_BILLTO_INF=====================================================
        [WebMethod]
        public bool INSERT_SCM_BILLTO_INF(TB_CM_BILLTO_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_BILLTO_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_MODEL_CAT======================================================
        [WebMethod]
        public bool INSERT_SCM_MODEL_CAT(TB_CM_MODEL_CAT entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_MODEL_CAT", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHIPTO_INF=====================================================
        [WebMethod]
        public bool INSERT_SCM_SHIPTO_INF(TB_CM_SHIPTO_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHIPTO_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHOP_BILLTO====================================================
        [WebMethod]
        public bool INSERT_SCM_SHOP_BILLTO(TB_CM_SHOP_BILLTO entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHOP_BILLTO", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHOP_INF=======================================================
        [WebMethod]
        public bool INSERT_SCM_SHOP_INF(TB_CM_SHOP_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHOP_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_EDI_RESULT========================================================
        [WebMethod]
        public bool INSERT_SEDI_RESULT(TB_EDI_RESULT entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_EDI_RESULT", colllection);
            return id > -1;
        }

        // ===========================================================TB_MO_HIST===========================================================
        [WebMethod]
        public bool INSERT_SMO_HIST(TB_MO_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MO_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_MT_HIST=========================================================== 
        [WebMethod]
        public bool INSERT_SMT_HIST(TB_MT_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MT_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_MT_SMS_RESP_MSG===================================================
        [WebMethod]
        public bool INSERT_SMT_SMS_RESP_MSG(TB_MT_SMS_RESP_MSG entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MT_SMS_RESP_MSG", colllection);
            return id > -1;
        }

        // ===========================================================TB_ORDER_SHIP_HIST===================================================
        [WebMethod]
        public bool INSERT_SORDER_SHIP_HIST(TB_ORDER_SHIP_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_ORDER_SHIP_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_CDC_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_CDC_HIST(TB_SN_CDC_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_CDC_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_PND_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_PND_HIST(TB_SN_PND_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_PND_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_RDC_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_RDC_HIST(TB_SN_RDC_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_RDC_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_DEALERS=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_DEALERS(TB_SN_SO_DEALERS entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_DEALERS", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_WT_HIST=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_HIST(TB_SN_SO_WT_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_WT_MST======================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_MST(TB_SN_SO_WT_MST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_MST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_WT_MST0=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_MST0(TB_SN_SO_WT_MST0 entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_MST0", colllection);
            return id > -1;
        }
    }
}
