using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Reflection;

namespace LGEVN.Client.Console
{
    public class OracleDataHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        /// <summary>
        /// Exec a procedure in oracle
        /// </summary>
        /// <param name="StoreName">Name (with namespace) of Store procedure</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteProcedure(string StoreName, params OracleParameter[] parameters)
        {
            int result = -1;
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = StoreName;
                    if (parameters != null)
                        foreach (OracleParameter param in parameters) command.Parameters.Add(param);
                    result = command.ExecuteNonQuery();
                }
                conn.Close();
            }
            return result;
        }


        /// <summary>
        /// Exec a procedure in oracle
        /// </summary>
        /// <param name="StoreName">Name (with namespace) of Store procedure</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteProcedure(string StoreName, OracleParameterCollection parameters)
        {
            int result = -1;
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = StoreName;
                    if (parameters != null)
                    {
                        foreach (OracleParameter param in parameters)
                        {
                            if (param.Value == null) param.Value = System.DBNull.Value;
                            command.Parameters.AddWithValue(param.ParameterName, param.Value);
                        }
                    }
                    result = command.ExecuteNonQuery();
                }
                conn.Close();
            }
            return result;
        }


        /// <summary>
        /// Exec a storeprocedure with returl db table map value
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="StoreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> ExecuteProcedure<TEntity>(string StoreName, params OracleParameter[] parameters) //where TEntity : class
        {

            Type myType = typeof(TEntity);
            var prop = myType.GetProperties();

            IEnumerable<TEntity> result = null;
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = StoreName;
                    if (parameters != null)
                    {
                        foreach (OracleParameter param in parameters)
                        {
                            if (param.Value == null) param.Value = System.DBNull.Value;
                            command.Parameters.Add(param);
                        }
                    }

                    var reader = command.ExecuteReader();
                    if (typeof(TEntity).IsClass)
                    // result = AutoMapper.Mapper.DynamicMap<IDataReader, IEnumerable<TEntity>>(reader);
                    {
                        List<TEntity> lst = new List<TEntity>();
                        while (reader.Read())
                        {
                            var entity = (TEntity)Activator.CreateInstance(myType);
                            foreach (var inf in prop)
                            {
                                object value = reader[inf.Name];
                                if (value == System.DBNull.Value) continue;
                                inf.SetValue(entity, value, null);
                            }
                            lst.Add(entity);
                        }
                        if (lst.Count != 0) result = lst;
                    }
                    else
                    {
                        List<TEntity> lst = new List<TEntity>();
                        while (reader.Read())
                        {
                            // get the results of each column
                            TEntity item = (TEntity)reader[0];
                            lst.Add(item);
                        }
                        if (lst.Count != 0) result = lst;
                    }
                }
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Exec a storeprocedure with returl db table map value
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="StoreName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> GetNoTransfer<TEntity>(string table_name, string flag) //where TEntity : class
        {
            Type myType = typeof(TEntity);
            var prop = myType.GetProperties();

            // string a = ConnectionString;
            IEnumerable<TEntity> result = null;
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM \"" + table_name + "\" WHERE (" + flag + " IS NULL OR " + flag + " = 'N') AND ROWNUM <=100";

                    var reader = command.ExecuteReader();
                    if (typeof(TEntity).IsClass)
                    //result = AutoMapper.Mapper.DynamicMap<IDataReader, IEnumerable<TEntity>>(reader);
                    {
                        List<TEntity> lst = new List<TEntity>();
                        while (reader.Read())
                        {
                            var entity = (TEntity)Activator.CreateInstance(myType);
                            foreach (var inf in prop)
                            {
                                string table_column = inf.Name;
                                if (table_column == "CELL_NO_1") table_column = "CELL_NO#1";
                                else if (table_column == "CELL_NO_2") table_column = "CELL_NO#2";
                                if (table_column == "RESP_MSG_1") table_column = "RESP_MSG#1";
                                else if (table_column == "RESP_MSG_2") table_column = "RESP_MSG#2";
                                object value = reader[table_column];
                                if (value == System.DBNull.Value) continue;
                                inf.SetValue(entity, value, null);
                            }
                            lst.Add(entity);
                        }
                        if (lst.Count != 0) result = lst;
                    }
                    else
                    {
                        List<TEntity> lst = new List<TEntity>();
                        while (reader.Read())
                        {
                            // get the results of each column
                            TEntity item = (TEntity)reader[0];
                            lst.Add(item);
                        }
                        if (lst.Count != 0) result = lst;
                    }
                }
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Exec a procedure in oracle
        /// </summary>
        /// <param name="StoreName">Name (with namespace) of Store procedure</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteFlag<TEntity>(TEntity entity, string table_name, string flag, string date, params string[] keysfield)
        {
            int result = -1;
            string datestruct = string.Empty;
            if (!string.IsNullOrEmpty(date)) datestruct = "," + date + "=" + ":p_" + date;

            string query = "UPDATE \"" + table_name + "\" SET " + flag + "='Y' " + datestruct;

            Dictionary<string, string> dictkey = new Dictionary<string, string>();
            //Get dict of params
            foreach (var key in keysfield)
            {
                dictkey.Add(key.ToUpper(), key.ToUpper());
            }
            string swhere = "";
            string sSet = "";
            //Get property infor of key field
            Type myType = typeof(TEntity);
            var props = myType.GetProperties();
            List<OracleParameter> param_where = new List<OracleParameter>();
            List<OracleParameter> param_set = new List<OracleParameter>();
            foreach (var inf in props)
            {
                string proname = inf.Name;
                var val = inf.GetValue(entity, null);
                if (val == null) continue;

                if (dictkey.ContainsKey(proname.ToUpper()))
                {
                    if (swhere != string.Empty) swhere += " AND ";
                    swhere += proname + "=:p_" + proname;
                    param_where.Add(new OracleParameter("p_" + proname, val));
                }
                else if (proname.ToUpper() != flag.ToUpper() && proname.ToUpper() != date.ToUpper())
                {
                    string table_column = proname;
                    if (table_column == "CELL_NO_1") table_column = "CELL_NO#1";
                    else if (table_column == "CELL_NO_2") table_column = "CELL_NO#2";

                    if (table_column == "RESP_MSG_1") table_column = "RESP_MSG#1";
                    else if (table_column == "RESP_MSG_2") table_column = "RESP_MSG#2";

                    sSet += ",\"" + table_column + "\"=:p_" + proname;
                    param_set.Add(new OracleParameter("p_" + proname, val));
                }
            }
            query += sSet + " WHERE " + swhere;

            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    foreach (var param in param_set) command.Parameters.Add(param);
                    if (!string.IsNullOrEmpty(date)) command.Parameters.Add("p_" + date, DateTime.Now);
                    foreach (var param in param_where) command.Parameters.Add(param);
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    result = command.ExecuteNonQuery();
                }
                conn.Close();
            }
            return result;
        }

        public static bool InsertEntity<TEntity>(object entity, string table_name)
        {
            string sInto = "", sValue = "";
            //Get property infor of key field
            Type myType = typeof(TEntity);
            var props = myType.GetProperties();
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    try
                    {
                        foreach (var inf in props)
                        {
                            string proname = inf.Name;
                            object value = inf.GetValue(entity, null);
                            if (value == null && proname.ToUpper() != "SO_TRANSFER_FLAG" && proname.ToUpper() != "SO_TRANSFER_DATE") continue;

                            string table_column = inf.Name;
                            if (table_column == "CELL_NO_1") table_column = "CELL_NO#1";
                            else if (table_column == "CELL_NO_2") table_column = "CELL_NO#2";

                            if (table_column == "RESP_MSG_1") table_column = "RESP_MSG#1";
                            else if (table_column == "RESP_MSG_2") table_column = "RESP_MSG#2";

                            if (proname == "SO_TRANSFER_DATE") value = DateTime.Now;
                            if (proname == "SO_TRANSFER_FLAG") value = "Y";

                            if (sInto != string.Empty)
                            {
                                sInto += ", ";
                                sValue += ", ";
                            }

                            sValue += ":p_" + proname;
                            sInto += table_column;
                            var param = new OracleParameter("p_" + proname, value);
                            command.Parameters.Add(param);
                        }
                        string query = "INSERT INTO " + table_name + "(" + sInto + ") VALUES (" + sValue + ")";
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("ORA-00001")) return true;
                        return false;
                    }
                }
                conn.Close();
            }
            return true;
        }
    }
}