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
    public class MetricFeedbackLiveTests : MetricsAdvisorLiveTestBase
    {
        public MetricFeedbackLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private DateTimeOffset CreatedFeedbackStartTime => DateTimeOffset.Parse("2020-09-26T00:00:00Z");

        private DateTimeOffset CreatedFeedbackEndTime => DateTimeOffset.Parse("2020-09-29T00:00:00Z");

        [RecordedTest]
        public async Task AddAndGetAnomalyFeedbackWithMinimumSetup()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);

            var feedbackToAdd = new MetricAnomalyFeedback(MetricId, filter, CreatedFeedbackStartTime, CreatedFeedbackEndTime, AnomalyValue.AutoDetect);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Anomaly));

            var anomalyFeedback = addedFeedback as MetricAnomalyFeedback;

            Assert.That(anomalyFeedback, Is.Not.Null);
            Assert.That(anomalyFeedback.AnomalyValue, Is.EqualTo(AnomalyValue.AutoDetect));
            Assert.That(anomalyFeedback.StartTime, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(anomalyFeedback.EndTime, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(anomalyFeedback.AnomalyDetectionConfigurationId, Is.Null);
            Assert.That(anomalyFeedback.AnomalyDetectionConfigurationSnapshot, Is.Null);
        }

        [RecordedTest]
        public async Task AddAndGetAnomalyFeedbackWithOptionalDetectionConfigurationFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);

            var feedbackToAdd = new MetricAnomalyFeedback(MetricId, filter, CreatedFeedbackStartTime, CreatedFeedbackEndTime, AnomalyValue.AutoDetect)
            {
                AnomalyDetectionConfigurationId = DetectionConfigurationId
            };

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Anomaly));

            var anomalyFeedback = addedFeedback as MetricAnomalyFeedback;

            Assert.That(anomalyFeedback, Is.Not.Null);
            Assert.That(anomalyFeedback.AnomalyValue, Is.EqualTo(AnomalyValue.AutoDetect));
            Assert.That(anomalyFeedback.StartTime, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(anomalyFeedback.EndTime, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(anomalyFeedback.AnomalyDetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
            // TODO: Add snapshot validation (https://github.com/azure/azure-sdk-for-net/issues/15915)
        }

        [RecordedTest]
        public async Task AddAndGetChangePointFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);

            var feedbackToAdd = new MetricChangePointFeedback(MetricId, filter, CreatedFeedbackStartTime, CreatedFeedbackEndTime, ChangePointValue.AutoDetect);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.ChangePoint));

            var changePointFeedback = addedFeedback as MetricChangePointFeedback;

            Assert.That(changePointFeedback, Is.Not.Null);
            Assert.That(changePointFeedback.ChangePointValue, Is.EqualTo(ChangePointValue.AutoDetect));
            Assert.That(changePointFeedback.StartTime, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(changePointFeedback.EndTime, Is.EqualTo(CreatedFeedbackEndTime));
        }

        /// <param name="populateOptionalMembers">
        /// When <c>true</c>, all optional properties are populated to make sure values are being passed and returned
        /// correctly. When <c>false</c>, the test makes sure it's still possible to make a request with the minimum
        /// configuration and that the responses with <c>null</c> and <c>default</c> values can be parsed by the client.
        /// </param>
        [RecordedTest]
        public async Task AddAndGetCommentFeedbackWithMinimumSetup()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);
            var comment = "Feedback created in a .NET test.";

            var feedbackToAdd = new MetricCommentFeedback(MetricId, filter, comment);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Comment));

            var commentFeedback = addedFeedback as MetricCommentFeedback;

            Assert.That(commentFeedback, Is.Not.Null);
            Assert.That(commentFeedback.Comment, Is.EqualTo(comment));
            Assert.That(commentFeedback.StartTime, Is.Null);
            Assert.That(commentFeedback.EndTime, Is.Null);
        }

        [RecordedTest]
        public async Task AddAndGetCommentFeedbackWithOptionalTimeFilters()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);
            var comment = "Feedback created in a .NET test.";

            var feedbackToAdd = new MetricCommentFeedback(MetricId, filter, comment)
            {
                StartTime = CreatedFeedbackStartTime,
                EndTime = CreatedFeedbackEndTime
            };

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Comment));

            var commentFeedback = addedFeedback as MetricCommentFeedback;

            Assert.That(commentFeedback, Is.Not.Null);
            Assert.That(commentFeedback.Comment, Is.EqualTo(comment));
            Assert.That(commentFeedback.StartTime, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(commentFeedback.EndTime, Is.EqualTo(CreatedFeedbackEndTime));
        }

        [RecordedTest]
        public async Task AddAndGetPeriodFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensionKey = new DimensionKey();
            dimensionKey.AddDimensionColumn("city", "Delhi");
            dimensionKey.AddDimensionColumn("category", "Handmade");

            var filter = new FeedbackDimensionFilter(dimensionKey);
            var periodValue = 10;

            var feedbackToAdd = new MetricPeriodFeedback(MetricId, filter, PeriodType.AutoDetect, periodValue);

            string feedbackId = await client.AddFeedbackAsync(feedbackToAdd);

            Assert.That(feedbackId, Is.Not.Null);

            MetricFeedback addedFeedback = await client.GetFeedbackAsync(feedbackId);

            ValidateMetricFeedback(addedFeedback, feedbackId, dimensionKey);

            Assert.That(addedFeedback.Type, Is.EqualTo(FeedbackType.Period));

            var periodFeedback = addedFeedback as MetricPeriodFeedback;

            Assert.That(periodFeedback, Is.Not.Null);
            Assert.That(periodFeedback.PeriodType, Is.EqualTo(PeriodType.AutoDetect));
            Assert.That(periodFeedback.PeriodValue, Is.EqualTo(periodValue));
        }

        [RecordedTest]
        public async Task GetAllFeedbackWithMinimumSetup()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.CreatedTime, Is.Not.Null);

                Assert.That(feedback.DimensionFilter, Is.Not.Null);
                Assert.That(feedback.DimensionFilter.DimensionFilter, Is.Not.Null);

                ValidateGroupKey(feedback.DimensionFilter.DimensionFilter);

                if (feedback.Type == FeedbackType.Anomaly)
                {
                    var anomalyFeedback = feedback as MetricAnomalyFeedback;

                    Assert.That(anomalyFeedback, Is.Not.Null);
                    Assert.That(anomalyFeedback.AnomalyValue, Is.Not.EqualTo(default(AnomalyFeedbackValue)));

                    if (anomalyFeedback.AnomalyDetectionConfigurationId != null)
                    {
                        // TODO: Add snapshot validation (https://github.com/azure/azure-sdk-for-net/issues/15915).
                    }
                }
                else if (feedback.Type == FeedbackType.ChangePoint)
                {
                    var changePointFeedback = feedback as MetricChangePointFeedback;

                    Assert.That(changePointFeedback, Is.Not.Null);
                    Assert.That(changePointFeedback.ChangePointValue, Is.Not.EqualTo(default(ChangePointValue)));
                }
                else if (feedback.Type == FeedbackType.Comment)
                {
                    var commentFeedback = feedback as MetricCommentFeedback;

                    Assert.That(commentFeedback, Is.Not.Null);
                    Assert.That(commentFeedback.Comment, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(feedback.Type, Is.EqualTo(FeedbackType.Period));

                    var periodFeedback = feedback as MetricPeriodFeedback;

                    Assert.That(periodFeedback, Is.Not.Null);
                    Assert.That(periodFeedback.PeriodType, Is.Not.EqualTo(default(PeriodType)));
                }

                if (++feedbackCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(feedbackCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetAllFeedbackWithOptionalFeedbackFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            // The sampling time range was chosen in a way to make sure there'll be feedback returned by the
            // service call. Changing these values can make this test fail.

            DateTimeOffset feedbackSamplingStartTime = DateTimeOffset.Parse("2020-12-01T00:00:00Z");
            DateTimeOffset feedbackSamplingEndTime = DateTimeOffset.Parse("2020-12-31T00:00:00Z");

            var options = new GetAllFeedbackOptions()
            {
                TimeMode = FeedbackQueryTimeMode.FeedbackCreatedTime,
                StartTime = feedbackSamplingStartTime,
                EndTime = feedbackSamplingEndTime,
                FeedbackType = FeedbackType.Comment,
            };

            options.Filter.AddDimensionColumn("city", "Delhi");

            var feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId, options))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.CreatedTime, Is.Not.Null);
                Assert.That(feedback.CreatedTime, Is.GreaterThanOrEqualTo(feedbackSamplingStartTime));
                Assert.That(feedback.CreatedTime, Is.LessThanOrEqualTo(feedbackSamplingEndTime));

                Assert.That(feedback.DimensionFilter, Is.Not.Null);
                Assert.That(feedback.DimensionFilter.DimensionFilter, Is.Not.Null);

                ValidateGroupKey(feedback.DimensionFilter.DimensionFilter);

                Dictionary<string, string> dimensionColumns = feedback.DimensionFilter.DimensionFilter.AsDictionary();

                Assert.That(dimensionColumns.ContainsKey("city"));
                Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));

                Assert.That(feedback.Type, Is.EqualTo(FeedbackType.Comment));

                var commentFeedback = feedback as MetricCommentFeedback;

                Assert.That(commentFeedback, Is.Not.Null);
                Assert.That(commentFeedback.Comment, Is.Not.Null.And.Not.Empty);

                if (++feedbackCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(feedbackCount, Is.GreaterThan(0));
        }

        private void ValidateMetricFeedback(MetricFeedback feedback, string expectedFeedbackId, DimensionKey expectedDimensionKey)
        {
            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.Id, Is.EqualTo(expectedFeedbackId));
            Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
            Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(feedback.CreatedTime, Is.GreaterThan(justNow));

            Assert.That(feedback.DimensionFilter, Is.Not.Null);
            Assert.That(feedback.DimensionFilter.DimensionFilter, Is.EqualTo(expectedDimensionKey));
        }
    }
}
