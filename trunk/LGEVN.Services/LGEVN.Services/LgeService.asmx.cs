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
            colllection.Add(new OracleParameter("p_NAME", entity.NAME));
            colllection.Add(new OracleParameter("p_MSG", entity.MSG));
            colllection.Add(new OracleParameter("p_LINE", entity.LINE));
            colllection.Add(new OracleParameter("p_CDATE", entity.CDATE));
            colllection.Add(new OracleParameter("p_CTIME", entity.CTIME));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_APP_ERROR", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_BILLTO_INF=====================================================
        [WebMethod]
        public bool INSERT_SCM_BILLTO_INF(TB_CM_BILLTO_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_BILLTO_CODE", entity.BILLTO_CODE));
            colllection.Add(new OracleParameter("p_PROFILE", entity.PROFILE));
            colllection.Add(new OracleParameter("p_SHORT_NAME", entity.SHORT_NAME));
            colllection.Add(new OracleParameter("p_FULL_NAME", entity.FULL_NAME));
            colllection.Add(new OracleParameter("p_REPRESENTATIVE", entity.REPRESENTATIVE));
            colllection.Add(new OracleParameter("p_BIZ_NO", entity.BIZ_NO));
            colllection.Add(new OracleParameter("p_TAX_ID", entity.TAX_ID));
            colllection.Add(new OracleParameter("p_CUSTOMER_CODE", entity.CUSTOMER_CODE));
            colllection.Add(new OracleParameter("p_ADDRESS", entity.ADDRESS));
            colllection.Add(new OracleParameter("p_CREDIT_LEVEL", entity.CREDIT_LEVEL));
            colllection.Add(new OracleParameter("p_GRADE", entity.GRADE));
            colllection.Add(new OracleParameter("p_HIGH_SALE_CHANNEL", entity.HIGH_SALE_CHANNEL));
            colllection.Add(new OracleParameter("p_PAY_FROM", entity.PAY_FROM));
            colllection.Add(new OracleParameter("p_LOW_PRICE_GROUP", entity.LOW_PRICE_GROUP));
            colllection.Add(new OracleParameter("p_HIGH_PRICE_GROUP", entity.HIGH_PRICE_GROUP));
            colllection.Add(new OracleParameter("p_VN_DEPARTMENT", entity.VN_DEPARTMENT));
            colllection.Add(new OracleParameter("p_AVTIVE", entity.AVTIVE));
            colllection.Add(new OracleParameter("p_LOW_SALE_CHANNEL", entity.LOW_SALE_CHANNEL));
            colllection.Add(new OracleParameter("p_BUYING_GROUP", entity.BUYING_GROUP));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_BILLTO_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_MODEL_CAT======================================================
        [WebMethod]
        public bool INSERT_SCM_MODEL_CAT(TB_CM_MODEL_CAT entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_PROD_L1", entity.PROD_L1));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_MP_MODEL", entity.MP_MODEL));
            colllection.Add(new OracleParameter("p_MP_SUFFIX", entity.MP_SUFFIX));
            colllection.Add(new OracleParameter("p_ACTIVE_CODE", entity.ACTIVE_CODE));
            colllection.Add(new OracleParameter("p_SALE_FLAG", entity.SALE_FLAG));
            colllection.Add(new OracleParameter("p_PROD_L2", entity.PROD_L2));
            colllection.Add(new OracleParameter("p_PROD_L3", entity.PROD_L3));
            colllection.Add(new OracleParameter("p_PROD_L4", entity.PROD_L4));
            colllection.Add(new OracleParameter("p_TENTATIVE_FLAG", entity.TENTATIVE_FLAG));
            colllection.Add(new OracleParameter("p_MODEL_SPEC", entity.MODEL_SPEC));
            colllection.Add(new OracleParameter("p_PUR_TYPE", entity.PUR_TYPE));
            colllection.Add(new OracleParameter("p_ENABLE_FLAG", entity.ENABLE_FLAG));
            colllection.Add(new OracleParameter("p_LAST_UPDATE_DATE", entity.LAST_UPDATE_DATE));
            colllection.Add(new OracleParameter("p_UNIT", entity.UNIT));
            colllection.Add(new OracleParameter("p_AU_CODE", entity.AU_CODE));
            colllection.Add(new OracleParameter("p_AF_CODE", entity.AF_CODE));
            colllection.Add(new OracleParameter("p_EOM", entity.EOM));
            colllection.Add(new OracleParameter("p_PROD_TYPE", entity.PROD_TYPE));
            colllection.Add(new OracleParameter("p_MKT", entity.MKT));
            colllection.Add(new OracleParameter("p_IF_DATE", entity.IF_DATE));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_MODEL_CAT", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHIPTO_INF=====================================================
        [WebMethod]
        public bool INSERT_SCM_SHIPTO_INF(TB_CM_SHIPTO_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_BILLTO_CODE", entity.BILLTO_CODE));
            colllection.Add(new OracleParameter("p_BILLTO_NAME", entity.BILLTO_NAME));
            colllection.Add(new OracleParameter("p_BILLTO_FULLNAME", entity.BILLTO_FULLNAME));
            colllection.Add(new OracleParameter("p_BILLTO_ADDRESS1", entity.BILLTO_ADDRESS1));
            colllection.Add(new OracleParameter("p_SHIPTO_CODE", entity.SHIPTO_CODE));
            colllection.Add(new OracleParameter("p_SHIPTO_NAME", entity.SHIPTO_NAME));
            colllection.Add(new OracleParameter("p_SHIPTO_FULLNAME", entity.SHIPTO_FULLNAME));
            colllection.Add(new OracleParameter("p_ADDRESS1", entity.ADDRESS1));
            colllection.Add(new OracleParameter("p_ADDRESS2", entity.ADDRESS2));
            colllection.Add(new OracleParameter("p_ADDRESS3", entity.ADDRESS3));
            colllection.Add(new OracleParameter("p_ADDRESS4", entity.ADDRESS4));
            colllection.Add(new OracleParameter("p_POSTAL_CODE", entity.POSTAL_CODE));
            colllection.Add(new OracleParameter("p_COUNTRY", entity.COUNTRY));
            colllection.Add(new OracleParameter("p_CITY", entity.CITY));
            colllection.Add(new OracleParameter("p_BIZ_REG", entity.BIZ_REG));
            colllection.Add(new OracleParameter("p_SHIPTO_STATUS", entity.SHIPTO_STATUS));
            colllection.Add(new OracleParameter("p_MARKET_TYPE", entity.MARKET_TYPE));
            colllection.Add(new OracleParameter("p_SALES_CHANNEL", entity.SALES_CHANNEL));
            colllection.Add(new OracleParameter("p_ACTIVE_FLAG", entity.ACTIVE_FLAG));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHIPTO_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHOP_BILLTO====================================================
        [WebMethod]
        public bool INSERT_SCM_SHOP_BILLTO(TB_CM_SHOP_BILLTO entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));
            colllection.Add(new OracleParameter("p_BILLTO_CODE", entity.BILLTO_CODE));
            colllection.Add(new OracleParameter("p_SHOP_CODE", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_MODIFY_DATE", entity.MODIFY_DATE));
            colllection.Add(new OracleParameter("p_CREATE_USER", entity.CREATE_USER));
            colllection.Add(new OracleParameter("p_MODIFY_USER", entity.MODIFY_USER));
            colllection.Add(new OracleParameter("p_USE_FLAG", entity.USE_FLAG));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHOP_BILLTO", colllection);
            return id > -1;
        }

        // ===========================================================TB_CM_SHOP_INF=======================================================
        [WebMethod]
        public bool INSERT_SCM_SHOP_INF(TB_CM_SHOP_INF entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_", entity));
            colllection.Add(new OracleParameter("p_BILLTO_CODE", entity.BILLTO_CODE));
            colllection.Add(new OracleParameter("p_SHOP_CODE", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_SHOP_NAME", entity.SHOP_NAME));
            colllection.Add(new OracleParameter("p_ADDRESS", entity.ADDRESS));
            colllection.Add(new OracleParameter("p_CELL_NO_1", entity.CELL_NO_1));
            colllection.Add(new OracleParameter("p_DIST_CODE", entity.DIST_CODE));
            colllection.Add(new OracleParameter("p_PROVINCE_CODE", entity.PROVINCE_CODE));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_UPDATE_DATE", entity.UPDATE_DATE));
            colllection.Add(new OracleParameter("p_ISDN_NO", entity.ISDN_NO));
            colllection.Add(new OracleParameter("p_CUSTOMER_CODE", entity.CUSTOMER_CODE));
            colllection.Add(new OracleParameter("p_AREA_CODE", entity.AREA_CODE));
            colllection.Add(new OracleParameter("p_CELL_NO_2", entity.CELL_NO_2));
            colllection.Add(new OracleParameter("p_OWNER_NAME", entity.OWNER_NAME));
            colllection.Add(new OracleParameter("p_OWNER_EMAIL", entity.OWNER_EMAIL));
            colllection.Add(new OracleParameter("p_USE_FLAG", entity.USE_FLAG));
            colllection.Add(new OracleParameter("p_CHANNEL", entity.CHANNEL));
            colllection.Add(new OracleParameter("p_REG_ID", entity.REG_ID));
            colllection.Add(new OracleParameter("p_CREATE_USER", entity.CREATE_USER));
            colllection.Add(new OracleParameter("p_UPDATE_USER", entity.UPDATE_USER));
            colllection.Add(new OracleParameter("p_SHOP_TYPE", entity.SHOP_TYPE));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_CM_SHOP_INF", colllection);
            return id > -1;
        }

        // ===========================================================TB_EDI_RESULT========================================================
        [WebMethod]
        public bool INSERT_SEDI_RESULT(TB_EDI_RESULT entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_DUP_CNT", entity.DUP_CNT));
            colllection.Add(new OracleParameter("p_DONE_CNT", entity.DONE_CNT));
            colllection.Add(new OracleParameter("p_DUP_ITEM", entity.DUP_ITEM));
            colllection.Add(new OracleParameter("p_EDI_FILE", entity.EDI_FILE));
            colllection.Add(new OracleParameter("p_FAIL_CNT", entity.FAIL_CNT));
            colllection.Add(new OracleParameter("p_FAIL_ITEM", entity.FAIL_ITEM));
            colllection.Add(new OracleParameter("p_EDI_DATE", entity.EDI_DATE));
            colllection.Add(new OracleParameter("p_EDI_TIME", entity.EDI_TIME));
            colllection.Add(new OracleParameter("p_EDI_HEAD", entity.EDI_HEAD));
            colllection.Add(new OracleParameter("p_EDI_CODE", entity.EDI_CODE));
            colllection.Add(new OracleParameter("p_NEW_CNT", entity.NEW_CNT));
            colllection.Add(new OracleParameter("p_DONE_ITEM", entity.DONE_ITEM));
            colllection.Add(new OracleParameter("p_RESPONSE", entity.RESPONSE));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_EDI_RESULT", colllection);
            return id > -1;
        }

        // ===========================================================TB_MO_HIST===========================================================
        [WebMethod]
        public bool INSERT_SMO_HIST(TB_MO_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_CELL_NO", entity.CELL_NO));
            colllection.Add(new OracleParameter("p_SHORTCODE", entity.SHORTCODE));
            colllection.Add(new OracleParameter("p_MOSEQ", entity.MOSEQ));
            colllection.Add(new OracleParameter("p_CMDCODE", entity.CMDCODE));
            colllection.Add(new OracleParameter("p_MSGBODY", entity.MSGBODY));
            colllection.Add(new OracleParameter("p_RECEIVE_TIME", entity.RECEIVE_TIME));
            colllection.Add(new OracleParameter("p_FILENAME", entity.FILENAME));
            colllection.Add(new OracleParameter("p_FILEDATE", entity.FILEDATE));
            colllection.Add(new OracleParameter("p_TRANSFER_FLAG", entity.TRANSFER_FLAG));
            colllection.Add(new OracleParameter("p_TRANSFER_DATE", entity.TRANSFER_DATE));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MO_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_MT_HIST=========================================================== 
        [WebMethod]
        public bool INSERT_SMT_HIST(TB_MT_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_MOSEQ", entity.MOSEQ));
            colllection.Add(new OracleParameter("p_SHORTCODE", entity.SHORTCODE));
            colllection.Add(new OracleParameter("p_CELL_NO", entity.CELL_NO));
            colllection.Add(new OracleParameter("p_MSGBODY", entity.MSGBODY));
            colllection.Add(new OracleParameter("p_MSGTYPE", entity.MSGTYPE));
            colllection.Add(new OracleParameter("p_MTTOTALSEQ", entity.MTTOTALSEQ));
            colllection.Add(new OracleParameter("p_MTSEQREF", entity.MTSEQREF));
            colllection.Add(new OracleParameter("p_SEND_TIME", entity.SEND_TIME));
            colllection.Add(new OracleParameter("p_FINISH_TIME", entity.FINISH_TIME));
            colllection.Add(new OracleParameter("p_SEND_FLAG", entity.SEND_FLAG));
            colllection.Add(new OracleParameter("p_RESULT", entity.RESULT));
            colllection.Add(new OracleParameter("p_LAST_UPDATE_DATE", entity.LAST_UPDATE_DATE));
            colllection.Add(new OracleParameter("p_CPID", entity.CPID));
            colllection.Add(new OracleParameter("p_CMDCODE", entity.CMDCODE));
            colllection.Add(new OracleParameter("p_MO_MSGBODY", entity.MO_MSGBODY));
            colllection.Add(new OracleParameter("p_RESP_TYPE", entity.RESP_TYPE));
            colllection.Add(new OracleParameter("p_MO_RECEIVE_TIME", entity.MO_RECEIVE_TIME));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MT_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_MT_SMS_RESP_MSG===================================================
        [WebMethod]
        public bool INSERT_SMT_SMS_RESP_MSG(TB_MT_SMS_RESP_MSG entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_RESP_TYPE", entity.RESP_TYPE));
            colllection.Add(new OracleParameter("p_RESP_MSG_1", entity.RESP_MSG_1));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_MSGBODY_LEN", entity.MSGBODY_LEN));
            colllection.Add(new OracleParameter("p_RESP_MSG_2", entity.RESP_MSG_2));
            colllection.Add(new OracleParameter("p_GABIT_TEMPLATE", entity.GABIT_TEMPLATE));
            colllection.Add(new OracleParameter("p_GABIT_ID", entity.GABIT_ID));
            colllection.Add(new OracleParameter("p_TEMPLATE", entity.TEMPLATE));
            colllection.Add(new OracleParameter("p_PURPOSE", entity.PURPOSE));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_MT_SMS_RESP_MSG", colllection);
            return id > -1;
        }

        // ===========================================================TB_ORDER_SHIP_HIST===================================================
        [WebMethod]
        public bool INSERT_SORDER_SHIP_HIST(TB_ORDER_SHIP_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_INV_ORG", entity.INV_ORG));
            colllection.Add(new OracleParameter("p_SHIPTO_CODE", entity.SHIPTO_CODE));
            colllection.Add(new OracleParameter("p_SHIPTO_NAME", entity.SHIPTO_NAME));
            colllection.Add(new OracleParameter("p_CITY", entity.CITY));
            colllection.Add(new OracleParameter("p_ORDER_NO", entity.ORDER_NO));
            colllection.Add(new OracleParameter("p_LINE_NO", entity.LINE_NO));
            colllection.Add(new OracleParameter("p_LINE_STATUS", entity.LINE_STATUS));
            colllection.Add(new OracleParameter("p_PROD_DIV", entity.PROD_DIV));
            colllection.Add(new OracleParameter("p_MODEL_SUFFIX", entity.MODEL_SUFFIX));
            colllection.Add(new OracleParameter("p_ORDER_QTY", entity.ORDER_QTY));
            colllection.Add(new OracleParameter("p_RELEASE_QTY", entity.RELEASE_QTY));
            colllection.Add(new OracleParameter("p_UNIT_SELL_PRICE", entity.UNIT_SELL_PRICE));
            colllection.Add(new OracleParameter("p_ORDER_AMT", entity.ORDER_AMT));
            colllection.Add(new OracleParameter("p_SHIPPING_METHOD", entity.SHIPPING_METHOD));
            colllection.Add(new OracleParameter("p_REQUEST_SHIPPED_DATE", entity.REQUEST_SHIPPED_DATE));
            colllection.Add(new OracleParameter("p_REQUEST_ARRIVAL_DATE", entity.REQUEST_ARRIVAL_DATE));
            colllection.Add(new OracleParameter("p_SHIPPING_REMARK", entity.SHIPPING_REMARK));
            colllection.Add(new OracleParameter("p_INVOICE_NO", entity.INVOICE_NO));
            colllection.Add(new OracleParameter("p_INVOICE_DATE", entity.INVOICE_DATE));
            colllection.Add(new OracleParameter("p_BOOKED_DATE", entity.BOOKED_DATE));
            colllection.Add(new OracleParameter("p_PICK_NO", entity.PICK_NO));
            colllection.Add(new OracleParameter("p_PICK_RELEASE_DATE", entity.PICK_RELEASE_DATE));
            colllection.Add(new OracleParameter("p_DELIVERY_NO", entity.DELIVERY_NO));
            colllection.Add(new OracleParameter("p_SUBINVENTORY", entity.SUBINVENTORY));
            colllection.Add(new OracleParameter("p_CREATION_DATE", entity.CREATION_DATE));
            colllection.Add(new OracleParameter("p_BILLTO_CODE", entity.BILLTO_CODE));
            colllection.Add(new OracleParameter("p_BILLTO_NAME", entity.BILLTO_NAME));
            colllection.Add(new OracleParameter("p_SALESCHANNEL_CODE", entity.SALESCHANNEL_CODE));
            colllection.Add(new OracleParameter("p_SALESCHANNEL_NAME", entity.SALESCHANNEL_NAME));
            colllection.Add(new OracleParameter("p_CREATED_BY", entity.CREATED_BY));
            colllection.Add(new OracleParameter("p_SALESPERSON", entity.SALESPERSON));
            colllection.Add(new OracleParameter("p_UNIQUE_ID", entity.UNIQUE_ID));
            colllection.Add(new OracleParameter("p_PICK_SEQ", entity.PICK_SEQ));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_AR_FLAG", entity.AR_FLAG));
            colllection.Add(new OracleParameter("p_AU_CODE", entity.AU_CODE));
            colllection.Add(new OracleParameter("p_ACCEPTANCE_CODE", entity.ACCEPTANCE_CODE));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_ORDER_SHIP_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_CDC_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_CDC_HIST(TB_SN_CDC_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_INV_ORG", entity.INV_ORG));
            colllection.Add(new OracleParameter("p_LOADPLAN_NO", entity.LOADPLAN_NO));
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_BOX_NO", entity.BOX_NO));
            colllection.Add(new OracleParameter("p_SHIPTO_CODE", entity.SHIPTO_CODE));
            colllection.Add(new OracleParameter("p_SHIPTO_NAME", entity.SHIPTO_NAME));
            colllection.Add(new OracleParameter("p_SHIPTO_DATE", entity.SHIPTO_DATE));
            colllection.Add(new OracleParameter("p_ORDER_NO", entity.ORDER_NO));
            colllection.Add(new OracleParameter("p_CLOSED_DATE", entity.CLOSED_DATE));
            colllection.Add(new OracleParameter("p_INVOICE_NO", entity.INVOICE_NO));
            colllection.Add(new OracleParameter("p_INVOICE_DATE", entity.INVOICE_DATE));
            colllection.Add(new OracleParameter("p_CUSTOMER_CODE", entity.CUSTOMER_CODE));
            colllection.Add(new OracleParameter("p_CUSTOMER_NAME", entity.CUSTOMER_NAME));
            colllection.Add(new OracleParameter("p_UNIQUE_ID", entity.UNIQUE_ID));
            colllection.Add(new OracleParameter("p_SELLOUT_FLAG", entity.SELLOUT_FLAG));
            colllection.Add(new OracleParameter("p_SELLOUT_DATE", entity.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_INCENTIVE_FLAG", entity.INCENTIVE_FLAG));
            colllection.Add(new OracleParameter("p_WARRANTY_IF_FLAG", entity.WARRANTY_IF_FLAG));
            colllection.Add(new OracleParameter("p_WARRANTY_IF_DATE", entity.WARRANTY_IF_DATE));
            colllection.Add(new OracleParameter("p_SEQ_NO", entity.SEQ_NO));
            colllection.Add(new OracleParameter("p_MODEL_SUFFIX", entity.MODEL_SUFFIX));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_CDC_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_PND_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_PND_HIST(TB_SN_PND_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_MOSEQ", entity.MOSEQ));
            colllection.Add(new OracleParameter("p_RESP_TYPE", entity.RESP_TYPE));
            colllection.Add(new OracleParameter("p_CMDCODE", entity.CMDCODE));
            colllection.Add(new OracleParameter("p_RECEIVE_DATE", entity.RECEIVE_DATE));
            colllection.Add(new OracleParameter("p_PND_DAYS", entity.PND_DAYS));
            colllection.Add(new OracleParameter("p_CFM_FLAG", entity.CFM_FLAG));
            colllection.Add(new OracleParameter("p_CFM_TYPE", entity.CFM_TYPE));
            colllection.Add(new OracleParameter("p_CFM_DATE", entity.CFM_DATE));
            colllection.Add(new OracleParameter("p_SHOP_CELL", entity.SHOP_CELL));
            colllection.Add(new OracleParameter("p_RESP_MSG", entity.RESP_MSG));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_CFM_USER", entity.CFM_USER));
            colllection.Add(new OracleParameter("p_MO_MSGBODY", entity.MO_MSGBODY));
            colllection.Add(new OracleParameter("p_END_USER_CELL", entity.END_USER_CELL));
            colllection.Add(new OracleParameter("p_PND_TYPE", entity.PND_TYPE));
            colllection.Add(new OracleParameter("p_SHOP_CODE", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_SMS_YN", entity.SMS_YN));
            colllection.Add(new OracleParameter("p_REJECT_FLAG", entity.REJECT_FLAG));
            colllection.Add(new OracleParameter("p_REJECT_DATE", entity.REJECT_DATE));
            colllection.Add(new OracleParameter("p_REJECT_USER", entity.REJECT_USER));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_PND_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_RDC_HIST=======================================================
        [WebMethod]
        public bool INSERT_SSN_RDC_HIST(TB_SN_RDC_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_INV_ORG", entity.INV_ORG));
            colllection.Add(new OracleParameter("p_EDI_NO", entity.EDI_NO));
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_BOX_NO", entity.BOX_NO));
            colllection.Add(new OracleParameter("p_MODEL_SUFFIX", entity.MODEL_SUFFIX));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_SHIP_NO", entity.SHIP_NO));
            colllection.Add(new OracleParameter("p_LINE_NO", entity.LINE_NO));
            colllection.Add(new OracleParameter("p_OUT_DATE", entity.OUT_DATE));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_SELLOUT_DATE", entity.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_INCENTIVE_DATE", entity.INCENTIVE_DATE));
            colllection.Add(new OracleParameter("p_WT_IF_DATE", entity.WT_IF_DATE));
            colllection.Add(new OracleParameter("p_WT_IF_FLAG", entity.WT_IF_FLAG));
            colllection.Add(new OracleParameter("p_SELLOUT_STATUS", entity.SELLOUT_STATUS));
            colllection.Add(new OracleParameter("p_INCENTIVE_FLAG", entity.INCENTIVE_FLAG));
            colllection.Add(new OracleParameter("p_SMS_YN", entity.SMS_YN));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_RDC_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_DEALERS=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_DEALERS(TB_SN_SO_DEALERS entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_SHOP_CODE", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_BOX_NO", entity.BOX_NO));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_MODEL_DESC", entity.MODEL_DESC));
            colllection.Add(new OracleParameter("p_EDI_NO", entity.EDI_NO));
            colllection.Add(new OracleParameter("p_SELLOUT_DATE", entity.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_EU_CELL", entity.EU_CELL));
            colllection.Add(new OracleParameter("p_EU_NAME", entity.EU_NAME));
            colllection.Add(new OracleParameter("p_EU_ADDRESS", entity.EU_ADDRESS));
            colllection.Add(new OracleParameter("p_UPDATE_DATE", entity.UPDATE_DATE));
            colllection.Add(new OracleParameter("p_UPLOAD_USER", entity.UPLOAD_USER));
            colllection.Add(new OracleParameter("p_VRF_FLAG", entity.VRF_FLAG));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_CFM_FLAG", entity.CFM_FLAG));
            colllection.Add(new OracleParameter("p_CFM_USER", entity.CFM_USER));
            colllection.Add(new OracleParameter("p_CFM_DATE", entity.CFM_DATE));
            colllection.Add(new OracleParameter("p_CFM_COMMENT", entity.CFM_COMMENT));
            colllection.Add(new OracleParameter("p_SELLIN_DATE", entity.SELLIN_DATE));
            colllection.Add(new OracleParameter("p_EDI_DATE", entity.EDI_DATE));
            colllection.Add(new OracleParameter("p_EDI_FILE", entity.EDI_FILE));


            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_DEALERS", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_WT_HIST=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_HIST(TB_SN_SO_WT_HIST entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_END_USER_CELL", entity.END_USER_CELL));
            colllection.Add(new OracleParameter("p_SHOP_CODE", entity.SHOP_CODE));
            colllection.Add(new OracleParameter("p_SHOP_CELL", entity.SHOP_CELL));
            colllection.Add(new OracleParameter("p_RECEIVE_DATE", entity.RECEIVE_DATE));
            colllection.Add(new OracleParameter("p_MOSEQ", entity.MOSEQ));
            colllection.Add(new OracleParameter("p_CMDCODE", entity.CMDCODE));
            colllection.Add(new OracleParameter("p_RESP_TYPE", entity.RESP_TYPE));
            colllection.Add(new OracleParameter("p_RESP_MSG", entity.RESP_MSG));
            colllection.Add(new OracleParameter("p_MO_MSGBODY", entity.MO_MSGBODY));
            colllection.Add(new OracleParameter("p_SMS_YN", entity.SMS_YN));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_SUCCESS_FLAG", entity.SUCCESS_FLAG));
            colllection.Add(new OracleParameter("p_EDI_FILE", entity.EDI_FILE));
            colllection.Add(new OracleParameter("p_EDI_HEAD", entity.EDI_HEAD));

            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_HIST", colllection);
            return id > -1;
        }

        // ===========================================================TB_SN_SO_WT_MST======================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_MST(TB_SN_SO_WT_MST entity)
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

        // ===========================================================TB_SN_SO_WT_MST0=====================================================
        [WebMethod]
        public bool INSERT_SSN_SO_WT_MST0(TB_SN_SO_WT_MST0 entity)
        {
            OracleParameterCollection colllection = new OracleParameterCollection();
            colllection.Add(new OracleParameter("p_MODEL", entity.MODEL));
            colllection.Add(new OracleParameter("p_SUFFIX", entity.SUFFIX));
            colllection.Add(new OracleParameter("p_SERIAL_NO", entity.SERIAL_NO));
            colllection.Add(new OracleParameter("p_WT_START_DATE", entity.WT_START_DATE));
            colllection.Add(new OracleParameter("p_WT_END_DATE", entity.WT_END_DATE));
            colllection.Add(new OracleParameter("p_END_USER_CELL", entity.END_USER_CELL));
            colllection.Add(new OracleParameter("p_WT_RESP_MSG", entity.WT_RESP_MSG));
            colllection.Add(new OracleParameter("p_WT_RESP_TYPE", entity.WT_RESP_TYPE));
            colllection.Add(new OracleParameter("p_SMS_YN", entity.SMS_YN));
            colllection.Add(new OracleParameter("p_CREATE_DATE", entity.CREATE_DATE));
            colllection.Add(new OracleParameter("p_WT_CFM_USER", entity.WT_CFM_USER));
            colllection.Add(new OracleParameter("p_LAST_UPDATE_DATE", entity.LAST_UPDATE_DATE));
            colllection.Add(new OracleParameter("p_SELLIN_DATE", entity.SELLIN_DATE));
            colllection.Add(new OracleParameter("p_SELLOUT_DATE", entity.SELLOUT_DATE));
            colllection.Add(new OracleParameter("p_SELLOUT_TIME", entity.SELLOUT_TIME));
            colllection.Add(new OracleParameter("p_TRANSFER_FLAG", entity.TRANSFER_FLAG));
            colllection.Add(new OracleParameter("p_TRANSFER_DATE", entity.TRANSFER_DATE));
            int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_SN_SO_WT_MST0", colllection);
            return id > -1;
        }
    }
}
