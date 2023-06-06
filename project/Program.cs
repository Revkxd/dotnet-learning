using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using project.Models;
using project.Data;

namespace project {
    public class Program {
        static void Main(string[] args) {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            DataContextDapper dapper = new DataContextDapper(configuration);
            DataContextEF entityFramework = new DataContextEF(configuration);

            DateTime rightnow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
            Console.WriteLine(rightnow);

            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            // entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                + "', '" + myComputer.HasWifi
                + "', '" + myComputer.HasLTE
                + "', '" + myComputer.ReleaseDate
                + "', '" + myComputer.Price
                + "', '" + myComputer.VideoCard
            + "')\n";

            File.WriteAllText("log.txt", sql);

            using StreamWriter openFile = new ("log.txt", append:true);
            openFile.WriteLine(sql);
            openFile.Close();

            Console.WriteLine(File.ReadAllText("log.txt"));
        }
    }
}