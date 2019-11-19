// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void RecognizeEntities()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            Debug.WriteLine($"Recognizing entities for input: \"{input}\"");
            var entities = client.RecognizeEntities(input).Value;

            Debug.WriteLine($"Recognized {entities.Count()} entities:");
            foreach (NamedEntity entity in entities)
            {
                Debug.WriteLine($"Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score}, Offset: {entity.Offset}, Length: {entity.Length}");
            }
        }
    }
}
