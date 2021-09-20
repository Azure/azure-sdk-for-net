// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task ClassifyCustomCategoryConvenienceAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsClassifyCustomCategoryAsync
            // Get input document.
            string document = @"I am so hungry! I can hear my stomach growling; I need this order to get here as soon as possible!";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };

            var classifyCustomCategoryAction = new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>() { classifyCustomCategoryAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

            await operation.WaitForCompletionAsync();
            #endregion Snippet:TextAnalyticsClassifyCustomCategoryAsync

            #region Snippet:TextAnalyticsClassifyCustomCategoryOperationStatus
            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();
            #endregion Snippet:TextAnalyticsClassifyCustomCategoryOperationStatus

            #region Snippet:TextAnalyticsClassifyCustomCategoryAsyncViewResults
            // View operation results.
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<ClassifyCustomCategoryActionResult> classificationResultsCollection = documentsInPage.ClassifyCustomCategoryResults;

                foreach (ClassifyCustomCategoryActionResult classificationActionResults in classificationResultsCollection)
                {
                    if (classificationActionResults.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Action error code: {classificationActionResults.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {classificationActionResults.Error.Message}");
                        continue;
                    }

                    foreach (ClassifyCustomCategoryResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                            Console.WriteLine($"  Message: {documentResults.Error.Message}");
                            continue;
                        }

                        Console.WriteLine($"  Class category \"{documentResults.DocumentClassification.Category}\" predicted with a confidence score of {documentResults.DocumentClassification.ConfidenceScore}.");
                        Console.WriteLine();
                    }
                }
            }
            #endregion Snippet:TextAnalyticsClassifyCustomCategoryAsyncViewResults
        }
    }
}
