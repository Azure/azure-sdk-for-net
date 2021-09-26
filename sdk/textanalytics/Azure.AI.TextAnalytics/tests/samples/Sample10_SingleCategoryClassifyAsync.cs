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
        public async Task SingleCategoryClassifyAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string projectName = TestEnvironment.SingleClassificationProjectName;
            string deploymentName = TestEnvironment.SingleClassificationDeploymentName;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Get input document.
            string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", document)
                {
                     Language = "en",
                }
            };

            var singleCategoryClassifyAction = new SingleCategoryClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>() { singleCategoryClassifyAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, actions);

            await operation.WaitForCompletionAsync();

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
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<SingleCategoryClassifyActionResult> classificationResultsCollection = documentsInPage.SingleCategoryClassifyResults;

                foreach (SingleCategoryClassifyActionResult classificationActionResults in classificationResultsCollection)
                {
                    if (classificationActionResults.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Action error code: {classificationActionResults.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {classificationActionResults.Error.Message}");
                        continue;
                    }

                    foreach (SingleCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                            Console.WriteLine($"  Message: {documentResults.Error.Message}");
                            continue;
                        }

                        Console.WriteLine($"  Class category \"{documentResults.ClassificationCategory.Category}\" predicted with a confidence score of {documentResults.ClassificationCategory.ConfidenceScore}.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
