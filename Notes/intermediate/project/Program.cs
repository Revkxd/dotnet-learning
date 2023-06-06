using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using project.Models;
using project.Data;
using System.Text.Json;
using Newtonsoft.Json;

namespace project {
    public class Program {
        static void Main(string[] args) {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            DataContextDapper dapper = new DataContextDapper(config);

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard
            //     + "', '" + myComputer.HasWifi
            //     + "', '" + myComputer.HasLTE
            //     + "', '" + myComputer.ReleaseDate
            //     + "', '" + myComputer.Price
            //     + "', '" + myComputer.VideoCard
            // + "')\n";

            string computersJson = File.ReadAllText("Computers.json");

            // JsonSerializerOptions options = new JsonSerializerOptions {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };
            // IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson, options);
            IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if(computers != null) {
                foreach(Computer computer in computers) {
                    Console.WriteLine(computer.Motherboard);
                }
            }

            string computersCopy = JsonConvert.SerializeObject(computers);
            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopy);

            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computers);
            File.WriteAllText("computersCopySystem.txt", computersCopySystem);
        }
    }
}