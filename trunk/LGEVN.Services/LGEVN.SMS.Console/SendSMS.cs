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
                                    " WHERE send_flag  ='N'";
                var oradbConnection = new OracleConnection(connstring);
                var sqlcmd = new OracleCommand(sql, oradbConnection);
                var _dataAdapter = new OracleDataAdapter();
                _dataAdapter.SelectCommand = sqlcmd;
                var _dataTable = new DataTable();
                _dataAdapter.Fill(_dataTable);
                StringBuilder rtbLog = new StringBuilder();
                sql = string.Empty;
                foreach (DataRow _row in _dataTable.Rows)
                {
                    //Application.DoEvents();
                    //    Dim _mt_send_datetime = Format(Date.Now, "MMddyyyyHHmmss")

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
                    sqlcmd.Dispose();
                    sqlcmd.Clone();
                    sqlcmd = new OracleCommand(sql, oradbConnection);
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.ExecuteNonQuery();
                }
                sqlcmd.Dispose();
                _dataAdapter.Dispose();
                _dataTable.Dispose();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("<==========================MT sending errors===============================>");
                System.Console.WriteLine(ex.Message + ", " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            }
            System.Console.Read();
        }
    }
}
