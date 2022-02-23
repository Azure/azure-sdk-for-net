﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public async Task SingleCategoryClassifyAsync()
        {
            // Create a Text Analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

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
