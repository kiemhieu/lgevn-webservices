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
            var cm_mrp_list = OracleDataHelper.GetNoTransfer<TB_CM_MRP>("TB_CM_MRP", "SO_TRANSFER_FLAG");
            ////---------GET LIST FROM STOREPROCEDURED ----------------------------------------
            //OracleDataHelper.ExecuteProcedure<HIEUNK_TEST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST",
            //new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor});
            if (cm_mrp_list == null && cm_mrp_list.Count() <= 0) return;

            foreach (var item in cm_mrp_list)
            {
                //var item = cm_mrp_list.ElementAt(0);
                try
                {
                    //2. Insert to server (with checked existing)
                    var entity = new TestApplication.LGService.TB_CM_MRP
                    {
                        MRP = item.MRP,
                        MODEL = item.MODEL,
                        CREATE_DATE = item.CREATE_DATE,
                        SO_TRANSFER_FLAG = "Y",
                        SO_TRANSFER_DATE = DateTime.Now
                    };
                    TestApplication.LGService.LgeService service = new TestApplication.LGService.LgeService();
                    service.INSERT_TB_CM_MRP(entity);
                    //int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_HIEUNK_TEST", colllection);

                    //3. Update flag to Client
                    OracleDataHelper.ExecuteFlag<TB_CM_MRP>(item, "TB_CM_MRP", "SO_TRANSFER_FLAG", "MODEL");
                }
                catch { }
            }
        }
    }
}
