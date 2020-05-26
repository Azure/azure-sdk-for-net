// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task RecognizeEntitiesBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "A key technology in Text Analytics is Named Entity Recognition (NER).",
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            Console.WriteLine($"Recognized entities for each document are:");
            int i = 0;
            foreach (RecognizeEntitiesResult result in results)
            {
                Console.WriteLine($"For document: \"{documents[i++]}\",");
                Console.WriteLine($"the following {result.Entities.Count()} entities were found: ");

                foreach (CategorizedEntity entity in result.Entities)
                {
                    Console.WriteLine($"    Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                }
            }
        }
    }
}
