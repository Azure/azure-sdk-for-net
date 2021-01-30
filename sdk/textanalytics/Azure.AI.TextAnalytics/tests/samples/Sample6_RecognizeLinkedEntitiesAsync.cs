// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

            string document = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                                Steve Ballmer, eventually became CEO after Bill Gates as well. Steve Ballmer eventually stepped
                                down as CEO of Microsoft, and was succeeded by Satya Nadella.
                                Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                                headquartered in Redmond";

            try
            {
                Response<LinkedEntityCollection> response = await client.RecognizeLinkedEntitiesAsync(document);
                LinkedEntityCollection linkedEntities = response.Value;

                Console.WriteLine($"Recognized {linkedEntities.Count} entities:");
                foreach (LinkedEntity linkedEntity in linkedEntities)
                {
                    Console.WriteLine($"  Name: {linkedEntity.Name}");
                    Console.WriteLine($"  Language: {linkedEntity.Language}");
                    Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
                    Console.WriteLine($"  URL: {linkedEntity.Url}");
                    Console.WriteLine($"  Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
                    foreach (LinkedEntityMatch match in linkedEntity.Matches)
                    {
                        Console.WriteLine($"    Match Text: {match.Text}");
                        Console.WriteLine($"    Offset: {match.Offset}");
                        Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
                    }
                    Console.WriteLine("");
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error Code: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
        }
    }
}
