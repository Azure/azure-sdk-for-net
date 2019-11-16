// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics;

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

            string input = "That was the best day of my life!";

            Debug.WriteLine($"Analyzing sentiment for input: \"{input}\"");
            var sentiment = client.AnalyzeSentiment(input).Value;

            Debug.WriteLine($"Sentiment was {sentiment.SentimentClass.ToString()}, with scores: ");
            Debug.WriteLine($"    Positive score: {sentiment.PositiveScore:0.00}.");
            Debug.WriteLine($"    Neutral score: {sentiment.NeutralScore:0.00}.");
            Debug.WriteLine($"    Negative score: {sentiment.NeutralScore:0.00}.");
        }
    }
}
