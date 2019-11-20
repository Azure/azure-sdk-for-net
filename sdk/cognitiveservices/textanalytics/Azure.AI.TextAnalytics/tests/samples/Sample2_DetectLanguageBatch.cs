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

            var inputs = new List<DetectLangaugeInput>
            {
                new DetectLangaugeInput("1")
                {
                     CountryHint = "us",
                     Text = "Hello world"
                },
                new DetectLangaugeInput("2")
                {
                     CountryHint = "fr",
                     Text = "Bonjour tout le monde",
                },
                new DetectLangaugeInput("3")
                {
                     CountryHint = "es",
                     Text = "Hola mundo",
                },
                new DetectLangaugeInput("4")
                {
                     CountryHint = "us",
                     Text = ":) :( :D"
                }
            };

            TextBatchResponse<DetectLanguageResult> response = client.DetectLanguages(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{response.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (var result in response.Value)
            {
                var document = inputs[i++];

                Debug.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\", Text=\"{document.Text}\"):");

                if (result.ErrorMessage != default)
                {
                    Debug.WriteLine($"    Document error: {result.ErrorMessage}.");
                }
                else
                {
                    Debug.WriteLine($"    Detected language {result.PrimaryLanguage.Name} with confidence {result.PrimaryLanguage.Score:0.00}.");

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {response.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {response.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count:{response.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count:{response.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
