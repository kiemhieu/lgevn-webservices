using LGEVN.Services.Implement;
using LGEVN.Services.Interface;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

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
        public bool SendSelloutData(ISellout sellout)
        {
            OracleDataHelper.ExecuteProcedure("", );
            return true;
        }


        [WebMethod]
        public ISellout GetSelloutData(string serial_no, string model)
        {
            ISellout sellout = new Sellout();
            return sellout;
        }
    }
}