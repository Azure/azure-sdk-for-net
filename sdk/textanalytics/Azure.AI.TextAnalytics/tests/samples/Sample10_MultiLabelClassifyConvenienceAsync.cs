// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public async Task MultiLabelClassifyConvenienceAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.StaticEndpoint;
            string apiKey = TestEnvironment.StaticApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey), CreateSampleOptions());

            #region Snippet:TextAnalyticsMultiLabelClassifyAsync
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
            string projectName = TestEnvironment.MultiClassificationProjectName;
            string deploymentName = TestEnvironment.MultiClassificationDeploymentName;
#endif

            var multiLabelClassifyAction = new MultiLabelClassifyAction(projectName, deploymentName);

            TextAnalyticsActions actions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>() { multiLabelClassifyAction }
            };

            // Start analysis process.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

            await operation.WaitForCompletionAsync();
            #endregion Snippet:TextAnalyticsMultiLabelClassifyAsync

            #region Snippet:TextAnalyticsMultiLabelClassifyOperationStatus
            // View operation status.
            Console.WriteLine($"AnalyzeActions operation has completed");
            Console.WriteLine();

            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();
            #endregion Snippet:TextAnalyticsMultiLabelClassifyOperationStatus

            #region Snippet:TextAnalyticsMultiLabelClassifyAsyncViewResults
            // View operation results.
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<MultiLabelClassifyActionResult> multiClassificationActionResults = documentsInPage.MultiLabelClassifyResults;

                foreach (MultiLabelClassifyActionResult classificationActionResults in multiClassificationActionResults)
                {
                    Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
                    foreach (ClassifyDocumentResult documentResults in classificationActionResults.DocumentsResults)
                    {
                        if (documentResults.ClassificationCategories.Count > 0)
                        {
                            Console.WriteLine($"  The following classes were predicted for this document:");

                            foreach (ClassificationCategory classification in documentResults.ClassificationCategories)
                            {
                                Console.WriteLine($"  Class label \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
            #endregion Snippet:TextAnalyticsMultiLabelClassifyAsyncViewResults
        }
    }
}
