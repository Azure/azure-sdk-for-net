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
        public void RecognizePiiEntitiesBatchAdvanced()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<DocumentInput>
            {
                new DocumentInput("1")
                {
                     Language = "en",
                     Text = "A developer with SSN 859-98-0987 whose phone number is 206-867-5309 is building tools with our APIs."
                },
                new DocumentInput("2")
                {
                     Language = "en",
                     Text = "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
                },
                new DocumentInput("3")
                {
                     Language = "en",
                     Text = "Is 998.214.865-68 your Brazilian CPF number?",
                }
            };

            var resultCollection = client.RecognizePiiEntities(inputs, new TextAnalyticsRequestOptions(showStatistics: true)).Value;

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Pii Entity Recognition\" Model, version: \"{resultCollection.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (var result in resultCollection)
            {
                var document = inputs[i++];

                Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");
                Debug.WriteLine($"    Recognized the following {result.Count()} PII entit{(result.Count() > 1 ? "ies" : "y ")}:");

                foreach (var entity in result)
                {
                    Debug.WriteLine($"        Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score:0.00}, Offset: {entity.Offset}, Length: {entity.Length}");
                }

                Debug.WriteLine($"    Document statistics:");
                Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                Debug.WriteLine("");
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {resultCollection.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {resultCollection.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count:{resultCollection.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count:{resultCollection.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
