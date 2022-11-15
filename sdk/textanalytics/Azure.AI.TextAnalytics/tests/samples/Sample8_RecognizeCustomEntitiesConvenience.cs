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
        public void RecognizeCustomEntitiesConvenience()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.StaticEndpoint;
            string apiKey = TestEnvironment.StaticApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            // Create input documents.
            string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                                worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                                We tried again today and it was amazing. Everyone in my family liked the trail although
                                it was too challenging for the less athletic among us.";

            string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                                our anniversary so they helped me organize a little surprise for my partner.
                                The room was clean and with the decoration I requested. It was perfect!";

            var batchDocuments = new List<string>
            {
                documentA,
                documentB
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
