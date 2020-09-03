// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check."
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents);

            int i = 0;
            foreach (RecognizePiiEntitiesResult result in results)
            {
                Console.WriteLine($"For document: {documents[i++]}");
                if (result.Entities.Count > 0)
                {
                    Console.WriteLine($"Redacted Text: {result.Entities.RedactedText}");
                    Console.WriteLine($"The following {result.Entities.Count} PII entit{(result.Entities.Count > 1 ? "ies were" : "y was")} found:");

                    foreach (PiiEntity entity in result.Entities)
                    {
                        Console.WriteLine($"    Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                    }
                }
                else
                {
                    Console.WriteLine("No entities were found.");
                }
            }
        }
    }
}
