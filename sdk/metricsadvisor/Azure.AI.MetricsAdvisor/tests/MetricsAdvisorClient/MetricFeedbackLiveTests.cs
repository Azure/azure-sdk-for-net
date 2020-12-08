// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricFeedbackLiveTests : MetricsAdvisorLiveTestBase
    {
        public MetricFeedbackLiveTests(bool isAsync) : base(isAsync)
        {
        }

        // The sampling time range for feedback differs from other tests so it doesn't interfere in anomaly
        // detection and other tests' results.

        private DateTimeOffset FeedbackSamplingStartTime => FeedbackSamplingEndTime.Subtract(TimeSpan.FromDays(3));

        private DateTimeOffset FeedbackSamplingEndTime => SamplingStartTime.Subtract(TimeSpan.FromDays(2));

        private DateTimeOffset FeedbackSamplingStartTimeReal => DateTimeOffset.Parse("2020-12-01T00:00:00Z");

        private DateTimeOffset FeedbackSamplingEndTimeReal => DateTimeOffset.Parse("2020-12-31T00:00:00Z");

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddAndGetAnomalyFeedback(bool populateOptionalMembers)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Delhi");

            var filter = new FeedbackDimensionFilter(groupKey);

            var feedbackToAdd = new MetricAnomalyFeedback(MetricId, filter, FeedbackSamplingStartTime, FeedbackSamplingEndTime, AnomalyValue.AutoDetect);

            if (populateOptionalMembers)
            {
                feedbackToAdd.AnomalyDetectionConfigurationId = DetectionConfigurationId;
            }

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Anomaly));

            var anomalyFeedback = addedFeedback as MetricAnomalyFeedback;

            Assert.That(anomalyFeedback, Is.Not.Null);
            Assert.That(anomalyFeedback.AnomalyValue, Is.EqualTo(AnomalyValue.AutoDetect));
            Assert.That(anomalyFeedback.StartTime, Is.EqualTo(FeedbackSamplingStartTime));
            Assert.That(anomalyFeedback.EndTime, Is.EqualTo(FeedbackSamplingEndTime));

            if (populateOptionalMembers)
            {
                Assert.That(anomalyFeedback.AnomalyDetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
                // TODO: Validate snapshot!
            }
            else
            {
                Assert.That(anomalyFeedback.AnomalyDetectionConfigurationId, Is.Null);
                Assert.That(anomalyFeedback.AnomalyDetectionConfigurationSnapshot, Is.Null);
            }
        }

        [Test]
        public async Task AddAndGetChangePointFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Delhi");

            var filter = new FeedbackDimensionFilter(groupKey);

            var feedbackToAdd = new MetricChangePointFeedback(MetricId, filter, FeedbackSamplingStartTime, FeedbackSamplingEndTime, ChangePointValue.AutoDetect);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.ChangePoint));

            var changePointFeedback = addedFeedback as MetricChangePointFeedback;

            Assert.That(changePointFeedback, Is.Not.Null);
            Assert.That(changePointFeedback.ChangePointValue, Is.EqualTo(ChangePointValue.AutoDetect));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddAndGetCommentFeedback(bool populateOptionalMembers)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Delhi");

            var filter = new FeedbackDimensionFilter(groupKey);
            var comment = "Feedback created in a .NET test.";

            var feedbackToAdd = new MetricCommentFeedback(MetricId, filter, comment);

            if (populateOptionalMembers)
            {
                feedbackToAdd.StartTime = FeedbackSamplingStartTime;
                feedbackToAdd.EndTime = FeedbackSamplingEndTime;
            }

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Comment));

            var commentFeedback = addedFeedback as MetricCommentFeedback;

            Assert.That(commentFeedback, Is.Not.Null);
            Assert.That(commentFeedback.Comment, Is.EqualTo(comment));

            if (populateOptionalMembers)
            {
                Assert.That(commentFeedback.StartTime, Is.EqualTo(FeedbackSamplingStartTime));
                Assert.That(commentFeedback.EndTime, Is.EqualTo(FeedbackSamplingEndTime));
            }
            else
            {
                Assert.That(commentFeedback.StartTime, Is.Null);
                Assert.That(commentFeedback.EndTime, Is.Null);
            }
        }

        [Test]
        public async Task AddAndGetPeriodFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Delhi");

            var filter = new FeedbackDimensionFilter(groupKey);
            var periodValue = 10;

            var feedbackToAdd = new MetricPeriodFeedback(MetricId, filter, PeriodType.AutoDetect, periodValue);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Period));

            var periodFeedback = addedFeedback as MetricPeriodFeedback;

            Assert.That(periodFeedback, Is.Not.Null);
            Assert.That(periodFeedback.PeriodType, Is.EqualTo(PeriodType.AutoDetect));
            Assert.That(periodFeedback.PeriodValue, Is.EqualTo(periodValue));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAllFeedback(bool populateOptionalMembers)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAllFeedbackOptions();

            if (populateOptionalMembers)
            {
                options.TimeMode = FeedbackQueryTimeMode.FeedbackCreatedTime;
                options.StartTime = FeedbackSamplingStartTimeReal;
                options.EndTime = FeedbackSamplingEndTimeReal;
                options.FeedbackType = FeedbackType.Comment;

                options.Filter.AddDimensionColumn("city", "Delhi");
            }

            var feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId, options))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.CreatedTime, Is.Not.Null);

                Assert.That(feedback.DimensionFilter, Is.Not.Null);
                Assert.That(feedback.DimensionFilter.DimensionFilter, Is.Not.Null);

                //ValidateDimensionKey(feedback.DimensionFilter.DimensionFilter);

                if (populateOptionalMembers)
                {
                    Assert.That(feedback.CreatedTime, Is.GreaterThanOrEqualTo(FeedbackSamplingStartTimeReal));
                    Assert.That(feedback.CreatedTime, Is.LessThanOrEqualTo(FeedbackSamplingEndTimeReal));
                    Assert.That(feedback.Type, Is.EqualTo(FeedbackType.Comment));

                    // TODO: make sure that dimension key is within specified filter.
                }

                // TODO: make possible type checks?

                if (++feedbackCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(feedbackCount, Is.GreaterThan(0));
        }

        private void ValidateMetricFeedback(MetricFeedback feedback, string expectedFeedbackId)
        {
            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.Id, Is.EqualTo(expectedFeedbackId));
            Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
            Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);

            DateTimeOffset justNow = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(feedback.CreatedTime, Is.GreaterThan(justNow));

            Assert.That(feedback.DimensionFilter, Is.Not.Null);
            Assert.That(feedback.DimensionFilter.DimensionFilter, Is.Not.Null);

            Dictionary<string, string> dimensionColumns = feedback.DimensionFilter.DimensionFilter.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns.ContainsKey("city"));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));
        }
    }
}
