using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace project.Data {
    public class DataContextDapper
    {
        private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True";

        public IEnumerable<T> LoadData<T>(string sql) 
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql) 
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql) > 0;
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }
}