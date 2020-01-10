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
        public void RecognizePiiEntitiesBatchConvenience()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
            };

            #region Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
            RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntities(inputs);
            #endregion

            Debug.WriteLine($"The following Personally Identifiable Information entities were recognized:");
            int i = 0;
            foreach (RecognizePiiEntitiesResult result in results)
            {
                Debug.WriteLine($"For input: \"{inputs[i++]}\",");
                Debug.WriteLine($"the following {result.NamedEntities.Count()} PII entit{(result.NamedEntities.Count() > 1 ? "ies were" : "y was")} found:");

                foreach (NamedEntity entity in result.NamedEntities)
                {
                    Debug.WriteLine($"    Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score:0.00}, Offset: {entity.Offset}, Length: {entity.Length}");
                }
            }
        }
    }
}
