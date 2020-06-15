// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task DetectLanguageBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "Hello world",
                "Bonjour tout le monde",
                "Hola mundo",
                ":) :( :D",
            };

            Console.WriteLine($"Detecting language for documents:");
            foreach (string document in documents)
            {
                Debug.WriteLine($"    {document}");
            }

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            int i = 0;
            foreach (DetectLanguageResult result in results)
            {
                Console.WriteLine($"On document {documents[i++]}:");
                Console.WriteLine($"Detected language: {result.PrimaryLanguage.Name}, with confidence score {result.PrimaryLanguage.ConfidenceScore}.");
            }
        }
    }
}
