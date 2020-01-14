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
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            #region Snippet:RecognizeEntitiesAsync
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            RecognizeEntitiesResult result = await client.RecognizeEntitiesAsync(input);
            IReadOnlyCollection<NamedEntity> entities = result.NamedEntities;

            Console.WriteLine($"Recognized {entities.Count()} entities:");
            foreach (NamedEntity entity in entities)
            {
                Console.WriteLine($"Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score}, Offset: {entity.Offset}, Length: {entity.Length}");
            }
            #endregion
        }
    }
}
