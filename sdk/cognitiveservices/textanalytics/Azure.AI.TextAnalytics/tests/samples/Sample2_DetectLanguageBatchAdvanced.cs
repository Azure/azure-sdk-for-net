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

            var inputs = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1")
                {
                     CountryHint = "us",
                     Text = "Hello world"
                },
                new DetectLanguageInput("2")
                {
                     CountryHint = "fr",
                     Text = "Bonjour tout le monde",
                },
                new DetectLanguageInput("3")
                {
                     CountryHint = "es",
                     Text = "Hola mundo",
                },
                new DetectLanguageInput("4")
                {
                     CountryHint = "us",
                     Text = ":) :( :D"
                }
            };

            DocumentResultCollection<DetectedLanguage> results = client.DetectLanguages(inputs, new TextAnalyticsRequestOptions(showStatistics: true));

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (var result in results)
            {
                var document = inputs[i++];

                Debug.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\", Text=\"{document.Text}\"):");
                Debug.WriteLine($"    Detected language {result[0].Name} with confidence {result[0].Score:0.00}.");

                Debug.WriteLine($"    Document statistics:");
                Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                Debug.WriteLine("");
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count:{results.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count:{results.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
