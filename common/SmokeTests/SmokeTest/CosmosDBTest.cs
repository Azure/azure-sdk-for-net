// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

    class CosmosDBTest
    {
        private static DocumentClient client;
        private static string DataBaseName = $"netSolarSystemDB-{Guid.NewGuid()}";
        private const string CollectionName = "PlanetsCollection";
        private static List<Planet> planets = new List<Planet>();

        /// <summary>
        /// Test the Cosmos DB SDK by creating an example Database called {DataBaseName} and a PlanetsCollection with planets on it.
        /// </summary>
        public static async Task RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("COSMOS DB");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 5:");
            Console.WriteLine("1.- Create a Database");
            Console.WriteLine("2.- Create a Collection in the DB");
            Console.WriteLine("3.- Create 2 JSON Documents (Items) in the collection");
            Console.WriteLine("4.- Excecute simple query to the collection");
            Console.WriteLine("5.- Clean up the resource (Delete DB)\n");

            string endpoint = Environment.GetEnvironmentVariable("COSMOS_URI");
            string authKey = Environment.GetEnvironmentVariable("COSMOS_AUTH_KEY");
            client = new DocumentClient(new Uri(endpoint), authKey);

            //Delete the database to ensure that the test environment is clean.
            try
            {
                await DeleteDatabase();
            }
            catch
            { }

            await CreateDatabase();
            await CreateCollection();
            await CreateDocuments();
            ExecuteSimpleQuery();
            await DeleteDatabase();
        }

        private static async Task CreateDatabase()
        {
            Console.Write("Creating Database '" + DataBaseName + "'...");
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = DataBaseName });
            Console.WriteLine("\tdone");
        }

        private static async Task CreateCollection()
        {
            Console.Write("Creating collection '" + CollectionName + "'...");
            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DataBaseName), new DocumentCollection { Id = CollectionName });
            Console.WriteLine("\tdone");
        }

        private static async Task CreateDocuments()
        {
            planets.Add(new Planet
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
            });
            planets.Add(new Planet
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
            });

            //The items must NOT exists in the collection
            foreach (Planet planet in planets)
            {
                Console.Write("Inserting '"+planet.Id+"' document...");
                await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DataBaseName, CollectionName), planet);
                Console.WriteLine("\tdone");
            }
        }

        /// <summary>
        /// The query retrieve all planets, this is going to verify that planets match
        /// </summary>
        private static void ExecuteSimpleQuery(){
            Console.Write("Querying... ");
            IQueryable<Planet> planetarySqlQuery = client.CreateDocumentQuery<Planet>(UriFactory.CreateDocumentCollectionUri(DataBaseName, CollectionName), "SELECT * FROM c");

            var planetsSet = new HashSet<string>();
            foreach(Planet planet in planets)
            {
                planetsSet.Add(planet.ToString());
            }

            int i = 0;
            foreach (Planet planet in planetarySqlQuery)
            {
                var serializedPlanet = planet.ToString();
                if (planetsSet.Contains(serializedPlanet))
                {
                    i++;
                }
            }

            if(i != planets.Count)
            {
                throw new Exception("Error, values do not match.");
            }
            Console.WriteLine("\tdone");
        }

        private static async Task DeleteDatabase()
        {
            Console.Write("Cleaning up the resource...");
            await client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri(DataBaseName));
            Console.WriteLine("\tdone");
        }
    }
}