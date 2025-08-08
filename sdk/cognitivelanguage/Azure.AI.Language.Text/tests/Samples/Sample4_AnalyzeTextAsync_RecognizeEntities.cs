// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample4_AnalyzeTextAsync_RecognizeEntities : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task RecognizeEntities()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample4_AnalyzeTextAsync_RecognizeEntities
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

            AnalyzeTextInput body = new TextEntityRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                        new MultiLanguageInput("B", textB) { Language = "es" },
                        new MultiLanguageInput("C", textC) { Language = "en" },
                        new MultiLanguageInput("D", textD),
                    }
                },
                ActionContent = new EntitiesActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

            foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
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
                    Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            foreach (DocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
            {
                Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
                Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
                Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
                Console.WriteLine();
                continue;
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task RecognizeEntitiesPreview()
        {
            #region Snippet:Sample4_AnalyzeTextAsync_RecognizeEntities_Preview
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2024_11_15_Preview);
            var client = new TextAnalysisClient(endpoint, credential, options);

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

            AnalyzeTextInput body = new TextEntityRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                        new MultiLanguageInput("B", textB) { Language = "es" },
                        new MultiLanguageInput("C", textC) { Language = "en" },
                        new MultiLanguageInput("D", textD),
                    }
                },
                ActionContent = new EntitiesActionContent()
                {
                    ModelVersion = "latest",
                    OverlapPolicy = new AllowOverlapEntityPolicyType(),
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

            foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{nerResult.Id}\":");

                Console.WriteLine($"  Recognized {nerResult.Entities.Count} entities:");

                foreach (NamedEntityWithMetadata entity in nerResult.Entities)
                {
                    Console.WriteLine($"    Text: {entity.Text}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    Length: {entity.Length}");
                    Console.WriteLine($"    Category: {entity.Type}");
                    Console.WriteLine($"    Type: {entity.Type}");
                    Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                    Console.WriteLine($"    Entity Tags:");
                    foreach (EntityTag tag in entity.Tags)
                    {
                        Console.WriteLine($"      Tag Name: {tag.Name}");
                        Console.WriteLine($"      Tag Score: {tag.ConfidenceScore}");
                        Console.WriteLine();
                    }
                    if (entity.Metadata != null)
                    {
                        switch (entity.Metadata)
                        {
                            case TimeMetadata timeMetadata:
                                Console.WriteLine($"    TimeMetadata:");
                                foreach (DateValue time in timeMetadata.Dates)
                                    PrintDateValue(timeMetadata.Dates);
                                break;
                            case DateMetadata dateMetadata:
                                Console.WriteLine($"    DateMetadata:");
                                foreach (DateValue date in dateMetadata.Dates)
                                    PrintDateValue(dateMetadata.Dates);
                                break;
                            case DateTimeMetadata dateTimeMetadata:
                                Console.WriteLine($"    DateTimeMetadata:");
                                PrintDateValue(dateTimeMetadata.Dates);
                                break;
                            case TemporalSetMetadata temporalSetMetadata:
                                Console.WriteLine($"    TemporalSetMetadata:");
                                PrintDateValue(temporalSetMetadata.Dates);
                                break;
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            foreach (DocumentError analyzeTextDocumentError in entitiesTaskResult.Results.Errors)
            {
                Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
                Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
                Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
                Console.WriteLine();
                continue;
            }
            #endregion
        }

        #region Snippet:Sample4_AnalyzeTextAsync_RecognizeEntities_PrintDateValue
        public void PrintDateValue(IReadOnlyList<DateValue> dateValues)
        {
            foreach (DateValue date in dateValues)
            {
                Console.WriteLine($"      Timex: {date.Timex}");
                Console.WriteLine($"      Value: {date.Value}");
            }
        }
        #endregion
    }
}
