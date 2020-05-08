// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrases()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:TextAnalyticsSample3CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:ExtractKeyPhrases
            string document = "My cat might need to see a veterinarian.";

            KeyPhraseCollection keyPhrases = client.ExtractKeyPhrases(document);

            Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
            foreach (string keyPhrase in keyPhrases)
            {
                Console.WriteLine(keyPhrase);
            }
            #endregion
        }
    }
}
