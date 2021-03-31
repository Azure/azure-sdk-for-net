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
    public class TimeSeriesInsightsQuerySeriesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(30);

        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsQuerySeriesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsQuery_GetSeriesLifecycle()
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
                        10)
                    .ConfigureAwait(false);

                // Act

                // Query for temperature events with two calculateions. First with the temperature value as is, and the second
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
                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> querySeriesEventsPages = tsiClient.QuerySeriesAsync(
                        tsiId,
                        startTime,
                        endTime,
                        querySeriesRequestOptions);

                    await foreach (QueryResultPage seriesEventsPage in querySeriesEventsPages)
                    {
                        seriesEventsPage.Timestamps.Should().HaveCount(10);
                        seriesEventsPage.Timestamps.Should().OnlyContain(timeStamp => timeStamp >= startTime)
                        .And
                         .OnlyContain(timeStamp => timeStamp <= endTime);
                        seriesEventsPage.Properties.Count.Should().Be(3); // EventCount, Temperature and TemperatureTimesTwo
                        seriesEventsPage.Properties.Should().Contain((property) => property.Name == QueryTestsHelper.Temperature)
                        .And
                         .Contain((property) => property.Name == temperatureTimesTwoVariableName);

                        // Assert that the values for the Temperature property is equal to the values for the other property, multiplied by 2
                        var temperatureValues = seriesEventsPage
                        .Properties
                        .First((property) => property.Name == QueryTestsHelper.Temperature)
                        .Values.Cast<double>().ToList();

                        var temperatureTimesTwoValues = seriesEventsPage
                        .Properties
                        .First((property) => property.Name == temperatureTimesTwoVariableName)
                        .Values.Cast<double>().ToList();
                        temperatureTimesTwoValues.Should().Equal(temperatureValues.Select((property) => property * 2).ToList());
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for all the series events using a timespan
                AsyncPageable<QueryResultPage> querySeriesEventsPagesWithTimespan = tsiClient.QuerySeriesAsync(tsiId, TimeSpan.FromMinutes(10), null, querySeriesRequestOptions);
                await foreach (QueryResultPage seriesEventsPage in querySeriesEventsPagesWithTimespan)
                {
                    seriesEventsPage.Timestamps.Should().HaveCount(10);
                    seriesEventsPage.Properties.Count.Should().Be(3); // EventCount, Temperature and TemperatureTimesTwo
                }

                // Query for temperature and humidity
                var humidityNumericVariable = new NumericVariable(
                    new TimeSeriesExpression("$event.Humidity"),
                    new TimeSeriesExpression("avg($value)"));
                querySeriesRequestOptions.InlineVariables[QueryTestsHelper.Humidity] = humidityNumericVariable;
                querySeriesRequestOptions.ProjectedVariables.Add(QueryTestsHelper.Temperature);
                querySeriesRequestOptions.ProjectedVariables.Add(QueryTestsHelper.Humidity);
                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> querySeriesEventsPages = tsiClient.QuerySeriesAsync(tsiId, startTime, endTime, querySeriesRequestOptions);

                    await foreach (QueryResultPage seriesEventsPage in querySeriesEventsPages)
                    {
                        seriesEventsPage.Timestamps.Should().HaveCount(10);
                        seriesEventsPage.Timestamps.Should().OnlyContain(timeStamp => timeStamp >= startTime)
                        .And
                         .OnlyContain(timeStamp => timeStamp <= endTime);
                        seriesEventsPage.Properties.Count.Should().Be(2); // Temperature and Humidity
                        seriesEventsPage.Properties.Should().Contain((property) => property.Name == QueryTestsHelper.Temperature)
                        .And
                         .Contain((property) => property.Name == QueryTestsHelper.Humidity);
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
                querySeriesRequestOptions.Filter = "$event.Temperature.Double = 1.2";
                await TestRetryHelper.RetryAsync<AsyncPageable<QueryResultPage>>(async () =>
                {
                    AsyncPageable<QueryResultPage> querySeriesEventsPages = tsiClient.QuerySeriesAsync(tsiId, startTime, endTime, querySeriesRequestOptions);
                    await foreach (QueryResultPage seriesEventsPage in querySeriesEventsPages)
                    {
                        seriesEventsPage.Timestamps.Should().HaveCount(2);
                        seriesEventsPage.Properties.Should().HaveCount(2)
                        .And
                         .Contain((property) => property.Name == QueryTestsHelper.Temperature)
                        .And
                         .Contain((property) => property.Name == QueryTestsHelper.Humidity);

                        var temperatureValues = seriesEventsPage
                        .Properties
                        .First((property) => property.Name == QueryTestsHelper.Temperature)
                        .Values.Cast<double>().ToList();
                        temperatureValues.Should().AllBeEquivalentTo(1.2);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Query for the two events with a filter, but only take 1
                querySeriesRequestOptions.MaximumNumberOfEvents = 1;
                AsyncPageable<QueryResultPage> querySeriesEventsPagesWithFilter = tsiClient.QuerySeriesAsync(tsiId, startTime, endTime, querySeriesRequestOptions);
                await foreach (QueryResultPage seriesEventsPage in querySeriesEventsPagesWithFilter)
                {
                    seriesEventsPage.Timestamps.Should().HaveCount(1);
                    seriesEventsPage.Properties.Should().HaveCount(2)
                    .And
                     .Contain((property) => property.Name == QueryTestsHelper.Temperature)
                    .And
                     .Contain((property) => property.Name == QueryTestsHelper.Humidity);

                    var temperatureValues = seriesEventsPage
                    .Properties
                    .First((property) => property.Name == QueryTestsHelper.Temperature)
                    .Values.Cast<double>().ToList();
                    temperatureValues.Should().AllBeEquivalentTo(1.2);
                }
            }
            finally
            {
                deviceClient?.Dispose();
            }
        }
    }
}
