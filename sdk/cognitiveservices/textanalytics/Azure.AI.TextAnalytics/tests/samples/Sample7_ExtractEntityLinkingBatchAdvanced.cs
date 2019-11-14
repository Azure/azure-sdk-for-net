// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractEntityLinkingBatchAdvanced()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<DocumentInput>
            {
                new DocumentInput("1")
                {
                     Language = "en",
                     Text = "Microsoft was founded by Bill Gates and Paul Allen."
                },
                new DocumentInput("2")
                {
                     Language = "en",
                     Text = "Text Analytics is one of the Azure Cognitive Services."
                },
                new DocumentInput("3")
                {
                     Language = "en",
                     Text = "Pike place market is my favorite Seattle attraction."
                }
            };

            var resultCollection = client.ExtractEntityLinking(inputs, new TextAnalyticsRequestOptions(showStatistics: true)).Value;

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{resultCollection.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (var result in resultCollection)
            {
                var document = inputs[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");
                Debug.WriteLine($"    Extracted the following {result.Count()} linked entities:");

                foreach (var linkedEntity in result)
                {
                    Debug.WriteLine($"    Name: \"{linkedEntity.Name}\", Id: \"{linkedEntity.Id}\", Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Uri: {linkedEntity.Uri.ToString()}");
                    foreach (LinkedEntityMatch match in linkedEntity.Matches)
                    {
                        Debug.WriteLine($"        Match Text: \"{match.Text}\", Score: {match.Score:0.00}, Offset: {match.Offset}, Length: {match.Length}.");
                    }
                }

                Debug.WriteLine($"    Document statistics:");
                Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                Debug.WriteLine("");
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {resultCollection.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {resultCollection.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count:{resultCollection.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count:{resultCollection.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
