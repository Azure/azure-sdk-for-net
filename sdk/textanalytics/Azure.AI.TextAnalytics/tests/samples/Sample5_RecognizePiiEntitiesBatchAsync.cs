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
        public async Task RecognizePiiEntitiesBatchAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string documentA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            string documentB =
                "Hoy recibí una llamada al medio día del usuario Juanito Perez, quien preguntaba cómo acceder a su"
                + " nuevo correo electrónico. Este trabaja en Microsoft y su correo es juanito.perez@contoso.com. El"
                + " usuario accedió a compartir su número para futuras comunicaciones. El número es 800-102-1101.";

            string documentC =
                "Yesterday, Dan Doe was asking where they could find the ABA number. I explained that it is the first"
                + " 9 digits in the lower left hand corner of their personal check. After looking at their account"
                + " they confirmed the number was 111000025.";

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
                     Language = "es",
                },
                new TextDocumentInput("3", documentC)
                {
                     Language = "en",
                }
            };

            RecognizePiiEntitiesOptions options = new() { IncludeStatistics = true };
            Response<RecognizePiiEntitiesResultCollection> response = await client.RecognizePiiEntitiesBatchAsync(batchedDocuments, options);
            RecognizePiiEntitiesResultCollection entititesPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Recognize PII Entities, model version: \"{entititesPerDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizePiiEntitiesResult documentResult in entititesPerDocuments)
            {
                TextDocumentInput document = batchedDocuments[i++];

                Console.WriteLine($"Result for document with Id = \"{document.Id}\" and Language = \"{document.Language}\":");

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

                Console.WriteLine($"  Document statistics:");
                Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
                Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                Console.WriteLine();
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {entititesPerDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {entititesPerDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {entititesPerDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {entititesPerDocuments.Statistics.TransactionCount}");
            Console.WriteLine();
        }
    }
}
