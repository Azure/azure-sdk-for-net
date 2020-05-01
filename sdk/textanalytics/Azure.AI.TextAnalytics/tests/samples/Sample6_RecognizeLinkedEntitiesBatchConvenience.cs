// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
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
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Text Analytics is one of the Azure Cognitive Services.",
                "Pike place market is my favorite Seattle attraction.",
            };

            #region Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
            RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntitiesBatch(documents);
            #endregion

            Debug.WriteLine($"Linked entities for each document are:\n");
            int i = 0;
            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Debug.Write($"For document: \"{documents[i++]}\", ");
                Debug.WriteLine($"extracted {result.Entities.Count()} linked entit{(result.Entities.Count() > 1 ? "ies" : "y")}:");

                foreach (LinkedEntity linkedEntity in result.Entities)
                {
                    Debug.WriteLine($"    Name: \"{linkedEntity.Name}\", Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: \"{linkedEntity.DataSourceEntityId}\"");
                    foreach (LinkedEntityMatch match in linkedEntity.Matches)
                    {
                        Debug.WriteLine($"        Match Text: \"{match.Text}\", Confidence score: {match.ConfidenceScore}");
                    }
                }

                Debug.WriteLine("");
            }
        }
    }
}
