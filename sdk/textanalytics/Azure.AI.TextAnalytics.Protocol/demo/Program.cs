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
            var requestBody = new JsonData();
            var documents = requestBody.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(10))
            {
                var document = documents.AddEmptyObject();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            Response response = await client.GetSentimentAsync(RequestContent.Create(requestBody));
            var responseBody = JsonData.FromBytes(response.Content.ToMemory());

            if (response.Status == 200)
            {
                foreach (var document in responseBody["documents"].Items)
                {
                    Console.WriteLine($"{document["id"]} is {document["sentiment"]}");
                }
            }
            else
            {
                Console.Error.WriteLine(responseBody["error"]);
            }
        }

        /// <summary>
        /// For words or phrases in those reviews that can be categorized as a Person, Location, or Organization, identify whether they are a person, location, or organization.
        /// Print the phrase found in text and its category, e.g.Kurt Russell is a Person.
        /// </summary>
        /// <returns></returns>
        static async Task Task2()
        {
            var requestBody = new JsonData();
            var documents = requestBody.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(5))
            {
                var document = documents.AddEmptyObject();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            Response response = await client.GetEntitiesAsync(RequestContent.Create(requestBody));
            var responseBody = JsonData.FromBytes(response.Content.ToMemory());

            if (response.Status == 200)
            {
                foreach (var document in responseBody["documents"].Items)
                {
                    foreach (var entity in document["entities"].Items)
                    {
                        switch (entity["category"].ToString())
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
                Console.Error.WriteLine(responseBody["error"]);
            }
        }

        /// <summary>
        ///  Detect Person entities that may have entries in the Wikipedia and print all associated hyperlinks to the console 
        /// </summary>
        /// <returns></returns>
        static async Task Task3()
        {
            // Build the body (shared across calls)
            var body = new JsonData();
            var documents = body.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson().Take(5))
            {
                var document = documents.AddEmptyObject();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            // Get all the persons:
            var response = await client.GetEntitiesAsync(RequestContent.Create(body));
            var responseBody = JsonData.FromBytes(response.Content.ToMemory());

            if (response.Status != 200)
            {
                Console.Error.WriteLine(responseBody["error"]);
                return;
            }

            var people = responseBody["documents"].Items.SelectMany(x => x["entities"].Items.Where(e => e["category"] == "Person").Select(e => e["text"])).Distinct();

            // Now, get the links
            response = await client.GetLinkedEntitiesAsync(RequestContent.Create(body));
            responseBody = JsonData.FromBytes(response.Content.ToMemory());

            // For any links, if they are about people in our list, print them.
            if (response.Status == 200)
            {
                foreach (var document in responseBody["documents"].Items)
                {
                    foreach (var entity in document["entities"].Items)
                    {
                        if (people.Contains(entity["name"]) && entity["dataSource"] == "Wikipedia")
                        {
                            Console.WriteLine($"Learn more about {entity["name"]} on {entity["dataSource"]} ({entity["url"]})");
                        }
                    }
                }
            }
            else
            {
                Console.Error.WriteLine(responseBody["error"]);
            }
        }

        /// <summary>
        ///  You are provided with a set of reviews in multiple languages. (reviews_mixed.json). 
        ///  Use text analytics API to detect the language for each review and see if the review contains any Personal Identifiable Information. Print review numbers that contains PII.
        /// </summary>
        /// <remarks>
        ///  Seems like this endpoint also returns information about things which aren't PII from time to time? Anyway, the behavior of the SDK matches that of a hand authored REST request
        /// </remarks>
        static async Task Task4()
        {
            // The body we can share across our two calls.
            var body = new JsonData();
            var documents = body.SetEmptyArray("documents");

            int i = 0;
            foreach (string review in ReadReviewsFromJson("reviews_mixed.json").Take(5))
            {
                var document = documents.AddEmptyObject();
                document["id"] = (++i).ToString();
                document["text"] = review;
            }

            // Get languages.
            var response = await client.GetLanguagesAsync(RequestContent.Create(body));
            var responseBody = JsonData.FromBytes(response.Content.ToMemory());

            if (response.Status != 200)
            {
                Console.Error.WriteLine(responseBody["error"]);
                return;
            }

            // Build a map of DocumentID -> Language Name from the response.
            var languageMap = new Dictionary<JsonData, JsonData>(responseBody["documents"].Items.Select(e =>
            {
                return new KeyValuePair<JsonData, JsonData>(e["id"], e["detectedLanguage"]["iso6391Name"]);
            }));
                
            // Go back over the body object and augment each document with a language
            foreach (JsonData document in body["documents"].Items)
            {
                document["language"] = languageMap[document["id"]];
            }

            response = await client.GetEntitiesPiiAsync(RequestContent.Create(body));
            responseBody = JsonData.FromBytes(response.Content.ToMemory());

            if (response.Status == 200)
            {
                foreach (var document in responseBody["documents"].Items)
                {
                    foreach (var entity in document["entities"].Items)
                    {
                        Console.WriteLine($"Document {document["id"]} has PII of type: {entity["category"]}");
                    }
                }
            }
            else
            {
                Console.Error.WriteLine(responseBody["error"]);
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
            Task4().GetAwaiter().GetResult();
        }
    }
}
