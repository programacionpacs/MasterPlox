using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPlox.DAL
{
    class DataAccess
    {

        #region Singleton

        private static volatile DataAccess instance = null;
        private static readonly object padlock = new object();
        public string InitialCatalog = "";
        private string conString = "Server=LAPTOP-4T0FBODR\\JASI;Database=SimiDB;User Id=pacs;Password=pacs;";

        private DataAccess()
        {

        }
        public static DataAccess Instance()
        {
            if (instance == null)

                lock (padlock)
                    if (instance == null)
                        instance = new DataAccess();
            return instance;

        }
        #endregion
        #region Query/Execute Dapper
        public T QuerySingle<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
        }


        public T QuerySingle<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
        }


        public T QuerySingleOrDefault<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
        }

        public T QuerySingleOrDefault<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
        }

        public string QueryString(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<string>(query, commandType: CommandType.StoredProcedure, commandTimeout: 3000);

        }
        public string QueryString(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<string>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);

        }

        public List<T> Query<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.Query<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 3000).ToList();

        }
        public List<T> Query<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.Query<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000).ToList();

        }

        public int Insert(string query, DynamicParameters dynamicParameters, string fieldName)
        {
            using (var con = new SqlConnection(conString))
                return (int)((IDictionary<string, object>)con.QuerySingle(query, dynamicParameters, commandType:
                    CommandType.StoredProcedure, commandTimeout: 300))[fieldName];
        }

        public int Execute(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, commandType: CommandType.StoredProcedure, commandTimeout: 3000);

        }

        public int Execute(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);

        }
        #endregion

    }
}
