// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public void SingleLabelClassify()
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
            List<TextDocumentInput> batchedDocuments = new()
            {
                new TextDocumentInput("1", document)
                {
                     Language = "en",
                }
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities.
            string projectName = TestEnvironment.SingleClassificationProjectName;
            string deploymentName = TestEnvironment.SingleClassificationDeploymentName;

            // Perform the text analysis operation.
            ClassifyDocumentOperation operation = client.SingleLabelClassify(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);

            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            // View the operation results.
            foreach (ClassifyDocumentResultCollection documentsInPage in operation.GetValues())
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

                    Console.WriteLine($"  Predicted the following class:");
                    Console.WriteLine();

                    ClassificationCategory classification = documentResult.ClassificationCategories.First();

                    Console.WriteLine($"  Category: {classification.Category}");
                    Console.WriteLine($"  Confidence score: {classification.ConfidenceScore}");
                    Console.WriteLine();
                }
            }
        }
    }
}
