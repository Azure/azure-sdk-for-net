using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTest
{
    public class Planet
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public bool GassyPlanet { get; set; }
        public int Radius { get; set; }
        public Moon[] Moons { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Moon
    {
        public string Name { get; set; }
    }

    class CosmosDBTest
    {
        private DocumentClient client;
        
        public CosmosDBTest(string endpoint, string authKey)
        {
            client = new DocumentClient(new Uri(endpoint), authKey);
        }

        public async Task<bool> RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("COSMOS DB");
            Console.WriteLine("(Microsoft.Azure.DocumentDB)");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: #:");
            Console.WriteLine("1.- Create a Database\n");

            Console.Write("Creating Database 'SolarSystemDB'... ");
            var result1 = await CreateDatabase();
            if(result1 != null)
            {
                Console.Write("FAILED\n");
                Console.WriteLine(result1);
                //If this test failed, the next ones are going to fail too
                Console.WriteLine("Cannot create a Collection, Query the collection and neither Delete it.");
                return false;
            }
            else
            {
                Console.Write("DB created.\n");
            }

            Console.Write("Creating collection 'PlanetsCollection' ");


            return true;
        }

        private async Task<Exception> CreateDatabase()
        {
            try
            {
                await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "SolarSystemDB" });
            }
            catch (Exception ex)
            {
                return ex;
            }            
            return null;
        }

        private async Task<Exception> CreateCollection()
        {
            try
            {
                await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("SolarSystemDB"), new DocumentCollection { Id = "PlanetsCollection" });
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        private async Task<Exception> CreateDocuments()
        {
            Planet planetEarth = new Planet
            {
                Id = "Earth",
                GassyPlanet = false,
                Radius = 3959,
                Moons = new Moon[]
                {
                    new Moon
                    {
                        Name = "Moon"
                    }
                }
            };

            Planet planetMars = new Planet
            {
                Id = "Mars",
                GassyPlanet = false,
                Radius = 2106,
                Moons = new Moon[]
                {
                    new Moon
                    {
                        Name = "Phobos"
                    },
                    new Moon
                    {
                        Name = "Deimos"
                    }
                }
            };

            return null;
        }

        private async Task<Exception> ExecuteSimpleQuery(){
            try
            {

            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
}
