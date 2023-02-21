// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void DynamicClassifyBatchConvenience()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample11_DynamicClassifyBatchConvenience
            string documentA =
                "“The Microsoft Adaptive Accessories are intended to remove the barriers that traditional mice and"
                + " keyboards may present to people with limited mobility,” says Gabi Michel, director of Accessible"
                + " Accessories at Microsoft. “No two people are alike, and empowering people to configure their own"
                + " system that works for them was definitely the goal.”";

            string documentB =
                "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete"
                + " in the National Football League (NFL) as a member club of the league's National Football"
                + " Conference (NFC) West, which they rejoined in 2002 as part of conference realignment.";

            string documentC = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB,
                documentC
            };

            // Specify the categories that the documents can be classified with.
            List<string> categories = new()
            {
                "Health",
                "Politics",
                "Music",
                "Sports",
                "Technology"
            };

            Response<DynamicClassifyDocumentResultCollection> response = client.DynamicClassifyBatch(batchedDocuments, categories);
            DynamicClassifyDocumentResultCollection results = response.Value;

            int i = 0;
            Console.WriteLine($"Dynamic Classify, model version: \"{results.ModelVersion}\"");
            Console.WriteLine();

            foreach (ClassifyDocumentResult documentResult in results)
            {
                Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

                if (documentResult.HasError)
                {
                    Console.WriteLine($"  Error!");
                    Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                    Console.WriteLine($"  Message: {documentResult.Error.Message}");
                    Console.WriteLine();
                    continue;
                }

                foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
                {
                    Console.WriteLine($"  Category: {classification.Category}");
                    Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
                    Console.WriteLine();
                }
            }
            #endregion
        }
    }
}
