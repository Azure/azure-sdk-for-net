using Azure;
using Azure.AI.TextAnalytics.Protocol;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        static TextAnalyticsClient client = new TextAnalyticsClient(new Uri("<fill-me-in>"), new AzureKeyCredential("<fill-me-in>"));

        /// <summary>
        /// Use text analytics services and detect whether a review is positive or not positive and print out the result to the console 
        /// </summary>
        static async Task Task1()
        {
            var request = client.GetSentimentRequest();
            var documents = request.Body.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(10))
            {
                var document = documents.AddEmptyObjet();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            DynamicResponse response = await request.SendAsync();

            if (response.Status == 200)
            {
                foreach (var document in response.Body["documents"].Items)
                {
                    // NOTE(ellismg): There are quotes around these values in the output because ToString() JSON Serializes the value.
                    Console.WriteLine($"{document["id"]} is {document["sentiment"]}");
                }
            }
            else
            {
                Console.Error.WriteLine(response.Body["error"]);
            }
        }

        /// <summary>
        /// For words or phrases in those reviews that can be categorized as a Person, Location, or Organization, identify whether they are a person, location, or organization.
        /// Print the phrase found in text and its category, e.g.Kurt Russell is a Person.
        /// </summary>
        /// <returns></returns>
        static async Task Task2()
        {
            var request = client.GetEntitiesRequest();
            var documents = request.Body.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(5))
            {
                var document = documents.AddEmptyObjet();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            DynamicResponse response = await request.SendAsync();

            if (response.Status == 200)
            {
                foreach (var document in response.Body["documents"].Items)
                {
                    foreach (var entity in document["entities"].Items)
                    {
                        // NOTE(ellismg): The cast here is subtle, note that ".ToString()" would do the wrong thing
                        // and wrap the value in quotes (since it returns a stringified JSON document).
                        switch ((string)entity["category"])
                        {
                            case "Person":
                            case "Location":
                            case "Organization":
                                Console.WriteLine($"Entity {entity["text"]} is a {entity["category"]}");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.Error.WriteLine(response.Body["error"]);
            }
        }

        /// <summary>
        ///  Detect Person entities that may have entries in the Wikipedia and print all associated hyperlinks to the console 
        /// </summary>
        /// <returns></returns>
        static async Task Task3()
        {
            var request = client.GetLinkedEntitiesRequest();
            var documents = request.Body.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(5))
            {
                var document = documents.AddEmptyObjet();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            DynamicResponse response = await request.SendAsync();

            if (response.Status == 200)
            {
                foreach (var document in response.Body["documents"].Items)
                {
                    foreach (var entity in document["entities"].Items)
                    {
                        // NOTE(ellismg): Would be nice if we overloaded == against a string here.
                        if ((string)entity["dataSource"] == "Wikipedia")
                        {
                            Console.WriteLine($"Learn more about {entity["text"]} on ${entity["dataSource"]} ({entity["url"]})");
                        }
                    }
                }
            }
            else
            {
                Console.Error.WriteLine(response.Body["error"]);
            }
        }

        static IEnumerable<string> ReadReviewsFromJson(string fileName = "reviews_english.json")
        {
            var reviews = JsonSerializer.Deserialize<Dictionary<string, string>[]>(File.ReadAllText(fileName));
            return reviews.Select(x => x["text"]);
        }

        static void Main(string[] args)
        {
            Task1().GetAwaiter().GetResult();
            Task2().GetAwaiter().GetResult();
            Task3().GetAwaiter().GetResult();
        }
    }
}
