// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public async Task AnalyzeOperationConvenienceAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:AnalyzeOperationConvenienceAsync
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us.";

            string documentB =
                "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
                + " so they helped me organize a little surprise for my partner. The room was clean and with the"
                + " decoration I requested. It was perfect!";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB
            };

            TextAnalyticsActions actions = new()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() { ActionName = "ExtractKeyPhrasesSample" } },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() { ActionName = "RecognizeEntitiesSample" } },
                DisplayName = "AnalyzeOperationSample"
            };

            // Perform the text analysis operation.
            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchedDocuments, actions);

            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            if (!string.IsNullOrEmpty(operation.DisplayName))
            {
                Console.WriteLine($"Display name: {operation.DisplayName}");
                Console.WriteLine();
            }

            Console.WriteLine($"Total actions: {operation.ActionsTotal}");
            Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
            Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
            Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
            Console.WriteLine();

            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResults = documentsInPage.ExtractKeyPhrasesResults;
                IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResults = documentsInPage.RecognizeEntitiesResults;

                Console.WriteLine("Recognized Entities");
                int docNumber = 1;
                foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesResults)
                {
                    Console.WriteLine($" Action name: {entitiesActionResults.ActionName}");
                    Console.WriteLine();
                    foreach (RecognizeEntitiesResult documentResult in entitiesActionResults.DocumentsResults)
                    {
                        Console.WriteLine($" Document #{docNumber++}");
                        Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

                        foreach (CategorizedEntity entity in documentResult.Entities)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"    Entity: {entity.Text}");
                            Console.WriteLine($"    Category: {entity.Category}");
                            Console.WriteLine($"    Offset: {entity.Offset}");
                            Console.WriteLine($"    Length: {entity.Length}");
                            Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                            Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("Extracted Key Phrases");
                docNumber = 1;
                foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesResults)
                {
                    Console.WriteLine($" Action name: {keyPhrasesActionResult.ActionName}");
                    Console.WriteLine();
                    foreach (ExtractKeyPhrasesResult documentResults in keyPhrasesActionResult.DocumentsResults)
                    {
                        Console.WriteLine($" Document #{docNumber++}");
                        Console.WriteLine($"  Recognized the following {documentResults.KeyPhrases.Count} Keyphrases:");

                        foreach (string keyphrase in documentResults.KeyPhrases)
                        {
                            Console.WriteLine($"    {keyphrase}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        #endregion
    }
}
