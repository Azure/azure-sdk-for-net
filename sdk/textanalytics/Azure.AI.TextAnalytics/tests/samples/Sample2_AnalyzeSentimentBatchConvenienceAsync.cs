// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task AnalyzeSentimentBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "That was the best day of my life!",
                "This food is very bad.",
                "I'm not sure how I feel about this product.",
                "Pike place market is my favorite Seattle attraction.",
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (AnalyzeSentimentResult result in results)
            {
                Console.WriteLine($"On document {documents[i++]}");

                if (result.HasError)
                {
                    Console.WriteLine($"    Document error: {result.Error.ErrorCode}.");
                    Console.WriteLine($"    Message: {result.Error.Message}.");
                }
                else
                {
                    Console.WriteLine($"Document sentiment is {result.DocumentSentiment.Sentiment}, with confidence scores: ");
                    Console.WriteLine($"    Positive confidence score: {result.DocumentSentiment.ConfidenceScores.Positive}.");
                    Console.WriteLine($"    Neutral confidence score: {result.DocumentSentiment.ConfidenceScores.Neutral}.");
                    Console.WriteLine($"    Negative confidence score: {result.DocumentSentiment.ConfidenceScores.Negative}.");

                    Console.WriteLine($"    Sentence sentiment results:");

                    foreach (SentenceSentiment sentenceSentiment in result.DocumentSentiment.Sentences)
                    {
                        Console.WriteLine($"    For sentence: \"{sentenceSentiment.Text}\"");
                        Console.WriteLine($"    Sentiment is {sentenceSentiment.Sentiment}, with confidence scores: ");
                        Console.WriteLine($"        Positive confidence score: {sentenceSentiment.ConfidenceScores.Positive}.");
                        Console.WriteLine($"        Neutral confidence score: {sentenceSentiment.ConfidenceScores.Neutral}.");
                        Console.WriteLine($"        Negative confidence score: {sentenceSentiment.ConfidenceScores.Negative}.");
                    }

                    Console.WriteLine($"    Document statistics:");
                    Console.WriteLine($"        Character count (in Unicode graphemes): {result.Statistics.CharacterCount}");
                    Console.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Console.WriteLine("");
                }
            }
        }
    }
}
