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
            string apiKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_API_KEY");

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeSentiment
            string input = "That was the best day of my life!";

            DocumentSentiment docSentiment = client.AnalyzeSentiment(input);

            Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with scores: ");
            Console.WriteLine($"    Positive score: {docSentiment.SentimentScores.Positive:0.00}.");
            Console.WriteLine($"    Neutral score: {docSentiment.SentimentScores.Neutral:0.00}.");
            Console.WriteLine($"    Negative score: {docSentiment.SentimentScores.Negative:0.00}.");
            #endregion
        }
    }
}
