// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.AI.TextAnalytics;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        public void DetectLanguages()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(endpoint, subscriptionKey);


            string spanishInput = "Este documento está en español.";

            Debug.WriteLine($"Detecting language for input: \"{spanishInput}\"");
            DetectedLanguage result = client.DetectLanguage(spanishInput);

            Debug.WriteLine($"Detected language {result.Name} with confidence {result.Score}.");


            string unknownLanguageInput = ":) :( :D";

            Debug.WriteLine($"Detecting language for input: \"{unknownLanguageInput}\"");
            result = client.DetectLanguage(unknownLanguageInput);

            Debug.WriteLine($"Detected language {result.Name} with confidence {result.Score}.");
        }
    }
}
