// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void MultiCategoryClassifyConvenience()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Get input document.
            string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };

            // Set project and deployment names of the target model
            // To train a model to classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities
            string projectName = TestEnvironment.MultiClassificationProjectName;
            string deploymentName = TestEnvironment.MultiClassificationDeploymentName;

            var multiCategoryClassifyAction = new MultiCategoryClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>() { multiCategoryClassifyAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = client.StartAnalyzeActions(batchInput, actions);

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
                IReadOnlyCollection<MultiCategoryClassifyActionResult> multiClassificationActionResults = documentsInPage.MultiCategoryClassifyResults;

                foreach (MultiCategoryClassifyActionResult classificationActionResults in multiClassificationActionResults)
                {
                    Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
                    foreach (MultiCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.Classifications.Count > 0)
                        {
                            Console.WriteLine($"  The following classes were predicted for this document:");

                            foreach (ClassificationCategory classification in documentResults.Classifications)
                            {
                                Console.WriteLine($"  Class category \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
