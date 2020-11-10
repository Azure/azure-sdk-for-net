// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorClientLiveTests : MetricsAdvisorLiveTestBase
    {
        public MetricsAdvisorClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [RecordedTest]
        public async Task GetMetricFeedbacks()
        {
            var client = GetMetricsAdvisorClient();

            int pages = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId, new GetAllFeedbackOptions() { TopCount = 2 }))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                switch (feedback.Type.ToString())
                {
                    case "Anomaly":
                        Assert.That(feedback is MetricAnomalyFeedback);
                        break;
                    case "ChangePoint":
                        Assert.That(feedback is MetricChangePointFeedback);
                        break;
                    case "Period":
                        Assert.That(feedback is MetricPeriodFeedback);
                        break;
                    case "Comment":
                        Assert.That(feedback is MetricCommentFeedback);
                        break;
                    default:
                        Assert.Fail("Unexpected MetricFeedback type");
                        break;
                }

                // Just fetch 2 pages
                if (++pages > 2)
                {
                    break;
                }
            }

            Assert.That(pages, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task CreateMetricFeedback()
        {
            var client = GetMetricsAdvisorClient();
            FeedbackDimensionFilter dimensionFilter = new FeedbackDimensionFilter(
                new DimensionKey(
                    new Dictionary<string, string>
                    {
                        {"city", "Los Angeles"}
                    }));
            DateTimeOffset start = Recording.UtcNow.AddMonths(-4);
            DateTimeOffset end = Recording.UtcNow;

            MetricAnomalyFeedback anomalyFeedback = new MetricAnomalyFeedback(MetricId, dimensionFilter, start, end, AnomalyValue.NotAnomaly);
            MetricChangePointFeedback changePointFeedback = new MetricChangePointFeedback(MetricId, dimensionFilter, start, end, ChangePointValue.NotChangePoint);
            MetricPeriodFeedback periodFeedback = new MetricPeriodFeedback(MetricId, dimensionFilter, PeriodType.AssignValue, 5);
            MetricCommentFeedback commentFeedback = new MetricCommentFeedback(MetricId, dimensionFilter, "my comment");

            var feedbacks = new List<MetricFeedback>
            {
                anomalyFeedback,
                changePointFeedback,
                periodFeedback,
                commentFeedback
            };

            foreach (var feedback in feedbacks)
            {
                string createdFeedbackId = await client.AddFeedbackAsync(feedback).ConfigureAwait(false);

                Assert.That(createdFeedbackId, Is.Not.Null);

                MetricFeedback getFeedback = await client.GetFeedbackAsync(feedbackId: createdFeedbackId).ConfigureAwait(false);

                Assert.That(getFeedback.Id, Is.EqualTo(createdFeedbackId));
            }
        }
    }
}
