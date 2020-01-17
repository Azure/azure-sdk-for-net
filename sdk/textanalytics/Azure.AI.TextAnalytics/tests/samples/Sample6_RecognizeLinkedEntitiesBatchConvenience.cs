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
        public void ExtractEntityLinkingBatchConvenience()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "Pike place market is my favorite Seattle attraction.",
            };

            #region Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
            RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntities(inputs);
            #endregion

            Debug.WriteLine($"Linked entities for each input are:\n");
            int i = 0;
            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Debug.Write($"For input: \"{inputs[i++]}\", ");
                Debug.WriteLine($"extracted {result.LinkedEntities.Count()} linked entit{(result.LinkedEntities.Count() > 1 ? "ies" : "y")}:");

                foreach (LinkedEntity linkedEntity in result.LinkedEntities)
                {
                    Debug.WriteLine($"    Name: \"{linkedEntity.Name}\", Id: \"{linkedEntity.Id}\", Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Uri: {linkedEntity.Uri.ToString()}");
                    foreach (LinkedEntityMatch match in linkedEntity.Matches)
                    {
                        Debug.WriteLine($"        Match Text: \"{match.Text}\", Score: {match.Score:0.00}, Offset: {match.Offset}, Length: {match.Length}.");
                    }
                }

                Debug.WriteLine("");
            }
        }
    }
}
