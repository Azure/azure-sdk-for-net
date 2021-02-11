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
        public void ExtractKeyPhrasesWithWarnings()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string document = @"Anthony runs his own personal training business so
                              thisisaverylongtokenwhichwillbetruncatedtoshowushowwarningsareemittedintheapi";

            try
            {
                Response<KeyPhraseCollection> response = client.ExtractKeyPhrases(document);
                KeyPhraseCollection keyPhrases = response.Value;

                if (keyPhrases.Warnings.Count > 0)
                {
                    Console.WriteLine("**Warnings:**");
                    foreach (TextAnalyticsWarning warning in keyPhrases.Warnings)
                    {
                        Console.WriteLine($"  Warning: Code: {warning.WarningCode}, Message: {warning.Message}");
                    }
                }

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
        }
    }
}
