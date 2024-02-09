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
    public partial class Sample3_AnalyzeText_ExtractKeyPhrases : SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ExtractKeyPhrases()
        {
            #region Snippet:Sample3_AnalyzeText_ExtractKeyPhrases
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

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

            AnalyzeTextTask body = new AnalyzeTextKeyPhraseExtractionInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                        new MultiLanguageInput("B", documentB, "es"),
                        new MultiLanguageInput("C", documentC, "en"),
                        new MultiLanguageInput("D", documentD),
                    }
                },
                Parameters = new KeyPhraseTaskParameters()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextTaskResult> response = client.AnalyzeText(body);
            KeyPhraseTaskResult keyPhraseTaskResult = (KeyPhraseTaskResult)response.Value;

            foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{kpeResult.Id}\":");
                foreach (string keyPhrase in kpeResult.KeyPhrases)
                {
                    Console.WriteLine($"    {keyPhrase}");
                }
                Console.WriteLine();
            }

            foreach (AnalyzeTextDocumentError analyzeTextDocumentError in keyPhraseTaskResult.Results.Errors)
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
