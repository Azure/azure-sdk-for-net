// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void DynamicClassifyBatch()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            // Get the documents.
            string documentA =
                "“The Microsoft Adaptive Accessories are intended to remove the barriers that traditional mice and"
                + " keyboards may present to people with limited mobility,” says Gabi Michel, director of Accessible"
                + " Accessories at Microsoft. “No two people are alike, and empowering people to configure their own"
                + " system that works for them was definitely the goal.”";

            string documentB =
                "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete"
                + " in the National Football League (NFL) as a member club of the league's National Football"
                + " Conference (NFC) West, which they rejoined in 2002 as part of conference realignment.";

            string documentC = string.Empty;

            // Specify the categories that the documents can be classified with.
            List<string> categories = new()
            {
                "Health",
                "Politics",
                "Music",
                "Sports",
                "Technology"
            };

            List<TextDocumentInput> documents = new()
            {
                new TextDocumentInput("1", documentA),
                new TextDocumentInput("2", documentB),
                new TextDocumentInput("3", documentC)
            };

            DynamicClassifyOptions options = new() { IncludeStatistics = true };

            Response<DynamicClassifyDocumentResultCollection> response = client.DynamicClassifyBatch(documents, categories, options: options);
            DynamicClassifyDocumentResultCollection batchResults = response.Value;

            Console.WriteLine($"Results of \"Dynamic Classification\" Model, version: \"{batchResults.ModelVersion}\"");
            Console.WriteLine();

            foreach (ClassifyDocumentResult documentResult in batchResults)
            {
                Console.WriteLine($"On document (Id={documentResult.Id}):");

                if (documentResult.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {documentResult.Error.Message}");
                    Console.WriteLine();
                    continue;
                }

                foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
                {
                    Console.WriteLine($"  Category: {classification.Category}");
                    Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}.");
                    Console.WriteLine();
                }

                Console.WriteLine($"  Document statistics:");
                Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
                Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                Console.WriteLine();
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {batchResults.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {batchResults.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {batchResults.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {batchResults.Statistics.TransactionCount}");
        }
    }
}
