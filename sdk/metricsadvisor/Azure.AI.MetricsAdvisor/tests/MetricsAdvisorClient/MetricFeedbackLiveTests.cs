﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const string ExpectedCity = "Delhi";

        private const string ExpectedCategory = "Handmade";

        public MetricFeedbackLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private DateTimeOffset CreatedFeedbackStartTime => DateTimeOffset.Parse("2020-09-26T00:00:00Z");

        private DateTimeOffset CreatedFeedbackEndTime => DateTimeOffset.Parse("2020-09-29T00:00:00Z");

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddAndGetAnomalyFeedbackWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var feedbackToAdd = new MetricAnomalyFeedback(MetricId, dimensionKey, CreatedFeedbackStartTime, CreatedFeedbackEndTime, AnomalyValue.AutoDetect);

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Anomaly));

            var anomalyFeedback = addedFeedback as MetricAnomalyFeedback;

            Assert.That(anomalyFeedback, Is.Not.Null);
            Assert.That(anomalyFeedback.AnomalyValue, Is.EqualTo(AnomalyValue.AutoDetect));
            Assert.That(anomalyFeedback.StartsOn, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(anomalyFeedback.EndsOn, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(anomalyFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
            Assert.That(anomalyFeedback.DetectionConfigurationId, Is.Null);
            Assert.That(anomalyFeedback.DetectionConfigurationSnapshot, Is.Null);
        }

        [RecordedTest]
        public async Task AddAndGetAnomalyFeedbackWithOptionalDetectionConfigurationFilter()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var feedbackToAdd = new MetricAnomalyFeedback(MetricId, dimensionKey, CreatedFeedbackStartTime, CreatedFeedbackEndTime, AnomalyValue.AutoDetect)
            {
                DetectionConfigurationId = DetectionConfigurationId
            };

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Anomaly));

            var anomalyFeedback = addedFeedback as MetricAnomalyFeedback;

            Assert.That(anomalyFeedback, Is.Not.Null);
            Assert.That(anomalyFeedback.AnomalyValue, Is.EqualTo(AnomalyValue.AutoDetect));
            Assert.That(anomalyFeedback.StartsOn, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(anomalyFeedback.EndsOn, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(anomalyFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
            Assert.That(anomalyFeedback.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));
            // TODO: Add snapshot validation (https://github.com/azure/azure-sdk-for-net/issues/15915)
        }

        [RecordedTest]
        public async Task AddAndGetChangePointFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var feedbackToAdd = new MetricChangePointFeedback(MetricId, dimensionKey, CreatedFeedbackStartTime, CreatedFeedbackEndTime, ChangePointValue.AutoDetect);

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.ChangePoint));

            var changePointFeedback = addedFeedback as MetricChangePointFeedback;

            Assert.That(changePointFeedback, Is.Not.Null);
            Assert.That(changePointFeedback.ChangePointValue, Is.EqualTo(ChangePointValue.AutoDetect));
            Assert.That(changePointFeedback.StartsOn, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(changePointFeedback.EndsOn, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(changePointFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
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

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var comment = "Feedback created in a .NET test.";

            var feedbackToAdd = new MetricCommentFeedback(MetricId, dimensionKey, comment);

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Comment));

            var commentFeedback = addedFeedback as MetricCommentFeedback;

            Assert.That(commentFeedback, Is.Not.Null);
            Assert.That(commentFeedback.Comment, Is.EqualTo(comment));
            Assert.That(commentFeedback.StartsOn, Is.Null);
            Assert.That(commentFeedback.EndsOn, Is.Null);
            Assert.That(commentFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
        }

        [RecordedTest]
        public async Task AddAndGetCommentFeedbackWithOptionalTimeFilters()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var comment = "Feedback created in a .NET test.";

            var feedbackToAdd = new MetricCommentFeedback(MetricId, dimensionKey, comment)
            {
                StartsOn = CreatedFeedbackStartTime,
                EndsOn = CreatedFeedbackEndTime
            };

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Comment));

            var commentFeedback = addedFeedback as MetricCommentFeedback;

            Assert.That(commentFeedback, Is.Not.Null);
            Assert.That(commentFeedback.Comment, Is.EqualTo(comment));
            Assert.That(commentFeedback.StartsOn, Is.EqualTo(CreatedFeedbackStartTime));
            Assert.That(commentFeedback.EndsOn, Is.EqualTo(CreatedFeedbackEndTime));
            Assert.That(commentFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
        }

        [RecordedTest]
        public async Task AddAndGetPeriodFeedback()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var dimensions = new Dictionary<string, string>() { { "city", ExpectedCity }, { "category", ExpectedCategory } };
            var dimensionKey = new DimensionKey(dimensions);

            var periodValue = 10;

            var feedbackToAdd = new MetricPeriodFeedback(MetricId, dimensionKey, MetricPeriodType.AutoDetect, periodValue);

            MetricFeedback addedFeedback = await client.AddFeedbackAsync(feedbackToAdd);

            ValidateMetricFeedback(addedFeedback);

            Assert.That(addedFeedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Period));

            var periodFeedback = addedFeedback as MetricPeriodFeedback;

            Assert.That(periodFeedback, Is.Not.Null);
            Assert.That(periodFeedback.PeriodType, Is.EqualTo(MetricPeriodType.AutoDetect));
            Assert.That(periodFeedback.PeriodValue, Is.EqualTo(periodValue));
            Assert.That(periodFeedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAllFeedbackWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient(useTokenCredential);

            var feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.CreatedOn, Is.Not.Null);

                Assert.That(feedback.DimensionFilter, Is.Not.Null);
                Assert.That(feedback.DimensionFilter.DimensionKey, Is.Not.Null);

                ValidateGroupKey(feedback.DimensionFilter.DimensionKey);

                if (feedback.FeedbackKind == MetricFeedbackKind.Anomaly)
                {
                    var anomalyFeedback = feedback as MetricAnomalyFeedback;

                    Assert.That(anomalyFeedback, Is.Not.Null);
                    Assert.That(anomalyFeedback.AnomalyValue, Is.Not.EqualTo(default(AnomalyFeedbackValue)));

                    if (anomalyFeedback.DetectionConfigurationId != null)
                    {
                        // TODO: Add snapshot validation (https://github.com/azure/azure-sdk-for-net/issues/15915).
                    }
                }
                else if (feedback.FeedbackKind == MetricFeedbackKind.ChangePoint)
                {
                    var changePointFeedback = feedback as MetricChangePointFeedback;

                    Assert.That(changePointFeedback, Is.Not.Null);
                    Assert.That(changePointFeedback.ChangePointValue, Is.Not.EqualTo(default(ChangePointValue)));
                }
                else if (feedback.FeedbackKind == MetricFeedbackKind.Comment)
                {
                    var commentFeedback = feedback as MetricCommentFeedback;

                    Assert.That(commentFeedback, Is.Not.Null);
                    Assert.That(commentFeedback.Comment, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.That(feedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Period));

                    var periodFeedback = feedback as MetricPeriodFeedback;

                    Assert.That(periodFeedback, Is.Not.Null);
                    Assert.That(periodFeedback.PeriodType, Is.Not.EqualTo(default(MetricPeriodType)));
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

            var dimensions = new Dictionary<string, string>() { { "city", "Delhi" } };
            var options = new GetAllFeedbackOptions()
            {
                Filter = new FeedbackFilter()
                {
                    DimensionKey = new DimensionKey(dimensions),
                    TimeMode = FeedbackQueryTimeMode.FeedbackCreatedOn,
                    StartsOn = feedbackSamplingStartTime,
                    EndsOn = feedbackSamplingEndTime,
                    FeedbackKind = MetricFeedbackKind.Comment,
                }
            };

            var feedbackCount = 0;

            await foreach (MetricFeedback feedback in client.GetAllFeedbackAsync(MetricId, options))
            {
                Assert.That(feedback, Is.Not.Null);
                Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
                Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);
                Assert.That(feedback.CreatedOn, Is.Not.Null);
                Assert.That(feedback.CreatedOn, Is.GreaterThanOrEqualTo(feedbackSamplingStartTime));
                Assert.That(feedback.CreatedOn, Is.LessThanOrEqualTo(feedbackSamplingEndTime));

                Assert.That(feedback.DimensionFilter, Is.Not.Null);

                DimensionKey dimensionKeyFilter = feedback.DimensionFilter.DimensionKey;

                Assert.That(dimensionKeyFilter, Is.Not.Null);

                ValidateGroupKey(dimensionKeyFilter);

                Assert.That(dimensionKeyFilter.TryGetValue("city", out string city));
                Assert.That(city, Is.EqualTo("Delhi"));

                Assert.That(feedback.FeedbackKind, Is.EqualTo(MetricFeedbackKind.Comment));

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

        private void ValidateMetricFeedback(MetricFeedback feedback)
        {
            Assert.That(feedback, Is.Not.Null);
            Assert.That(feedback.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(feedback.MetricId, Is.EqualTo(MetricId));
            Assert.That(feedback.UserPrincipal, Is.Not.Null.And.Not.Empty);

            DateTimeOffset justNow = Recording.UtcNow.Subtract(TimeSpan.FromMinutes(5));
            Assert.That(feedback.CreatedOn, Is.GreaterThan(justNow));

            Assert.That(feedback.DimensionFilter, Is.Not.Null);

            DimensionKey dimensionFilter = feedback.DimensionFilter.DimensionKey;

            Assert.That(dimensionFilter, Is.Not.Null);

            Assert.That(Count(dimensionFilter), Is.EqualTo(2));
            Assert.That(dimensionFilter.TryGetValue("city", out string city));
            Assert.That(dimensionFilter.TryGetValue("category", out string category));
            Assert.That(city, Is.EqualTo(ExpectedCity));
            Assert.That(category, Is.EqualTo(ExpectedCategory));
        }
    }
}
