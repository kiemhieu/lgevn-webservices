using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGEVN.SMS.Console
{
    public class SendSMS
    {
        int smsindex = 1;
        public void CheckSMSStatus(Object stateInfo)
        {
            try
            {
                var _url = ConfigurationManager.AppSettings["ServiceURL"];
                var _user = ConfigurationManager.AppSettings["wsUser"];
                var _pass = ConfigurationManager.AppSettings["wsPwd"];

                var connstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                var ws = new LG.SMS.Service();
                ws.Url = _url;

                var sql = " SELECT    moseq " +
                                    ",shortcode " +
                                    ",cell_no " +
                                    ",msgbody " +
                                    ",msgtype " +
                                    ",mttotalseq " +
                                    ",mtseqref " +
                                    ",cpid" +
                                    " FROM  tb_mt_hist " +
                                    " WHERE send_flag  ='N' AND ROWNUM <=100";
                var oradbConnection = new OracleConnection(connstring);
                var sqlcmd = new OracleCommand(sql, oradbConnection);
                var _dataAdapter = new OracleDataAdapter();
                _dataAdapter.SelectCommand = sqlcmd;
                var _dataTable = new DataTable();
                _dataAdapter.Fill(_dataTable);
                StringBuilder rtbLog = new StringBuilder();
                sql = string.Empty;

                int count = (_dataTable.Rows == null ? 0 : _dataTable.Rows.Count);
                //Task[] tasks = new Task[] { };
                //if (count > 0) Array.Resize(ref tasks, count);
                int index = 0;
                for (index = 0; index < count; index++ )
                {
                    int idtm = index;

                    //Application.DoEvents();
                    //    Dim _mt_send_datetime = Format(Date.Now, "MMddyyyyHHmmss")
                    //tasks[idtm] = Task.Factory.StartNew(() =>
                    {
                        DataRow _row = _dataTable.Rows[idtm];
                        System.Console.WriteLine("<==============================MT sending==============================>");
                        System.Console.WriteLine("MT started : " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " to " + (_row["cell_no"] == null ? string.Empty : _row["cell_no"].ToString()));

                        var _result = ws.SendMT((_row["moseq"] == null ? string.Empty : _row["moseq"].ToString()),
                                                (_row["shortcode"] == null ? string.Empty : _row["shortcode"].ToString()),
                                                (_row["cell_no"] == null ? string.Empty : _row["cell_no"].ToString()),
                                                (_row["msgbody"] == null ? string.Empty : _row["msgbody"].ToString()),
                                                (_row["msgtype"] == null ? string.Empty : _row["msgtype"].ToString()),
                                                (_row["mttotalseq"] == null ? string.Empty : _row["mttotalseq"].ToString()),
                                                (_row["mtseqref"] == null ? string.Empty : _row["mtseqref"].ToString()),
                                                (_row["cpid"] == null ? string.Empty : _row["cpid"].ToString()),
                                                "1",
                                                _user,
                                                _pass);
                        //int _result = 200;
                        byte attemp = 1;
                        int mo_cnt = 0;
                        do
                        {
                            var _mt_sent_datetime = DateTime.Now.ToString("MMddyyyyHHmmss");
                            if (attemp <= 3)
                            {
                                if (_result == 200)
                                {
                                    sql = " UPDATE tb_mt_hist SET send_flag   ='Y', " +
                                                                " result      ='" + _result.ToString() + "'," +
                                                                " send_time   ='" + _mt_sent_datetime + "', " +
                                                                " finish_time ='" + _mt_sent_datetime + "' " +
                                          " WHERE                 moseq       ='" + (_row["moseq"] == null ? string.Empty : _row["moseq"].ToString()) + "'";

                                    System.Console.WriteLine("Success :" + (_row["msgbody"] == null ? string.Empty : _row["msgbody"].ToString()) + "=>" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                                    break;
                                }
                                else
                                {
                                    sql = " UPDATE tb_mt_hist SET result    ='" + _result.ToString() + "', " +
                                                                " send_time ='" + _mt_sent_datetime + "'" +
                                          " WHERE                 moseq     ='" + (_row["moseq"] == null ? string.Empty : _row["moseq"].ToString()) + "'";
                                    System.Console.WriteLine("Fail : " + (_row["msgbody"] == null ? string.Empty : _row["msgbody"].ToString()) + "=>" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                                    attemp++;
                                }
                            }
                            else
                            {
                                sql = " UPDATE tb_mt_hist SET send_flag   ='Y', " +
                                                                " result      ='" + _result.ToString() + "'," +
                                                                " send_time   ='" + _mt_sent_datetime + "', " +
                                                                " finish_time ='" + _mt_sent_datetime + "' " +
                                          " WHERE                 moseq       ='" + (_row["moseq"] == null ? string.Empty : _row["moseq"].ToString()) + "'";
                                System.Console.WriteLine("Fail : " + (_row["msgbody"] == null ? string.Empty : _row["msgbody"].ToString()) + "=>" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                                break;
                            }
                            mo_cnt++;
                        } while (attemp == 5);

                        mo_cnt++;
                        System.Console.WriteLine("...done, cnt : " + mo_cnt.ToString());
                        var oradbConnectionSub = new OracleConnection(connstring);
                        oradbConnectionSub.Open();
                        using (var sqlcmdsub = new OracleCommand(sql, oradbConnectionSub))
                        {
                            sqlcmdsub.CommandType = CommandType.Text;
                            sqlcmdsub.ExecuteNonQuery();
                        }
                        oradbConnectionSub.Close();
                        oradbConnectionSub.Dispose();
                    }//);
                }
                //Task.WaitAll(tasks);
                sqlcmd.Dispose();
                _dataAdapter.Dispose();
                _dataTable.Dispose();
                oradbConnection.Close();
                oradbConnection.Dispose();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("<==========================MT sending errors===============================>");
                System.Console.WriteLine(ex.Message + ", " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            }
            string stt = smsindex.ToString();
            if (smsindex % 10 == 1) stt += "ST";
            else if (smsindex % 10 == 2) stt += "ND";
            else if (smsindex % 10 == 3) stt += "RD";
            else stt += "TH";
            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("---------------------- END SMS CONSOLE APPLICATION AT " + stt.PadRight(21, '-'));
            System.Console.WriteLine("---------------------------------------------------------------------------");
            System.Console.WriteLine("\n\n");
            smsindex++;
            //reset index
            if (smsindex > 1000000) smsindex = 0;
            System.Console.Read();
        }
    }
}
