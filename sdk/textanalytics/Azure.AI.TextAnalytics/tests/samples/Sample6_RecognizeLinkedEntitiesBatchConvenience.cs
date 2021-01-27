// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

            #region Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
            string documentA = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                                Steve Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped
                                down as CEO of Microsoft, and was succeeded by Satya Nadella.
                                Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                                headquartered in Redmond";

            string documentB = @"Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and 
                                sell BASIC interpreters for the Altair 8800. During his career at Microsoft, Gates held
                                the positions of chairman chief executive officer, president and chief software architect
                                while also being the largest individual shareholder until May 2014.";

            string documentC = string.Empty;

            var documents = new List<string>
            {
                documentA,
                documentB,
                documentC
            };

            Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(documents);
            RecognizeLinkedEntitiesResultCollection entitiesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{entitiesInDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizeLinkedEntitiesResult entitiesInDocument in entitiesInDocuments)
            {
                Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
                Console.WriteLine("");

                if (entitiesInDocument.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error code: {entitiesInDocument.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {entitiesInDocument.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"Recognized {entitiesInDocument.Entities.Count} entities:");
                    foreach (LinkedEntity linkedEntity in entitiesInDocument.Entities)
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
                Console.WriteLine("");
            }
            #endregion
        }
    }
}
