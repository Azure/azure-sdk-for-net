// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.Language.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample5_AnalyzeTextAsync_RecognizePii : SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async void RecognizePii()
        {
            #region Snippet:Sample5_AnalyzeTextAsync_RecognizePii
            Uri endpoint = new("<endpoint>");
            AzureKeyCredential credential = new("<apiKey>");
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

            string documentA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            string documentB =
                "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
                + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
                + " they confirmed the number was 111000025.";

            string documentC = string.Empty;

            AnalyzeTextTask body = new AnalyzeTextPIIEntitiesRecognitionInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                        new MultiLanguageInput("B", documentB, "es"),
                        new MultiLanguageInput("C", documentC),
                    }
                },
                Parameters = new PIITaskParameters()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextTaskResult> response = await client.AnalyzeTextAsync(body);
            PIITaskResult piiTaskResult = (PIITaskResult)response.Value;

            foreach (PIIResultWithDetectedLanguage piiResult in piiTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{piiResult.Id}\":");

                Console.WriteLine($"  Recognized {piiResult.Entities.Count} entities:");

                foreach (Entity entity in piiResult.Entities)
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

            foreach (AnalyzeTextDocumentError analyzeTextDocumentError in piiTaskResult.Results.Errors)
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
