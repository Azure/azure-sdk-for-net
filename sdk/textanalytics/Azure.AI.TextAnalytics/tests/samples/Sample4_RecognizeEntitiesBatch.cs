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
        public void RecognizeEntitiesBatch()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample4_RecognizeEntitiesBatch
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            string documentB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string documentC =
                "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
                + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
                + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
                + " great. We will definitely come back.";

            string documentD = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<TextDocumentInput> batchedDocuments = new()
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
                new TextDocumentInput("4", documentD)
            };

            TextAnalyticsRequestOptions options = new() { IncludeStatistics = true };
            Response<RecognizeEntitiesResultCollection> response = client.RecognizeEntitiesBatch(batchedDocuments, options);
            RecognizeEntitiesResultCollection entitiesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Recognize Entities, model version: \"{entitiesInDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizeEntitiesResult documentResult in entitiesInDocuments)
            {
                TextDocumentInput document = batchedDocuments[i++];

                Console.WriteLine($"Result for document with Id = \"{document.Id}\" and Language = \"{document.Language}\":");

                if (documentResult.HasError)
                {
                    Console.WriteLine($"  Error!");
                    Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {documentResult.Error.Message}");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

                foreach (CategorizedEntity entity in documentResult.Entities)
                {
                    Console.WriteLine($"    Text: {entity.Text}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    Length: {entity.Length}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    if (!string.IsNullOrEmpty(entity.SubCategory))
                        Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                    Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                    if (entity.Resolutions.Count > 0)
                    {
                        Console.WriteLine($"    Resolutions:");
                        foreach (BaseResolution resolution in entity.Resolutions)
                        {
                            // There are several different kinds of resolutions. In this particular sample, we are
                            // interested in viewing those of type DateTimeResolution and TemporalSpanResolution.

                            if (resolution is DateTimeResolution dateTime)
                            {
                                Console.WriteLine($"      Value: {dateTime.Value} ");
                                Console.WriteLine($"      DateTimeSubKind: {dateTime.DateTimeSubKind} ");
                                if (!string.IsNullOrEmpty(dateTime.Timex))
                                    Console.WriteLine($"      Timex: {dateTime.Timex}");
                                if (dateTime.Modifier is not null)
                                    Console.WriteLine($"      Modifier: {dateTime.Modifier}");
                            }

                            if (resolution is TemporalSpanResolution temporalSpan)
                            {
                                if (!string.IsNullOrEmpty(temporalSpan.Begin))
                                    Console.WriteLine($"      Begin: {temporalSpan.Begin}");
                                if (!string.IsNullOrEmpty(temporalSpan.End))
                                    Console.WriteLine($"      End: {temporalSpan.End}");
                                if (!string.IsNullOrEmpty(temporalSpan.Duration))
                                    Console.WriteLine($"      Duration: {temporalSpan.Duration}");
                                if (!string.IsNullOrEmpty(temporalSpan.End))
                                    Console.WriteLine($"      Timex: {temporalSpan.Timex}");
                                if (temporalSpan.Modifier is not null)
                                    Console.WriteLine($"      Modifier: {temporalSpan.Modifier}");
                            }
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"  Document statistics:");
                Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
                Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                Console.WriteLine();
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {entitiesInDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {entitiesInDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {entitiesInDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {entitiesInDocuments.Statistics.TransactionCount}");
            Console.WriteLine();
            #endregion
        }
    }
}
