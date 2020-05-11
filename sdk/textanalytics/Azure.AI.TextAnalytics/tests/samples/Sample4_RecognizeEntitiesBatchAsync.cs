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
        public async Task RecognizeEntitiesBatchAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Text Analytics is one of the Azure Cognitive Services.")
                {
                     Language = "en",
                },
                new TextDocumentInput("3", "A key technology in Text Analytics is Named Entity Recognition (NER).")
                {
                     Language = "en",
                }
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Named Entity Recognition\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizeEntitiesResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Console.WriteLine($"    Document error code: {result.Error.ErrorCode}.");
                    Console.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Console.WriteLine($"    Recognized the following {result.Entities.Count()} entities:");

                    foreach (CategorizedEntity entity in result.Entities)
                    {
                        Console.WriteLine($"        Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                    }

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
