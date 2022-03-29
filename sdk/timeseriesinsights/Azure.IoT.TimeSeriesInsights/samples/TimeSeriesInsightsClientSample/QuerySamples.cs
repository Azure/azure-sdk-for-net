// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class QuerySamples
    {
        /// <summary>
        /// This sample demonstrates querying for raw events, series and aggregate series data from a Time Series Insights environment.
        /// </summary>
        /// <remarks>
        /// The Query APIs make use Time Series Expressions (TSX) to build filters, value and aggregation expressions. Visit
        /// <see href="https://docs.microsoft.com/rest/api/time-series-insights/reference-time-series-expression-syntax"/> to learn more about TSX.
        /// </remarks>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client, TimeSeriesId tsId)
        {
            PrintHeader("TIME SERIES INSIGHTS QUERY SAMPLE");

            TimeSeriesInsightsQueries queriesClient = client.GetQueriesClient();

            await RunQueryEventsSample(queriesClient, tsId);

            await RunQueryAggregateSeriesSample(queriesClient, tsId);

            await RunQuerySeriesSampleWithInlineVariables(queriesClient, tsId);

            await RunQuerySeriesSampleWithPreDefinedVariables(client, tsId);
        }

        private async Task RunQueryEventsSample(TimeSeriesInsightsQueries queriesClient, TimeSeriesId tsId)
        {
            #region Snippet:TimeSeriesInsightsSampleQueryEvents
            Console.WriteLine("\n\nQuery for raw temperature events over the past 10 minutes.\n");

            // Get events from last 10 minute
            DateTimeOffset endTime = DateTime.UtcNow;
            DateTimeOffset startTime = endTime.AddMinutes(-10);

            TimeSeriesQueryAnalyzer temperatureEventsQuery = queriesClient.CreateEventsQuery(tsId, startTime, endTime);
            await foreach (TimeSeriesPoint point in temperatureEventsQuery.GetResultsAsync())
            {
                TimeSeriesValue temperatureValue = point.GetValue("Temperature");

                // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
                // environment best, you probably do not need this logic and you can skip to directly casting to the proper
                // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
                // too familiar with the property type.
                if (temperatureValue.Type == typeof(double?))
                {
                    Console.WriteLine($"{point.Timestamp} - Temperature: {point.GetNullableDouble("Temperature")}");
                }
                else if (temperatureValue.Type == typeof(int?))
                {
                    Console.WriteLine($"{point.Timestamp} - Temperature: {point.GetNullableInt("Temperature")}");
                }
                else
                {
                    Console.WriteLine("The type of the Time Series value for Temperature is not numeric.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryEvents

            // Query for raw events using a time interval
            #region Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan
            Console.WriteLine("\n\nQuery for raw humidity events over the past 30 seconds.\n");

            TimeSeriesQueryAnalyzer humidityEventsQuery = queriesClient.CreateEventsQuery(tsId, TimeSpan.FromSeconds(30));
            await foreach (TimeSeriesPoint point in humidityEventsQuery.GetResultsAsync())
            {
                TimeSeriesValue humidityValue = point.GetValue("Humidity");

                // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
                // environment best, you probably do not need this logic and you can skip to directly casting to the proper
                // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
                // too familiar with the property type.
                if (humidityValue.Type == typeof(double?))
                {
                    Console.WriteLine($"{point.Timestamp} - Humidity: {point.GetNullableDouble("Humidity")}");
                }
                else if (humidityValue.Type == typeof(int?))
                {
                    Console.WriteLine($"{point.Timestamp} - Humidity: {point.GetNullableInt("Humidity")}");
                }
                else
                {
                    Console.WriteLine("The type of the Time Series value for Humidity is not numeric.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan
        }

        private async Task RunQuerySeriesSampleWithPreDefinedVariables(TimeSeriesInsightsClient client, TimeSeriesId tsId)
        {
            // Setup
            TimeSeriesInsightsInstances instancesClient = client.GetInstancesClient();
            TimeSeriesInsightsTypes typesClient = client.GetTypesClient();
            TimeSeriesInsightsQueries queriesClient = client.GetQueriesClient();

            // First create the Time Series type along with the numeric variables
            var timeSeriesTypes = new List<TimeSeriesType>();

            var celsiusVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature"),
                new TimeSeriesExpression("avg($value)"));
            var fahrenheitVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature * 1.8 + 32"),
                new TimeSeriesExpression("avg($value)"));

            var celsiusVariableName = "TemperatureInCelsius";
            var fahrenheitVariableName = "TemperatureInFahrenheit";
            var variables = new Dictionary<string, TimeSeriesVariable>
            {
                { celsiusVariableName, celsiusVariable },
                { fahrenheitVariableName, fahrenheitVariable }
            };

            timeSeriesTypes.Add(new TimeSeriesType("TemperatureSensor", variables) { Id = "TemperatureSensorTypeId" });

            Response<TimeSeriesTypeOperationResult[]> createTypesResult = await typesClient
                .CreateOrReplaceAsync(timeSeriesTypes)
                .ConfigureAwait(false);

            if (createTypesResult.Value.First().Error != null)
            {
                Console.WriteLine($"\n\nFailed to create a Time Series Insights type. " +
                    $"Error Message: '{createTypesResult.Value.First().Error.Message}.' " +
                    $"Code: '{createTypesResult.Value.First().Error.Code}'.");
            }

            // Get the Time Series instance and replace its type with the one we just created
            Response<InstancesOperationResult[]> getInstanceResult = await instancesClient
                .GetByIdAsync(new List<TimeSeriesId> { tsId });
            if (getInstanceResult.Value.First().Error != null)
            {
                Console.WriteLine($"\n\nFailed to retrieve Time Series instance with Id '{tsId}'. " +
                    $"Error Message: '{getInstanceResult.Value.First().Error.Message}.' " +
                    $"Code: '{getInstanceResult.Value.First().Error.Code}'.");
            }

            TimeSeriesInstance instanceToReplace = getInstanceResult.Value.First().Instance;
            instanceToReplace.TimeSeriesTypeId = createTypesResult.Value.First().TimeSeriesType.Id;
            Response<InstancesOperationResult[]> replaceInstanceResult = await instancesClient
                .ReplaceAsync(new List<TimeSeriesInstance> { instanceToReplace });
            if (replaceInstanceResult.Value.First().Error != null)
            {
                Console.WriteLine($"\n\nFailed to retrieve Time Series instance with Id '{tsId}'. " +
                    $"Error Message: '{replaceInstanceResult.Value.First().Error.Message}.' " +
                    $"Code: '{replaceInstanceResult.Value.First().Error.Code}'.");
            }

            // Now that we set up the instance with the property type, query for the data
            #region Snippet:TimeSeriesInsightsSampleQuerySeries
            Console.WriteLine($"\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes. " +
                $"The Time Series instance belongs to a type that has predefined numeric variable that represents the temperature " +
                $"in Celsuis, and a predefined numeric variable that represents the temperature in Fahrenheit.\n");

            DateTimeOffset endTime = DateTime.UtcNow;
            DateTimeOffset startTime = endTime.AddMinutes(-10);
            TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
                tsId,
                startTime,
                endTime);

            await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
            {
                double? tempInCelsius = point.GetNullableDouble(celsiusVariableName);
                double? tempInFahrenheit = point.GetNullableDouble(fahrenheitVariableName);

                Console.WriteLine($"{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. " +
                    $"Average temperature in Fahrenheit: {tempInFahrenheit}.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQuerySeries
        }

        private async Task RunQuerySeriesSampleWithInlineVariables(TimeSeriesInsightsQueries queriesClient, TimeSeriesId tsId)
        {
            // Query for two series, one with the temperature values in Celsius and another in Fahrenheit
            #region Snippet:TimeSeriesInsightsSampleQuerySeriesWithInlineVariables
            Console.WriteLine("\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes.\n");

            var celsiusVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature"),
                new TimeSeriesExpression("avg($value)"));
            var fahrenheitVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature * 1.8 + 32"),
                new TimeSeriesExpression("avg($value)"));

            var querySeriesRequestOptions = new QuerySeriesRequestOptions();
            querySeriesRequestOptions.InlineVariables["TemperatureInCelsius"] = celsiusVariable;
            querySeriesRequestOptions.InlineVariables["TemperatureInFahrenheit"] = fahrenheitVariable;

            TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
                tsId,
                TimeSpan.FromMinutes(10),
                null,
                querySeriesRequestOptions);

            await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
            {
                double? tempInCelsius = (double?)point.GetValue("TemperatureInCelsius");
                double? tempInFahrenheit = (double?)point.GetValue("TemperatureInFahrenheit");

                Console.WriteLine($"{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. Average temperature in Fahrenheit: {tempInFahrenheit}.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQuerySeriesWithInlineVariables
        }

        private async Task RunQueryAggregateSeriesSample(TimeSeriesInsightsQueries queriesClient, TimeSeriesId tsId)
        {
            #region Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithNumericVariable
            Console.WriteLine("\n\nQuery for the average temperature over the past 30 seconds, in 2-second time slots.\n");

            var numericVariable = new NumericVariable(
                new TimeSeriesExpression("$event.Temperature"),
                new TimeSeriesExpression("avg($value)"));

            var requestOptions = new QueryAggregateSeriesRequestOptions();
            requestOptions.InlineVariables["Temperature"] = numericVariable;
            requestOptions.ProjectedVariableNames.Add("Temperature");

            TimeSeriesQueryAnalyzer aggregateSeriesQuery = queriesClient.CreateAggregateSeriesQuery(
                tsId,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(30),
                null,
                requestOptions);

            await foreach (TimeSeriesPoint point in aggregateSeriesQuery.GetResultsAsync())
            {
                double? averageTemperature = point.GetNullableDouble("Temperature");
                if (averageTemperature != null)
                {
                    Console.WriteLine($"{point.Timestamp} - Average temperature: {averageTemperature}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithNumericVariable

            #region Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable
            Console.WriteLine("\n\nCount the number of temperature events over the past 3 minutes, in 1-minute time slots.\n");

            // Get the count of events in 60-second time slots over the past 3 minutes
            DateTimeOffset endTime = DateTime.UtcNow;
            DateTimeOffset startTime = endTime.AddMinutes(-3);

            var aggregateVariable = new AggregateVariable(
                new TimeSeriesExpression("count()"));

            var countVariableName = "Count";

            var aggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
            aggregateSeriesRequestOptions.InlineVariables[countVariableName] = aggregateVariable;
            aggregateSeriesRequestOptions.ProjectedVariableNames.Add(countVariableName);

            TimeSeriesQueryAnalyzer query = queriesClient.CreateAggregateSeriesQuery(
                tsId,
                startTime,
                endTime,
                TimeSpan.FromSeconds(60),
                aggregateSeriesRequestOptions);

            await foreach (TimeSeriesPoint point in query.GetResultsAsync())
            {
                long? temperatureCount = (long?)point.GetValue(countVariableName);
                Console.WriteLine($"{point.Timestamp} - Temperature count: {temperatureCount}");
            }
            #endregion Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable
        }
    }
}
