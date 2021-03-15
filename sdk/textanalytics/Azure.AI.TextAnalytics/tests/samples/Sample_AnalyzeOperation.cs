// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void AnalyzeOperation()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsAnalyzeOperation

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

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>() { new RecognizeEntitiesOptions() },
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() },
                RecognizeLinkedEntitiesOptions = new List<RecognizeLinkedEntitiesOptions>() { new RecognizeLinkedEntitiesOptions() },
                DisplayName = "AnalyzeOperationSample"
            };

            AnalyzeBatchActionsOperation operation = client.StartAnalyzeBatchActions(batchDocuments, actions);

            TimeSpan pollingInterval = new TimeSpan(1000);

            while (!operation.HasCompleted)
            {
                Thread.Sleep(pollingInterval);
                operation.UpdateStatus();

                Console.WriteLine($"Status: {operation.Status}");
                //If operation has not started, all other fields are null
                if (operation.Status != TextAnalyticsOperationStatus.NotStarted)
                {
                    Console.WriteLine($"Expires On: {operation.ExpiresOn}");
                    Console.WriteLine($"Last modified: {operation.LastModified}");
                    if (!string.IsNullOrEmpty(operation.DisplayName))
                        Console.WriteLine($"Display name: {operation.DisplayName}");
                    Console.WriteLine($"Total actions: {operation.TotalActions}");
                    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
                    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
                    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
                }
            }

            foreach (AnalyzeBatchActionsResult documentsInPage in operation.GetValues())
            {
                RecognizeEntitiesResultCollection entitiesResult = documentsInPage.RecognizeEntitiesActionsResults.FirstOrDefault().Result;

                ExtractKeyPhrasesResultCollection keyPhrasesResult = documentsInPage.ExtractKeyPhrasesActionsResults.FirstOrDefault().Result;

                RecognizePiiEntitiesResultCollection piiResult = documentsInPage.RecognizePiiEntitiesActionsResults.FirstOrDefault().Result;

                RecognizeLinkedEntitiesResultCollection linkedEntitiesResult = documentsInPage.RecognizeLinkedEntitiesActionsResults.FirstOrDefault().Result;

                Console.WriteLine("Recognized Entities");

                foreach (RecognizeEntitiesResult result in entitiesResult)
                {
                    Console.WriteLine($"  Recognized the following {result.Entities.Count} entities:");

                    foreach (CategorizedEntity entity in result.Entities)
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

                Console.WriteLine("Recognized PII Entities");

                foreach (RecognizePiiEntitiesResult result in piiResult)
                {
                    Console.WriteLine($"  Recognized the following {result.Entities.Count} PII entities:");

                    foreach (PiiEntity entity in result.Entities)
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

                Console.WriteLine("Key Phrases");

                foreach (ExtractKeyPhrasesResult result in keyPhrasesResult)
                {
                    Console.WriteLine($"  Recognized the following {result.KeyPhrases.Count} Keyphrases:");

                    foreach (string keyphrase in result.KeyPhrases)
                    {
                        Console.WriteLine($"  {keyphrase}");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("Recognized Linked Entities");

                foreach (RecognizeLinkedEntitiesResult result in linkedEntitiesResult)
                {
                    Console.WriteLine($"  Recognized the following {result.Entities.Count} linked entities:");

                    foreach (LinkedEntity entity in result.Entities)
                    {
                        Console.WriteLine($"  Entity: {entity.Name}");
                        Console.WriteLine($"  DataSource: {entity.DataSource}");
                        Console.WriteLine($"  DataSource EntityId: {entity.DataSourceEntityId}");
                        Console.WriteLine($"  Language: {entity.Language}");
                        Console.WriteLine($"  DataSource Url: {entity.Url}");

                        Console.WriteLine($"  Total Matches: {entity.Matches.Count()}");
                        foreach (LinkedEntityMatch match in entity.Matches)
                        {
                            Console.WriteLine($"    Match Text: {match.Text}");
                            Console.WriteLine($"    ConfidenceScore: {match.ConfidenceScore}");
                            Console.WriteLine($"    Offset: {match.Offset}");
                            Console.WriteLine($"    Length: {match.Length}");
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine("");
                }
            }
        }

        #endregion
    }
}
