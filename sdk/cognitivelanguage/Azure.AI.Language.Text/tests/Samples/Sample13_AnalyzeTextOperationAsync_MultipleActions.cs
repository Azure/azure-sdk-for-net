// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample13_AnalyzeTextOperationAsync_MultipleActions : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task MultipleActions()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample13_AnalyzeTextOperationAsync_MultipleActions
            string textA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            string textB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string textC =
                "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
                + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
                + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
                + " great. We will definitely come back.";

            string textD = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA) { Language = "en" },
                    new MultiLanguageInput("B", textB) { Language = "es" },
                    new MultiLanguageInput("C", textC) { Language = "en" },
                    new MultiLanguageInput("D", textD),
                }
            };

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new EntitiesOperationAction
                {
                    Name = "EntitiesOperationActionSample", // Optional string for humans to identify action by name.
                },
                new KeyPhraseOperationAction
                {
                    Name = "KeyPhraseOperationActionSample", // Optional string for humans to identify action by name.
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextJobState = response.Value;

            foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
            {
                if (analyzeTextLROResult is EntityRecognitionOperationResult)
                {
                    EntityRecognitionOperationResult entityRecognitionLROResult = (EntityRecognitionOperationResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (EntityActionResultWithMetadata nerResult in entityRecognitionLROResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

                        Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

                        foreach (NamedEntityWithMetadata entity in nerResult.Entities)
                        {
                            Console.WriteLine($"    Text: {entity.Text}");
                            Console.WriteLine($"    Offset: {entity.Offset}");
                            Console.WriteLine($"    Length: {entity.Length}");
                            Console.WriteLine($"    Category: {entity.Category}");
                            Console.WriteLine($"    Type: {entity.Type}");
                            Console.WriteLine($"    Tags:");
                            foreach (EntityTag tag in entity.Tags)
                            {
                                Console.WriteLine($"            TagName: {tag.Name}");
                                Console.WriteLine($"            TagConfidenceScore: {tag.ConfidenceScore}");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                    // View the errors in the document
                    foreach (DocumentError error in entityRecognitionLROResult.Results.Errors)
                    {
                        Console.WriteLine($"  Error in document: {error.Id}!");
                        Console.WriteLine($"  Document error: {error.Error}");
                        continue;
                    }
                }

                if (analyzeTextLROResult is KeyPhraseExtractionOperationResult)
                {
                    KeyPhraseExtractionOperationResult keyPhraseExtractionLROResult = (KeyPhraseExtractionOperationResult)analyzeTextLROResult;

                    // View the classifications recognized in the input documents.
                    foreach (KeyPhrasesActionResult kpeResult in keyPhraseExtractionLROResult.Results.Documents)
                    {
                        Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
                        foreach (string keyPhrase in kpeResult.KeyPhrases)
                        {
                            Console.WriteLine($"    {keyPhrase}");
                        }
                        Console.WriteLine();
                    }
                    // View the errors in the document
                    foreach (DocumentError error in keyPhraseExtractionLROResult.Results.Errors)
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
