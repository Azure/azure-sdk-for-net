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
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));

            var inputs = new List<string>
            {
                "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
            };

            #region Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
            RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(inputs);
            #endregion

            Debug.WriteLine($"The following Personally Identifiable Information entities were recognized:");
            int i = 0;
            foreach (RecognizePiiEntitiesResult result in results)
            {
                Debug.WriteLine($"For input: \"{inputs[i++]}\",");
                Debug.WriteLine($"the following {result.Entities.Count()} PII entit{(result.Entities.Count() > 1 ? "ies were" : "y was")} found:");

                foreach (PiiEntity entity in result.Entities)
                {
                    Debug.WriteLine($"    Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                }
            }
        }
    }
}
