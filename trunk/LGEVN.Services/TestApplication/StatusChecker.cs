using LGEVN.Services.Implement;
using System;
using System.Data.OracleClient;
using System.Linq;

namespace LGEVN.ClientServices
{
    public class StatusChecker
    {
        /// <summary>
        /// Do this when timer check & fire
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            //1. Get All uncheck Client
            var tests = OracleDataHelper.GetNoTransfer<HIEUNK_TEST>("HIEUNK_TEST", "FLAG");
            //OracleDataHelper.ExecuteProcedure<HIEUNK_TEST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST",
            //new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor});
            if (tests == null && tests.Count() <= 0) return;

            foreach (var item in tests)
            {
                //2. Insert to server (with checked existing)
                OracleParameterCollection colllection = new OracleParameterCollection();
                colllection.Add(new OracleParameter("p_serial_no", item.ID));
                colllection.Add(new OracleParameter("p_sellin_date", item.NAME));
                colllection.Add(new OracleParameter("p_sellout_date", item.DESCRIPTION));
                colllection.Add(new OracleParameter("p_wt_start_date", item.FLAG));
                //int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_HIEUNK_TEST", colllection);


                //3. Update flag to Client
                OracleDataHelper.ExecuteFlag<HIEUNK_TEST>(item, "HIEUNK_TEST", "FLAG", "ID");
            }
        }
    }
}
