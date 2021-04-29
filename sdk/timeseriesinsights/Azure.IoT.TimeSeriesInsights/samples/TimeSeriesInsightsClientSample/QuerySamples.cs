// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class QuerySamples
    {
        /// <summary>
        /// This sample demonstrates querying for raw events and aggregate series data from a Time Series Insights environment.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client, DeviceClient deviceClient)
        {
            // Figure out what keys make up the Time Series Id
            TimeSeriesModelSettings modelSettings = await client.ModelSettings.GetAsync().ConfigureAwait(false);

            int numOfIdKeys = modelSettings.TimeSeriesIdProperties.Count;

            // Create a Time Series Id where the number of keys that make up the Time Series Id is fetched from Model Settings
            var id = new List<string>();
            for (int i = 0; i < numOfIdKeys; i++)
            {
                id.Add(Guid.NewGuid().ToString());
            }

            TimeSeriesId tsId = numOfIdKeys switch
            {
                1 => new TimeSeriesId(id[0]),
                2 => new TimeSeriesId(id[0], id[1]),
                3 => new TimeSeriesId(id[0], id[1], id[2]),
                _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
            };

            // In order to query for data, let's first send events to the IoT Hub
            await SendEventsToIotHubAsync(deviceClient, tsId, modelSettings.TimeSeriesIdProperties.ToArray()).ConfigureAwait(false);

            // Sleeping for a few seconds to allow data to fully propagate in the Time Series Insights service
            Thread.Sleep(TimeSpan.FromSeconds(3));

            await RunQueryEventsSample(client, tsId).ConfigureAwait(false);

            await RunQuerySeriesSample(client, tsId).ConfigureAwait(false);

            await RunQueryAggregateSeriesSample(client, tsId).ConfigureAwait(false);
        }

        private async Task RunQueryAggregateSeriesSample(TimeSeriesInsightsClient client, TimeSeriesId tsId)
        {
            #region Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithNumericVariable
            Console.WriteLine("\n\nQuery for the average temperature over the past 30 seconds, in 2-second time slots.\n");

            var numericVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature"),
                new TimeSeriesExpression("avg($value)"));

            var requestOptions = new QueryAggregateSeriesRequestOptions();
            requestOptions.InlineVariables["Temperature"] = numericVariable;
            requestOptions.ProjectedVariables.Add("Temperature");

            QueryAnalyzer queryAggregateSeriesAnalyzer = client.Query.CreateAggregateSeriesQueryAnalyzer(
                tsId,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(30),
                null,
                requestOptions);

            await foreach (TimeSeriesPoint point in queryAggregateSeriesAnalyzer.GetResultsAsync())
            {
                double? averageTemperature = (double?)point.GetValue("Temperature");
                if (averageTemperature != null)
                {
                    Console.WriteLine($"{point.Timestamp} - Average temperature: {averageTemperature}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithNumericVariable

            #region Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable
            Console.WriteLine("\n\nCount the number of temperature vents over the past 3 minutes, in 1-minute time slots.\n");

            // Get the count of events in 60-second time slots over the past 3 minutes
            DateTimeOffset now = DateTime.UtcNow;
            DateTimeOffset endTime = now.AddMinutes(3);
            DateTimeOffset startTime = now.AddMinutes(-3);

            var aggregateVariable = new AggregateVariable(
                new TimeSeriesExpression("count()"));

            var aggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
            aggregateSeriesRequestOptions.InlineVariables["Count"] = aggregateVariable;
            aggregateSeriesRequestOptions.ProjectedVariables.Add("Count");

            QueryAnalyzer aggregateSeriesQueryAnalyzer = client.Query.CreateAggregateSeriesQueryAnalyzer(
                tsId,
                startTime,
                endTime,
                TimeSpan.FromSeconds(60),
                aggregateSeriesRequestOptions);

            await foreach (TimeSeriesPoint point in aggregateSeriesQueryAnalyzer.GetResultsAsync())
            {
                long? temperatureCount = (long?)point.GetValue("Count");
                Console.WriteLine($"{point.Timestamp} - Temperature count: {temperatureCount}");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable
        }

        private async Task RunQueryEventsSample(TimeSeriesInsightsClient client, TimeSeriesId tsId)
        {
            #region Snippet:TimeSeriesInsightsSampleQueryEvents
            Console.WriteLine("\n\nQuery for raw temperature events over the past 10 minutes.\n");

            // Get events from last 10 minute
            DateTimeOffset now = DateTime.UtcNow;
            DateTimeOffset endTime = now.AddMinutes(10);
            DateTimeOffset startTime = now.AddMinutes(-10);


            QueryAnalyzer temperatureEventsQueryAnalyzer = client.Query.CreateEventsQueryAnalyzer(tsId, startTime, endTime);
            await foreach (TimeSeriesPoint point in temperatureEventsQueryAnalyzer.GetResultsAsync())
            {
                double? temperatureValue = (double?)point.GetValue("Temperature");
                Console.WriteLine($"{point.Timestamp} - Temperature: {temperatureValue}");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryEvents

            // Query for raw events using a time interval
            #region Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan
            Console.WriteLine("\n\nQuery for raw humidity events over the past 30 seconds.\n");

            QueryAnalyzer humidityEventsQueryAnalyzer = client.Query.CreateEventsQueryAnalyzer(tsId, TimeSpan.FromSeconds(30));
            await foreach (TimeSeriesPoint point in humidityEventsQueryAnalyzer.GetResultsAsync())
            {
                double? humidityValue = (double?)point.GetValue("Humidity");
                Console.WriteLine($"{point.Timestamp} - Humidity: {humidityValue}");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan
        }

        private async Task RunQuerySeriesSample(TimeSeriesInsightsClient client, TimeSeriesId tsId)
        {
            // Query for two series, one with the temperature values in Celsius and another in Fahrenheit
            #region Snippet:TimeSeriesInsightsSampleQuerySeries
            Console.WriteLine("\n\nQuery for temperature series in celsius and fahrenheit over the past 10 minutes.\n");

            DateTimeOffset now = DateTime.UtcNow;
            DateTimeOffset endTime = now.AddMinutes(10);
            DateTimeOffset startTime = now.AddMinutes(-10);

            var celsiusVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature"),
                new TimeSeriesExpression("avg($value)"));
            var fahrenheitVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature * 1.8 + 32"),
                new TimeSeriesExpression("avg($value)"));

            var querySeriesRequestOptions = new QuerySeriesRequestOptions();
            querySeriesRequestOptions.InlineVariables["TemperatureInCelsius"] = celsiusVariable;
            querySeriesRequestOptions.InlineVariables["TemperatureInFahrenheit"] = fahrenheitVariable;

            QueryAnalyzer seriesQueryAnalyzer = client.Query.CreateSeriesQueryAnalyzer(
                tsId,
                startTime,
                endTime,
                querySeriesRequestOptions);

            await foreach (TimeSeriesPoint point in seriesQueryAnalyzer.GetResultsAsync())
            {
                double? tempInCelsius = (double?)point.GetValue("TemperatureInCelsius");
                double? tempInFahrenheit = (double?)point.GetValue("TemperatureInFahrenheit");

                Console.WriteLine($"{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. Average temperature in Fahrenheit: {tempInFahrenheit}.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQuerySeries
        }


        private static async Task SendEventsToIotHubAsync(
            DeviceClient deviceClient,
            TimeSeriesId tsId,
            TimeSeriesIdProperty[] timeSeriesIdProperties)
        {
            IDictionary<string, object> messageBase = BuildMessageBase(timeSeriesIdProperties, tsId);
            double minTemperature = 20;
            double minHumidity = 60;
            var rand = new Random();

            Console.WriteLine("\n\nSending temperature and humidity events to the IoT Hub.\n");

            // Build the message base that is used as the base for every event going out
            for (int i = 0; i < 10; i++)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;
                messageBase["Temperature"] = currentTemperature;
                messageBase["Humidity"] = currentHumidity;
                string messageBody = JsonSerializer.Serialize(messageBase);
                var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                };

                await deviceClient.SendEventAsync(message).ConfigureAwait(false);

                Console.WriteLine($"{DateTime.UtcNow} - Temperature: {currentTemperature}. " +
                    $"Humidity: {currentHumidity}.");

                await Task.Delay(TimeSpan.FromSeconds(1));
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
