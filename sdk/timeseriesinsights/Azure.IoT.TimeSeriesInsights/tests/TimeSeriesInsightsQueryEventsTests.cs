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
    public class TimeSeriesInsightsQueryEventsTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(30);

        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsQueryEventsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_GetEventsLifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient tsiClient = GetClient();
            DeviceClient deviceClient = await GetDeviceClient().ConfigureAwait(false);

            // Figure out what the Time Series Id is composed of
            TimeSeriesModelSettings modelSettings = await tsiClient.GetModelSettingsAsync().ConfigureAwait(false);

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            TimeSeriesId tsiId = await GetUniqueTimeSeriesInstanceIdAsync(tsiClient, modelSettings.TimeSeriesIdProperties.Count)
                .ConfigureAwait(false);

            try
            {
                // Send some events to the IoT hub
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        2)
                    .ConfigureAwait(false);

                // Act

                // Get events from last 1 minute
                DateTimeOffset now = Recording.UtcNow;
                DateTimeOffset endTime = now.AddMinutes(10);
                DateTimeOffset startTime = now.AddMinutes(-10);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> queryEventsPages = tsiClient.QueryEventsAsync(tsiId, startTime, endTime);

                    await foreach (QueryResultPage eventPage in queryEventsPages)
                    {
                        eventPage.Timestamps.Should().HaveCount(2);
                        eventPage.Timestamps.Should().OnlyContain(timeStamp => timeStamp >= startTime).And.OnlyContain(timeStamp => timeStamp <= endTime);
                        eventPage.Properties.Should().NotBeEmpty();
                        eventPage.Properties.First().Should().NotBeNull();
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Send more events to the hub
                await QueryTestsHelper.SendEventsToHubAsync(
                        deviceClient,
                        tsiId,
                        modelSettings.TimeSeriesIdProperties.ToArray(),
                        2)
                    .ConfigureAwait(false);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> queryEventsPages = tsiClient.QueryEventsAsync(tsiId, startTime, endTime);

                    await foreach (QueryResultPage eventPage in queryEventsPages)
                    {
                        eventPage.Timestamps.Should().HaveCount(4);
                        eventPage.Timestamps.Should()
                        .OnlyContain(timeStamp => timeStamp >= startTime)
                        .And
                         .OnlyContain(timeStamp => timeStamp <= endTime);
                        eventPage.Properties.Should().NotBeEmpty();
                        eventPage.Properties.First().Should().NotBeNull();
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
                await sendEventAct.Should().NotThrowAsync();

                // Send it again
                sendEventAct.Should().NotThrow();

                // Query for the two events with a filter

                // Only project Temperature and one of the Id properties
                var queryRequestOptions = new QueryEventsRequestOptions
                {
                    Filter = "$event.Temperature.Double = 1.2",
                    StoreType = StoreType.WarmStore,
                };
                queryRequestOptions.ProjectedProperties.Add(
                    new EventProperty
                    {
                        Name = QueryTestsHelper.Temperature,
                        Type = "Double",
                    });
                queryRequestOptions.ProjectedProperties.Add(
                    new EventProperty
                    {
                        Name = modelSettings.TimeSeriesIdProperties.First().Name,
                        Type = modelSettings.TimeSeriesIdProperties.First().Type.ToString(),
                    });

                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> queryEventsPages = tsiClient.QueryEventsAsync(tsiId, startTime, endTime, queryRequestOptions);
                    await foreach (QueryResultPage eventPage in queryEventsPages)
                    {
                        eventPage.Timestamps.Should().HaveCount(2);
                        eventPage.Properties.Should().HaveCount(2);
                        eventPage.Properties.First().Should().NotBeNull();
                        eventPage.Properties.First().Name.Should().Be(QueryTestsHelper.Temperature);
                        eventPage.Properties[1].Name.Should().Be(modelSettings.TimeSeriesIdProperties.First().Name);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for the two events with a filter, but only take 1
                queryRequestOptions.MaximumNumberOfEvents = 1;
                AsyncPageable<QueryResultPage> queryEventsPagesWithFilter = tsiClient.QueryEventsAsync(tsiId, startTime, endTime, queryRequestOptions);
                await foreach (QueryResultPage eventPage in queryEventsPagesWithFilter)
                {
                    eventPage.Timestamps.Should().HaveCount(1);
                    eventPage.Properties.Should().HaveCount(2);
                    eventPage.Properties.First().Should().NotBeNull();
                    eventPage.Properties.First().Name.Should().Be(QueryTestsHelper.Temperature);
                    eventPage.Properties[1].Name.Should().Be(modelSettings.TimeSeriesIdProperties.First().Name);
                }

                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    // Query for all the events using a timespan
                    AsyncPageable<QueryResultPage> queryEventsPagesWithTimespan = tsiClient.QueryEventsAsync(tsiId, TimeSpan.FromMinutes(20), endTime);
                    await foreach (QueryResultPage eventPage in queryEventsPagesWithTimespan)
                    {
                        eventPage.Timestamps.Should().HaveCount(6);
                        eventPage.Timestamps.Should()
                            .OnlyContain(timeStamp => timeStamp >= startTime)
                            .And
                             .OnlyContain(timeStamp => timeStamp <= endTime);
                        eventPage.Properties.Should().NotBeEmpty();
                        eventPage.Properties.First().Should().NotBeNull();
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
