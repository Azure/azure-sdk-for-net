// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
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
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample1DetectLanguageBatch
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

            DetectLanguageResultCollection results = client.DetectLanguageBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Detect Language\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (DetectLanguageResult result in results)
            {
                DetectLanguageInput document = documents[i++];

                Debug.WriteLine($"On document (Id={document.Id}, CountryHint=\"{document.CountryHint}\", Text=\"{document.Text}\"):");

                if (result.HasError)
                {
                    Debug.WriteLine($"    Document error code: {result.Error.ErrorCode}.");
                    Debug.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Debug.WriteLine($"    Detected language {result.PrimaryLanguage.Name} with confidence score {result.PrimaryLanguage.ConfidenceScore}.");

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
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
