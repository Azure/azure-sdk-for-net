// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task ExtractKeyPhrasesBatchAsync()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            string documentB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string documentC =
                "That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo. They had"
                + " great amenities that included an indoor pool, a spa, and a bar. The spa offered couples massages"
                + " which were really good. The spa was clean and felt very peaceful. Overall the whole experience was"
                + " great. We will definitely come back.";

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
                },
                new TextDocumentInput("4", string.Empty)
            };

            TextAnalyticsRequestOptions options = new() { IncludeStatistics = true };
            Response<ExtractKeyPhrasesResultCollection> response = await client.ExtractKeyPhrasesBatchAsync(batchedDocuments, options);
            ExtractKeyPhrasesResultCollection keyPhrasesInDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Extract Key Phrases, model version: \"{keyPhrasesInDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (ExtractKeyPhrasesResult documentResult in keyPhrasesInDocuments)
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

                Console.WriteLine($"  Extracted {documentResult.KeyPhrases.Count()} key phrases:");

                foreach (string keyPhrase in documentResult.KeyPhrases)
                {
                    Console.WriteLine($"    {keyPhrase}");
                }

                Console.WriteLine();

                Console.WriteLine($"  Document statistics:");
                Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
                Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                Console.WriteLine();
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {keyPhrasesInDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {keyPhrasesInDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {keyPhrasesInDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {keyPhrasesInDocuments.Statistics.TransactionCount}");
            Console.WriteLine();
        }
    }
}
