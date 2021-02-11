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
            string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                                worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                                We tried again today and it was amazing. Everyone in my family liked the trail although
                                it was too challenging for the less athletic among us.
                                Not necessarily recommended for small children.
                                A hotel close to the trail offers services for childcare in case you want that.";

            string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                                our anniversary so they helped me organize a little surprise for my partner.
                                The room was clean and with the decoration I requested. It was perfect!";

            string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                                They had great amenities that included an indoor pool, a spa, and a bar.
                                The spa offered couples massages which were really good. 
                                The spa was clean and felt very peaceful. Overall the whole experience was great.
                                We will definitely come back.";

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "en",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "en",
                },
                new TextDocumentInput("3", documentC)
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
                RecognizeEntitiesResultCollection entitiesResult = documentsInPage.RecognizeEntitiesActionsResults.FirstOrDefault().Result;

                ExtractKeyPhrasesResultCollection keyPhrasesResult = documentsInPage.ExtractKeyPhrasesActionsResults.FirstOrDefault().Result;

                RecognizePiiEntitiesResultCollection piiResult = documentsInPage.RecognizePiiEntitiesActionsResults.FirstOrDefault().Result;

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
