// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task CreateMetricFeedbackAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            DimensionKey groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Belo Horizonte");

            FeedbackDimensionFilter filter = new FeedbackDimensionFilter(groupKey);
            var startTime = DateTimeOffset.Parse("2020-02-01T00:00:00Z");
            var endTime = DateTimeOffset.Parse("2020-02-03T00:00:00Z");

            // Other types of feedback, such as MetricCommentFeedback, MetricChangePointFeedback,
            // and MetricPeriodFeedback are supported as well.

            var anomalyFeedback = new MetricAnomalyFeedback(metricId, filter, startTime, endTime, AnomalyValue.NotAnomaly);

            Response<MetricFeedback> response = await client.CreateMetricFeedbackAsync(anomalyFeedback);

            MetricFeedback feedback = response.Value;

            Console.WriteLine($"Feedback ID: {feedback.Id}");
        }

        [Test]
        public async Task GetMetricFeedbackAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string feedbackId = FeedbackId;

            Response<MetricFeedback> response = await client.GetMetricFeedbackAsync(feedbackId);

            MetricFeedback feedback = response.Value;

            Console.WriteLine($"Feedback ID: {feedback.Id}");
            Console.WriteLine($"Metric ID: {feedback.MetricId}");
            Console.WriteLine($"Feedback type: {feedback.Type}");
            Console.WriteLine();

            if (feedback.Type == FeedbackType.Anomaly)
            {
                MetricAnomalyFeedback anomalyFeedback = feedback as MetricAnomalyFeedback;

                Console.WriteLine($"Detection configuration ID: {anomalyFeedback.AnomalyDetectionConfigurationId}");
                Console.WriteLine($"Anomaly value: {anomalyFeedback.AnomalyValue}");
            }
            else if (feedback.Type == FeedbackType.Comment)
            {
                MetricCommentFeedback commentFeedback = feedback as MetricCommentFeedback;

                Console.WriteLine($"Comment: {commentFeedback.Comment}");
            }
            else if (feedback.Type == FeedbackType.ChangePoint)
            {
                MetricChangePointFeedback changePointFeedback = feedback as MetricChangePointFeedback;

                Console.WriteLine($"Change point value: {changePointFeedback.ChangePointValue}");
            }
            else if (feedback.Type == FeedbackType.Period)
            {
                MetricPeriodFeedback periodFeedback = feedback as MetricPeriodFeedback;

                Console.WriteLine($"Period type: {periodFeedback.PeriodType}");
                Console.WriteLine($"Period value: {periodFeedback.PeriodValue}");
            }
        }

        [Test]
        public async Task GetMetricFeedbacksAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var options = new GetMetricFeedbacksOptions()
            {
                StartTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z"),
                EndTime = DateTimeOffset.Parse("2020-09-09T00:00:00Z"),
                TimeMode = FeedbackQueryTimeMode.MetricTimestamp,
                TopCount = 5
            };

            int feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetMetricFeedbacksAsync(metricId, options))
            {
                Console.WriteLine($"Feedback ID: {feedback.Id}");
                Console.WriteLine($"Metric ID: {feedback.MetricId}");
                Console.WriteLine($"Feedback type: {feedback.Type}");
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
