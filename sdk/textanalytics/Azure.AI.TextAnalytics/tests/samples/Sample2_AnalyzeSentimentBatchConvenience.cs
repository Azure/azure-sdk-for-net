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
        public void AnalyzeSentimentBatchConvenience()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));

            var inputs = new List<string>
            {
                "That was the best day of my life!",
                "This food is very bad.",
                "I'm not sure how I feel about this product.",
                "Pike place market is my favorite Seattle attraction.",
            };

            Debug.WriteLine($"Analyzing sentiment for inputs:");
            foreach (string input in inputs)
            {
                Debug.WriteLine($"    {input}");
            }

            #region Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
            AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(inputs);
            #endregion

            Debug.WriteLine($"Predicted sentiments are:");
            foreach (AnalyzeSentimentResult result in results)
            {
                DocumentSentiment docSentiment = result.DocumentSentiment;
                Debug.WriteLine($"Document sentiment is {docSentiment.Sentiment}, with confidence scores: ");
                Debug.WriteLine($"    Positive confidence score: {docSentiment.ConfidenceScores.Positive}.");
                Debug.WriteLine($"    Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}.");
                Debug.WriteLine($"    Negative confidence score: {docSentiment.ConfidenceScores.Negative}.");
            }
        }
    }
}
