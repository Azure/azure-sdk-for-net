// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task RecognizePiiEntitiesAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string document = @"Parker Doe has repaid all of their loans as of 2020-04-25.
                                Their SSN is 859-98-0987. To contact them, use their phone number 800-102-1100.
                                They are originally from Brazil and have document ID number 998.214.865-68";

            try
            {
                Response<PiiEntityCollection> response = await client.RecognizePiiEntitiesAsync(document);
                PiiEntityCollection entities = response.Value;

                Console.WriteLine($"Redacted Text: {entities.RedactedText}");
                Console.WriteLine("");
                Console.WriteLine($"Recognized {entities.Count} PII entities:");
                foreach (PiiEntity entity in entities)
                {
                    Console.WriteLine($"  Text: {entity.Text}");
                    Console.WriteLine($"  Category: {entity.Category}");
                    if (!string.IsNullOrEmpty(entity.SubCategory))
                        Console.WriteLine($"  SubCategory: {entity.SubCategory}");
                    Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
                    Console.WriteLine("");
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
