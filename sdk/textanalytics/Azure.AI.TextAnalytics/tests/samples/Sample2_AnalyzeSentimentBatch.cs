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
        public void AnalyzeSentimentBatch()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample2_AnalyzeSentimentBatch
            string documentA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            string documentB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string documentC =
                "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
                + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
                + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
                + " smelly. It could have been that the toilet was not cleaned before we arrived. Either way it was"
                + " very uncomfortable. Once we notified the staff, they came and cleaned it and left candles.";

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

            AnalyzeSentimentOptions options = new() { IncludeStatistics = true };
            Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(batchedDocuments, options);
            AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Analyze Sentiment, model version: \"{sentimentPerDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (AnalyzeSentimentResult documentResult in sentimentPerDocuments)
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

                Console.WriteLine($"  Document sentiment is {documentResult.DocumentSentiment.Sentiment} with: ");
                Console.WriteLine($"    Positive confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Positive}");
                Console.WriteLine($"    Neutral confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Neutral}");
                Console.WriteLine($"    Negative confidence score: {documentResult.DocumentSentiment.ConfidenceScores.Negative}");
                Console.WriteLine();
                Console.WriteLine($"  Sentence sentiment results:");

                foreach (SentenceSentiment sentimentInSentence in documentResult.DocumentSentiment.Sentences)
                {
                    Console.WriteLine($"  * For sentence: \"{sentimentInSentence.Text}\"");
                    Console.WriteLine($"    Sentiment is {sentimentInSentence.Sentiment} with: ");
                    Console.WriteLine($"      Positive confidence score: {sentimentInSentence.ConfidenceScores.Positive}");
                    Console.WriteLine($"      Neutral confidence score: {sentimentInSentence.ConfidenceScores.Neutral}");
                    Console.WriteLine($"      Negative confidence score: {sentimentInSentence.ConfidenceScores.Negative}");
                    Console.WriteLine();
                }

                Console.WriteLine($"  Document statistics:");
                Console.WriteLine($"    Character count: {documentResult.Statistics.CharacterCount}");
                Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                Console.WriteLine();
            }

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"  Document count: {sentimentPerDocuments.Statistics.DocumentCount}");
            Console.WriteLine($"  Valid document count: {sentimentPerDocuments.Statistics.ValidDocumentCount}");
            Console.WriteLine($"  Invalid document count: {sentimentPerDocuments.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"  Transaction count: {sentimentPerDocuments.Statistics.TransactionCount}");
            #endregion
        }
    }
}
