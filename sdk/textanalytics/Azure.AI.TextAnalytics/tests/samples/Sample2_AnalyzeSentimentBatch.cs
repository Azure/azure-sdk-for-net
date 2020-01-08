// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
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
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            #region Snippet:TextAnalyticsSample2AnalyzeSentimentBatch
            var inputs = new List<TextDocumentInput>
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

            AnalyzeSentimentResultCollection results = client.AnalyzeSentiment(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
            #endregion

            int i = 0;
            Debug.WriteLine($"Results of Azure Text Analytics \"Sentiment Analysis\" Model, version: \"{results.ModelVersion}\"");
            Debug.WriteLine("");

            foreach (AnalyzeSentimentResult result in results)
            {
                TextDocumentInput document = inputs[i++];

                if (result.ErrorMessage != default)
                {
                    Debug.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\", Text=\"{document.Text}\"):");
                }
                else
                {
                    Debug.WriteLine($"Document sentiment is {result.DocumentSentiment.SentimentClass.ToString()}, with scores: ");
                    Debug.WriteLine($"    Positive score: {result.DocumentSentiment.PositiveScore:0.00}.");
                    Debug.WriteLine($"    Neutral score: {result.DocumentSentiment.NeutralScore:0.00}.");
                    Debug.WriteLine($"    Negative score: {result.DocumentSentiment.NegativeScore:0.00}.");

                    Debug.WriteLine($"    Sentence sentiment results:");

                    foreach (TextSentiment sentenceSentiment in result.SentenceSentiments)
                    {
                        Debug.WriteLine($"    On sentence \"{document.Text.Substring(sentenceSentiment.Offset, sentenceSentiment.Length)}\"");

                        Debug.WriteLine($"    Sentiment is {sentenceSentiment.SentimentClass.ToString()}, with scores: ");
                        Debug.WriteLine($"        Positive score: {sentenceSentiment.PositiveScore:0.00}.");
                        Debug.WriteLine($"        Neutral score: {sentenceSentiment.NeutralScore:0.00}.");
                        Debug.WriteLine($"        Negative score: {sentenceSentiment.NegativeScore:0.00}.");
                    }

                    Debug.WriteLine($"    Document statistics:");
                    Debug.WriteLine($"        Character count: {result.Statistics.CharacterCount}");
                    Debug.WriteLine($"        Transaction count: {result.Statistics.TransactionCount}");
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine($"Batch operation statistics:");
            Debug.WriteLine($"    Document count: {results.Statistics.DocumentCount}");
            Debug.WriteLine($"    Valid document count: {results.Statistics.ValidDocumentCount}");
            Debug.WriteLine($"    Invalid document count: {results.Statistics.InvalidDocumentCount}");
            Debug.WriteLine($"    Transaction count: {results.Statistics.TransactionCount}");
            Debug.WriteLine("");
        }
    }
}
