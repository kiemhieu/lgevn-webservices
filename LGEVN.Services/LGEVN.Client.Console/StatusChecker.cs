﻿using LGEVN.Services.Implement;
using System;
using System.Collections.Generic;
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
            //1. Get All uncheck Client
            var cm_mrp_list = OracleDataHelper.GetNoTransfer<TB_CM_MRP>("TB_CM_MRP", "SO_TRANSFER_FLAG");
            //1. Synchronize to server
            Synchronize<TB_CM_MRP, LGService.TB_CM_MRP>(cm_mrp_list);
        }

        private void Synchronize<TSource, TDest>(IEnumerable<TSource> cm_mrp_list)
        {
            Dictionary<string, string> dictkey = new Dictionary<string, string>();
            //Get dict of params

            //Get property infor of key field
            Type myTypeS = typeof(TSource);
            Type myTypeD = typeof(TDest);
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
                        linesPrint.Add(infD.Name.PadRight(20) + " = " + valueS.ToString());
                    }

                    CallWebservice<TDest>(entity);
                    //int id = OracleDataHelper.ExecuteProcedure("PKG_WEBSERVICE.ADD_HIEUNK_TEST", colllection);

                    //3. Update flag to Client
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
                    Thread.Sleep(20);
                }
                catch { }
            }
            System.Console.WriteLine("\r{0}",
                                     "---------------------------------------------------------------------------");
            System.Console.WriteLine("------------------------------ END TB_CM_MRP ------------------------------");
            System.Console.WriteLine("---------------------------------------------------------------------------");
        }

        private void CallWebservice<TEntity>(object entity)
        {
            Type myTypeS = typeof(TEntity);
            string name = myTypeS.Name.ToUpper();
            LGService.LgeService service = new LGService.LgeService();
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
                    service.INSERT_TB_CM_MRP((LGService.TB_CM_MRP)entity);
                    break;
                case "TB_CM_PROVINCE":
                    //service.INSERT_SCM_PROVINCEP((LGService.TB_CM_PROVINCE)entity);
                    break;
                case "TB_CM_REGION":
                    //service.INSERT_TB_CM_REGION((LGService.TB_CM_REGION)entity);
                    break;
                case "TB_CM_SHIPTO_INF":
                    service.INSERT_SCM_SHIPTO_INF((LGService.TB_CM_SHIPTO_INF)entity);
                    break;
                case "TB_CM_SHOP_BILLTO":
                    service.INSERT_SCM_SHOP_BILLTO((LGService.TB_CM_SHOP_BILLTO)entity);
                    break;
                case "TB_CM_SHOP_CELL":
                    //service.INSERT_CM_SHOP_CELL((LGService.TB_CM_SHOP_CELL)entity);
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
    }
}