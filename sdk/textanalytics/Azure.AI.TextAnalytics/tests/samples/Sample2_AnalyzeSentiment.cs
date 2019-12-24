// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void AnalyzeSentiment()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);

            #region Snippet:AnalyzeSentiment
            string input = "That was the best day of my life!";

            // Analyze the sentiment of the input text.
            AnalyzeSentimentResult result = client.AnalyzeSentiment(input);
            TextSentiment sentiment = result.DocumentSentiment;

            Console.WriteLine($"Sentiment was {sentiment.SentimentClass.ToString()}, with scores: ");
            Console.WriteLine($"    Positive score: {sentiment.PositiveScore:0.00}.");
            Console.WriteLine($"    Neutral score: {sentiment.NeutralScore:0.00}.");
            Console.WriteLine($"    Negative score: {sentiment.NeutralScore:0.00}.");
            #endregion
        }
    }
}
