// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task DetectLanguageBatchAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", "Hello world")
                {
                     CountryHint = "us",
                },
                new DetectLanguageInput("2", "Bonjour tout le monde")
                {
                     CountryHint = "fr",
                },
                new DetectLanguageInput("3", "Hola mundo")
                {
                     CountryHint = "es",
                },
                new DetectLanguageInput("4", ":) :( :D")
                {
                     CountryHint = DetectLanguageInput.None,
                }
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (DetectLanguageResult result in results)
            {
                DetectLanguageInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Console.WriteLine($"    Document error code: {result.Error.ErrorCode}.");
                    Console.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Console.WriteLine($"    Detected language {result.PrimaryLanguage.Name} with confidence score {result.PrimaryLanguage.ConfidenceScore}.");

                    Console.WriteLine($"    Document statistics:");
                    Console.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
                    Console.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Console.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Console.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Console.WriteLine("");
        }
    }
}
