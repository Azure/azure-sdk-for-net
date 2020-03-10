// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractEntityLinking()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            #region Snippet:TextAnalyticsSample6CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
            #endregion

            #region Snippet:RecognizeLinkedEntities
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            IReadOnlyCollection<LinkedEntity> linkedEntities = client.RecognizeLinkedEntities(input).Value;

            Console.WriteLine($"Extracted {linkedEntities.Count} linked entit{(linkedEntities.Count > 1 ? "ies" : "y")}:");
            foreach (LinkedEntity linkedEntity in linkedEntities)
            {
                Console.WriteLine($"Name: {linkedEntity.Name}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
                foreach (LinkedEntityMatch match in linkedEntity.Matches)
                {
                    Console.WriteLine($"    Match Text: {match.Text}, Confidence score: {match.ConfidenceScore}");
                }
            }
            #endregion
        }
    }
}
