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
            TestEnvironment.IgnoreIfNotPublicCloud();

            Uri endpoint = new(TestEnvironment.StaticEndpoint);
            AzureKeyCredential credential = new(TestEnvironment.StaticApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions(true));

            #region Snippet:Sample10_MultiLabelClassifyConvenienceAsync
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
#if SNIPPET
            string projectName = "<projectName>";
            string deploymentName = "<deploymentName>";
#else
            string projectName = TestEnvironment.MultiClassificationProjectName;
            string deploymentName = TestEnvironment.MultiClassificationDeploymentName;
#endif

            // Perform the text analysis operation.
            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);
            #endregion

            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            #region Snippet:Sample10_MultiLabelClassifyConvenienceAsync_ViewResults
            // View the operation results.
            await foreach (ClassifyDocumentResultCollection documentsInPage in operation.Value)
            {
                foreach (ClassifyDocumentResult documentResult in documentsInPage)
                {
                    if (documentResult.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                        Console.WriteLine($"  Message: {documentResult.Error.Message}");
                        continue;
                    }

                    Console.WriteLine($"  Predicted the following classes:");
                    Console.WriteLine();

                    foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
                    {
                        Console.WriteLine($"  Category: {classification.Category}");
                        Console.WriteLine($"  Confidence score: {classification.ConfidenceScore}");
                        Console.WriteLine();
                    }
                }
            }
            #endregion
        }
    }
}
