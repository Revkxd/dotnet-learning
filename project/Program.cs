using System;
using project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace project {
    public class Program {
        static void Main(string[] args) {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            string sqlCommand = "SELECT GETDATE()";
            DateTime rightnow = dbConnection.QuerySingle<DateTime>(sqlCommand);
            Console.WriteLine(rightnow);

            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.ReleaseDate);
            // Console.WriteLine(myComputer.VideoCard);
        }
    }
}