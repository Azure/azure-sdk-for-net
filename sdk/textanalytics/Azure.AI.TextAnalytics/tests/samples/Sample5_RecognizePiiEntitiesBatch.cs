// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void RecognizePiiEntitiesBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample5RecognizePiiEntitiesBatch
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
                {
                     Language = "en",
                }
            };

            RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(documents, new RecognizePiiEntitiesOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Pii Entity Recognition\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizePiiEntitiesResult result in results)
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
                    if (result.Entities.Count > 0)
                    {
                        Console.WriteLine($"    Redacted Text: {result.Entities.RedactedText}");
                        Console.WriteLine($"    Recognized the following {result.Entities.Count} PII entit{(result.Entities.Count > 1 ? "ies" : "y ")}:");
                        foreach (PiiEntity entity in result.Entities)
                        {
                            Console.WriteLine($"        Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No entities were found.");
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
