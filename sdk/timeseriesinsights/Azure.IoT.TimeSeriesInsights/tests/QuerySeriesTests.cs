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
    public class QuerySeriesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(30);

        private const int MaxNumberOfRetries = 10;

        public QuerySeriesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_GetSeriesLifecycle()
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
                // Send some events to the IoT hub
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        10)
                    .ConfigureAwait(false);

                // Act

                // Query for temperature events with two calculations. First with the temperature value as is, and the second
                // with the temperature value multiplied by 2.
                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                var temperatureNumericVariable = new NumericVariable(
                    new TimeSeriesExpression($"$event.{QueryTestsHelper.Temperature}"),
                    new TimeSeriesExpression("avg($value)"));
                var temperatureNumericVariableTimesTwo = new NumericVariable(
                    new TimeSeriesExpression($"$event.{QueryTestsHelper.Temperature} * 2"),
                    new TimeSeriesExpression("avg($value)"));
                var temperatureTimesTwoVariableName = $"{QueryTestsHelper.Temperature}TimesTwo";

                var querySeriesRequestOptions = new QuerySeriesRequestOptions();
                querySeriesRequestOptions.InlineVariables[QueryTestsHelper.Temperature] = temperatureNumericVariable;
                querySeriesRequestOptions.InlineVariables[temperatureTimesTwoVariableName] = temperatureNumericVariableTimesTwo;

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer querySeriesEventsPages = queriesClient.CreateSeriesQuery(
                        tsiId,
                        startTime,
                        endTime,
                        querySeriesRequestOptions);

                    await foreach (Page<TimeSeriesPoint> seriesEventsPage in querySeriesEventsPages.GetResultsAsync().AsPages())
                    {
                        seriesEventsPage.Values.Should().HaveCount(10);
                        for (int index = 0; index < seriesEventsPage.Values.Count; index++)
                        {
                            TimeSeriesPoint point = seriesEventsPage.Values[index];
                            point.Timestamp.Should().BeAfter(startTime).And.BeBefore(endTime);
                            point.GetUniquePropertyNames().Should().HaveCount(3);
                            point.GetUniquePropertyNames().Should().Contain((property) => property == QueryTestsHelper.Temperature)
                                .And
                                .Contain((property) => property == temperatureTimesTwoVariableName);

                            // Assert that the values for the Temperature property is equal to the values for the other property, multiplied by 2
                            var temperatureTimesTwoValue = (double?)point.GetValue(temperatureTimesTwoVariableName);
                            var temperatureValue = (double?)point.GetValue(QueryTestsHelper.Temperature);
                            temperatureTimesTwoValue.Should().Be(temperatureValue * 2);
                        }
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for all the series events using a timespan
                TimeSeriesQueryAnalyzer querySeriesEventsPagesWithTimespan = queriesClient
                    .CreateSeriesQuery(tsiId, TimeSpan.FromMinutes(10), null, querySeriesRequestOptions);

                await foreach (Page<TimeSeriesPoint> seriesEventsPage in querySeriesEventsPagesWithTimespan.GetResultsAsync().AsPages())
                {
                    seriesEventsPage.Values.Should().HaveCount(10);
                    foreach (TimeSeriesPoint point in seriesEventsPage.Values)
                    {
                        point.GetUniquePropertyNames().Should().HaveCount(3);
                    }
                }

                // Query for temperature and humidity
                var humidityNumericVariable = new NumericVariable(
                    new TimeSeriesExpression("$event.Humidity"),
                    new TimeSeriesExpression("avg($value)"));
                querySeriesRequestOptions.InlineVariables[QueryTestsHelper.Humidity] = humidityNumericVariable;
                querySeriesRequestOptions.ProjectedVariableNames.Add(QueryTestsHelper.Temperature);
                querySeriesRequestOptions.ProjectedVariableNames.Add(QueryTestsHelper.Humidity);
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer querySeriesEventsPages = queriesClient.CreateSeriesQuery(tsiId, startTime, endTime, querySeriesRequestOptions);

                    await foreach (Page<TimeSeriesPoint> seriesEventsPage in querySeriesEventsPages.GetResultsAsync().AsPages())
                    {
                        seriesEventsPage.Values.Should().HaveCount(10);
                        foreach (TimeSeriesPoint point in seriesEventsPage.Values)
                        {
                            point.Timestamp.Should().BeAfter(startTime).And.BeBefore(endTime);
                            point.GetUniquePropertyNames().Should().HaveCount(2)
                                .And
                                 .Contain((property) => property == QueryTestsHelper.Temperature)
                                .And
                                 .Contain((property) => property == QueryTestsHelper.Humidity);
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
                querySeriesRequestOptions.Filter = new TimeSeriesExpression("$event.Temperature.Double = 1.2");
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer querySeriesEventsPages = queriesClient.CreateSeriesQuery(tsiId, startTime, endTime, querySeriesRequestOptions);
                    await foreach (Page<TimeSeriesPoint> seriesEventsPage in querySeriesEventsPages.GetResultsAsync().AsPages())
                    {
                        seriesEventsPage.Values.Should().HaveCount(2);
                        foreach (TimeSeriesPoint point in seriesEventsPage.Values)
                        {
                            point.GetUniquePropertyNames().Should().HaveCount(2);
                            var temperatureValue = (double?)point.GetValue(QueryTestsHelper.Temperature);
                            temperatureValue.Should().Be(1.2);
                        }
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for the two events with a filter, but only take 1
                querySeriesRequestOptions.MaxNumberOfEvents = 1;
                TimeSeriesQueryAnalyzer querySeriesEventsPagesWithFilter = queriesClient.CreateSeriesQuery(tsiId, startTime, endTime, querySeriesRequestOptions);
                await foreach (Page<TimeSeriesPoint> seriesEventsPage in querySeriesEventsPagesWithFilter.GetResultsAsync().AsPages())
                {
                    seriesEventsPage.Values.Should().HaveCount(1);
                }
            }
            finally
            {
                deviceClient?.Dispose();
            }
        }
    }
}
