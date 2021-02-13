using Azure;
using Azure.AI.TextAnalytics.Protocol;
using Azure.Core;
using System;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TextAnalyticsClient client = new TextAnalyticsClient(new Uri("<fill-me-in>"), new AzureKeyCredential("<fill-me-in>"));

            // Passing the body "in-line" and using the object constructor with an anonymous object.
            {
                DynamicResponse res = client.GetLanguages(new JsonData(new
                {
                    doucments = new JsonData(new object[]
                    {
                        new
                        {
                            countryHint = "US",
                            id = 1,
                            text = "Hello world",
                        },
                        new
                        {
                            id = 2,
                            text = "Bonjour tout le monde"
                        },
                        new
                        {
                            id = 3,
                            text = "La carretera estaba atascada. Había mucho tráfico el día de ayer."
                        }
                    })
                }));

                Console.WriteLine($"Status: {res.Status}");

                if (res.Status == 200)
                {
                    dynamic dymamicBody = res.Body;

                    foreach (var document in dymamicBody.documents)
                    {
                        Console.WriteLine($"id: {document.id} name: {document.detectedLanguage.name}");
                    }
                }
            }

            // Using the request builder pattern and the "builder" methods on JsonData.
            {
                DynamicRequest req = client.GetLanguagesRequest();


                var body = new JsonData();
                JsonData documents = req.Body.SetEmpty("documents", isArray: true);
                documents.Add(new
                {
                    countryHint = "US",
                    id = "1",
                    text = "Hello world"
                });
                documents.Add(new
                {
                    id = "2",
                    text = "Bonjour tout le monde",
                });
                documents.Add(new
                {
                    id = "3",
                    text = "La carretera estaba atascada. Había mucho tráfico el día de ayer."
                });

                DynamicResponse res = req.Send();

                Console.WriteLine($"Status: {res.Status}");

                if (res.Status == 200)
                {
                    foreach (var document in ((dynamic)res.Body).documents)
                    {
                        Console.WriteLine($"id: {document.id}, {document.detectedLanguage.name}");
                    }
                }
            }
        }
    }
}
