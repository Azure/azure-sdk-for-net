// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "That was the best day of my life!")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "This food is very bad. Everyone who ate with us got sick.")
                {
                     Language = "en",
                },
                new TextDocumentInput("3", "I'm not sure how I feel about this product.")
                {
                     Language = "en",
                },
                new TextDocumentInput("4", "Pike Place Market is my favorite Seattle attraction.  We had so much fun there.")
                {
                     Language = "en",
                }
            };

            AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Console.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{results.ModelVersion}\"");
            Console.WriteLine("");

            foreach (AnalyzeSentimentResult result in results)
            {
                TextDocumentInput document = documents[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");

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

            Console.WriteLine($"Batch operation statistics:");
            Console.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Console.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Console.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Console.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Console.WriteLine("");
        }
    }
}
