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
        public void RecognizeEntitiesBatchConvenience()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "A key technology in Text Analytics is Named Entity Recognition (NER).",
            };

            #region Snippet:TextAnalyticsSample4RecognizeEntitiesConvenience
            RecognizeEntitiesResultCollection results = client.RecognizeEntities(inputs);
            #endregion

            Debug.WriteLine($"Recognized entities for each input are:");
            int i = 0;
            foreach (RecognizeEntitiesResult result in results)
            {
                Debug.WriteLine($"For input: \"{inputs[i++]}\",");
                Debug.WriteLine($"the following {result.NamedEntities.Count()} entities were found: ");

                foreach (NamedEntity entity in result.NamedEntities)
                {
                    Debug.WriteLine($"    Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score:0.00}, Offset: {entity.Offset}, Length: {entity.Length}");
                }
            }
        }
    }
}
