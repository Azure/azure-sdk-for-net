// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public void RecognizeCustomEntities()
        {
            TestEnvironment.IgnoreIfNotPublicCloud();

            Uri endpoint = new(TestEnvironment.StaticEndpoint);
            AzureKeyCredential credential = new(TestEnvironment.StaticApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions(true));

            string documentA =
                "A recent report by the Government Accountability Office (GAO) found that the dramatic increase in oil"
                + " and natural gas development on federal lands over the past six years has stretched the staff of"
                + " the BLM to a point that it has been unable to meet its environmental protection responsibilities.";

            string documentB =
                "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC),"
                + " Washington, D.C., discussed the physical activity component.";

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
            string projectName = TestEnvironment.RecognizeCustomEntitiesProjectName;
            string deploymentName = TestEnvironment.RecognizeCustomEntitiesDeploymentName;

            // Perform the text analysis operation.
            RecognizeCustomEntitiesOperation operation = client.RecognizeCustomEntities(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);

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
            foreach (RecognizeCustomEntitiesResultCollection documentsInPage in operation.GetValues())
            {
                foreach (RecognizeEntitiesResult documentResult in documentsInPage)
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
    }
}
