// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrases()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample3_ExtractKeyPhrases
            string document =
                "My cat might need to see a veterinarian. It has been sneezing more than normal, and although my"
                + " little sister thinks it is funny, I am worried it has the cold that I got last week. We are going"
                + " to call tomorrow and try to schedule an appointment for this week. Hopefully it will be covered by"
                + " the cat's insurance. It might be good to not let it sleep in my room for a while.";

            try
            {
                Response<KeyPhraseCollection> response = client.ExtractKeyPhrases(document);
                KeyPhraseCollection keyPhrases = response.Value;

                Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
                foreach (string keyPhrase in keyPhrases)
                {
                    Console.WriteLine($"  {keyPhrase}");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }
    }
}
