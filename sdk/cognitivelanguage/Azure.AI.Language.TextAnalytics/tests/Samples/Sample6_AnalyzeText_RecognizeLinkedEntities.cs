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
    public partial class Sample6_AnalyzeTextAsync_RecognizeLinkedEntities : SamplesBase<TextAnalyticsClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task RecognizeLinkedEntities()
        {
            #region Snippet:Sample6_AnalyzeTextAsync_RecognizeLinkedEntities
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            Text.Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");

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

            string documentC =
                "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
                + " Ingeniero de Software en el año 1992.";

            string documentD = string.Empty;

            AnalyzeTextTask body = new AnalyzeTextEntityLinkingInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                        new MultiLanguageInput("B", documentB, "en"),
                        new MultiLanguageInput("C", documentC, "es"),
                        new MultiLanguageInput("D", documentD),
                    }
                },
                Parameters = new EntityLinkingTaskParameters()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextTaskResult> response = await client.AnalyzeTextAsync(body);
            EntityLinkingTaskResult entityLinkingTaskResult = (EntityLinkingTaskResult)response.Value;

            foreach (EntityLinkingResultWithDetectedLanguage entityLinkingResult in entityLinkingTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{entityLinkingResult.Id}\":");
                Console.WriteLine($"Recognized {entityLinkingResult.Entities.Count} entities:");
                foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
                {
                    Console.WriteLine($"  Name: {linkedEntity.Name}");
                    Console.WriteLine($"  Language: {linkedEntity.Language}");
                    Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
                    Console.WriteLine($"  URL: {linkedEntity.Url}");
                    Console.WriteLine($"  Entity Id in Data Source: {linkedEntity.Id}");
                    foreach (Match match in linkedEntity.Matches)
                    {
                        Console.WriteLine($"    Match Text: {match.Text}");
                        Console.WriteLine($"    Offset: {match.Offset}");
                        Console.WriteLine($"    Length: {match.Length}");
                        Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
                    }
                }
                Console.WriteLine();
            }

            foreach (AnalyzeTextDocumentError analyzeTextDocumentError in entityLinkingTaskResult.Results.Errors)
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
