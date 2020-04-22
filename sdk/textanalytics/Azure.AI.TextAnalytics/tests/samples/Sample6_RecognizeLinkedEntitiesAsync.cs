// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task ExtractEntityLinkingAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string document = "Microsoft was founded by Bill Gates and Paul Allen.";

            Response<IReadOnlyCollection<LinkedEntity>> linkedEntities = await client.RecognizeLinkedEntitiesAsync(document);

            Console.WriteLine($"Extracted {linkedEntities.Value.Count} linked entit{(linkedEntities.Value.Count > 1 ? "ies" : "y")}:");
            foreach (LinkedEntity linkedEntity in linkedEntities.Value)
            {
                Console.WriteLine($"Name: {linkedEntity.Name}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
                foreach (LinkedEntityMatch match in linkedEntity.Matches)
                {
                    Console.WriteLine($"    Match Text: {match.Text}, Confidence score: {match.ConfidenceScore}");
                }
            }
        }
    }
}
