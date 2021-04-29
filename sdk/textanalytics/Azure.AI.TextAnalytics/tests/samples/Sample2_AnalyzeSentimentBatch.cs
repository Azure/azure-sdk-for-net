// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void AnalyzeSentimentBatch()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample2AnalyzeSentimentBatch
            string documentA = @"The food and service were unacceptable, but the concierge were nice.
                                After talking to them about the quality of the food and the process
                                to get room service they refunded the money we spent at the restaurant and
                                gave us a voucher for nearby restaurants.";

            string documentB = @"Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia
                                sabía de nuestra celebración y me ayudaron a tenerle una sorpresa a mi pareja.
                                La habitación estaba limpia y decorada como yo había pedido. Una gran experiencia.
                                El próximo año volveremos.";

            string documentC = @"The rooms were beautiful. The AC was good and quiet, which was key for us as outside
                                it was 100F and our baby was getting uncomfortable because of the heat. The breakfast
                                was good too with good options and good servicing times.
                                The thing we didn't like was that the toilet in our bathroom was smelly.
                                It could have been that the toilet was not cleaned before we arrived.
                                Either way it was very uncomfortable. Once we notified the staff, they came and cleaned
                                it and left candles.";

            var documents = new List<TextDocumentInput>
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

            var options = new AnalyzeSentimentOptions { IncludeStatistics = true };

            Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(documents, options);
            AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{sentimentPerDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (AnalyzeSentimentResult sentimentInDocument in sentimentPerDocuments)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

                if (sentimentInDocument.HasError)
                {
                    Console.WriteLine("  Error!");
                    Console.WriteLine($"  Document error: {sentimentInDocument.Error.ErrorCode}.");
                    Console.WriteLine($"  Message: {sentimentInDocument.Error.Message}");
                }
                else
                {
                    Console.WriteLine($"Document sentiment is {sentimentInDocument.DocumentSentiment.Sentiment}, with confidence scores: ");
                    Console.WriteLine($"  Positive confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Positive}.");
                    Console.WriteLine($"  Neutral confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Neutral}.");
                    Console.WriteLine($"  Negative confidence score: {sentimentInDocument.DocumentSentiment.ConfidenceScores.Negative}.");
                    Console.WriteLine("");
                    Console.WriteLine($"  Sentence sentiment results:");

                    foreach (SentenceSentiment sentimentInSentence in sentimentInDocument.DocumentSentiment.Sentences)
                    {
                        Console.WriteLine($"  For sentence: \"{sentimentInSentence.Text}\"");
                        Console.WriteLine($"  Sentiment is {sentimentInSentence.Sentiment}, with confidence scores: ");
                        Console.WriteLine($"    Positive confidence score: {sentimentInSentence.ConfidenceScores.Positive}.");
                        Console.WriteLine($"    Neutral confidence score: {sentimentInSentence.ConfidenceScores.Neutral}.");
                        Console.WriteLine($"    Negative confidence score: {sentimentInSentence.ConfidenceScores.Negative}.");
                        Console.WriteLine("");
                    }

                    Console.WriteLine($"  Document statistics:");
                    Console.WriteLine($"    Character count: {sentimentInDocument.Statistics.CharacterCount}");
                    Console.WriteLine($"    Transaction count: {sentimentInDocument.Statistics.TransactionCount}");
                }
                Console.WriteLine("");
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
