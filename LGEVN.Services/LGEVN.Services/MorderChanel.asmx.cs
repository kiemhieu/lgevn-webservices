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
        public Sellout GetSellout(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<Sellout>("PKG_WEBSERVICE.GET_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<Sellout> GetSelloutData()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<Sellout>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_SO_WT_MST================================================================
        [WebMethod]
        public TB_SN_SO_WT_MST GET_TB_SN_SO_WT_MST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_SO_WT_MST> GET_TB_SN_SO_WT_MST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_SN_SO_WT_MST0===============================================================
        [WebMethod]
        public TB_SN_SO_WT_MST0 GET_TB_SN_SO_WT_MST0(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST0>("PKG_WEBSERVICE.GET_SN_SO_WT_MST0", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_SO_WT_MST0> GET_TB_SN_SO_WT_MST0_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_MST0>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_MST0", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_SO_WT_HST================================================================
        [WebMethod]
        public TB_SN_SO_WT_HIST GET_TB_SN_SO_WT_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_HIST>("PKG_WEBSERVICE.GET_SN_SO_WT_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_SO_WT_HIST> GET_TB_SN_SO_WT_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_WT_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_WT_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_SO_DEALERS================================================================
        [WebMethod]
        public TB_SN_SO_DEALERS GET_TB_SN_SO_DEALERS(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_DEALERS>("PKG_WEBSERVICE.GET_SN_SO_DEALERS", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_SO_DEALERS> GET_TB_SN_SO_DEALERS_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_SO_DEALERS>("PKG_WEBSERVICE.GET_NOTRANS_SN_SO_DEALERS", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_RDC_HIST================================================================
        [WebMethod]
        public TB_SN_RDC_HIST GET_TB_SN_RDC_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_RDC_HIST>("PKG_WEBSERVICE.GET_SN_RDC_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_RDC_HIST> GET_TB_SN_RDC_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_RDC_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_RDC_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_SN_PND_HIST================================================================
        [WebMethod]
        public TB_SN_PND_HIST GET_TB_SN_PND_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_PND_HIST>("PKG_WEBSERVICE.GET_SN_PND_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_PND_HIST> GET_TB_SN_PND_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_PND_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_PND_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_SN_CDC_HIST================================================================
        [WebMethod]
        public TB_SN_CDC_HIST GET_TB_SN_CDC_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_CDC_HIST>("PKG_WEBSERVICE.GET_SN_CDC_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_SN_CDC_HIST> GET_TB_SN_CDC_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_SN_CDC_HIST>("PKG_WEBSERVICE.GET_NOTRANS_SN_CDC_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }


        // ===========================================================TB_ORDER_SHIP_HIST================================================================
        [WebMethod]
        public TB_ORDER_SHIP_HIST GET_TB_ORDER_SHIP_HIST(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_ORDER_SHIP_HIST>("PKG_WEBSERVICE.GET_ORDER_SHIP_HIST", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_ORDER_SHIP_HIST> GET_TB_ORDER_SHIP_HIST_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_ORDER_SHIP_HIST>("PKG_WEBSERVICE.GET_NOTRANS_ORDER_SHIP_HIST", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_APP_ERROR==============================================================
        [WebMethod]
        public TB_APP_ERROR GET_TB_APP_ERROR(string serial_no, string model)
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_APP_ERROR>("PKG_WEBSERVICE.GET_APP_ERROR", new OracleParameter[]{
            new OracleParameter("p_serial_no", serial_no), 
            new OracleParameter("p_model", model), 
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});

            if (sellouts != null && sellouts.Count() > 0) return sellouts.ElementAt(0);
            else return null;
        }

        [WebMethod]
        public IEnumerable<TB_APP_ERROR> GET_TB_APP_ERROR_NOTRANS()
        {
            var sellouts = OracleDataHelper.ExecuteProcedure<TB_APP_ERROR>("PKG_WEBSERVICE.GET_NOTRANS_APP_ERROR", new OracleParameter[]{
            new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor}});
            return sellouts;
        }

        // ===========================================================TB_CM_BILLTO_INFT==========================================================
        // ===========================================================TB_CM_MODEL_CATT===========================================================
        // ===========================================================TB_CM_SHIPTO_INFT==========================================================
        // ===========================================================TB_CM_SHOP_BILLTOT=========================================================
        // ===========================================================TB_CM_SHOP_INFT============================================================
        // ===========================================================TB_EDI_RESULTT=============================================================
        // ===========================================================TB_MO_HISTT================================================================
        // ===========================================================TB_MT_HISTT================================================================
        // ===========================================================TB_MT_SMS_RESP_MSGT======================================================== 
    }
}
