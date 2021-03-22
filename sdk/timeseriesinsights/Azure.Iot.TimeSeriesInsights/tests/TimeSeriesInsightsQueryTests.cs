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

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class TimeSeriesInsightsQueryTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(10);

        private const int MaxNumberOfRetries = 10;
        private const string Humidity = "Humidity";
        private const string Temperature = "Temperature";

        public TimeSeriesInsightsQueryTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_GetEventsLifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient tsiClient = GetClient();
            DeviceClient deviceClient = GetDeviceClient();

            // Figure out what the Time Series Id is composed of
            TimeSeriesModelSettings modelSettings = await tsiClient.GetModelSettingsAsync().ConfigureAwait(false);

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            TimeSeriesId tsiId = await GetUniqueTimeSeriesInstanceIdAsync(tsiClient, modelSettings.TimeSeriesIdProperties.Count)
                .ConfigureAwait(false);

            try
            {
                // Send some events to the IoT hub
                await SendEventsToHubAsync(
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
                await SendEventsToHubAsync(
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
                IDictionary<string, object> messageBase = BuildMessageBase(modelSettings.TimeSeriesIdProperties.ToArray(), tsiId);
                messageBase[Temperature] = 1.2;
                messageBase[Humidity] = 3.4;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                await deviceClient.SendEventAsync(message).ConfigureAwait(false);

                // Send it again
                await deviceClient.SendEventAsync(message).ConfigureAwait(false);

                // Query for the two events with a filter

                // Only project Temperature and one of the Id properties
                var projectedProperties = new List<EventProperty>
                {
                    new EventProperty
                    {
                        Name = Temperature,
                        Type = "Double",
                    },
                    new EventProperty
                    {
                        Name = modelSettings.TimeSeriesIdProperties.First().Name,
                        Type = modelSettings.TimeSeriesIdProperties.First().Type.ToString(),
                    }
                };

                var queryRequestOptions = new QueryEventsRequestOptions
                {
                    Filter = "$event.Temperature.Double = 1.2",
                    ProjectedProperties = projectedProperties.ToArray(),
                    StoreType = StoreType.WarmStore,
                };

                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> queryEventsPages = tsiClient.QueryEventsAsync(tsiId, startTime, endTime, queryRequestOptions);
                    await foreach (QueryResultPage eventPage in queryEventsPages)
                    {
                        eventPage.Timestamps.Should().HaveCount(2);
                        eventPage.Properties.Should().HaveCount(2);
                        eventPage.Properties.First().Should().NotBeNull();
                        eventPage.Properties.First().Name.Should().Be(Temperature);
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
                    eventPage.Properties.First().Name.Should().Be(Temperature);
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

        private async Task SendEventsToHubAsync(DeviceClient client, TimeSeriesId tsiId, TimeSeriesIdProperty[] timeSeriesIdProperties, int numberOfEventsToSend)
        {
            IDictionary<string, object> messageBase = BuildMessageBase(timeSeriesIdProperties, tsiId);
            double minTemperature = 20;
            double minHumidity = 60;
            var rand = new Random();

            // Build the message base that is used as the base for every event going out
            for (int i = 0; i < numberOfEventsToSend; i++)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
                messageBase[Temperature] = currentTemperature;
                messageBase[Humidity] = currentHumidity;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                await client.SendEventAsync(message).ConfigureAwait(false);
            }
        }

        private static IDictionary<string, object> BuildMessageBase(TimeSeriesIdProperty[] timeSeriesIdProperties, TimeSeriesId tsiId)
        {
            var messageBase = new Dictionary<string, object>();
            string[] tsiIdArray = tsiId.ToArray();
            for (int i = 0; i < timeSeriesIdProperties.Count(); i++)
            {
                TimeSeriesIdProperty idProperty = timeSeriesIdProperties[i];
                string tsiIdValue = tsiIdArray[i];
                messageBase[idProperty.Name] = tsiIdValue;
            }

            return messageBase;
        }
    }
}
