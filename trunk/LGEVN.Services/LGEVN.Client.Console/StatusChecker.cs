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
        private string table_pre = string.Empty;// "0_";
        /// <summary>
        /// Do this when timer check & fire
        /// </summary>
        /// <param name="stateInfo"></param>
        public void CheckStatus(Object stateInfo)
        {
            try
            {
                OracleDataHelper.ExecuteProcedure<HIEUNK_TEST>("PK_EDI_MST.PR_RESPONSE_WS_EDI", 
                new OracleParameter[]{
                     new OracleParameter { ParameterName = "P_WS_SHOP_CODE", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_WS_SHOP_KEY", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_SERIAL_NO", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_MODEL", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_SELL_DATE", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_EUCELL", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_EUNAME", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_EUADD", Value= string.Empty},
                     new OracleParameter { ParameterName = "P_REQUEST_TIME", Value= string.Empty},
                     new OracleParameter { ParameterName = "items_cursor", Direction = System.Data.ParameterDirection.Output, OracleType=OracleType.Cursor}
                });
                return;
                //1. TB_APP_ERROR
                var err_list = OracleDataHelper.GetNoTransfer<TB_APP_ERROR>(table_pre + "TB_APP_ERROR", "SO_TRANSFER_FLAG");
                Synchronize<TB_APP_ERROR, LGService.TB_APP_ERROR>(err_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "NAME", "MSG", "LINE", "CDATE", "CTIME" });

                //2. TB_CM_BILLTO_INF
                var blii_inf_list = OracleDataHelper.GetNoTransfer<TB_CM_BILLTO_INF>(table_pre + "TB_CM_BILLTO_INF", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_BILLTO_INF, LGService.TB_CM_BILLTO_INF>(blii_inf_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "BILLTO_CODE", "SHOP_CODE", "SHOP_NAME", "ADDRESS", "DIST_CODE", "PROVINCE_CODE", "CREATE_DATE", "UPDATE_DATE", "ISDN_NO", "CUSTOMER_CODE", "AREA_CODE", "OWNER_NAME", "OWNER_EMAIL", "USE_FLAG", "CHANNEL", "REG_ID", "CREATE_USER", "UPDATE_USER", "SHOP_TYPE" });

                //3. TB_CM_MODEL_CAT
                var model_cat_list = OracleDataHelper.GetNoTransfer<TB_CM_MODEL_CAT>(table_pre + "TB_CM_MODEL_CAT", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_MODEL_CAT, LGService.TB_CM_MODEL_CAT>(model_cat_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "PROD_L1", "MODEL", "CREATE_DATE", "SUFFIX", "MP_MODEL", "MP_SUFFIX", "ACTIVE_CODE", "SALE_FLAG", "PROD_L2", "PROD_L3", "PROD_L4", "TENTATIVE_FLAG", "MODEL_SPEC", "PUR_TYPE", "ENABLE_FLAG", "LAST_UPDATE_DATE", "UNIT", "AU_CODE", "AF_CODE", "EOM", "PROD_TYPE", "MKT", "IF_DATE" });

                //4. Get All uncheck Client
                var cm_mrp_list = OracleDataHelper.GetNoTransfer<TB_CM_MRP>(table_pre + "TB_CM_MRP", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_MRP, LGService.TB_CM_MRP>(cm_mrp_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "MODEL", "MRP", "CREATE_DATE" });

                //5. TB_CM_PROVINCE
                var cm_province_list = OracleDataHelper.GetNoTransfer<TB_CM_PROVINCE>(table_pre + "TB_CM_PROVINCE", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_PROVINCE, LGService.TB_CM_PROVINCE>(cm_province_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", "ID");

                //6. TB_CM_REGION
                var cm_region_list = OracleDataHelper.GetNoTransfer<TB_CM_REGION>(table_pre + "TB_CM_REGION", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_REGION, LGService.TB_CM_REGION>(cm_region_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", "ID");

                //7. TB_CM_SHOP_BILLTO
                var cm_shop_list = OracleDataHelper.GetNoTransfer<TB_CM_SHOP_BILLTO>(table_pre + "TB_CM_SHOP_BILLTO", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_SHOP_BILLTO, LGService.TB_CM_SHOP_BILLTO>(cm_shop_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "BILLTO_CODE", "SHOP_CODE", "CREATE_DATE", "MODIFY_DATE", "CREATE_USER", "MODIFY_USER", "USE_FLAG" });

                //8. TB_CM_SHOP_CELL
                var cm_cell_list = OracleDataHelper.GetNoTransfer<TB_CM_SHOP_CELL>(table_pre + "TB_CM_SHOP_CELL", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_SHOP_CELL, LGService.TB_CM_SHOP_CELL>(cm_cell_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", "SHOP_CELL");

                //9. TB_CM_SHOP_INF
                var cm_inf_list = OracleDataHelper.GetNoTransfer<TB_CM_SHOP_INF>(table_pre + "TB_CM_SHOP_INF", "SO_TRANSFER_FLAG");
                Synchronize<TB_CM_SHOP_INF, LGService.TB_CM_SHOP_INF>(cm_inf_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", "SHOP_CODE");

                //10. TB_MO_HIST
                var cm_mo_list = OracleDataHelper.GetNoTransfer<TB_MO_HIST>(table_pre + "TB_MO_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_MO_HIST, LGService.TB_MO_HIST>(cm_mo_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "SHORTCODE", "MOSEQ", "CMDCODE", "MSGBODY", "RECEIVE_TIME", "FILENAME", "FILEDATE", "TRANSFER_FLAG", "TRANSFER_DATE" });

                //11. TB_MT_HIST
                var cm_mt_list = OracleDataHelper.GetNoTransfer<TB_MT_HIST>(table_pre + "TB_MT_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_MT_HIST, LGService.TB_MT_HIST>(cm_mt_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "MOSEQ", "SHORTCODE", "CELL_NO", "MSGBODY", "MSGTYPE", "SEND_FLAG", "CMDCODE" });

                //12. TB_MT_SMS_RESP_MSG
                var cm_sms_list = OracleDataHelper.GetNoTransfer<TB_MT_SMS_RESP_MSG>(table_pre + "TB_MT_SMS_RESP_MSG", "SO_TRANSFER_FLAG");
                Synchronize<TB_MT_SMS_RESP_MSG, LGService.TB_MT_SMS_RESP_MSG>(cm_sms_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", "RESP_TYPE");

                //13. TB_ORDER_SHIP_HIST
                var cm_ship_list = OracleDataHelper.GetNoTransfer<TB_ORDER_SHIP_HIST>(table_pre + "TB_ORDER_SHIP_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_ORDER_SHIP_HIST, LGService.TB_ORDER_SHIP_HIST>(cm_ship_list, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "INV_ORG", "SHIPTO_CODE", "ORDER_NO", "LINE_NO", "ORDER_QTY", "RELEASE_QTY", "REQUEST_ARRIVAL_DATE", "MODEL", "SUFFIX" });

                //14. TB_SN_CDC_HIST
                var list14 = OracleDataHelper.GetNoTransfer<TB_SN_CDC_HIST>(table_pre + "TB_SN_CDC_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_CDC_HIST, LGService.TB_SN_CDC_HIST>(list14, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "INV_ORG", "ORDER_NO", "SHIPTO_CODE", "MODEL", "SERIAL_NO", "SUFFIX" });

                //15. TB_SN_PND_HIST
                var list15 = OracleDataHelper.GetNoTransfer<TB_SN_PND_HIST>(table_pre + "TB_SN_PND_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_PND_HIST, LGService.TB_SN_PND_HIST>(list15, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "SERIAL_NO", "PND_TYPE" });

                //16. TB_SN_RDC_HIST
                var list16 = OracleDataHelper.GetNoTransfer<TB_SN_RDC_HIST>(table_pre + "TB_SN_RDC_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_RDC_HIST, LGService.TB_SN_RDC_HIST>(list16, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "INV_ORG", "EDI_NO", "SERIAL_NO", "MODEL", "SUFFIX", "OUT_DATE" });

                //17. TB_SN_SO_WT_HIST
                var list17 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_HIST>(table_pre + "TB_SN_SO_WT_HIST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_HIST, LGService.TB_SN_SO_WT_HIST>(list17, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "SERIAL_NO", "MODEL", "END_USER_CELL", "SHOP_CODE", "SHOP_CELL", "RECEIVE_DATE", "MOSEQ", "CMDCODE", "RESP_TYPE", "RESP_MSG", "MO_MSGBODY", "SMS_YN", "CREATE_DATE", "SUCCESS_FLAG", "EDI_FILE", "EDI_HEAD" });


                //18. TB_SN_SO_WT_MST
                var list18 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_MST>(table_pre + "TB_SN_SO_WT_MST", "SO_TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_MST, LGService.TB_SN_SO_WT_MST>(list18, "SO_TRANSFER_FLAG", "SO_TRANSFER_DATE", new string[] { "SERIAL_NO", "SELLIN_DATE", "SELLOUT_DATE", "WT_START_DATE", "WT_END_DATE", "SHOP_CODE", "SHOP_CELL", "SELLOUT_RESP_MSG", "POINT", "AMT", "SELLOUT_RESP_TYPE", "SELLOUT_TIME", "INCENTIVE_CFM_FLAG", "INCENTIVE_CFM_DATE", "MODEL", "SUFFIX", "CLOSE_FLAG", "CLOSE_PERIOD", "SMS_YN", "CREATE_DATE", "INCENTIVE_CFM_USER", "CLOSE_USER", "INCENTIVE_CFM_PERIOD", "LAST_UPDATE_DATE", "END_USER_CELL", "TRANSFER_FLAG", "TRANSFER_DATE" });


                //19. TB_SN_SO_WT_MST0
                var list19 = OracleDataHelper.GetNoTransfer<TB_SN_SO_WT_MST0>(table_pre + "TB_SN_SO_WT_MST0", "TRANSFER_FLAG");
                Synchronize<TB_SN_SO_WT_MST0, LGService.TB_SN_SO_WT_MST0>(list19, "TRANSFER_FLAG", "TRANSFER_DATE", new string[] { "MODEL", "SUFFIX", "SERIAL_NO", "WT_START_DATE", "WT_END_DATE", "END_USER_CELL", "WT_RESP_MSG", "WT_RESP_TYPE", "SMS_YN", "CREATE_DATE", "WT_CFM_USER", "LAST_UPDATE_DATE", "SELLIN_DATE", "SELLOUT_DATE", "SELLOUT_TIME" });

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("\n\n");
                System.Console.WriteLine(ex.Message);
            }
        }

        private void Synchronize<TSource, TDest>(IEnumerable<TSource> cm_mrp_list, string flag, string date, params string[] keys)
        {
            //Get property infor of key field
            Type myTypeS = typeof(TSource);
            Type myTypeD = typeof(TDest);

            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("                         BEGIN SYNCHRONIZE " + myTypeS.Name);
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
                    OracleDataHelper.ExecuteFlag<TSource>(item, table_pre + myTypeS.Name, flag, date, keys);
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
        private bool CallWebservice<TEntity>(object entity)
        {
            Type myTypeS = typeof(TEntity);
            string name = myTypeS.Name.ToUpper();
            LGService.LgeService service = new LGService.LgeService();
            service.Url = ConfigurationManager.AppSettings["ServiceURL"];
            bool result = false;
            switch (name)
            {
                case "TB_APP_ERROR":
                    result = service.INSERT_SAPP_ERROR((LGService.TB_APP_ERROR)entity);
                    break;
                case "TB_CM_BILLTO_INF":
                    result = service.INSERT_SCM_BILLTO_INF((LGService.TB_CM_BILLTO_INF)entity);
                    break;
                case "TB_CM_MODEL_CAT":
                    result = service.INSERT_SCM_MODEL_CAT((LGService.TB_CM_MODEL_CAT)entity);
                    break;
                case "TB_CM_MRP":
                    var obj = (LGService.TB_CM_MRP)entity;
                    if (obj.CREATE_DATE == null) obj.CREATE_DATE = DateTime.Now;
                    if (obj.SO_TRANSFER_DATE == null) obj.SO_TRANSFER_DATE = DateTime.Now;
                    result = service.INSERT_TB_CM_MRP(obj);
                    break;
                case "TB_CM_PROVINCE":
                    result = service.INSERT_TB_CM_PROVINCE((LGService.TB_CM_PROVINCE)entity);
                    break;
                case "TB_CM_REGION":
                    result = service.INSERT_TB_CM_REGION((LGService.TB_CM_REGION)entity);
                    break;
                case "TB_CM_SHIPTO_INF":
                    result = service.INSERT_SCM_SHIPTO_INF((LGService.TB_CM_SHIPTO_INF)entity);
                    break;
                case "TB_CM_SHOP_BILLTO":
                    result = service.INSERT_SCM_SHOP_BILLTO((LGService.TB_CM_SHOP_BILLTO)entity);
                    break;
                case "TB_CM_SHOP_CELL":
                    result = service.INSERT_TB_CM_SHOP_CELL((LGService.TB_CM_SHOP_CELL)entity);
                    break;
                case "TB_CM_SHOP_INF":
                    result = service.INSERT_SCM_SHOP_INF((LGService.TB_CM_SHOP_INF)entity);
                    break;
                case "TB_EDI_RESULT":
                    result = service.INSERT_SEDI_RESULT((LGService.TB_EDI_RESULT)entity);
                    break;
                case "TB_MO_HIST":
                    result = service.INSERT_SMO_HIST((LGService.TB_MO_HIST)entity);
                    break;
                case "TB_MT_HIST":
                    result = service.INSERT_SMT_HIST((LGService.TB_MT_HIST)entity);
                    break;
                case "TB_MT_SMS_RESP_MSG":
                    result = service.INSERT_SMT_SMS_RESP_MSG((LGService.TB_MT_SMS_RESP_MSG)entity);
                    break;
                case "TB_ORDER_SHIP_HIST":
                    result = service.INSERT_SORDER_SHIP_HIST((LGService.TB_ORDER_SHIP_HIST)entity);
                    break;
                case "TB_SN_CDC_HIST":
                    var obj2 = (LGService.TB_SN_CDC_HIST)entity;
                    if (obj2.SO_TRANSFER_DATE == null) obj2.SO_TRANSFER_DATE = DateTime.Now;
                    result = service.INSERT_SSN_CDC_HIST(obj2);
                    break;
                case "TB_SN_PND_HIST":
                    result = service.INSERT_SSN_PND_HIST((LGService.TB_SN_PND_HIST)entity);
                    break;
                case "TB_SN_RDC_HIST":
                    result = service.INSERT_SN_RDC_HIST((LGService.TB_SN_RDC_HIST)entity);
                    break;
                case "TB_SN_SO_DEALERS":
                    result = service.INSERT_SSN_SO_DEALERS((LGService.TB_SN_SO_DEALERS)entity);
                    break;
                case "TB_SN_SO_WT_HIST":
                    result = service.INSERT_SSN_SO_WT_HIST((LGService.TB_SN_SO_WT_HIST)entity);
                    break;
                case "TB_SN_SO_WT_MST":
                    result = service.INSERT_SSN_SO_WT_MST((LGService.TB_SN_SO_WT_MST)entity);
                    break;
                case "TB_SN_SO_WT_MST0":
                    result = service.INSERT_SSN_SO_WT_MST0((LGService.TB_SN_SO_WT_MST0)entity);
                    break;
            }
            return result;
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
