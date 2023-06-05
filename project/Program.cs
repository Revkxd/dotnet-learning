using System;
using project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using project.Data;

namespace project {
    public class Program {
        static void Main(string[] args) {
            DataContextDapper dapper = new DataContextDapper();

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
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach (Computer computer in computers) {
                Console.WriteLine(computer.Motherboard);
                Console.WriteLine(computer.HasWifi);
                Console.WriteLine(computer.HasLTE);
                Console.WriteLine(computer.ReleaseDate);
                Console.WriteLine(computer.Price);
                Console.WriteLine(computer.VideoCard);
                Console.WriteLine();
            }
        }
    }
}