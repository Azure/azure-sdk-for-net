// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample6_AnalyzeText_RecognizeLinkedEntities : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void RecognizeLinkedEntities()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample6_AnalyzeText_RecognizeLinkedEntities
            string textA =
                "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
                + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
                + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
                + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

            string textB =
                "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, to develop and sell BASIC"
                + " interpreters for the Altair 8800. During his career at Microsoft, Gates held the positions of"
                + " chairman chief executive officer, president and chief software architect while also being the"
                + " largest individual shareholder until May 2014.";

            string textC =
                "El CEO de Microsoft es Satya Nadella, quien asumió esta posición en Febrero de 2014. Él empezó como"
                + " Ingeniero de Software en el año 1992.";

            string textD = string.Empty;

            AnalyzeTextInput body = new TextEntityLinkingInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                        new MultiLanguageInput("B", textB) { Language = "en" },
                        new MultiLanguageInput("C", textC) { Language = "es" },
                        new MultiLanguageInput("D", textD),
                    }
                },
                ActionContent = new EntityLinkingActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = client.AnalyzeText(body);
            AnalyzeTextEntityLinkingResult entityLinkingTaskResult = (AnalyzeTextEntityLinkingResult)response.Value;

            foreach (EntityLinkingActionResult entityLinkingResult in entityLinkingTaskResult.Results.Documents)
            {
                Console.WriteLine($"Result for document with Id = \"{entityLinkingResult.Id}\":");
                Console.WriteLine($"Recognized {entityLinkingResult.Entities.Count} entities:");
                foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
                {
                    Console.WriteLine($"  Name: {linkedEntity.Name}");
                    Console.WriteLine($"  LanguageClient: {linkedEntity.Language}");
                    Console.WriteLine($"  Data Source: {linkedEntity.DataSource}");
                    Console.WriteLine($"  URL: {linkedEntity.Url}");
                    Console.WriteLine($"  NamedEntity Id in Data Source: {linkedEntity.Id}");
                    foreach (EntityLinkingMatch match in linkedEntity.Matches)
                    {
                        Console.WriteLine($"    EntityLinkingMatch Text: {match.Text}");
                        Console.WriteLine($"    Offset: {match.Offset}");
                        Console.WriteLine($"    Length: {match.Length}");
                        Console.WriteLine($"    Confidence score: {match.ConfidenceScore}");
                    }
                }
                Console.WriteLine();
            }

            foreach (DocumentError analyzeTextDocumentError in entityLinkingTaskResult.Results.Errors)
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
