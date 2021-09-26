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
        public async Task MultiCategoryClassifyConvenienceAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string projectName = TestEnvironment.MultiClassificationProjectName;
            string deploymentName = TestEnvironment.MultiClassificationDeploymentName;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsMultiCategoryClassifyAsync
            // Get input document.
            string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };

            var multiCategoryClassifyAction = new MultiCategoryClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>() { multiCategoryClassifyAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

            await operation.WaitForCompletionAsync();
            #endregion Snippet:TextAnalyticsMultiCategoryClassifyAsync

            #region Snippet:TextAnalyticsMultiCategoryClassifyOperationStatus
            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();
            #endregion Snippet:TextAnalyticsMultiCategoryClassifyOperationStatus

            #region Snippet:TextAnalyticsMultiCategoryClassifyAsyncViewResults
            // View operation results.
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<MultiCategoryClassifyActionResult> classificationResultsCollection = documentsInPage.MultiCategoryClassifyResults;

                foreach (MultiCategoryClassifyActionResult classificationActionResults in classificationResultsCollection)
                {
                    if (classificationActionResults.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Action error code: {classificationActionResults.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {classificationActionResults.Error.Message}");
                        continue;
                    }

                    foreach (MultiCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                            Console.WriteLine($"  Message: {documentResults.Error.Message}");
                            continue;
                        }

                        if (documentResults.ClassificationCategories.Count > 0)
                        {
                            Console.WriteLine($"  The following classes were predicted for this document:");

                            foreach (ClassificationCategory classification in documentResults.ClassificationCategories)
                            {
                                Console.WriteLine($"  Class category \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
            #endregion Snippet:TextAnalyticsMultiCategoryClassifyAsyncViewResults
        }
    }
}
