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
        public void DetectLanguageBatchConvenience()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));

            var inputs = new List<string>
            {
                "Hello world",
                "Bonjour tout le monde",
                "Hola mundo",
                ":) :( :D",
            };

            Debug.WriteLine($"Detecting language for inputs:");
            foreach (string input in inputs)
            {
                Debug.WriteLine($"    {input}");
            }

            #region Snippet:TextAnalyticsSample1DetectLanguagesConvenience
            DetectLanguageResultCollection results = client.DetectLanguageBatch(inputs);
            #endregion

            int i = 0;
            foreach (DetectLanguageResult result in results)
            {
                Debug.WriteLine($"On document {inputs[i++]}:");
                Debug.WriteLine($"Detected language: {result.PrimaryLanguage.Name}, with confidence {result.PrimaryLanguage.Score}.");
            }
        }
    }
}
