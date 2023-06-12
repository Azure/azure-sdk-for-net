﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public void SingleLabelClassifyConvenience()
        {
            TestEnvironment.IgnoreIfNotPublicCloud();

            Uri endpoint = new(TestEnvironment.StaticEndpoint);
            AzureKeyCredential credential = new(TestEnvironment.StaticApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions(true));

            string document =
                "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
                + " add it to my playlist.";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                document
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities.
            string projectName = TestEnvironment.SingleClassificationProjectName;
            string deploymentName = TestEnvironment.SingleClassificationDeploymentName;
            SingleLabelClassifyAction singleLabelClassifyAction = new(projectName, deploymentName);

            TextAnalyticsActions actions = new()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>() { singleLabelClassifyAction }
            };

            //  Perform the text analysis operation.
            AnalyzeActionsOperation operation = client.StartAnalyzeActions(batchedDocuments, actions);
            operation.WaitForCompletion();

            // View the operation status.
            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            // View the operation results.
            foreach (AnalyzeActionsResult documentsInPage in operation.GetValues())
            {
                IReadOnlyCollection<SingleLabelClassifyActionResult> singleClassificationActionResults = documentsInPage.SingleLabelClassifyResults;

                foreach (SingleLabelClassifyActionResult classificationActionResults in singleClassificationActionResults)
                {
                    Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
                    foreach (ClassifyDocumentResult documentResult in classificationActionResults.DocumentsResults)
                    {
                        ClassificationCategory classification = documentResult.ClassificationCategories.First();

                        Console.WriteLine($"  Class label \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
