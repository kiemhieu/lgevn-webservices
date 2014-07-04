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
                        foreach (OracleParameter param in parameters) command.Parameters.AddWithValue(param.ParameterName, param.Value);
                    result = command.ExecuteNonQuery();
                }
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
                        foreach (OracleParameter param in parameters) command.Parameters.Add(param);
                    var reader = command.ExecuteReader();
                    if (typeof(TEntity).IsClass)
                        result = AutoMapper.Mapper.DynamicMap<IDataReader, IEnumerable<TEntity>>(reader);
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
            string a = ConnectionString;
            IEnumerable<TEntity> result = null;
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM \"" + table_name + "\" WHERE (" + flag + " IS NULL OR " + flag + " = 'N')  AND ROWNUM <=100";

                    var reader = command.ExecuteReader();
                    if (typeof(TEntity).IsClass)
                        result = AutoMapper.Mapper.DynamicMap<IDataReader, IEnumerable<TEntity>>(reader);
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

            string query = "UPDATE \"" + table_name + "\" SET " + flag + "='Y' " + datestruct + " WHERE ";

            Dictionary<string, string> dictkey = new Dictionary<string, string>();
            //Get dict of params
            foreach (var key in keysfield)
            {
                dictkey.Add(key.ToUpper(), key.ToUpper());
            }
            string swhere = "";
            //Get property infor of key field
            Type myType = typeof(TEntity);
            var props = myType.GetProperties();
            List<OracleParameter> param_where = new List<OracleParameter>();

            foreach (var inf in props)
            {
                string proname = inf.Name;
                if (dictkey.ContainsKey(proname.ToUpper()))
                {
                    var val = inf.GetValue(entity, null);
                    if (val == null) continue;
                    if (swhere != string.Empty) swhere += " AND ";
                    swhere += proname + "=:p_" + proname; //"='" + val.ToString() + "'";
                    param_where.Add(new OracleParameter("p_" + proname, val));
                }
            }
            query += swhere;

            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    if (!string.IsNullOrEmpty(date)) command.Parameters.Add("p_" + date, DateTime.Now);
                    foreach (var param in param_where) command.Parameters.Add(param);
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static TEntity ExecuteFunction<TEntity>(string FunctionName, params OracleParameter[] parameters)
        {
            var returnParam = new OracleParameter { ParameterName = "p_ReturnValue", Size=256, Direction = System.Data.ParameterDirection.ReturnValue };
            TEntity result = default(TEntity);
            using (var conn = new OracleConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = FunctionName;
                    if (parameters != null)
                        foreach (OracleParameter param in parameters) command.Parameters.Add(param);
                    command.Parameters.Add(returnParam);
                    var reader = command.ExecuteNonQuery();
                    result = AutoMapper.Mapper.DynamicMap<object, TEntity>(command.Parameters["p_ReturnValue"].Value);
                }
            }
            return result;
        }
    }
}