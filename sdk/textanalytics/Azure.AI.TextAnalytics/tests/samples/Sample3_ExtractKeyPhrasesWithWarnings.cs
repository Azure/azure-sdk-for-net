// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrasesWithWarnings()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string document =
                "Anthony runs his own personal training business so"
                + " thisisaverylongtokenwhichwillbetruncatedtoshowushowwarningsareemittedintheapi";

            try
            {
                Response<ExtractKeyPhrasesResultCollection> response = client.ExtractKeyPhrasesBatch(new List<string>() { document }, options: new TextAnalyticsRequestOptions() { ModelVersion = "2020-07-01" });
                ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;
                KeyPhraseCollection keyPhrases = keyPhrasesInDocuments.FirstOrDefault().KeyPhrases;

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
