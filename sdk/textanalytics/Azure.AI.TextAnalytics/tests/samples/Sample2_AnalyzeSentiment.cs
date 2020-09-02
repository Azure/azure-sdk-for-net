// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
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
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:TextAnalyticsSample2CreateClient
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            #endregion

            #region Snippet:AnalyzeSentiment
            string document = "That was the best day of my life!";

            DocumentSentiment docSentiment = client.AnalyzeSentiment(document);

            Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with confidence scores: ");
            Console.WriteLine($"    Positive confidence score: {docSentiment.ConfidenceScores.Positive}.");
            Console.WriteLine($"    Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}.");
            Console.WriteLine($"    Negative confidence score: {docSentiment.ConfidenceScores.Negative}.");
            #endregion
        }
    }
}
