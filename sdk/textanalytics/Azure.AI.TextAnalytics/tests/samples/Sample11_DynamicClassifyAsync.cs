// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public async Task DynamicClassifyAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            // Get the document.
            string document =
                "“The Microsoft Adaptive Accessories are intended to remove the barriers that traditional mice and"
                + " keyboards may present to people with limited mobility,” says Gabi Michel, director of Accessible"
                + " Accessories at Microsoft. “No two people are alike, and empowering people to configure their own"
                + " system that works for them was definitely the goal.”";

            // Specify the categories that the document can be classified with.
            List<string> categories = new()
            {
                "Health",
                "Politics",
                "Music",
                "Sports",
                "Technology"
            };

            try
            {
                Response<ClassificationCategoryCollection> response = await client.DynamicClassifyAsync(document, categories);
                ClassificationCategoryCollection classifications = response.Value;

                Console.WriteLine($"The document was classified as follows:");
                Console.WriteLine();

                foreach (ClassificationCategory classification in classifications)
                {
                    Console.WriteLine($"  Category: {classification.Category}");
                    Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}.");
                    Console.WriteLine();
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
