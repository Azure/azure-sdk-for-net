// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
    using Xunit;
    using RequestTelemetry = Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Request;
    using TelemetryType = OpenTelemetry.LiveMetrics.Models.TelemetryType;

    public class DerivedMetricTests
    {
        [Fact]
        public void DerivedMetricFiltersCorrectly()
        {
            // ARRANGE
            var filterInfo1 = new FilterInfo("Name", PredicateType.Contains, "dog");
            var filterInfo2 = new FilterInfo("Name", PredicateType.Contains, "cat");
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new[] { new FilterConjunctionGroupInfo(new List<FilterInfo> { filterInfo1, filterInfo2 }) },
                projection: "Name",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetryThatMustPass = new RequestTelemetry() { Name = "Both the words 'dog' and 'CAT' are here, which satisfies both filters" };
            var telemetryThatMustFail1 = new RequestTelemetry() { Name = "This value only contains the word 'dog', but not the other one" };
            var telemetryThatMustFail2 = new RequestTelemetry() { Name = "This value only contains the word 'cat', but not the other one" };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);

            // ASSERT
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(telemetryThatMustFail1, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(telemetryThatMustFail2, out errors));
            Assert.Empty(errors);
        }

        [Fact]
        public void DerivedMetricHandlesNoFiltersCorrectly()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "Name",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetryThatMustPass = new RequestTelemetry() { Name = "Both the words 'dog' and 'CAT' are here, which satisfies both filters" };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);

            // ASSERT
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass, out errors));
            Assert.Empty(errors);
        }

        [Fact]
        public void DerivedMetricHandlesNullFiltersCorrectly()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: null,
                projection: "Name",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetryThatMustPass = new RequestTelemetry() { Name = "Both the words 'dog' and 'CAT' are here, which satisfies both filters" };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);

            // ASSERT
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass, out errors));
            Assert.Empty(errors);
        }

        [Fact]
        public void DerivedMetricPerformsLogicalConnectionsBetweenFiltersCorrectly()
        {
            // ARRANGE
            var filterInfoDog = new FilterInfo("Name", PredicateType.Contains, "dog");
            var filterInfoCat = new FilterInfo("Name", PredicateType.Contains, "cat");
            var filterInfoApple = new FilterInfo("Name", PredicateType.Contains, "apple");
            var filterInfoOrange = new FilterInfo("Name", PredicateType.Contains, "orange");
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups:
                    new[]
                    {
                        new FilterConjunctionGroupInfo(new[] { filterInfoDog, filterInfoCat }),
                        new FilterConjunctionGroupInfo(new[] { filterInfoApple, filterInfoOrange })
                    },
                projection: "Name",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetryThatMustPass1 = new RequestTelemetry() { Name = "Both the words 'dog' and 'CAT' are here, which satisfies the first OR." };
            var telemetryThatMustPass2 = new RequestTelemetry() { Name = "Both the words 'apple' and 'ORANGE' are here, which satisfies the second OR." };
            var telemetryThatMustPass3 = new RequestTelemetry() { Name = "All four words are here: 'dog', 'cat', 'apple', and 'orange'!" };
            var telemetryThatMustFail1 = new RequestTelemetry() { Name = "This value only contains the words 'dog' and 'apple', which is not enough to satisfy any of the OR conditions." };
            var telemetryThatMustFail2 = new RequestTelemetry() { Name = "This value only contains the word 'cat' and 'orange', which is not enough to satisfy any of the OR conditions." };
            var telemetryThatMustFail3 = new RequestTelemetry() { Name = "None of the words are here!" };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);

            // ASSERT
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass1, out errors));
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass2, out errors));
            Assert.Empty(errors);

            Assert.True(metric.CheckFilters(telemetryThatMustPass3, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(telemetryThatMustFail1, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(telemetryThatMustFail2, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(telemetryThatMustFail3, out errors));
            Assert.Empty(errors);
        }

        [Fact]
        public void DerivedMetricProjectsCorrectly()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "Id",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetry = new DocumentMock() { Name = "1.23", Id = "5.67" };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMock>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Sum, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(5.67d, projection);
        }

        [Fact(Skip = "CustomDimensions not working yet.")]
        public void DerivedMetricProjectsCorrectlyWhenCustomDimension()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "CustomDimensions.Dimension1",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetry = new DocumentMock(new List<KeyValuePairString>() { new("Dimension.1", "1.5") });

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMock>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Sum, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(1.5d, projection);
        }

        [Fact]
        public void DerivedMetricProjectsCorrectlyWhenCustomMetric()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "CustomMetrics.Metric1",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetry = new DocumentMock() { Metrics = { ["Metric1"] = 1.75d } };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMock>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Sum, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(1.75d, projection);
        }

        [Fact]
        public void DerivedMetricProjectsCorrectlyWhenCount()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "COUNT()",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetry = new RequestTelemetry();

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Sum, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(1d, projection);
        }

        [Fact]
        public void DerivedMetricProjectsCorrectlyWhenTimeSpan()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "Duration",
                aggregation: AggregationType.Avg,
                backEndAggregation: AggregationType.Avg
            );

            var telemetry = new DocumentMock() { Duration = TimeSpan.FromMilliseconds(120) };

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMock>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Avg, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(120, projection);
        }

        [Fact]
        public void DerivedMetricProjectsCorrectlyWhenDurationIsString()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "Duration",
                aggregation: AggregationType.Avg,
                backEndAggregation: AggregationType.Avg
            );

            var durationString = TimeSpan.FromMilliseconds(120).ToString();
            var telemetry = new DocumentMockWithStringDuration(durationString);

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMockWithStringDuration>(metricInfo, out errors);
            double projection = metric.Project(telemetry);

            // ASSERT
            Assert.Equal(AggregationType.Avg, metric.AggregationType);
            Assert.Empty(errors);
            Assert.Equal(120, projection);
        }

        [Fact(Skip = "Unknown failure.")]
        public void DerivedMetricReportsErrorsForInvalidFilters()
        {
            // ARRANGE
            var filterInfo1 = new FilterInfo("Name", PredicateType.Equal, "Sky");
            var filterInfo2 = new FilterInfo("NonExistentField", PredicateType.Equal, "Comparand");
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new[] { new FilterConjunctionGroupInfo(new[] { filterInfo1, filterInfo2 }) },
                projection: "Name",
                aggregation: AggregationType.Avg,
                backEndAggregation: AggregationType.Avg
            );

            // ACT
            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<RequestTelemetry>(metricInfo, out errors);

            // ASSERT
            Assert.Equal(CollectionConfigurationErrorType.FilterFailureToCreateUnexpected, errors.Single().CollectionConfigurationErrorType);
            Assert.Equal(
                "Failed to create a filter NonExistentField Equal Comparand.",
                errors.Single().Message);
            Assert.Contains("Error finding property NonExistentField in the type Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Request", errors.Single().FullException);
            Assert.Equal(4, errors[0].Data.Count);
            Assert.Equal("Metric1", errors[0].Data.GetValue("MetricId"));
            Assert.Equal("NonExistentField", errors[0].Data.GetValue("FilterFieldName"));
            Assert.Equal(Predicate.Equal.ToString(), errors[0].Data.GetValue("FilterPredicate"));
            Assert.Equal("Comparand", errors[0].Data.GetValue("FilterComparand"));

            // we must be left with the one valid filter only
            Assert.True(metric.CheckFilters(new RequestTelemetry() { Name = "sky" }, out errors));
            Assert.Empty(errors);

            Assert.False(metric.CheckFilters(new RequestTelemetry() { Name = "sky1" }, out errors));
            Assert.Empty(errors);
        }

        [Fact]
        public void DerivedMetricThrowsWhenInvalidProjection()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "NonExistentFieldName",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            // ACT, ASSERT
            CollectionConfigurationError[] errors;
            Assert.Throws<ArgumentOutOfRangeException>(() => new DerivedMetric<RequestTelemetry>(metricInfo, out errors));
        }

        [Fact]
        public void DerivedMetricReportsErrorWhenProjectionIsNotDouble()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "Id",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            var telemetry = new DocumentMock() { Id = "NotDoubleValue" };

            CollectionConfigurationError[] errors;
            var metric = new DerivedMetric<DocumentMock>(metricInfo, out errors);

            // ACT
            try
            {
                metric.Project(telemetry);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // ASSERT
                Assert.Contains("Id", e.ToString());
                return;
            }

            Assert.Fail("The code should not reach here.");
        }

        [Fact]
        public void DerivedMetricReportsErrorWhenProjectionIsAsterisk()
        {
            // ARRANGE
            var metricInfo = new DerivedMetricInfo(
                id: "Metric1",
                telemetryType: TelemetryType.Request.ToString(),
                filterGroups: new FilterConjunctionGroupInfo[0],
                projection: "*",
                aggregation: AggregationType.Sum,
                backEndAggregation: AggregationType.Sum
            );

            // ACT, ASSERT
            CollectionConfigurationError[] errors;
            Assert.Throws<ArgumentOutOfRangeException>(() => new DerivedMetric<RequestTelemetry>(metricInfo, out errors));
        }
    }
}
