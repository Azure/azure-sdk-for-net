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
            string document = @"My cat might need to see a veterinarian. It has been sneezing more than normal, and although my 
little sister thinks it is funny, I a worried it has the cold that I got last week.
We are going to call tomorrow and try to schedule an appointment for this week. Hopefully it will be covered by the cat's insurance.
It might be good to not let it sleep in my room for a while.";

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
