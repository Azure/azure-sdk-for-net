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
        public void DetectLanguageBatch()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            #region Snippet:TextAnalyticsSample1DetectLanguagesBatch
            var inputs = new List<DetectLanguageInput>
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
                     CountryHint = "us",
                }
            };

            DetectLanguageResultCollection results = client.DetectLanguages(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (DetectLanguageResult result in results)
            {
                DetectLanguageInput document = inputs[i++];

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
            Debug.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
