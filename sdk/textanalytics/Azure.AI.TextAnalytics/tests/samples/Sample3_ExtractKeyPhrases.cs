// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

            #region Snippet:TextAnalyticsSample3CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
            #endregion

            #region Snippet:ExtractKeyPhrases
            string input = "My cat might need to see a veterinarian.";

            ExtractKeyPhrasesResult result = client.ExtractKeyPhrases(input);
            IReadOnlyCollection<string> keyPhrases = result.KeyPhrases;

            Console.WriteLine($"Extracted {keyPhrases.Count()} key phrases:");
            foreach (string keyPhrase in keyPhrases)
            {
                Console.WriteLine(keyPhrase);
            }
            #endregion
        }
    }
}
