// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using Microsoft.Azure.Devices.Client;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    [LiveOnly]
    public class TimeSeriesInsightsQueryAggregateSeriesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(30);

        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsQueryAggregateSeriesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_AggregateSeriesWithNumericVariable()
        {
            // Arrange
            TimeSeriesInsightsClient tsiClient = GetClient();
            TimeSeriesInsightsModelSettings timeSeriesModelSettings = tsiClient.GetModelSettingsClient();
            TimeSeriesInsightsInstances instancesClient = tsiClient.GetInstancesClient();
            TimeSeriesInsightsQueries queriesClient = tsiClient.GetQueriesClient();
            DeviceClient deviceClient = await GetDeviceClient().ConfigureAwait(false);

            // Figure out what the Time Series Id is composed of
            TimeSeriesModelSettings modelSettings = await timeSeriesModelSettings.GetAsync().ConfigureAwait(false);

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            TimeSeriesId tsiId = await GetUniqueTimeSeriesInstanceIdAsync(instancesClient, modelSettings.TimeSeriesIdProperties.Count)
                .ConfigureAwait(false);

            try
            {
                // Send some events to the IoT hub with with a second between each event
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        30)
                      .ConfigureAwait(false);

                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                var temperatureNumericVariable = new NumericVariable(
                    new TimeSeriesExpression($"$event.{QueryTestsHelper.Temperature}"),
                    new TimeSeriesExpression("avg($value)"));

                var queryAggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
                queryAggregateSeriesRequestOptions.InlineVariables[QueryTestsHelper.Temperature] = temperatureNumericVariable;
                queryAggregateSeriesRequestOptions.ProjectedVariableNames.Add(QueryTestsHelper.Temperature);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryAggregateSeriesPages = queriesClient.CreateAggregateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        TimeSpan.FromSeconds(5),
                        queryAggregateSeriesRequestOptions);

                    var nonNullFound = false;
                    await foreach (Page<TimeSeriesPoint> aggregateSeriesPage in queryAggregateSeriesPages.GetResultsAsync().AsPages())
                    {
                        foreach (TimeSeriesPoint point in aggregateSeriesPage.Values)
                        {
                            point.GetUniquePropertyNames().Should().HaveCount(1).And.Contain((property) => property == QueryTestsHelper.Temperature);
                            var value = (double?)point.GetValue(QueryTestsHelper.Temperature);
                            if (value != null)
                            {
                                nonNullFound = true;
                            }
                        }

                        nonNullFound.Should().BeTrue();
                    }

                    queryAggregateSeriesPages.Progress.Should().Be(100);

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Add an interpolated variable
                var linearInterpolationNumericVariable = new NumericVariable(
                    new TimeSeriesExpression($"$event.{QueryTestsHelper.Temperature}"),
                    new TimeSeriesExpression("left($value)"));

                linearInterpolationNumericVariable.Interpolation = new TimeSeriesInterpolation
                {
                    Kind = InterpolationKind.Linear,
                    Boundary = new InterpolationBoundary()
                    {
                        Span = TimeSpan.FromSeconds(1),
                    },
                };

                const string linearInterpolation = "linearInterpolation";
                queryAggregateSeriesRequestOptions.InlineVariables[linearInterpolation] = linearInterpolationNumericVariable;
                queryAggregateSeriesRequestOptions.ProjectedVariableNames.Add(linearInterpolation);

                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryAggregateSeriesPages = queriesClient.CreateAggregateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        TimeSpan.FromSeconds(5),
                        queryAggregateSeriesRequestOptions);

                    await foreach (Page<TimeSeriesPoint> aggregateSeriesPage in queryAggregateSeriesPages.GetResultsAsync().AsPages())
                    {
                        aggregateSeriesPage.Values.Should().HaveCountGreaterThan(0);
                        foreach (var point in aggregateSeriesPage.Values)
                        {
                            point.GetUniquePropertyNames().Should().HaveCount(2)
                            .And
                             .Contain((property) => property == QueryTestsHelper.Temperature)
                            .And
                             .Contain((property) => property == linearInterpolation);
                        }
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Send 2 events with a special condition that can be used later to query on
                IDictionary<string, object> messageBase = QueryTestsHelper.BuildMessageBase(modelSettings.TimeSeriesIdProperties.ToArray(), tsiId);
                messageBase[QueryTestsHelper.Temperature] = 1.2;
                messageBase[QueryTestsHelper.Humidity] = 3.4;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                Func<Task> sendEventAct = async () => await deviceClient.SendEventAsync(message).ConfigureAwait(false);
                sendEventAct.Should().NotThrow();

                // Send it again
                sendEventAct.Should().NotThrow();

                // Query for the two events with a filter
                queryAggregateSeriesRequestOptions.Filter = new TimeSeriesExpression("$event.Temperature.Double = 1.2");
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryAggregateSeriesPages = queriesClient.CreateAggregateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        TimeSpan.FromSeconds(5),
                        queryAggregateSeriesRequestOptions);

                    var valueFound = false;
                    await foreach (TimeSeriesPoint point in queryAggregateSeriesPages.GetResultsAsync())
                    {
                        point.GetUniquePropertyNames().Should().HaveCount(2)
                        .And
                         .Contain((property) => property == QueryTestsHelper.Temperature)
                        .And
                         .Contain((property) => property == linearInterpolation);

                        var value = (double?)point.GetValue(QueryTestsHelper.Temperature);
                        if (value == 1.2)
                        {
                            valueFound = true;
                        }
                    }

                    valueFound.Should().BeTrue();

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                deviceClient?.Dispose();
            }
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_AggregateSeriesWithAggregateVariable()
        {
            // Arrange
            TimeSeriesInsightsClient tsiClient = GetClient();
            TimeSeriesInsightsModelSettings timeSeriesModelSettings = tsiClient.GetModelSettingsClient();
            TimeSeriesInsightsInstances instancesClient = tsiClient.GetInstancesClient();
            TimeSeriesInsightsQueries queriesClient = tsiClient.GetQueriesClient();
            DeviceClient deviceClient = await GetDeviceClient().ConfigureAwait(false);

            // Figure out what the Time Series Id is composed of
            TimeSeriesModelSettings modelSettings = await timeSeriesModelSettings.GetAsync().ConfigureAwait(false);

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            TimeSeriesId tsiId = await GetUniqueTimeSeriesInstanceIdAsync(instancesClient, modelSettings.TimeSeriesIdProperties.Count)
                .ConfigureAwait(false);

            try
            {
                // Send some events to the IoT hub with with a second between each event
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        30)
                      .ConfigureAwait(false);

                // Query for temperature events with two calculateions. First with the temperature value as is, and the second
                // with the temperature value multiplied by 2.
                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                var aggregateVariable = new AggregateVariable(
                    new TimeSeriesExpression("count()"));

                var queryAggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
                queryAggregateSeriesRequestOptions.InlineVariables["Count"] = aggregateVariable;
                queryAggregateSeriesRequestOptions.ProjectedVariableNames.Add("Count");

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryAggregateSeriesPages = queriesClient.CreateAggregateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        TimeSpan.FromSeconds(5),
                        queryAggregateSeriesRequestOptions);

                    long? totalCount = 0;
                    await foreach (TimeSeriesPoint point in queryAggregateSeriesPages.GetResultsAsync())
                    {
                        var currentCount = (long?)point.GetValue("Count");
                        totalCount += currentCount;
                    }

                    totalCount.Should().Be(30);

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                deviceClient?.Dispose();
            }
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_AggregateSeriesWithCategoricalVariable()
        {
            // Arrange
            TimeSeriesInsightsClient tsiClient = GetClient();
            TimeSeriesInsightsModelSettings timeSeriesInsightsModelSettings = tsiClient.GetModelSettingsClient();
            TimeSeriesInsightsInstances instancesClient = tsiClient.GetInstancesClient();
            TimeSeriesInsightsQueries queriesClient = tsiClient.GetQueriesClient();
            DeviceClient deviceClient = await GetDeviceClient().ConfigureAwait(false);

            // Figure out what the Time Series Id is composed of
            TimeSeriesModelSettings modelSettings = await timeSeriesInsightsModelSettings.GetAsync().ConfigureAwait(false);

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            TimeSeriesId tsiId = await GetUniqueTimeSeriesInstanceIdAsync(instancesClient, modelSettings.TimeSeriesIdProperties.Count)
                .ConfigureAwait(false);

            try
            {
                // Send some events to the IoT hub with with a second between each event
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        30)
                      .ConfigureAwait(false);

                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                var queryAggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();

                var categoricalVariable = new CategoricalVariable(
                    new TimeSeriesExpression($"tolong($event.{QueryTestsHelper.Temperature}.Double)"),
                    new TimeSeriesDefaultCategory("N/A"));
                categoricalVariable.Categories.Add(new TimeSeriesAggregateCategory("good", new List<object> { 1 }));

                queryAggregateSeriesRequestOptions.InlineVariables["categorical"] = categoricalVariable;

                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryAggregateSeriesPages = queriesClient.CreateAggregateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        TimeSpan.FromSeconds(5),
                        queryAggregateSeriesRequestOptions);

                    await foreach (TimeSeriesPoint point in queryAggregateSeriesPages.GetResultsAsync())
                    {
                        point.GetUniquePropertyNames().Should().HaveCount(3)
                        .And
                         .Contain((property) => property == "categorical[good]")
                        .And
                         .Contain((property) => property == "categorical[N/A]");
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                deviceClient?.Dispose();
            }
        }
    }
}
