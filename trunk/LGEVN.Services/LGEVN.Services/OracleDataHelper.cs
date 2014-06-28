using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Reflection;

namespace LGEVN.Services
{
    public class OracleDataHelper
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
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


        // <summary>
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

        public static bool InsertEntity<TEntity>(TEntity entity, string table_name)
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
                            object value = inf.GetValue(entity, null);
                            if (value == null) continue;
                            string proname = inf.Name;
                            if (sInto != string.Empty)
                            {
                                sInto += ", ";
                                sValue += ", ";
                            }

                            sValue += ":p_" + proname;
                            sInto += proname;
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
            }
            return true;
        }
    }
}