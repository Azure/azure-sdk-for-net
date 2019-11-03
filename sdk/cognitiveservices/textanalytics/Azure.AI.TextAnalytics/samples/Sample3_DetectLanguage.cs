// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        public void DetectLanguage()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(endpoint, subscriptionKey);


            string spanishInput = "Este documento está en español.";

            Debug.WriteLine($"Detecting language for input: \"{spanishInput}\"");

            DetectedLanguage language = client.DetectLanguage(spanishInput);

            Debug.WriteLine($"Detected language {language.Name} with confidence {language.Score}.");


            string unknownLanguageInput = ":) :( :D";

            Debug.WriteLine($"Detecting language for input: \"{unknownLanguageInput}\"");
            language = client.DetectLanguage(unknownLanguageInput);

            Debug.WriteLine($"Detected language {language.Name} with confidence {language.Score}.");
        }
    }
}
