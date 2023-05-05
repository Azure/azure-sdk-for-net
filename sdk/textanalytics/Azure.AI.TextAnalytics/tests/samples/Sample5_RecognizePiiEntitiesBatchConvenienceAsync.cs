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
        public async Task RecognizePiiEntitiesBatchConvenienceAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string documentA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            string documentB =
                "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
                + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
                + " they confirmed the number was 111000025.";

            string documentC = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB,
                documentC
            };

            Response<RecognizePiiEntitiesResultCollection> response = await client.RecognizePiiEntitiesBatchAsync(batchedDocuments);
            RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Recognize PII Entities, model version: \"{entititesPerDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizePiiEntitiesResult documentResult in entititesPerDocuments)
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

                Console.WriteLine($"  Redacted Text: {documentResult.Entities.RedactedText}");
                Console.WriteLine();
                Console.WriteLine($"  Recognized {documentResult.Entities.Count} PII entities:");
                foreach (PiiEntity piiEntity in documentResult.Entities)
                {
                    Console.WriteLine($"    Text: {piiEntity.Text}");
                    Console.WriteLine($"    Category: {piiEntity.Category}");
                    if (!string.IsNullOrEmpty(piiEntity.SubCategory))
                        Console.WriteLine($"    SubCategory: {piiEntity.SubCategory}");
                    Console.WriteLine($"    Confidence score: {piiEntity.ConfidenceScore}");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
