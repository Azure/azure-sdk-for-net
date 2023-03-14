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
        [Ignore("Disabled per request of the service team")]
        public async Task DynamicClassifyAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample11_DynamicClassifyAsync
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

                Console.WriteLine($"The document was classified as:");
                foreach (ClassificationCategory classification in classifications)
                {
                    Console.WriteLine($"  Category: {classification.Category}");
                    Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
                    Console.WriteLine();
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"  Error!");
                Console.WriteLine($"  ErrorCode: {exception.ErrorCode}");
                Console.WriteLine($"  Message: {exception.Message}");
            }
            #endregion
        }
    }
}
