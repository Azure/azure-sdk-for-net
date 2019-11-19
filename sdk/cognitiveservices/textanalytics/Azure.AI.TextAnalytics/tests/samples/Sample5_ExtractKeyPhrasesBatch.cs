// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractKeyPhrasesBatchAdvanced()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);


            var inputs = new List<TextDocumentInput>
            {
                new TextDocumentInput("1")
                {
                     Language = "en",
                     Text = "Microsoft was founded by Bill Gates and Paul Allen."
                },
                new TextDocumentInput("2")
                {
                     Language = "en",
                     Text = "Text Analytics is one of the Azure Cognitive Services.",
                },
                new TextDocumentInput("3")
                {
                     Language = "en",
                     Text = "My cat might need to see a veterinarian.",
                }
            };

            var response = client.ExtractKeyPhrases(inputs, new TextAnalyticsRequestOptions(showStatistics: true));

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Extract Key Phrases\" Model, version: \"{response.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (var result in response.Value)
            {
                var document = inputs[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

                if (result.ErrorMessage != default)
                {
                    Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");
                }
                else
                {
                    Debug.WriteLine($"    Extracted the following {result.Count()} key phrases:");

                    foreach (var keyPhrase in result)
                    {
                        Debug.WriteLine($"        {keyPhrase}");
                    }

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {response.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {response.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count:{response.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count:{response.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
