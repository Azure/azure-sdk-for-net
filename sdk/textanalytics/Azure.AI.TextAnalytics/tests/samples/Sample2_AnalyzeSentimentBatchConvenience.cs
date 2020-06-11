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
        public void AnalyzeSentimentBatchConvenience()
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

            Debug.WriteLine($"Analyzing sentiment for documents:");
            foreach (string document in documents)
            {
                Debug.WriteLine($"    {document}");
            }

            #region Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
            AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(documents);
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
