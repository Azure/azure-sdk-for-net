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
        public void SingleCategoryClassifyConvenience()
        {
            // Create a Text Analytics client.
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
            string projectName = TestEnvironment.SingleClassificationProjectName;
            string deploymentName = TestEnvironment.SingleClassificationDeploymentName;

            var singleCategoryClassifyAction = new SingleCategoryClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>() { singleCategoryClassifyAction }
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
                IReadOnlyCollection<SingleCategoryClassifyActionResult> singleClassificationActionResults = documentsInPage.SingleCategoryClassifyResults;

                foreach (SingleCategoryClassifyActionResult classificationActionResults in singleClassificationActionResults)
                {
                    Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
                    foreach (SingleCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        Console.WriteLine($"  Class category \"{documentResults.Classification.Category}\" predicted with a confidence score of {documentResults.Classification.ConfidenceScore}.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
