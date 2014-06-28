using LGEVN.Services.Implement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace LGEVN.Client.Console
{
    public class StatusChecker
    {
        /// <summary>
        /// Do this when timer check & fire
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            try
            {

                //1. TB_APP_ERROR
                //var cm_mrp_list = OracleDataHelper.GetNoTransfer<TB_CM_MRP>("TB_CM_MRP", "SO_TRANSFER_FLAG");
                //Synchronize<TB_APP_ERROR, LGService.TB_APP_ERROR>(cm_mrp_list, "SO_TRANSFER_FLAG", "MODEL");

                //2. TB_CM_BILLTO_INF
                //3. TB_CM_MODEL_CAT
                //4. Get All uncheck Client
                var cm_mrp_list = OracleDataHelper.GetNoTransfer<TB_CM_MRP>("TB_CM_MRP", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_MRP, LGService.TB_CM_MRP>(cm_mrp_list, "SO_TRANSFER_FLAG", "MODEL");
                //5. TB_CM_PROVINCE
                //6. TB_CM_REGION
                //7. TB_CM_SHOP_BILLTO
                //8. TB_CM_SHOP_CELL
                //9. TB_CM_SHOP_INF
                //10. TB_MO_HIST
                //11. TB_MT_HIST
                //12. TB_MT_SMS_RESP_MSG
                //13. TB_ORDER_SHIP_HIST
                return;
                //14. TB_SN_CDC_HIST
                var list14 = OracleDataHelper.GetNoTransfer<TB_SN_CDC_HIST>("TB_SN_CDC_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_CDC_HIST, LGService.TB_SN_CDC_HIST>(list14, "SO_TRANSFER_FLAG", new string[] { "INV_ORG", "ORDER_NO", "SHIPTO_CODE", "MODEL", "SERIAL_NO", "SUFFIX" });

                //15. TB_SN_PND_HIST
                var list15 = OracleDataHelper.GetNoTransfer<TB_SN_PND_HIST>("TB_SN_PND_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_PND_HIST, LGService.TB_SN_PND_HIST>(list15, "SO_TRANSFER_FLAG", new string[] { "SERIAL_NO", "OUT_DATE", "EDI_NO", "INV_ORG", "MODEL", "SUFFIX" });

                //16. TB_SN_RDC_HIST
                var list16 = OracleDataHelper.GetNoTransfer<TB_SN_RDC_HIST>("TB_SN_SO_WT_HIST", "SUCCESS_FLAG");
                Synchronize<TB_SN_RDC_HIST, LGService.TB_SN_RDC_HIST>(list16, "SUCCESS_FLAG", new string[] { "SERIAL_NO", "MODEL" });

                //17. TB_SN_SO_WT_HIST
                var list17 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_HIST>("TB_SN_SO_WT_HIST", "TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_HIST, LGService.TB_SN_SO_WT_HIST>(list17, "TRANSFER_FLAG", new string[] { "SERIAL_NO", "MODEL" });

                //18. TB_SN_SO_WT_MST
                var list18 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_MST>("TB_SN_SO_WT_MST", "TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_MST, LGService.TB_SN_SO_WT_MST>(list18, "TRANSFER_FLAG", new string[] { "SERIAL_NO", "MODEL" });

                //19. TB_SN_SO_WT_MST0
                var list19 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_MST0>("TB_SN_SO_WT_MST0", "TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_MST0, LGService.TB_SN_SO_WT_MST0>(list19, "TRANSFER_FLAG", new string[] { "SERIAL_NO", "MODEL" });

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("\n\n");
                System.Console.WriteLine(ex.Message);
            }
        }

        private void Synchronize<TSource, TDest>(IEnumerable<TSource> cm_mrp_list, string flag, params string[] keys)
        {
            //Get property infor of key field
            Type myTypeS = typeof(TSource);
            Type myTypeD = typeof(TDest);

            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("                         BEGIN SYNCHRONIZE TB_CM_MRP " + myTypeS.Name);
            System.Console.WriteLine("---------------------------------------------------------------------------");
            Dictionary<string, string> dictkey = new Dictionary<string, string>();
            //Get dict of params


            var dictS = new Dictionary<string, PropertyInfo>();
            var dictD = new Dictionary<string, PropertyInfo>();

            var propS = myTypeS.GetProperties();
            var propD = myTypeD.GetProperties();
            foreach (var infS in propS) if (!dictS.ContainsKey(infS.Name)) dictS.Add(infS.Name, infS);
            foreach (var infD in propD) if (!dictD.ContainsKey(infD.Name)) dictD.Add(infD.Name, infD);

            ////---------GET LIST FROM STOREPROCEDURED ----------------------------------------
            //OracleDataHelper.ExecuteProcedure<HIEUNK_TEST>("PKG_WEBSERVICE.GET_SN_SO_WT_MST",
            //new OracleParameter{ ParameterName="items_cursor", Direction= System.Data.ParameterDirection.Output, OracleType = OracleType.Cursor});
            if (cm_mrp_list == null && cm_mrp_list.Count() <= 0) return;
            int index = 1;
            foreach (var item in cm_mrp_list)
            {
                //var item = cm_mrp_list.ElementAt(0);
                try
                {
                    //2. Insert to server (with checked existing)
                    List<string> linesPrint = new List<string>();
                    var entity = Activator.CreateInstance(myTypeD);
                    foreach (var infD in propD)
                    {
                        object valueS = null;
                        if (dictS.ContainsKey(infD.Name)) valueS = dictS[infD.Name].GetValue(item, null);
                        infD.SetValue(entity, valueS, null);
                        linesPrint.Add(infD.Name.PadRight(20) + " = " + (valueS == null ? "''" : valueS.ToString()));
                    }

                    CallWebservice<TDest>(entity);
                    //int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_HIEUNK_TEST", colllection);
                    //3. Update flag to Client
                    OracleDataHelper.ExecuteFlag<TSource>(item, myTypeS.Name, flag, keys);
                    //OracleDataHelper.ExecuteFlag<TB_CM_MRP>(item, "TB_CM_MRP", "SO_TRANSFER_FLAG", "MODEL");
                    System.Console.WriteLine("Synchronized (" + index.ToString() + ")");
                    foreach (var line in linesPrint)
                        System.Console.WriteLine(line);
                    //System.Console.WriteLine("MRP   =" + entity.MRP);
                    //System.Console.WriteLine("MODEL =" + item.MODEL);
                    System.Console.WriteLine("---------------------");
                    System.Console.Write("\r{0}", getkey(index));
                    System.Console.Write("\r{0}", "");
                    index++;
                    //Thread.Sleep(20);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("\r{0}", ex.ToString());
                }
            }
            System.Console.WriteLine("\r{0}",
                                     "---------------------------------------------------------------------------");
            System.Console.WriteLine("                            END " + myTypeS.Name);
            System.Console.WriteLine("---------------------------------------------------------------------------");
        }


        #region Private functions
        private void CallWebservice<TEntity>(object entity)
        {
            Type myTypeS = typeof(TEntity);
            string name = myTypeS.Name.ToUpper();
            LGService.LgeService service = new LGService.LgeService();
            service.Url = ConfigurationManager.AppSettings["ServiceURL"];
            switch (name)
            {
                case "TB_APP_ERROR":
                    service.INSERT_SAPP_ERROR((LGService.TB_APP_ERROR)entity);
                    break;
                case "TB_CM_BILLTO_INF":
                    service.INSERT_SCM_BILLTO_INF((LGService.TB_CM_BILLTO_INF)entity);
                    break;
                case "TB_CM_MODEL_CAT":
                    service.INSERT_SCM_MODEL_CAT((LGService.TB_CM_MODEL_CAT)entity);
                    break;
                case "TB_CM_MRP":
                    var obj = (LGService.TB_CM_MRP)entity;
                    if (obj.CREATE_DATE == null) obj.CREATE_DATE = DateTime.Now;
                    if (obj.SO_TRANSFER_DATE == null) obj.SO_TRANSFER_DATE = DateTime.Now;
                    service.INSERT_TB_CM_MRP(obj);
                    break;
                case "TB_CM_PROVINCE":
                    service.INSERT_TB_CM_PROVINCE((LGService.TB_CM_PROVINCE)entity);
                    break;
                case "TB_CM_REGION":
                    service.INSERT_TB_CM_REGION((LGService.TB_CM_REGION)entity);
                    break;
                case "TB_CM_SHIPTO_INF":
                    service.INSERT_SCM_SHIPTO_INF((LGService.TB_CM_SHIPTO_INF)entity);
                    break;
                case "TB_CM_SHOP_BILLTO":
                    service.INSERT_SCM_SHOP_BILLTO((LGService.TB_CM_SHOP_BILLTO)entity);
                    break;
                case "TB_CM_SHOP_CELL":
                    service.INSERT_TB_CM_SHOP_CELL((LGService.TB_CM_SHOP_CELL)entity);
                    break;
                case "TB_CM_SHOP_INF":
                    service.INSERT_SCM_SHOP_INF((LGService.TB_CM_SHOP_INF)entity);
                    break;
                case "TB_EDI_RESULT":
                    service.INSERT_SEDI_RESULT((LGService.TB_EDI_RESULT)entity);
                    break;
                case "TB_MO_HIST":
                    service.INSERT_SMO_HIST((LGService.TB_MO_HIST)entity);
                    break;
                case "TB_MT_HIST":
                    service.INSERT_SMT_HIST((LGService.TB_MT_HIST)entity);
                    break;
                case "TB_MT_SMS_RESP_MSG":
                    service.INSERT_SMT_SMS_RESP_MSG((LGService.TB_MT_SMS_RESP_MSG)entity);
                    break;
                case "TB_ORDER_SHIP_HIST":
                    service.INSERT_SORDER_SHIP_HIST((LGService.TB_ORDER_SHIP_HIST)entity);
                    break;
                case "TB_SN_CDC_HIST":
                    service.INSERT_SSN_CDC_HIST((LGService.TB_SN_CDC_HIST)entity);
                    break;
                case "TB_SN_PND_HIST":
                    service.INSERT_SSN_PND_HIST((LGService.TB_SN_PND_HIST)entity);
                    break;
                case "TB_SN_RDC_HIST":
                    service.INSERT_SSN_RDC_HIST((LGService.TB_SN_RDC_HIST)entity);
                    break;
                case "TB_SN_SO_DEALERS":
                    service.INSERT_SSN_SO_DEALERS((LGService.TB_SN_SO_DEALERS)entity);
                    break;
                case "TB_SN_SO_WT_HIST":
                    service.INSERT_SSN_SO_WT_HIST((LGService.TB_SN_SO_WT_HIST)entity);
                    break;
                case "TB_SN_SO_WT_MST":
                    service.INSERT_SSN_SO_WT_MST((LGService.TB_SN_SO_WT_MST)entity);
                    break;
                case "TB_SN_SO_WT_MST0":
                    service.INSERT_SSN_SO_WT_MST0((LGService.TB_SN_SO_WT_MST0)entity);
                    break;
            }
        }

        private char getkey(int index)
        {
            int tm = index % 4;
            switch (tm)
            {
                case 0:
                    return '|';
                case 1:
                    return '\\';
                case 2:
                    return '–';
                case 3:
                    return '/';
            }
            return '–';
        }
        #endregion
    }
}
