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
        public void RecognizeEntitiesBatch()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "A key technology in Text Analytics is Named Entity Recognition (NER).",
            };

            var resultCollection = client.RecognizeEntities(inputs).Value;

            Debug.WriteLine($"Recognized entities for each input are:");
            int i = 0;
            foreach (var entities in resultCollection)
            {
                Debug.WriteLine($"For input: \"{inputs[i++]}\",");
                Debug.WriteLine($"the following {entities.Count()} entities were found: ");

                foreach (var entity in entities)
                {
                    Debug.WriteLine($"    Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score:0.00}, Offset: {entity.Offset}, Length: {entity.Length}");
                }
            }
        }
    }
}
