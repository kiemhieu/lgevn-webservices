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
    }
}
