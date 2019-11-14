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
        public void RecognizePiiEntitiesBatch()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "A developer with SSN 859-98-0987 whose phone number is 206-867-5309 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
                "Is 998.214.865-68 your Brazilian CPF number?",
            };

            var resultCollection = client.RecognizePiiEntities(inputs).Value;

            Debug.WriteLine($"The following Personally Identifiable Information entities were recognized:");
            int i = 0;
            foreach (var entities in resultCollection)
            {
                Debug.WriteLine($"For input: \"{inputs[i++]}\",");
                Debug.WriteLine($"the following {entities.Count()} PII entit{(entities.Count() > 1 ? "ies were" : "y was")} found:");

                foreach (var entity in entities)
                {
                    Debug.WriteLine($"    Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score:0.00}, Offset: {entity.Offset}, Length: {entity.Length}");
                }
            }
        }
    }
}
