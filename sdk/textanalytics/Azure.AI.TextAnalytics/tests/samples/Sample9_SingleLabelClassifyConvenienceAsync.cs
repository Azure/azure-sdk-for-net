// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public async Task SingleLabelClassifyConvenienceAsync()
        {
            // Create a Text Analytics client.
            string endpoint = TestEnvironment.StaticEndpoint;
            string apiKey = TestEnvironment.StaticApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            #region Snippet:TextAnalyticsSingleLabelClassifyAsync
            // Get input document.
            string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

            // Prepare analyze operation input. You can add multiple documents to this list and perform the same
            // operation to all of them.
            var batchInput = new List<string>
            {
                document
            };

            // Set project and deployment names of the target model
#if SNIPPET
            // To train a model to classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities
            string projectName = "<projectName>";
            string deploymentName = "<deploymentName>";
#else
            string projectName = TestEnvironment.SingleClassificationProjectName;
            string deploymentName = TestEnvironment.SingleClassificationDeploymentName;
#endif

            var singleLabelClassifyAction = new SingleLabelClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>() { singleLabelClassifyAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

            await operation.WaitForCompletionAsync();
            #endregion Snippet:TextAnalyticsSingleLabelClassifyAsync

            #region Snippet:TextAnalyticsSingleLabelClassifyOperationStatus
            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();
            #endregion Snippet:TextAnalyticsSingleLabelClassifyOperationStatus

            #region Snippet:TextAnalyticsSingleLabelClassifyAsyncViewResults
            // View operation results.
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<SingleLabelClassifyActionResult> singleClassificationActionResults = documentsInPage.SingleLabelClassifyResults;

                foreach (SingleLabelClassifyActionResult classificationActionResults in singleClassificationActionResults)
                {
                    Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
                    foreach (ClassifyDocumentResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        ClassificationCategory classification = documentResults.ClassificationCategories.First();

                        Console.WriteLine($"  Class label \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                        Console.WriteLine();
                    }
                }
            }
            #endregion Snippet:TextAnalyticsSingleLabelClassifyAsyncViewResults
        }
    }
}
