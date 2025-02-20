// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void RecognizeLinkedEntitiesBatchConvenience()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample6_RecognizeLinkedEntitiesBatchConvenience
            string documentA =
                "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
                + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
                + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
                + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

            string documentB =
                "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
                + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
                + " chairman chief executive officer, president and chief software architect while also being the"
                + " largest individual shareholder until May 2014.";

            string documentC = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB,
                documentC
            };

            Response<RecognizeLinkedEntitiesResultCollection> response = client.RecognizeLinkedEntitiesBatch(batchedDocuments);
            RecognizeLinkedEntitiesResultCollection entitiesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Recognize Linked Entities, model version: \"{entitiesInDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizeLinkedEntitiesResult documentResult in entitiesInDocuments)
            {
                Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

                if (documentResult.HasError)
                {
                    Console.WriteLine($"  Error!");
                    Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {documentResult.Error.Message}");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine($"Recognized {documentResult.Entities.Count} entities:");
                foreach (LinkedEntity linkedEntity in documentResult.Entities)
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
                        Console.WriteLine($"    Length: {match.Length}");
                        Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
