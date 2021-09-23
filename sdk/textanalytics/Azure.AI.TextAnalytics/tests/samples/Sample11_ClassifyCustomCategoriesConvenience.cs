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
        public void ClassifyCustomCategoriesConvenience()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string projectName = TestEnvironment.MultiCategoriesProjectName;
            string deploymentName = TestEnvironment.MultiCategoriesDeploymentName;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Get input document.
            string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };

            var classifyCustomCategoriesAction = new ClassifyCustomCategoriesAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>() { classifyCustomCategoriesAction }
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
                IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classificationResultsCollection = documentsInPage.ClassifyCustomCategoriesResults;

                foreach (ClassifyCustomCategoriesActionResult classificationActionResults in classificationResultsCollection)
                {
                    if (classificationActionResults.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Action error code: {classificationActionResults.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {classificationActionResults.Error.Message}");
                        continue;
                    }

                    foreach (ClassifyCustomCategoriesResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                            Console.WriteLine($"  Message: {documentResults.Error.Message}");
                            continue;
                        }

                        if (documentResults.DocumentClassifications.Count > 0)
                        {
                            Console.WriteLine($"  The following classes were predicted for this document:");

                            foreach (DocumentClassification classification in documentResults.DocumentClassifications)
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
