# Time Series Insights

## POST /timeseries/query
Executes Time Series Query in pages of results.

### Events

Retrieve raw events for a given Time Series Id and search span.

Examples: https://github.com/Azure/azure-rest-api-specs/tree/master/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/examples

Tsx Expressions: https://docs.microsoft.com/rest/api/time-series-insights/reference-time-series-expression-syntax


```csharp
/// <summary>
/// Retrieve raw events for a given Time Series Id asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
/// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
/// <param name="options">Optional parameters to use when querying for events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
public virtual AsyncPageable<QueryResultPage> QueryEventsAsync(
    TimeSeriesId timeSeriesId,
    DateTimeOffset startTime,
    DateTimeOffset endTime,
    QueryEventsRequestOptions options = null,
    CancellationToken cancellationToken = default);

/// <summary>
/// Retrieve raw events for a given Time Series Id over a specified timespan asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="timeSpan">The timespan over which to query data.</param>
/// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
/// <param name="options">Optional parameters to use when querying for events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
public virtual AsyncPageable<QueryResultPage> QueryEventsAsync(
    TimeSeriesId timeSeriesId,
    TimeSpan timeSpan,
    DateTimeOffset endTime = DateTimeOffset.UtcNow, 
    QueryEventsRequestOptions options = null,
    CancellationToken cancellationToken = default);

/// <summary>
/// Retrieve event series for a given Time Series Id asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
/// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
/// <param name="options">Optional parameters to use when querying for series events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
public virtual AsyncPageable<QueryResultPage> QuerySeriesAsync(
    TimeSeriesId timeSeriesId,
    DateTimeOffset startTime,
    DateTimeOffset endTime,
    QuerySeriesRequestOptions options = null,
    CancellationToken cancellationToken = default);

/// <summary>
/// Retrieve event series for a given Time Series Id over a certain timespan asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="timeSpan">The timespan over which to query data.</param>
/// <param name="options">Optional parameters to use when querying for series events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
public virtual AsyncPageable<QueryResultPage> QuerySeriesAsync(
    TimeSeriesId timeSeriesId,
    TimeSpan timeSpan,
    DateTimeOffset endTime = DateTimeOffset.UtcNow, 
    QuerySeriesRequestOptions options = null,
    CancellationToken cancellationToken = default);

/// <summary>
/// Retrieve aggregate event series for a given Time Series Id asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="startTime">Start timestamp of the time range. Events that have this timestamp are included.</param>
/// <param name="endTime">End timestamp of the time range. Events that match this timestamp are excluded.</param>
/// <param name="options">Optional parameters to use when querying for aggregate series events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
public virtual AsyncPageable<QueryResultPage> QueryAggregateSeriesAsync(
    TimeSeriesId timeseriesId,
    DateTimeOffset startTime,
    DateTimeOffset endTime,
    QueryAggregateSeriesRequestOptions options = null,
    CancellationToken cancellationToken = default);

/// <summary>
/// Retrieve aggregate event series for a given Time Series Id over a certain timespan asynchronously.
/// </summary>
/// <param name="timeSeriesId">The Time Series Id to retrieve raw events for.</param>
/// <param name="timeSpan">The timespan over which to query data.</param>
/// <param name="options">Optional parameters to use when querying for aggregate series events.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{QueryResultPage}"/> of query result frames.</returns>
public virtual AsyncPageable<QueryResultPage> QueryAggregateSeriesAsync(
    TimeSeriesId timeseriesId,
    TimeSpan timeSpan,
    DateTimeOffset endTime = DateTimeOffset.UtcNow, 
    QueryAggregateSeriesRequestOptions options = null,
    CancellationToken cancellationToken = default);
```

```csharp
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights.
    /// </summary>
    public abstract class QueryRequestOptions
    {
        /// <summary>
        /// For the environments with warm store enabled, the query can be executed either on the 'WarmStore' or 'ColdStore'.
        /// This parameter in the query defines which store the query should be executed on. If not defined, the query
        /// will be executed on the cold store.
        /// </summary>
        public StoreType? StoreType { get; set; }

        /// <summary>
        /// A Time series expression (TSX) filter written as a single string.
        /// Refer to the documentation on how to write time series expressions.
        /// </summary>
        /// <remarks>
        /// For filter examples, check out the TSX documentation
        /// <see href="https://docs.microsoft.com/rest/api/time-series-insights/reference-time-series-expression-syntax">here.</see>.
        /// </remarks>
        public string Filter { get; set; }

        /// <summary>
        /// The maximum number of property values in the whole response set, not the maximum number of property values per page. Defaults to 10,000 when not set. Maximum value of take can be 250,000.
        /// </summary>
        public int? MaximumNumberOfEvents { get; set; }
    }

    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights events.
    /// </summary>
    public class QueryEventsRequestOptions : QueryRequestOptions
    {
        /// <summary>
        /// An array of properties to be returned in the response. These properties must appear
        /// in the events; otherwise, they are not returned.
        /// </summary>
        public EventProperty[] ProjectedProperties { get; set; }
    }

    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights series.
    /// </summary>
    public class QuerySeriesRequestOptions : QueryRequestOptions
    {
        /// <summary>
        /// Selected variables that needs to be projected in the query result. When it is null or not set, all the
        /// variables and Time Series types in the model are returned.
        /// </summary>
        public string[] ProjectedVariables { get; set; }

        /// <summary>
        /// Optional inline variables apart from the ones already defined in the Time Series type in the model.
        /// When the inline variable name is the same name as in the model, the inline variable definition takes precedence.
        /// </summary>
        public IDictionary<string, TimeSeriesVariable> InlineVariables { get; set; }
    }
    
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights aggregate series.
    /// </summary>
    public class QueryAggregateSeriesRequestOptions : QuerySeriesRequestOptions
    {
        /// <summary>
        /// Interval size is specified in ISO-8601 duration format. All intervals are the same size.
        /// </summary>
        /// <remarks>
        /// One month is always converted to 30 days, and one year is always 365 days.
        /// Examples: 1 minute is "PT1M", 1 millisecond is "PT0.001S".
        /// For more information, see <see href="https://www.w3.org/TR/xmlschema-2/#duration">duration</see>.
        /// </remarks>
        public string Interval { get; set; }
    }
```
