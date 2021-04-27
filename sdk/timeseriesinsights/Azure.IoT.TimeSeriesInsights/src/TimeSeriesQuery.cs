// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Query client that can be used to query for events, series and aggregate series on Time Series Insights.
    /// </summary>
    public class TimeSeriesQuery
    {
        private readonly QueryRestClient _queryRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of TimeSeriesQuery. This constructor should only be used for mocking purposes.
        /// </summary>
        protected TimeSeriesQuery()
        {
        }

        internal TimeSeriesQuery(QueryRestClient queryRestClient, ClientDiagnostics clientDiagnostics)
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateEventsQueryAnalyzer(
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

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateEventsQueryAnalyzer(
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

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateSeriesQueryAnalyzer(
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

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateSeriesQueryAnalyzer(
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

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateAggregateSeriesQueryAnalyzer(
            TimeSeriesId timeSeriesId,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            TimeSpan interval,
            QueryAggregateSeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateAggregateSeriesQueryAnalyzer)}");
            scope.Start();

            try
            {
                var searchSpan = new DateTimeRange(startTime, endTime);
                var queryRequest = new QueryRequest
                {
                    AggregateSeries = new AggregateSeries(timeSeriesId, searchSpan, interval)
                };

                BuildAggregateSeriesRequestOptions(options, queryRequest);

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
        /// <returns>The <see cref="QueryAnalyzer"/> object that can be used to retrieve the pageable list <see cref="AsyncPageable{TimeSeriesPoint}"/>.</returns>
        public virtual QueryAnalyzer CreateAggregateSeriesQueryAnalyzer(
            TimeSeriesId timeSeriesId,
            TimeSpan interval,
            TimeSpan timeSpan,
            DateTimeOffset? endTime = null,
            QueryAggregateSeriesRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(CreateAggregateSeriesQueryAnalyzer)}");
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

                return new QueryAnalyzer(_queryRestClient, queryRequest, options?.StoreType?.ToString(), cancellationToken);
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
                    queryRequest.GetEvents.Filter = new TimeSeriesExpression(options.Filter);
                }

                if (options.ProjectedProperties != null)
                {
                    foreach (EventProperty projectedProperty in options.ProjectedProperties)
                    {
                        queryRequest.GetEvents.ProjectedProperties.Add(projectedProperty);
                    }
                }

                queryRequest.GetEvents.Take = options.MaximumNumberOfEvents;
            }
        }

        private static void BuildSeriesRequestOptions(QuerySeriesRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.GetSeries.Filter = new TimeSeriesExpression(options.Filter);
                }

                if (options.ProjectedVariables != null)
                {
                    foreach (string projectedVariable in options.ProjectedVariables)
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

                queryRequest.GetSeries.Take = options.MaximumNumberOfEvents;
            }
        }

        private static void BuildAggregateSeriesRequestOptions(QueryAggregateSeriesRequestOptions options, QueryRequest queryRequest)
        {
            if (options != null)
            {
                if (options.Filter != null)
                {
                    queryRequest.AggregateSeries.Filter = new TimeSeriesExpression(options.Filter);
                }

                if (options.ProjectedVariables != null)
                {
                    foreach (string projectedVariable in options.ProjectedVariables)
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
