// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task RecognizeEntitiesAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample4_RecognizeEntitiesAsync
            string document =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            try
            {
                Response<CategorizedEntityCollection> response = await client.RecognizeEntitiesAsync(document);
                CategorizedEntityCollection entitiesInDocument = response.Value;

                Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
                foreach (CategorizedEntity entity in entitiesInDocument)
                {
                    Console.WriteLine($"  Text: {entity.Text}");
                    Console.WriteLine($"  Offset: {entity.Offset}");
                    Console.WriteLine($"  Length: {entity.Length}");
                    Console.WriteLine($"  Category: {entity.Category}");
                    if (!string.IsNullOrEmpty(entity.SubCategory))
                        Console.WriteLine($"  SubCategory: {entity.SubCategory}");
                    Console.WriteLine($"  Confidence score: {entity.ConfidenceScore}");
                    Console.WriteLine();
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
