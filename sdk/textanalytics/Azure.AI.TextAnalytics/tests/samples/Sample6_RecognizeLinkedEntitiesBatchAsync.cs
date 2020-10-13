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
        public async Task ExtractEntityLinkingBatchAsync()
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
                new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
                {
                     Language = "en",
                }
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizeLinkedEntitiesResult result in results)
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
                    Console.WriteLine($"    Extracted the following {result.Entities.Count()} linked entities:");

                    foreach (LinkedEntity linkedEntity in result.Entities)
                    {
                        Console.WriteLine($"    Name: \"{linkedEntity.Name}\", Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: \"{linkedEntity.DataSourceEntityId}\"");
                        foreach (LinkedEntityMatch match in linkedEntity.Matches)
                        {
                            Console.WriteLine($"        Match Text: \"{match.Text}\", Confidence score: {match.ConfidenceScore}");
                        }
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
