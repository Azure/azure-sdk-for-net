// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task AnalyzeOperationAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:AnalyzeOperationBatchAsync
            string document = @"We went to Contoso Steakhouse located at midtown NYC last week for a dinner party, 
                                and we adore the spot! They provide marvelous food and they have a great menu. The
                                chief cook happens to be the owner (I think his name is John Doe) and he is super 
                                nice, coming out of the kitchen and greeted us all. We enjoyed very much dining in 
                                the place! The Sirloin steak I ordered was tender and juicy, and the place was impeccably
                                clean. You can even pre-order from their online menu at www.contososteakhouse.com, 
                                call 312-555-0176 or send email to order@contososteakhouse.com! The only complaint 
                                I have is the food didn't come fast enough. Overall I highly recommend it!";

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", document)
                {
                     Language = "en",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>() { new RecognizeEntitiesOptions() },
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() },
                DisplayName = "AnalyzeOperationSample"
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            await foreach (AnalyzeBatchActionsResult documentsInPage in operation.Value)
            {
                RecognizeEntitiesResultCollection entitiesResult = documentsInPage.RecognizeEntitiesActionsResults.ElementAt(0).Result;

                ExtractKeyPhrasesResultCollection keyPhrasesResult = documentsInPage.ExtractKeyPhrasesActionsResults.ElementAt(0).Result;

                RecognizePiiEntitiesResultCollection piiResult = documentsInPage.RecognizePiiEntitiesActionsResults.ElementAt(0).Result;

                Console.WriteLine("Recognized Entities");

                foreach (RecognizeEntitiesResult result in entitiesResult)
                {
                    Console.WriteLine($"    Recognized the following {result.Entities.Count} entities:");

                    foreach (CategorizedEntity entity in result.Entities)
                    {
                        Console.WriteLine($"    Entity: {entity.Text}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                        Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("Recognized PII Entities");

                foreach (RecognizePiiEntitiesResult result in piiResult)
                {
                    Console.WriteLine($"    Recognized the following {result.Entities.Count} PII entities:");

                    foreach (PiiEntity entity in result.Entities)
                    {
                        Console.WriteLine($"    Entity: {entity.Text}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                        Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("Key Phrases");

                foreach (ExtractKeyPhrasesResult result in keyPhrasesResult)
                {
                    Console.WriteLine($"    Recognized the following {result.KeyPhrases.Count} Keyphrases:");

                    foreach (string keyphrase in result.KeyPhrases)
                    {
                        Console.WriteLine($"    {keyphrase}");
                    }
                    Console.WriteLine("");
                }
            }
        }

        #endregion
    }
}
