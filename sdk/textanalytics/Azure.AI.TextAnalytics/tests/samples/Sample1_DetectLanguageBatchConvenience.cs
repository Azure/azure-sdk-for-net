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
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "Hello world",
                "Bonjour tout le monde",
                "Hola mundo",
                ":) :( :D",
            };

            Debug.WriteLine($"Detecting language for inputs:");
            foreach (var input in inputs)
            {
                Debug.WriteLine($"    {input}");
            }
            DetectLanguageResultCollection results = client.DetectLanguages(inputs);

            Debug.WriteLine($"Detected languages are:");
            foreach (DetectLanguageResult result in results)
            {
                Debug.WriteLine($"    {result.PrimaryLanguage.Name}, with confidence {result.PrimaryLanguage.Score:0.00}.");
            }
        }
    }
}
