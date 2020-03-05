// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task RecognizeEntitiesAsync()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));

            #region Snippet:RecognizeEntitiesAsync
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            Response<IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input);
            IEnumerable<CategorizedEntity> entities = response.Value;

            Console.WriteLine($"Recognized {entities.Count()} entities:");
            foreach (CategorizedEntity entity in entities)
            {
                Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Score: {entity.Score}, Offset: {entity.GraphemeOffset}, Length: {entity.GraphemeLength}");
            }
            #endregion
        }
    }
}
