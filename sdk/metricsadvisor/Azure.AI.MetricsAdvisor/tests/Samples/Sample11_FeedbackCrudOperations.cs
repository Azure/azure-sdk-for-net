// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task AddFeedbackAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var dimensions = new Dictionary<string, string>()
            {
                { "Dim1", "USD" }
            };
            var dimensionKey = new DimensionKey(dimensions);

            var startsOn = DateTimeOffset.Parse("2020-02-01T00:00:00Z");
            var endsOn = DateTimeOffset.Parse("2020-02-03T00:00:00Z");

            // Other types of feedback, such as MetricCommentFeedback, MetricChangePointFeedback,
            // and MetricPeriodFeedback are supported as well.

            var anomalyFeedback = new MetricAnomalyFeedback(metricId, dimensionKey, startsOn, endsOn, AnomalyValue.NotAnomaly);

            Response<MetricFeedback> response = await client.AddFeedbackAsync(anomalyFeedback);

            MetricFeedback addedFeedback = response.Value;

            Console.WriteLine($"Feedback ID: {addedFeedback.Id}");
        }

        [Test]
        public async Task GetFeedbackAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string feedbackId = FeedbackId;

            Response<MetricFeedback> response = await client.GetFeedbackAsync(feedbackId);

            MetricFeedback feedback = response.Value;

            Console.WriteLine($"Feedback ID: {feedback.Id}");
            Console.WriteLine($"Metric ID: {feedback.MetricId}");
            Console.WriteLine($"Feedback type: {feedback.FeedbackKind}");
            Console.WriteLine();

            if (feedback.FeedbackKind == MetricFeedbackKind.Anomaly)
            {
                MetricAnomalyFeedback anomalyFeedback = feedback as MetricAnomalyFeedback;

                Console.WriteLine($"Detection configuration ID: {anomalyFeedback.DetectionConfigurationId}");
                Console.WriteLine($"Anomaly value: {anomalyFeedback.AnomalyValue}");
            }
            else if (feedback.FeedbackKind == MetricFeedbackKind.Comment)
            {
                MetricCommentFeedback commentFeedback = feedback as MetricCommentFeedback;

                Console.WriteLine($"Comment: {commentFeedback.Comment}");
            }
            else if (feedback.FeedbackKind == MetricFeedbackKind.ChangePoint)
            {
                MetricChangePointFeedback changePointFeedback = feedback as MetricChangePointFeedback;

                Console.WriteLine($"Change point value: {changePointFeedback.ChangePointValue}");
            }
            else if (feedback.FeedbackKind == MetricFeedbackKind.Period)
            {
                MetricPeriodFeedback periodFeedback = feedback as MetricPeriodFeedback;

                Console.WriteLine($"Period type: {periodFeedback.PeriodType}");
                Console.WriteLine($"Period value: {periodFeedback.PeriodValue}");
            }
        }

        [Test]
        public async Task GetAllFeedbackAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var options = new GetAllFeedbackOptions()
            {
                Filter = new FeedbackFilter()
                {
                    StartsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z"),
                    EndsOn = DateTimeOffset.Parse("2020-09-09T00:00:00Z"),
                    TimeMode = FeedbackQueryTimeMode.MetricTimestamp
                },
                MaxPageSize = 5
            };

            int feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(metricId, options))
            {
                Console.WriteLine($"Feedback ID: {feedback.Id}");
                Console.WriteLine($"Metric ID: {feedback.MetricId}");
                Console.WriteLine($"Feedback type: {feedback.FeedbackKind}");
                Console.WriteLine();

                // Print at most 5 feedback entries.
                if (++feedbackCount >= 5)
                {
                    break;
                }
            }
        }
    }
}
