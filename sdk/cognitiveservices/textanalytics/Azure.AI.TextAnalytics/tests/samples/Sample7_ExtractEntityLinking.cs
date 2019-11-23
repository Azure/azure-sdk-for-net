// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void ExtractEntityLinking()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            Debug.WriteLine($"Linking entities for input: \"{input}\"");
            var linkedEntities = client.ExtractEntityLinking(input).Value;

            Debug.WriteLine($"Extracted {linkedEntities.Count()} linked entit{(linkedEntities.Count() > 1 ? "ies" : "y")}:");
            foreach (LinkedEntity linkedEntity in linkedEntities)
            {
                Debug.WriteLine($"Name: {linkedEntity.Name}, Id: {linkedEntity.Id}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Uri: {linkedEntity.Uri.ToString()}");
                foreach (LinkedEntityMatch match in linkedEntity.Matches)
                {
                    Debug.WriteLine($"    Match Text: {match.Text}, Score: {match.Score:0.00}, Offset: {match.Offset}, Length: {match.Length}.");
                }
            }
        }
    }
}
