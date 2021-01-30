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
        public void ExtractEntityLinkingBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
            string documentA = @"Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends,
                                Steve Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped
                                down as CEO of Microsoft, and was succeeded by Satya Nadella.
                                Microsoft originally moved its headquarters to Bellevue, Washington in Januaray 1979, but is now
                                headquartered in Redmond";

            string documentB = @"El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él
                                empezó como Ingeniero de Software en el año 1992.";

            string documentC = @"Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and 
                                sell BASIC interpreters for the Altair 8800. During his career at Microsoft, Gates held
                                the positions of chairman chief executive officer, president and chief software architect
                                while also being the largest individual shareholder until May 2014.";

            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "en",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "es",
                },
                new TextDocumentInput("3", documentC)
                {
                     Language = "en",
                },
                new TextDocumentInput("4", string.Empty)
            };

            var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(documents, options);
            RecognizeLinkedEntitiesResultCollection entitiesPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Entity Linking\", version: \"{entitiesPerDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (RecognizeLinkedEntitiesResult entitiesInDocument in entitiesPerDocuments)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

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

                    Console.WriteLine($"  Document statistics:");
                    Console.WriteLine($"    Character count: {entitiesInDocument.Statistics.CharacterCount}");
                    Console.WriteLine($"    Transaction count: {entitiesInDocument.Statistics.TransactionCount}");
                }
                Console.WriteLine("");
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {entitiesPerDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {entitiesPerDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {entitiesPerDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {entitiesPerDocuments.Statistics.TransactionCount}");
            Console.WriteLine("");
            #endregion
        }
    }
}
