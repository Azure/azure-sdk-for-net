// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task AnalyzeSentimentWithOpinionMiningAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var documents = new List<string>
            {
                "The food and service were unacceptable, but the concierge were nice.",
                "The rooms were beautiful. The AC was good and quiet.",
                "The breakfast was good, but the toilet was smelly.",
                "Loved this hotel - good breakfast - nice shuttle service - clean rooms.",
                "I had a great unobstructed view of the Microsoft campus.",
                "Nice rooms but bathrooms were old and the toilet was dirty when we arrived.",
                "We changed rooms as the toilet smelled."
            };

            AnalyzeSentimentResultCollection reviews = await client.AnalyzeSentimentBatchAsync(documents, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            Dictionary<string, int> complaints = GetComplaint(reviews);

            var negativeAspect = complaints.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine($"Alert! major complaint is *{negativeAspect}*");
            Console.WriteLine();
            Console.WriteLine("---All complaints:");
            foreach (KeyValuePair<string, int> complaint in complaints)
            {
                Console.WriteLine($"   {complaint.Key}, {complaint.Value}");
            }
        }

        private Dictionary<string, int> GetComplaint(AnalyzeSentimentResultCollection reviews)
        {
            var complaints = new Dictionary<string, int>();
            foreach (AnalyzeSentimentResult review in reviews)
            {
                foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
                {
                    foreach (MinedOpinion minedOpinion in sentence.MinedOpinions)
                    {
                        if (minedOpinion.Aspect.Sentiment == TextSentiment.Negative)
                        {
                            complaints.TryGetValue(minedOpinion.Aspect.Text, out var value);
                            complaints[minedOpinion.Aspect.Text] = value + 1;
                        }
                    }
                }
            }
            return complaints;
        }
    }
}
