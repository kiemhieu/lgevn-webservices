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
    /// Summary description for MorderChanel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MorderChanel : System.Web.Services.WebService
    {

        [WebMethod]
        public WS_RESP_PARS GET_WS_EDI(string ws_shop_code, string ws_shop_key, string serial_no, string model, string sell_date, string eucell, string euname, string euadd, string request_time)
        {
            var result = OracleDataHelper.ExecuteProcedure<WS_RESP_PARS>("PK_EDI_MST.PR_RESPONSE_WS_EDI",
                new OracleParameter[]{
                     new OracleParameter { ParameterName = "P_WS_SHOP_CODE", Value= ws_shop_code},
                     new OracleParameter { ParameterName = "P_WS_SHOP_KEY", Value=ws_shop_key},
                     new OracleParameter { ParameterName = "P_SERIAL_NO", Value= serial_no},
                     new OracleParameter { ParameterName = "P_MODEL", Value= model},
                     new OracleParameter { ParameterName = "P_SELL_DATE", Value= sell_date},
                     new OracleParameter { ParameterName = "P_EUCELL", Value= eucell},
                     new OracleParameter { ParameterName = "P_EUNAME", Value= euname},
                     new OracleParameter { ParameterName = "P_EUADD", Value= euadd},
                     new OracleParameter { ParameterName = "P_REQUEST_TIME", Value= request_time},
                     new OracleParameter { ParameterName = "items_cursor", Direction = System.Data.ParameterDirection.Output, OracleType=OracleType.Cursor}
                });

            return result == null ? null : result.ElementAt(0);
        }



        [WebMethod]
        private Sellout GetSellout(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<Sellout>("PKG_WEBSERVICE.GET_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<Sellout> GetSelloutData()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<Sellout>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        #region BASE FUNCTIONS
        // ===========================================================TB_SN_SO_WT_MST================================================================
        [WebMethod]
        private TB_SN_SO_WT_MST GET_TB_SN_SO_WT_MST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_SO_WT_MST> GET_TB_SN_SO_WT_MST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_SN_SO_WT_MST0===============================================================
        [WebMethod]
        private TB_SN_SO_WT_MST0 GET_TB_SN_SO_WT_MST0(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST0>("PKG_WEBSERVICE.GET_SN_SO_WT_MST0", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_SO_WT_MST0> GET_TB_SN_SO_WT_MST0_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST0>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST0", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_SO_WT_HST================================================================
        [WebMethod]
        private TB_SN_SO_WT_HIST GET_TB_SN_SO_WT_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_HIST>("PKG_WEBSERVICE.GET_SN_SO_WT_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_SO_WT_HIST> GET_TB_SN_SO_WT_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_SO_DEALERS================================================================
        [WebMethod]
        private TB_SN_SO_DEALERS GET_TB_SN_SO_DEALERS(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_DEALERS>("PKG_WEBSERVICE.GET_SN_SO_DEALERS", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_SO_DEALERS> GET_TB_SN_SO_DEALERS_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_DEALERS>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_DEALERS", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_RDC_HIST================================================================
        [WebMethod]
        private TB_SN_RDC_HIST GET_TB_SN_RDC_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_RDC_HIST>("PKG_WEBSERVICE.GET_SN_RDC_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_RDC_HIST> GET_TB_SN_RDC_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_RDC_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_RDC_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_SN_PND_HIST================================================================
        [WebMethod]
        private TB_SN_PND_HIST GET_TB_SN_PND_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_PND_HIST>("PKG_WEBSERVICE.GET_SN_PND_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_PND_HIST> GET_TB_SN_PND_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_PND_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_PND_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_CDC_HIST================================================================
        [WebMethod]
        private TB_SN_CDC_HIST GET_TB_SN_CDC_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_CDC_HIST>("PKG_WEBSERVICE.GET_SN_CDC_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_SN_CDC_HIST> GET_TB_SN_CDC_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_CDC_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_CDC_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_ORDER_SHIP_HIST================================================================
        [WebMethod]
        private TB_ORDER_SHIP_HIST GET_TB_ORDER_SHIP_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_ORDER_SHIP_HIST>("PKG_WEBSERVICE.GET_ORDER_SHIP_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_ORDER_SHIP_HIST> GET_TB_ORDER_SHIP_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_ORDER_SHIP_HIST>("PKG_WEBSERVICE.GET_NOTRANS_ORDER_SHIP_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_APP_ERROR==============================================================
        [WebMethod]
        private TB_APP_ERROR GET_TB_APP_ERROR(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_APP_ERROR>("PKG_WEBSERVICE.GET_APP_ERROR", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_APP_ERROR> GET_TB_APP_ERROR_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_APP_ERROR>("PKG_WEBSERVICE.GET_NOTRANS_APP_ERROR", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_BILLTO_INFT==========================================================
        private TB_CM_BILLTO_INF GET_TB_CM_BILLTO_INF(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_BILLTO_INF>("PKG_WEBSERVICE.GET_CM_BILLTO_INF", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_CM_BILLTO_INF> GET_TB_CM_BILLTO_INF_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_BILLTO_INF>("PKG_WEBSERVICE.GET_NOTRANS_CM_BILLTO_INF", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_MODEL_CAT===========================================================
        private TB_CM_MODEL_CAT GET_TB_CM_MODEL_CAT(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_MODEL_CAT>("PKG_WEBSERVICE.GET_CM_MODEL_CAT", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_CM_MODEL_CAT> GET_TB_CM_MODEL_CAT_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_MODEL_CAT>("PKG_WEBSERVICE.GET_NOTRANS_CM_MODEL_CAT", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_SHIPTO_INF==========================================================
        private TB_CM_SHIPTO_INF GET_TB_CM_SHIPTO_INF(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHIPTO_INF>("PKG_WEBSERVICE.GET_CM_SHIPTO_INF", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_CM_SHIPTO_INF> GET_TB_CM_SHIPTO_INF_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHIPTO_INF>("PKG_WEBSERVICE.GET_NOTRANS_CM_SHIPTO_INF", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_SHOP_BILLTO=========================================================
        private TB_CM_SHOP_BILLTO GET_TB_CM_SHOP_BILLTO(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHOP_BILLTO>("PKG_WEBSERVICE.GET_CM_SHOP_BILLTO", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_CM_SHOP_BILLTO> GET_TB_CM_SHOP_BILLTO_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHOP_BILLTO>("PKG_WEBSERVICE.GET_NOTRANS_CM_SHOP_BILLTO", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_SHOP_INF============================================================
        private TB_CM_SHOP_INF GET_TB_CM_SHOP_INF(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHOP_INF>("PKG_WEBSERVICE.GET_CM_SHOP_INF", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_CM_SHOP_INF> GET_TB_CM_SHOP_INF_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_CM_SHOP_INF>("PKG_WEBSERVICE.GET_NOTRANS_CM_SHOP_INF", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_EDI_RESULT=============================================================
        private TB_EDI_RESULT GET_TB_EDI_RESULT(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_EDI_RESULT>("PKG_WEBSERVICE.GET_EDI_RESULT", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_EDI_RESULT> GET_TB_EDI_RESULT_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_EDI_RESULT>("PKG_WEBSERVICE.GET_NOTRANS_EDI_RESULT", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_MO_HIST================================================================
        private TB_MO_HIST GET_TB_MO_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MO_HIST>("PKG_WEBSERVICE.GET_MO_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_MO_HIST> GET_TB_MO_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MO_HIST>("PKG_WEBSERVICE.GET_NOTRANS_MO_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_MT_HIST================================================================
        private TB_MT_HIST GET_TB_MT_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MT_HIST>("PKG_WEBSERVICE.GET_MT_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_MT_HIST> GET_TB_MT_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MT_HIST>("PKG_WEBSERVICE.GET_NOTRANS_MT_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_MT_SMS_RESP_MSG======================================================== 
        private TB_MT_SMS_RESP_MSG GET_TB_MT_SMS_RESP_MSG(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MT_SMS_RESP_MSG>("PKG_WEBSERVICE.GET_MT_SMS_RESP_MSG", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        private IEnumerable<TB_MT_SMS_RESP_MSG> GET_TB_MT_SMS_RESP_MSG_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_MT_SMS_RESP_MSG>("PKG_WEBSERVICE.GET_NOTRANS_MT_SMS_RESP_MSG", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }
        #endregion
    }
}
