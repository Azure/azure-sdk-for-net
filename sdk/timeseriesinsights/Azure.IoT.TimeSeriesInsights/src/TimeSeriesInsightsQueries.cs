// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// A client that can be used to query for events, series and aggregate series on Time Series Insights.
    /// </summary>
    public class TimeSeriesInsightsQueries
    {
        private readonly QueryRestClient _queryRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of TimeSeriesInsightsQueries. This constructor should only be used for mocking purposes.
        /// </summary>
        protected TimeSeriesInsightsQueries()
        {
        }

        internal TimeSeriesInsightsQueries(QueryRestClient queryRestClient, ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(queryRestClient, nameof(queryRestClient));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _queryRestClient = queryRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQueryEvents" language="csharp">
        /// Console.WriteLine(&quot;\n\nQuery for raw temperature events over the past 10 minutes.\n&quot;);
        ///
        /// // Get events from last 10 minute
        /// DateTimeOffset endTime = DateTime.UtcNow;
        /// DateTimeOffset startTime = endTime.AddMinutes(-10);
        ///
        /// TimeSeriesQueryAnalyzer temperatureEventsQuery = queriesClient.CreateEventsQuery(tsId, startTime, endTime);
        /// await foreach (TimeSeriesPoint point in temperatureEventsQuery.GetResultsAsync())
        /// {
        ///     TimeSeriesValue temperatureValue = point.GetValue(&quot;Temperature&quot;);
        ///
        ///     // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
        ///     // environment best, you probably do not need this logic and you can skip to directly casting to the proper
        ///     // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
        ///     // too familiar with the property type.
        ///     if (temperatureValue.Type == typeof(double?))
        ///     {
        ///         Console.WriteLine($&quot;{point.Timestamp} - Temperature: {point.GetNullableDouble(&quot;Temperature&quot;)}&quot;);
        ///     }
        ///     else if (temperatureValue.Type == typeof(int?))
        ///     {
        ///         Console.WriteLine($&quot;{point.Timestamp} - Temperature: {point.GetNullableInt(&quot;Temperature&quot;)}&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine(&quot;The type of the Time Series value for Temperature is not numeric.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateEventsQuery(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetEvents)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve raw events for a given Time Series Id over a specified time interval asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan" language="csharp">
        /// Console.WriteLine(&quot;\n\nQuery for raw humidity events over the past 30 seconds.\n&quot;);
        ///
        /// TimeSeriesQueryAnalyzer humidityEventsQuery = queriesClient.CreateEventsQuery(tsId, TimeSpan.FromSeconds(30));
        /// await foreach (TimeSeriesPoint point in humidityEventsQuery.GetResultsAsync())
        /// {
        ///     TimeSeriesValue humidityValue = point.GetValue(&quot;Humidity&quot;);
        ///
        ///     // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
        ///     // environment best, you probably do not need this logic and you can skip to directly casting to the proper
        ///     // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
        ///     // too familiar with the property type.
        ///     if (humidityValue.Type == typeof(double?))
        ///     {
        ///         Console.WriteLine($&quot;{point.Timestamp} - Humidity: {point.GetNullableDouble(&quot;Humidity&quot;)}&quot;);
        ///     }
        ///     else if (humidityValue.Type == typeof(int?))
        ///     {
        ///         Console.WriteLine($&quot;{point.Timestamp} - Humidity: {point.GetNullableInt(&quot;Humidity&quot;)}&quot;);
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine(&quot;The type of the Time Series value for Humidity is not numeric.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateEventsQuery(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QueryEventsRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetEvents)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetEvents = new GetEvents(timeSeriesId, searchSpan)
                };

                BuildEventsRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQuerySeries" language="csharp">
        /// Console.WriteLine($&quot;\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes. &quot; +
        ///     $&quot;The Time Series instance belongs to a type that has predefined numeric variable that represents the temperature &quot; +
        ///     $&quot;in Celsuis, and a predefined numeric variable that represents the temperature in Fahrenheit.\n&quot;);
        ///
        /// DateTimeOffset endTime = DateTime.UtcNow;
        /// DateTimeOffset startTime = endTime.AddMinutes(-10);
        /// TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
        ///     tsId,
        ///     startTime,
        ///     endTime);
        ///
        /// await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
        /// {
        ///     double? tempInCelsius = point.GetNullableDouble(celsiusVariableName);
        ///     double? tempInFahrenheit = point.GetNullableDouble(fahrenheitVariableName);
        ///
        ///     Console.WriteLine($&quot;{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. &quot; +
        ///         $&quot;Average temperature in Fahrenheit: {tempInFahrenheit}.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateSeriesQuery(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSeries)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve series events for a given Time Series Id over a specified time interval asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQuerySeriesWithInlineVariables" language="csharp">
        /// Console.WriteLine(&quot;\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes.\n&quot;);
        ///
        /// var celsiusVariable = new NumericVariable(
        ///     new TimeSeriesExpression(&quot;$event.Temperature&quot;),
        ///     new TimeSeriesExpression(&quot;avg($value)&quot;));
        /// var fahrenheitVariable = new NumericVariable(
        ///     new TimeSeriesExpression(&quot;$event.Temperature * 1.8 + 32&quot;),
        ///     new TimeSeriesExpression(&quot;avg($value)&quot;));
        ///
        /// var querySeriesRequestOptions = new QuerySeriesRequestOptions();
        /// querySeriesRequestOptions.InlineVariables[&quot;TemperatureInCelsius&quot;] = celsiusVariable;
        /// querySeriesRequestOptions.InlineVariables[&quot;TemperatureInFahrenheit&quot;] = fahrenheitVariable;
        ///
        /// TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
        ///     tsId,
        ///     TimeSpan.FromMinutes(10),
        ///     null,
        ///     querySeriesRequestOptions);
        ///
        /// await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
        /// {
        ///     double? tempInCelsius = (double?)point.GetValue(&quot;TemperatureInCelsius&quot;);
        ///     double? tempInFahrenheit = (double?)point.GetValue(&quot;TemperatureInFahrenheit&quot;);
        ///
        ///     Console.WriteLine($&quot;{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. Average temperature in Fahrenheit: {tempInFahrenheit}.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateSeriesQuery(
            TimeSeriesId timeSeriesId,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QuerySeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(GetSeries)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    GetSeries = new GetSeries(timeSeriesId, searchSpan)
                };

                BuildSeriesRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve aggregated time series from events for a given Time Series Id asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
        /// <param name="interval">Interval size used to group events by.</param>
        /// <param name="options">Optional parameters to use when querying for aggregated series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable" language="csharp">
        /// Console.WriteLine(&quot;\n\nCount the number of temperature events over the past 3 minutes, in 1-minute time slots.\n&quot;);
        ///
        /// // Get the count of events in 60-second time slots over the past 3 minutes
        /// DateTimeOffset endTime = DateTime.UtcNow;
        /// DateTimeOffset startTime = endTime.AddMinutes(-3);
        ///
        /// var aggregateVariable = new AggregateVariable(
        ///     new TimeSeriesExpression(&quot;count()&quot;));
        ///
        /// var countVariableName = &quot;Count&quot;;
        ///
        /// var aggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
        /// aggregateSeriesRequestOptions.InlineVariables[countVariableName] = aggregateVariable;
        /// aggregateSeriesRequestOptions.ProjectedVariableNames.Add(countVariableName);
        ///
        /// TimeSeriesQueryAnalyzer query = queriesClient.CreateAggregateSeriesQuery(
        ///     tsId,
        ///     startTime,
        ///     endTime,
        ///     TimeSpan.FromSeconds(60),
        ///     aggregateSeriesRequestOptions);
        ///
        /// await foreach (TimeSeriesPoint point in query.GetResultsAsync())
        /// {
        ///     long? temperatureCount = (long?)point.GetValue(countVariableName);
        ///     Console.WriteLine($&quot;{point.Timestamp} - Temperature count: {temperatureCount}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateAggregateSeriesQuery(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            TimeSpan interval,
            QueryAggregateSeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateAggregateSeriesQuery)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    AggregateSeries = new AggregateSeries(timeSeriesId, searchSpan, interval)
                };

                BuildAggregateSeriesRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve aggregated time series from events for a given Time Series Id over a specified time interval asynchronously.
        /// </summary>
        /// <param name="timeSeriesId">The Time Series Id to retrieve series events for.</param>
        /// <param name="interval">Interval size used to group events by.</param>
        /// <param name="timeSpan">The time interval over which to query data.</param>
        /// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded. If null is provided, <c>DateTimeOffset.UtcNow</c> is used.</param>
        /// <param name="options">Optional parameters to use when querying for aggregated series events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="TimeSeriesQueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithNumericVariable" language="csharp">
        /// Console.WriteLine(&quot;\n\nQuery for the average temperature over the past 30 seconds, in 2-second time slots.\n&quot;);
        ///
        /// var numericVariable = new NumericVariable(
        ///     new TimeSeriesExpression(&quot;$event.Temperature&quot;),
        ///     new TimeSeriesExpression(&quot;avg($value)&quot;));
        ///
        /// var requestOptions = new QueryAggregateSeriesRequestOptions();
        /// requestOptions.InlineVariables[&quot;Temperature&quot;] = numericVariable;
        /// requestOptions.ProjectedVariableNames.Add(&quot;Temperature&quot;);
        ///
        /// TimeSeriesQueryAnalyzer aggregateSeriesQuery = queriesClient.CreateAggregateSeriesQuery(
        ///     tsId,
        ///     TimeSpan.FromSeconds(2),
        ///     TimeSpan.FromSeconds(30),
        ///     null,
        ///     requestOptions);
        ///
        /// await foreach (TimeSeriesPoint point in aggregateSeriesQuery.GetResultsAsync())
        /// {
        ///     double? averageTemperature = point.GetNullableDouble(&quot;Temperature&quot;);
        ///     if (averageTemperature != null)
        ///     {
        ///         Console.WriteLine($&quot;{point.Timestamp} - Average temperature: {averageTemperature}.&quot;);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual TimeSeriesQueryAnalyzer CreateAggregateSeriesQuery(
            TimeSeriesId timeSeriesId,
            TimeSpan interval,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QueryAggregateSeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateAggregateSeriesQuery)}");
            scope.Start();

            try
            {
                DateTimeOffset rangeEndTime = endTime ?? DateTimeOffset.UtcNow;
                DateTimeOffset rangeStartTime = rangeEndTime - timeSpan;
                var searchSpan = new DateTimeRange(rangeStartTime, rangeEndTime);
                var queryRequest = new QueryRequest
                {
                    AggregateSeries = new AggregateSeries(timeSeriesId, searchSpan, interval)
                };

                BuildAggregateSeriesRequestOptions(options, queryRequest);

                return new TimeSeriesQueryAnalyzer(_queryRestClient, queryRequest, options?.Store?.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static void BuildEventsRequestOptions(QueryEventsRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.GetEvents.Filter = options.Filter;
                }

                if (options.ProjectedProperties != null)
                {
                    foreach (TimeSeriesInsightsEventProperty projectedProperty in options.ProjectedProperties)
                    {
                        queryRequest.GetEvents.ProjectedProperties.Add(projectedProperty);
                    }
                }

                queryRequest.GetEvents.Take = options.MaxNumberOfEvents;
            }
        }

        private static void BuildSeriesRequestOptions(QuerySeriesRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.GetSeries.Filter = options.Filter;
                }

                if (options.ProjectedVariableNames != null)
                {
                    foreach (string projectedVariable in options.ProjectedVariableNames)
                    {
                        queryRequest.GetSeries.ProjectedVariables.Add(projectedVariable);
                    }
                }

                if (options.InlineVariables != null)
                {
                    foreach (string inlineVariableKey in options.InlineVariables.Keys)
                    {
                        queryRequest.GetSeries.InlineVariables[inlineVariableKey] = options.InlineVariables[inlineVariableKey];
                    }
                }

                queryRequest.GetSeries.Take = options.MaxNumberOfEvents;
            }
        }

        private static void BuildAggregateSeriesRequestOptions(QueryAggregateSeriesRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.AggregateSeries.Filter = options.Filter;
                }

                if (options.ProjectedVariableNames != null)
                {
                    foreach (string projectedVariable in options.ProjectedVariableNames)
                    {
                        queryRequest.AggregateSeries.ProjectedVariables.Add(projectedVariable);
                    }
                }

                if (options.InlineVariables != null)
                {
                    foreach (string inlineVariableKey in options.InlineVariables.Keys)
                    {
                        queryRequest.AggregateSeries.InlineVariables[inlineVariableKey] = options.InlineVariables[inlineVariableKey];
                    }
                }
            }
        }
    }
}
