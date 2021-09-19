// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests.samples
{
    public partial class RecognizeCustomEntitiesSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void RecognizeCustomEntities()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Get input document(s).
            string documentA = @"A recent report by the Government Accountability Office (GAO) found that the dramatic
                                increase in oil and natural gas development on federal lands over the past six years
                                has stretched the staff of the BLM to a point that it has been unable to meet its 
                                environmental protection responsibilities.";

            string documentB = @"David Schmidt, senior vice president--Food Safety, International Food Information 
                                Council (IFIC), Washington, D.C., discussed the physical activity component.";

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

            //prepare actions
            var actions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitesProjectName, TestEnvironment.RecognizeCustomEntitesDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = client.StartAnalyzeActions(batchDocuments, actions);

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
                    Console.WriteLine($"Total actions: {operation.ActionsTotal}");
                    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
                    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
                    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
                }
            }

            foreach (AnalyzeActionsResult documentsInPage in operation.GetValues())
            {
                IReadOnlyCollection<RecognizeCustomEntitiesActionResult> customEntitiesResults = documentsInPage.RecognizeCustomEntitiesResults;
                foreach (RecognizeCustomEntitiesActionResult customEntitiesActionResulsts in customEntitiesResults)
                {
                    int docNumber = 1;
                    foreach (RecognizeEntitiesResult documentResults in customEntitiesActionResulsts.DocumentsResults)
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
            }
        }
    }
}
