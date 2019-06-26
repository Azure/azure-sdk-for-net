using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool HasRings { get; set; }
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


    class CosmosDBTest : TestBase
    {
        private DocumentClient client;
        private Planet planetEarth;
        private Planet planetMars;

        public CosmosDBTest(string endpoint, string authKey)
        {
            client = new DocumentClient(new Uri(endpoint), authKey);
        }

        /// <summary>
        /// Test the Cosmos DB SDK by creating an example Database called 'SolarSystemDB' and a PlanetsCollection with planets on it.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("COSMOS DB");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: #:");
            Console.WriteLine("1.- Create a Database");
            Console.WriteLine("2.- Create a Collection in the DB");
            Console.WriteLine("3.- Create 2 JSON Documents (Items) in the collection");
            Console.WriteLine("4.- Excecute simple query to the DB");
            Console.WriteLine("5.- Clean up the resource (Delete DB)\n");

            var testPassed = true;

            Console.Write("Creating Database 'SolarSystemDB'... ");
            var result1 = await ExcecuteTest(CreateDatabase);
            if(!result1)
            {
                //If this test failed, the next ones are going to fail too
                Console.WriteLine("Cannot create a Collection, Documents, Query the collection and neither Delete the DB.");
                return false;
            }

            Console.Write("Creating collection 'PlanetsCollection' ");
            var result2 = await ExcecuteTest(CreateCollection);
            if (!result2)
            {
                testPassed = false;
            }

            Console.Write("Inserting 'Earth' and 'Mars' JSON Documents... ");
            var result3 = await ExcecuteTest(CreateDocuments);
            if (!result3)
            {
                testPassed = false;
            }

            Console.Write("Querying... ");
            var result4 = await ExcecuteTest(ExecuteSimpleQuery);
            if (!result4)
            {
                testPassed = false;
            }
            
            Console.Write("Cleaning up the resource... ");
            var result5 = await ExcecuteTest(DeleteDatabase);
            if (!result5)
            {
                testPassed = false;
            }

            return testPassed;
        }

        private async Task CreateDatabase()
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "SolarSystemDB" });
        }

        private async Task CreateCollection()
        {
            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("SolarSystemDB"), new DocumentCollection { Id = "PlanetsCollection" });
        }

        private async Task CreateDocuments()
        {
            planetEarth = new Planet
            {
                Id = "Earth",
                HasRings = false,
                Radius = 3959,
                Moons = new Moon[]
                {
                    new Moon
                    {
                        Name = "Moon"
                    }
                }
            };

            planetMars = new Planet
            {
                Id = "Mars",
                HasRings = false,
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

            await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("SolarSystemDB", "PlanetsCollection"), planetEarth);
            await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("SolarSystemDB", "PlanetsCollection"), planetMars);

        }

        private async Task ExecuteSimpleQuery(){
            IQueryable<Planet> planetarySqlQuery = client.CreateDocumentQuery<Planet>(UriFactory.CreateDocumentCollectionUri("SolarSystemDB", "PlanetsCollection"), "SELECT * FROM c");

            foreach (Planet planet in planetarySqlQuery)
            {
                //The only 2 planets that were set before were Earth and Mars, if planet does not match any of those, then there is an error.
                if (planet.ToString() != planetEarth.ToString() && planet.ToString() != planetMars.ToString())
                {
                    throw new Exception(String.Format("Error, the values does not match.\n"));
                }
            }
        }

        private async Task DeleteDatabase()
        {
            await client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri("SolarSystemDB"));
        }

    }
}
