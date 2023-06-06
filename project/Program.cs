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

            entityFramework.Add(myComputer);
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
            + "')";

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            // bool result = dapper.ExecuteSql(sql);
            // Console.WriteLine(result);

            string sqlSelect = @"SELECT
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            foreach (Computer singleComputer in computers) {
                Console.WriteLine("'" + singleComputer.ComputerId
                + "', '" + singleComputer.Motherboard
                + "', '" + singleComputer.HasWifi
                + "', '" + singleComputer.HasLTE
                + "', '" + singleComputer.ReleaseDate
                + "', '" + singleComputer.Price
                + "', '" + singleComputer.VideoCard + "'");
            }
            Console.WriteLine();

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if(computersEf != null){
                Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
                foreach (Computer singleComputer in computersEf) {
                    Console.WriteLine("'" + singleComputer.ComputerId
                    + "', '" + singleComputer.Motherboard
                    + "', '" + singleComputer.HasWifi
                    + "', '" + singleComputer.HasLTE
                    + "', '" + singleComputer.ReleaseDate
                    + "', '" + singleComputer.Price
                    + "', '" + singleComputer.VideoCard + "'");
                }
                Console.WriteLine();
            }
        }
    }
}