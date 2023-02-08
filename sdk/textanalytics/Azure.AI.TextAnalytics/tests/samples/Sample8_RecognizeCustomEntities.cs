// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public void RecognizeCustomEntities()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.StaticEndpoint;
            string apiKey = TestEnvironment.StaticApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            // Create input documents.
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

            // Set project and deployment names of the target model
            // To train a model to recognize your custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition
            string projectName = TestEnvironment.RecognizeCustomEntitiesProjectName;
            string deploymentName = TestEnvironment.RecognizeCustomEntitiesDeploymentName;

            var recognizeCustomEntitiesAction = new RecognizeCustomEntitiesAction(projectName, deploymentName);

            // prepare actions.
            var actions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>() { recognizeCustomEntitiesAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = client.StartAnalyzeActions(batchDocuments, actions);

            // Wait for completion with manual polling.
            TimeSpan pollingInterval = new TimeSpan(1000);

            while (true)
            {
                Console.WriteLine($"Status: {operation.Status}");
                operation.UpdateStatus();
                if (operation.HasCompleted)
                {
                    break;
                }

                Thread.Sleep(pollingInterval);
            }

            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            // View operation results.
            foreach (AnalyzeActionsResult documentsInPage in operation.GetValues())
            {
                IReadOnlyCollection<RecognizeCustomEntitiesActionResult> customEntitiesActionResults = documentsInPage.RecognizeCustomEntitiesResults;
                foreach (RecognizeCustomEntitiesActionResult customEntitiesActionResult in customEntitiesActionResults)
                {
                    Console.WriteLine($" Action name: {customEntitiesActionResult.ActionName}");
                    int docNumber = 1;
                    foreach (RecognizeEntitiesResult documentResults in customEntitiesActionResult.DocumentsResults)
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
