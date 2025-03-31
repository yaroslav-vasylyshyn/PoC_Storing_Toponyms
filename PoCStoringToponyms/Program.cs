using MongoDB.Driver;
using Newtonsoft.Json;


namespace PoCStoringToponyms
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ToponymsDb");

            IRepository<Toponym> toponymRepository = new ToponymRepository(database);
            
            List<Toponym> toponyms = new List<Toponym>
            {
                new Toponym
                {
                    Oblast = "Львівська область",
                    AdminRegionOld = "Франківський р-н",
                    AdminRegionNew = "Франківський район",
                    Gromada = "ЛЬвівська ТГ",
                    Community = "м. Львів",
                    StreetName = "Городоцька",
                    StreetType = "вулиця",
                    Coordinate = new Coordinate { Latitude = 50.50688, Longitude = 29.78500 }
                },
                new Toponym
                {
                    Oblast = "Херсонська область",
                    AdminRegionOld = "Херсонський р-н",
                    AdminRegionNew = "Херсонський район",
                    Gromada = "Херсонська ТГ",
                    Community = "м. Херсон",
                    StreetName = "Соборна",
                    StreetType = "вулиця",
                    Coordinate = new Coordinate { Latitude = 50.50688, Longitude = 28.78500 }
                }
            };

            if (toponyms != null)
            {
                await toponymRepository.InsertManyAsync(toponyms);
                Console.WriteLine("data inserted into the database successfully.");
            }
            else
            {
                Console.WriteLine("toponyms is empty");
            }

            string json = JsonConvert.SerializeObject(toponyms, Formatting.Indented);

            string outputPath = "toponyms.json";
            File.WriteAllText(outputPath, json);

            Console.WriteLine($"JSON file saved successfully to {outputPath}");
        }
    }
}
