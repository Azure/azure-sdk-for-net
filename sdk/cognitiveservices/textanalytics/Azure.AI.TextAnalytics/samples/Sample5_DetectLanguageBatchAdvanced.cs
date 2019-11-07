// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void DetectLanguageBatchAdvanced()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<DocumentInput>
            {
                new DocumentInput
                {
                     Id = "1", // TODO: Id should be int?
                     Hint = "us",
                     Text = "Hello world"
                },
                new DocumentInput
                {
                     Id = "2",
                     Hint = "fr",
                     Text = "Bonjour tout le monde",
                },
                new DocumentInput
                {
                     Id = "3",
                     Hint = "es",
                     Text = "Hola mundo",
                },
                new DocumentInput
                {
                     Id = "4",
                     Hint = "us",
                     Text = ":) :( :D"
                }
            };

            var resultsPages = client.DetectLanguages(inputs, showStats: true).AsPages();

            int i = 0;
            foreach (var resultsPage in resultsPages)
            {
                TextAnalyticsResultPage<DetectedLanguage> page = (TextAnalyticsResultPage<DetectedLanguage>)resultsPage;

                Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{page.ModelVersion}\"");
                Debug.WriteLine("");

                foreach (var result in page.DocumentResults)
                {
                    var document = inputs[i++];
                    Debug.WriteLine($"On document (Id={document.Id}, Hint=\"{document.Hint}\", Text=\"{document.Text}\"):");
                    Debug.WriteLine($"    Detected language {result.Predictions[0].Name} with confidence {result.Predictions[0].Score:0.00}.");

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }

                Debug.WriteLine($"Batch operation statistics:");
                Debug.WriteLine($"    Document count: {page.Statistics.DocumentCount}");
                Debug.WriteLine($"    Valid document count: {page.Statistics.ValidDocumentCount}");
                Debug.WriteLine($"    Erroroneous document count:{page.Statistics.ErroneousDocumentCount}");
                Debug.WriteLine($"    Transaction count:{page.Statistics.TransactionCount}");
                Debug.WriteLine("");
            }
        }
    }
}
