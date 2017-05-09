using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SpecialOrderTaxUtility.Classes
{
    public static class Db
    {
        public static string Server = "localhost";
        public static string db = "database";
        private const string Pw = "password";
        private const string Id = "sa";
        //public static string m = "master";

        public static SqlConnection GetConn()
        {
            return new SqlConnection(GetConString());
        }
        public static object Query(string sql)
        {
            using (var conn = new SqlConnection(GetConString()))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static void NonQuery(string sql)
        {
            using (var sqlconn = new SqlConnection(GetConString()))
            {
                using (var sqlcmd = new SqlCommand(sql, sqlconn))
                {
                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                }
            }
        }

        private static string GetConString()
        {
            return $"Server={Server}; Database={db}; User Id={Id}; Password={Pw}";
        }
    }
}