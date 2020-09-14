// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void RecognizePiiEntities()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:TextAnalyticsSample5CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:RecognizePiiEntities
            string document = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.";

            PiiEntityCollection entities = client.RecognizePiiEntities(document).Value;

            Console.WriteLine($"Redacted Text: {entities.RedactedText}");
            if (entities.Count > 0)
            {
                Console.WriteLine($"Recognized {entities.Count} PII entit{(entities.Count > 1 ? "ies" : "y")}:");
                foreach (PiiEntity entity in entities)
                {
                    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                }
            }
            else
            {
                Console.WriteLine("No entities were found.");
            }
            #endregion
        }
    }
}
