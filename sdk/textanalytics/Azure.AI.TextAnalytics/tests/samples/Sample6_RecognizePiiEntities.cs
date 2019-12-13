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
        public void RecognizePiiEntities()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            string input = "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.";

            Debug.WriteLine($"Recognizing PII entities for input: \"{input}\"");
            RecognizePiiEntitiesResult result = client.RecognizePiiEntities(input);
            IReadOnlyCollection<NamedEntity> entities = result.NamedEntities;

            Debug.WriteLine($"Recognized {entities.Count()} PII entit{(entities.Count() > 1 ? "ies" : "y")}:");
            foreach (NamedEntity entity in entities)
            {
                Debug.WriteLine($"Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score}, Offset: {entity.Offset}, Length: {entity.Length}");
            }
        }
    }
}
