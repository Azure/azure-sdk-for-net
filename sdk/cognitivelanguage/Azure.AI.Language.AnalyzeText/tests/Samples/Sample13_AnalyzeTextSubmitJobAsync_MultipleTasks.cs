// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample13_AnalyzeTextSubmitJobAsync_MultipleTasks : SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task MultipleTask()
        {
            #region Snippet:Sample13_AnalyzeTextSubmitJob_MultipleTasks
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            Text.LanguageClient client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

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
            MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
            {
                Documents =
                {
                    new MultiLanguageInput("A", documentA, "en"),
                    new MultiLanguageInput("B", documentB, "es"),
                    new MultiLanguageInput("C", documentC, "en"),
                    new MultiLanguageInput("D", documentD),
                }
            };

            AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
            {
                new EntitiesLROTask(),
                new KeyPhraseLROTask(),
            });

            Operation operation = await client.AnalyzeTextSubmitJobAsync(WaitUntil.Completed, analyzeTextJobsInput);

            // View the operation results.
            AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

            foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
            {
                if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.EntityRecognitionLROResults)
                {
                    EntityRecognitionLROResult entityRecognitionLROResult = (EntityRecognitionLROResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entityRecognitionLROResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

                        Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

                        foreach (EntityWithMetadata entity in nerResult.Entities)
                        {
                            Console.WriteLine($"    Text: {entity.Text}");
                            Console.WriteLine($"    Offset: {entity.Offset}");
                            Console.WriteLine($"    Length: {entity.Length}");
                            Console.WriteLine($"    Category: {entity.Category}");
                            if (!string.IsNullOrEmpty(entity.Subcategory))
                                Console.WriteLine($"    SubCategory: {entity.Subcategory}");
                            Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                    // View the errors in the document
                    foreach (AnalyzeTextDocumentError error in entityRecognitionLROResult.Results.Errors)
                    {
                        Console.WriteLine($"  Error in document: {error.Id}!");
                        Console.WriteLine($"  Document error: {error.Error}");
                        continue;
                    }
                }

                if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.KeyPhraseExtractionLROResults)
                {
                    KeyPhraseExtractionLROResult keyPhraseExtractionLROResult = (KeyPhraseExtractionLROResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseExtractionLROResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
                        foreach (string keyPhrase in kpeResult.KeyPhrases)
                        {
                            Console.WriteLine($"    {keyPhrase}");
                        }
                        Console.WriteLine();
                    }
                    // View the errors in the document
                    foreach (AnalyzeTextDocumentError error in keyPhraseExtractionLROResult.Results.Errors)
                    {
                        Console.WriteLine($"  Error in document: {error.Id}!");
                        Console.WriteLine($"  Document error: {error.Error}");
                        continue;
                    }
                }
            }
            #endregion
        }
    }
}
