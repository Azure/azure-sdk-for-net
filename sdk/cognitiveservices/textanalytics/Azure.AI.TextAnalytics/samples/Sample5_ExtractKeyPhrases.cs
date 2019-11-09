// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrases()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            string input = "My cat might need to see a veterinarian.";

            Debug.WriteLine($"Extracting key phrases for input: \"{input}\"");
            var keyPhrases = client.ExtractKeyPhrases(input).Value;

            Debug.WriteLine($"Extracted {keyPhrases.Count()} key phrases:");
            foreach (string keyPhrase in keyPhrases)
            {
                Debug.WriteLine(keyPhrase);
            }
        }
    }
}
