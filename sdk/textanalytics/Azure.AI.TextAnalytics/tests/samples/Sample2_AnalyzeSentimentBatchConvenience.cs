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
        public void AnalyzeSentimentBatchConvenience()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
            string documentA = @"The food and service were unacceptable, but the concierge were nice.
                                After talking to them about the quality of the food and the process
                                to get room service they refunded the money we spent at the restaurant and
                                gave us a voucher for nearby restaurants.";

            string documentB = @"Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms
                                were old and the toilet was dirty when we arrived. It was close to bus stops and
                                groceries stores.
                                If you want to be close to campus I will recommend it, otherwise, might be
                                better to stay in a cleaner one";

            string documentC = @"The rooms were beautiful. The AC was good and quiet, which was key for us as outside
                                it was 100F and our baby was getting uncomfortable because of the heat. The breakfast
                                was good too with good options and good servicing times.
                                The thing we didn't like was that the toilet in our bathroom was smelly.
                                It could have been that the toilet was not cleaned before we arrived.";

            string documentD = string.Empty;

            var documents = new List<string>
            {
                documentA,
                documentB,
                documentC,
                documentD
            };

            Response<AnalyzeSentimentResultCollection> response = client.AnalyzeSentimentBatch(documents);
            AnalyzeSentimentResultCollection sentimentPerDocuments = response.Value;

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{sentimentPerDocuments.ModelVersion}\"");
            Console.WriteLine("");

            foreach (AnalyzeSentimentResult sentimentInDocument in sentimentPerDocuments)
            {
                Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
                Console.WriteLine("");

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
                }
                Console.WriteLine("");
            }
            #endregion
        }
    }
}
