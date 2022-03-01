﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task AnalyzeOperationAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                                worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                                We tried again today and it was amazing. Everyone in my family liked the trail although
                                it was too challenging for the less athletic among us.";

            string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                                our anniversary so they helped me organize a little surprise for my partner.
                                The room was clean and with the decoration I requested. It was perfect!";

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "en",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "en",
                }
            };

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() },
                DisplayName = "AnalyzeOperationSample"
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, actions);

            await operation.WaitForCompletionAsync();

            Console.WriteLine($"Status: {operation.Status}");
            Console.WriteLine($"Created On: {operation.CreatedOn}");
            Console.WriteLine($"Expires On: {operation.ExpiresOn}");
            Console.WriteLine($"Last modified: {operation.LastModified}");
            if (!string.IsNullOrEmpty(operation.DisplayName))
                Console.WriteLine($"Display name: {operation.DisplayName}");
            Console.WriteLine($"Total actions: {operation.ActionsTotal}");
            Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
            Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
            Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");

            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResults = documentsInPage.ExtractKeyPhrasesResults;
                IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResults = documentsInPage.RecognizeEntitiesResults;

                Console.WriteLine("Recognized Entities");
                int docNumber = 1;
                foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesResults)
                {
                    Console.WriteLine($" Action name: {entitiesActionResults.ActionName}");
                    foreach (RecognizeEntitiesResult documentResults in entitiesActionResults.DocumentsResults)
                    {
                        Console.WriteLine($" Document #{docNumber++}");
                        Console.WriteLine($"  Recognized the following {documentResults.Entities.Count} entities:");

                        foreach (CategorizedEntity entity in documentResults.Entities)
                        {
                            Console.WriteLine($"  Entity: {entity.Text}");
                            Console.WriteLine($"  Category: {entity.Category}");
                            Console.WriteLine($"  Offset: {entity.Offset}");
                            Console.WriteLine($"  Length: {entity.Length}");
                            Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
                        }
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("Key Phrases");
                docNumber = 1;
                foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesResults)
                {
                    foreach (ExtractKeyPhrasesResult documentResults in keyPhrasesActionResult.DocumentsResults)
                    {
                        Console.WriteLine($" Document #{docNumber++}");
                        Console.WriteLine($"  Recognized the following {documentResults.KeyPhrases.Count} Keyphrases:");

                        foreach (string keyphrase in documentResults.KeyPhrases)
                        {
                            Console.WriteLine($"  {keyphrase}");
                        }
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
