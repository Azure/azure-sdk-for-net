// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample5_AnalyzeTextAsync_RecognizePii : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task RecognizePii()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample5_AnalyzeTextAsync_RecognizePii
            string textA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            string textB =
                "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
                + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
                + " they confirmed the number was 111000025.";

            string textC = string.Empty;

            AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                        new MultiLanguageInput("B", textB) { Language = "es" },
                        new MultiLanguageInput("C", textC),
                    }
                },
                ActionContent = new PiiActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
                Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
                Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

                foreach (PiiEntity entity in piiResult.Entities)
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

            foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
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
        public async Task RecognizePii_RedactionPolicy()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample5_AnalyzeTextAsync_RecognizePii_RedactionPolicy
            string textA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            string textB =
                "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
                + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
                + " they confirmed the number was 111000025.";

            string textC = string.Empty;

            AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                        new MultiLanguageInput("B", textB) { Language = "es" },
                        new MultiLanguageInput("C", textC),
                    }
                },
                ActionContent = new PiiActionContent()
                {
                    ModelVersion = "latest",
                    // Avaliable RedactionPolicies: EntityMaskPolicyType, CharacterMaskPolicyType, and NoMaskPolicyType
                    RedactionPolicy = new EntityMaskPolicyType()
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");
                Console.WriteLine($"  Redacted Text: \"{piiResult.RedactedText}\":");
                Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

                foreach (PiiEntity entity in piiResult.Entities)
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

            foreach (DocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
            {
                Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
                Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
                Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
                Console.WriteLine();
                continue;
            }
            #endregion
        }
    }
}
