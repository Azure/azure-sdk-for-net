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
        public void AnalyzeSentimentBatchConvenience()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            #region Snippet:Sample2_AnalyzeSentimentBatchConvenience
            string documentA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            string documentB =
                "Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms were old and the"
                + " toilet was dirty when we arrived. It was close to bus stops and groceries stores. If you want to"
                + " be close to campus I will recommend it, otherwise, might be better to stay in a cleaner one";

            string documentC =
                "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
                + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
                + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
                + " smelly. It could have been that the toilet was not cleaned before we arrived.";

            string documentD = string.Empty;

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(batchedDocuments);
            AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Analyze Sentiment, model version: \"{sentimentPerDocuments.ModelVersion}\"");
            Console.WriteLine();

            foreach (AnalyzeSentimentResult documentResult in sentimentPerDocuments)
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
            }
            #endregion
        }
    }
}
