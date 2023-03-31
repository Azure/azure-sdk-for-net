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
        public async Task RecognizeCustomEntitiesAsync()
        {
            Uri endpoint = new(TestEnvironment.StaticEndpoint);
            AzureKeyCredential credential = new(TestEnvironment.StaticApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample8_RecognizeCustomEntitiesAsync
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us.";

            string documentB =
                "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
                + " so they helped me organize a little surprise for my partner. The room was clean and with the"
                + " decoration I requested. It was perfect!";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<TextDocumentInput> batchedDocuments = new()
            {
                new TextDocumentInput("1", documentA)
                {
                     Language = "en",
                },
                new TextDocumentInput("2", documentB)
                {
                     Language = "en",
                }
            };

            // Specify the project and deployment names of the desired custom model. To train your own custom model to
            // recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
#if SNIPPET
            string projectName = "<projectName>";
            string deploymentName = "<deploymentName>";
#else
            string projectName = TestEnvironment.RecognizeCustomEntitiesProjectName;
            string deploymentName = TestEnvironment.RecognizeCustomEntitiesDeploymentName;
#endif
            RecognizeCustomEntitiesAction recognizeCustomEntitiesAction = new(projectName, deploymentName);

            TextAnalyticsActions actions = new()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>() { recognizeCustomEntitiesAction }
            };

            // Perform the text analysis operation.
            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchedDocuments, actions);
            await operation.WaitForCompletionAsync();
            #endregion

            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            #region Snippet:Sample8_RecognizeCustomEntitiesAsync_ViewOperationStatus
            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();
            #endregion

            #region Snippet:Sample8_RecognizeCustomEntitiesAsync_ViewResults
            await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
            {
                IReadOnlyCollection<RecognizeCustomEntitiesActionResult> customEntitiesActionResults = documentsInPage.RecognizeCustomEntitiesResults;
                foreach (RecognizeCustomEntitiesActionResult customEntitiesActionResult in customEntitiesActionResults)
                {
                    Console.WriteLine($"Action name: {customEntitiesActionResult.ActionName}");

                    foreach (RecognizeEntitiesResult documentResult in customEntitiesActionResult.DocumentsResults)
                    {
                        Console.WriteLine($"Result for document with Id = \"{documentResult.Id}\":");

                        if (documentResult.HasError)
                        {
                            Console.WriteLine($"  Error!");
                            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                            Console.WriteLine($"  Message: {documentResult.Error.Message}");
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

                        foreach (CategorizedEntity entity in documentResult.Entities)
                        {
                            Console.WriteLine($"  Entity: {entity.Text}");
                            Console.WriteLine($"  Category: {entity.Category}");
                            Console.WriteLine($"  Offset: {entity.Offset}");
                            Console.WriteLine($"  Length: {entity.Length}");
                            Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
            }
            #endregion
        }
    }
}
