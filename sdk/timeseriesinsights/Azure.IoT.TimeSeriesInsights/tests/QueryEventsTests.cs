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
    public class QueryEventsTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(30);

        private const int MaxNumberOfRetries = 10;

        public QueryEventsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_GetEventsLifecycle()
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
                var initialEventsCount = 50;

                // Send some events to the IoT hub
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        initialEventsCount)
                    .ConfigureAwait(false);

                // Act

                // Get events from last 10 minute
                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryEventsPages = queriesClient.CreateEventsQuery(tsiId, startTime, endTime);
                    var count = 0;
                    await foreach (TimeSeriesPoint timeSeriesPoint in queryEventsPages.GetResultsAsync())
                    {
                        count++;
                        timeSeriesPoint.Timestamp.Should().BeAfter(startTime).And.BeBefore(endTime);

                        var temperatureValue = timeSeriesPoint.GetNullableDouble(QueryTestsHelper.Temperature);
                        temperatureValue.Should().NotBeNull();

                        var humidityValue = (double?)timeSeriesPoint.GetValue(QueryTestsHelper.Humidity);
                        humidityValue.Should().NotBeNull();
                    }

                    count.Should().Be(initialEventsCount);

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Send 2 events with a special condition that can be used later to query on
                IDictionary<string, object> messageBase = QueryTestsHelper.BuildMessageBase(
                    modelSettings.TimeSeriesIdProperties.ToArray(),
                    tsiId);
                messageBase[QueryTestsHelper.Temperature] = 1.2;
                messageBase[QueryTestsHelper.Humidity] = 3.4;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                Func<Task> sendEventAct = async () => await deviceClient.SendEventAsync(message).ConfigureAwait(false);
                await sendEventAct.Should().NotThrowAsync();

                // Send it again
                sendEventAct.Should().NotThrow();

                // Query for the two events with a filter

                // Only project Temperature and one of the Id properties
                var queryRequestOptions = new QueryEventsRequestOptions
                {
                    Filter = new TimeSeriesExpression("$event.Temperature.Double = 1.2"),
                    Store = StoreType.WarmStore,
                };
                queryRequestOptions.ProjectedProperties.Add(
                    new TimeSeriesInsightsEventProperty
                    {
                        Name = QueryTestsHelper.Temperature,
                        PropertyValueType = "Double",
                    });
                queryRequestOptions.ProjectedProperties.Add(
                    new TimeSeriesInsightsEventProperty
                    {
                        Name = modelSettings.TimeSeriesIdProperties.First().Name,
                        PropertyValueType = modelSettings.TimeSeriesIdProperties.First().PropertyType.ToString(),
                    });

                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    TimeSeriesQueryAnalyzer queryEventsPages = queriesClient.CreateEventsQuery(tsiId, startTime, endTime, queryRequestOptions);
                    await foreach (Page<TimeSeriesPoint> page in queryEventsPages.GetResultsAsync().AsPages())
                    {
                        page.Values.Should().HaveCount(2);
                        foreach (TimeSeriesPoint point in page.Values)
                        {
                            var value = (double?)point.GetValue(QueryTestsHelper.Temperature);
                            value.Should().Be(1.2);
                        }
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for the two events with a filter, but only take 1
                queryRequestOptions.MaxNumberOfEvents = 1;
                TimeSeriesQueryAnalyzer queryEventsPagesWithFilter = queriesClient.CreateEventsQuery(tsiId, startTime, endTime, queryRequestOptions);
                await foreach (Page<TimeSeriesPoint> page in queryEventsPagesWithFilter.GetResultsAsync().AsPages())
                {
                    page.Values.Should().HaveCount(1);
                }

                await TestRetryHelper.RetryAsync<AsyncPageable<TimeSeriesPoint>>(async () =>
                {
                    // Query for all the events using a timespan
                    TimeSeriesQueryAnalyzer queryEventsPagesWithTimespan = queriesClient
                        .CreateEventsQuery(tsiId, TimeSpan.FromMinutes(20), endTime);
                    await foreach (Page<TimeSeriesPoint> page in queryEventsPagesWithTimespan.GetResultsAsync().AsPages())
                    {
                        page.Values.Should().HaveCount(52);
                        foreach (TimeSeriesPoint point in page.Values)
                        {
                            point.Timestamp.Should().BeAfter(startTime).And.BeBefore(endTime);
                            var temperatureValue = (double?)point.GetValue(QueryTestsHelper.Temperature);
                            temperatureValue.Should().NotBeNull();
                            var humidityValue = (double?)point.GetValue(QueryTestsHelper.Humidity);
                            humidityValue.Should().NotBeNull();
                        }
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
