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

            var reviews = new List<string>
            {
                "The food and service were unacceptable, but the concierge were nice.",
                "The rooms were beautiful. The AC was good and quiet.",
                "The breakfast was good, but the toilet was smelly.",
                "Loved this hotel - good breakfast - nice shuttle service - clean rooms.",
                "I had a great unobstructed view of the Microsoft campus.",
                "Nice rooms but bathrooms were old and the toilet was dirty when we arrived.",
                "We changed rooms as the toilet smelled."
            };

            AnalyzeSentimentResultCollection analyzedReviews = await client.AnalyzeSentimentBatchAsync(reviews, options: new AnalyzeSentimentOptions() { MineOpinions = true });

            Dictionary<string, int> complaintTargets = GetNegativeOpinionTargets(analyzedReviews);

            var negativeOpinionTarget = complaintTargets.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
            Console.WriteLine($"Alert! major complaint target is *{negativeOpinionTarget}*");
            Console.WriteLine();
            Console.WriteLine("---All complaint targets:");
            foreach (KeyValuePair<string, int> complaintTarget in complaintTargets)
            {
                Console.WriteLine($"   OpinionTarget: {complaintTarget.Key}, Number of negative descriptions: {complaintTarget.Value}");
            }
        }

        private static Dictionary<string, int> GetNegativeOpinionTargets(AnalyzeSentimentResultCollection reviews)
        {
            var complaints = new Dictionary<string, int>();
            foreach (AnalyzeSentimentResult review in reviews)
            {
                foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
                {
                    foreach (MinedOpinion opinion in sentence.Opinions)
                    {
                        if (opinion.Target.Sentiment == TextSentiment.Negative)
                        {
                            complaints.TryGetValue(opinion.Target.Text, out var value);
                            complaints[opinion.Target.Text] = value + 1;
                        }
                    }
                }
            }
            return complaints;
        }
    }
}
