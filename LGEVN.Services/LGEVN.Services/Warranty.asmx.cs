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
    }
}