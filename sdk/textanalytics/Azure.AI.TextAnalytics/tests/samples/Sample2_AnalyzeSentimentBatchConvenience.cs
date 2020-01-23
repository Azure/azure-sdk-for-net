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
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

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
            AnalyzeSentimentResultCollection results = client.AnalyzeSentiment(inputs);
            #endregion

            Debug.WriteLine($"Predicted sentiments are:");
            foreach (AnalyzeSentimentResult result in results)
            {
                TextSentiment sentiment = result.DocumentSentiment;
                Debug.WriteLine($"Document sentiment is {sentiment.SentimentClass.ToString()}, with scores: ");
                Debug.WriteLine($"    Positive score: {sentiment.PositiveScore:0.00}.");
                Debug.WriteLine($"    Neutral score: {sentiment.NeutralScore:0.00}.");
                Debug.WriteLine($"    Negative score: {sentiment.NegativeScore:0.00}.");
            }
        }
    }
}
