using Microsoft.Azure.ApplicationInsights.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Azure.ApplicationInsights
{
    public partial interface IApplicationInsightsDataClient
    {
        /// <summary>
        /// Additional apps referenced in cross-resource queries.
        /// </summary>
        IList<string> AdditionalApplications { get; set; }

        ApiPreferences Preferences { get; set; }

        /// <summary>
        /// Unique name for the calling application. This is only used for telemetry and debugging.
        /// </summary>
        string NameHeader { get; set; }

        /// <summary>
        /// A unique ID per request. This will be generated per request if not specified.
        /// </summary>
        string RequestId { get; set; }

        #region Metric Extensions

        /// <summary>
        /// Retrieve summary metric data
        /// </summary>
        /// <remarks>
        /// Gets summary metric values for a single metric
        /// </remarks>
        /// <param name='metricId'>
        /// ID of the metric. This is either a standard AI metric, or an
        /// application-specific custom metric. Possible values include:
        /// 'requests/count', 'requests/duration', 'requests/failed',
        /// 'users/count', 'users/authenticated', 'pageViews/count',
        /// 'pageViews/duration', 'client/processingDuration',
        /// 'client/receiveDuration', 'client/networkDuration',
        /// 'client/sendDuration', 'client/totalDuration',
        /// 'dependencies/count', 'dependencies/failed',
        /// 'dependencies/duration', 'exceptions/count', 'exceptions/browser',
        /// 'exceptions/server', 'sessions/count',
        /// 'performanceCounters/requestExecutionTime',
        /// 'performanceCounters/requestsPerSecond',
        /// 'performanceCounters/requestsInQueue',
        /// 'performanceCounters/memoryAvailableBytes',
        /// 'performanceCounters/exceptionsPerSecond',
        /// 'performanceCounters/processCpuPercentage',
        /// 'performanceCounters/processIOBytesPerSecond',
        /// 'performanceCounters/processPrivateBytes',
        /// 'performanceCounters/processorCpuPercentage',
        /// 'availabilityResults/availabilityPercentage',
        /// 'availabilityResults/duration', 'billing/telemetryCount',
        /// 'customEvents/count'
        /// </param>
        /// <param name='timespan'>
        /// The timespan over which to retrieve metric values. This is an
        /// ISO8601 time period value. If timespan is omitted, a default time
        /// range of `PT12H` ("last 12 hours") is used. The actual timespan
        /// that is queried may be adjusted by the server based. In all cases,
        /// the actual time span used for the query is included in the
        /// response.
        /// </param>
        /// <param name='aggregation'>
        /// The aggregation to use when computing the metric values. To
        /// retrieve more than one aggregation at a time, separate them with a
        /// comma. If no aggregation is specified, then the default aggregation
        /// for the metric is used.
        /// </param>
        /// <param name='top'>
        /// The number of segments to return.  This value is only valid when
        /// segment is specified.
        /// </param>
        /// <param name='orderby'>
        /// The aggregation function and direction to sort the segments by.
        /// This value is only valid when segment is specified.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the results.  This value should be a
        /// valid OData filter expression where the keys of each clause should
        /// be applicable dimensions for the metric you are retrieving.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<MetricsSummaryResult>> GetMetricSummaryWithHttpMessagesAsync(string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>), int? top = default(int?), string orderby = default(string), string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='metricId'>
        /// ID of the metric. This is either a standard AI metric, or an
        /// application-specific custom metric. Possible values include:
        /// 'requests/count', 'requests/duration', 'requests/failed',
        /// 'users/count', 'users/authenticated', 'pageViews/count',
        /// 'pageViews/duration', 'client/processingDuration',
        /// 'client/receiveDuration', 'client/networkDuration',
        /// 'client/sendDuration', 'client/totalDuration',
        /// 'dependencies/count', 'dependencies/failed',
        /// 'dependencies/duration', 'exceptions/count', 'exceptions/browser',
        /// 'exceptions/server', 'sessions/count',
        /// 'performanceCounters/requestExecutionTime',
        /// 'performanceCounters/requestsPerSecond',
        /// 'performanceCounters/requestsInQueue',
        /// 'performanceCounters/memoryAvailableBytes',
        /// 'performanceCounters/exceptionsPerSecond',
        /// 'performanceCounters/processCpuPercentage',
        /// 'performanceCounters/processIOBytesPerSecond',
        /// 'performanceCounters/processPrivateBytes',
        /// 'performanceCounters/processorCpuPercentage',
        /// 'availabilityResults/availabilityPercentage',
        /// 'availabilityResults/duration', 'billing/telemetryCount',
        /// 'customEvents/count'
        /// </param>
        /// <param name='timespan'>
        /// The timespan over which to retrieve metric values. This is an
        /// ISO8601 time period value. If timespan is omitted, a default time
        /// range of `PT12H` ("last 12 hours") is used. The actual timespan
        /// that is queried may be adjusted by the server based. In all cases,
        /// the actual time span used for the query is included in the
        /// response.
        /// </param>
        /// <param name='interval'>
        /// The time interval to use when retrieving metric values. This is an
        /// ISO8601 duration. If interval is omitted, the metric value is
        /// aggregated across the entire timespan. If interval is supplied, the
        /// server may adjust the interval to a more appropriate size based on
        /// the timespan used for the query. In all cases, the actual interval
        /// used for the query is included in the response.
        /// </param>
        /// <param name='aggregation'>
        /// The aggregation to use when computing the metric values. To
        /// retrieve more than one aggregation at a time, separate them with a
        /// comma. If no aggregation is specified, then the default aggregation
        /// for the metric is used.
        /// </param>
        /// <param name='segment'>
        /// The name of the dimension to segment the metric values by. This
        /// dimension must be applicable to the metric you are retrieving. To
        /// segment by more than one dimension at a time, separate them with a
        /// comma (,). In this case, the metric data will be segmented in the
        /// order the dimensions are listed in the parameter.
        /// </param>
        /// <param name='top'>
        /// The number of segments to return.  This value is only valid when
        /// segment is specified.
        /// </param>
        /// <param name='orderby'>
        /// The aggregation function and direction to sort the segments by.
        /// This value is only valid when segment is specified.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the results.  This value should be a
        /// valid OData filter expression where the keys of each clause should
        /// be applicable dimensions for the metric you are retrieving.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<MetricsIntervaledResult>> GetIntervaledMetricWithHttpMessagesAsync(string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string), string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='metricId'>
        /// ID of the metric. This is either a standard AI metric, or an
        /// application-specific custom metric. Possible values include:
        /// 'requests/count', 'requests/duration', 'requests/failed',
        /// 'users/count', 'users/authenticated', 'pageViews/count',
        /// 'pageViews/duration', 'client/processingDuration',
        /// 'client/receiveDuration', 'client/networkDuration',
        /// 'client/sendDuration', 'client/totalDuration',
        /// 'dependencies/count', 'dependencies/failed',
        /// 'dependencies/duration', 'exceptions/count', 'exceptions/browser',
        /// 'exceptions/server', 'sessions/count',
        /// 'performanceCounters/requestExecutionTime',
        /// 'performanceCounters/requestsPerSecond',
        /// 'performanceCounters/requestsInQueue',
        /// 'performanceCounters/memoryAvailableBytes',
        /// 'performanceCounters/exceptionsPerSecond',
        /// 'performanceCounters/processCpuPercentage',
        /// 'performanceCounters/processIOBytesPerSecond',
        /// 'performanceCounters/processPrivateBytes',
        /// 'performanceCounters/processorCpuPercentage',
        /// 'availabilityResults/availabilityPercentage',
        /// 'availabilityResults/duration', 'billing/telemetryCount',
        /// 'customEvents/count'
        /// </param>
        /// <param name='timespan'>
        /// The timespan over which to retrieve metric values. This is an
        /// ISO8601 time period value. If timespan is omitted, a default time
        /// range of `PT12H` ("last 12 hours") is used. The actual timespan
        /// that is queried may be adjusted by the server based. In all cases,
        /// the actual time span used for the query is included in the
        /// response.
        /// </param>
        /// <param name='aggregation'>
        /// The aggregation to use when computing the metric values. To
        /// retrieve more than one aggregation at a time, separate them with a
        /// comma. If no aggregation is specified, then the default aggregation
        /// for the metric is used.
        /// </param>
        /// <param name='segment'>
        /// The name of the dimension to segment the metric values by. This
        /// dimension must be applicable to the metric you are retrieving. To
        /// segment by more than one dimension at a time, separate them with a
        /// comma (,). In this case, the metric data will be segmented in the
        /// order the dimensions are listed in the parameter.
        /// </param>
        /// <param name='top'>
        /// The number of segments to return.  This value is only valid when
        /// segment is specified.
        /// </param>
        /// <param name='orderby'>
        /// The aggregation function and direction to sort the segments by.
        /// This value is only valid when segment is specified.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the results.  This value should be a
        /// valid OData filter expression where the keys of each clause should
        /// be applicable dimensions for the metric you are retrieving.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<MetricsSegmentedResult>> GetSegmentedMetricWithHttpMessagesAsync(string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string), string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='metricId'>
        /// ID of the metric. This is either a standard AI metric, or an
        /// application-specific custom metric. Possible values include:
        /// 'requests/count', 'requests/duration', 'requests/failed',
        /// 'users/count', 'users/authenticated', 'pageViews/count',
        /// 'pageViews/duration', 'client/processingDuration',
        /// 'client/receiveDuration', 'client/networkDuration',
        /// 'client/sendDuration', 'client/totalDuration',
        /// 'dependencies/count', 'dependencies/failed',
        /// 'dependencies/duration', 'exceptions/count', 'exceptions/browser',
        /// 'exceptions/server', 'sessions/count',
        /// 'performanceCounters/requestExecutionTime',
        /// 'performanceCounters/requestsPerSecond',
        /// 'performanceCounters/requestsInQueue',
        /// 'performanceCounters/memoryAvailableBytes',
        /// 'performanceCounters/exceptionsPerSecond',
        /// 'performanceCounters/processCpuPercentage',
        /// 'performanceCounters/processIOBytesPerSecond',
        /// 'performanceCounters/processPrivateBytes',
        /// 'performanceCounters/processorCpuPercentage',
        /// 'availabilityResults/availabilityPercentage',
        /// 'availabilityResults/duration', 'billing/telemetryCount',
        /// 'customEvents/count'
        /// </param>
        /// <param name='timespan'>
        /// The timespan over which to retrieve metric values. This is an
        /// ISO8601 time period value. If timespan is omitted, a default time
        /// range of `PT12H` ("last 12 hours") is used. The actual timespan
        /// that is queried may be adjusted by the server based. In all cases,
        /// the actual time span used for the query is included in the
        /// response.
        /// </param>
        /// <param name='interval'>
        /// The time interval to use when retrieving metric values. This is an
        /// ISO8601 duration. If interval is omitted, the metric value is
        /// aggregated across the entire timespan. If interval is supplied, the
        /// server may adjust the interval to a more appropriate size based on
        /// the timespan used for the query. In all cases, the actual interval
        /// used for the query is included in the response.
        /// </param>
        /// <param name='aggregation'>
        /// The aggregation to use when computing the metric values. To
        /// retrieve more than one aggregation at a time, separate them with a
        /// comma. If no aggregation is specified, then the default aggregation
        /// for the metric is used.
        /// </param>
        /// <param name='segment'>
        /// The name of the dimension to segment the metric values by. This
        /// dimension must be applicable to the metric you are retrieving. To
        /// segment by more than one dimension at a time, separate them with a
        /// comma (,). In this case, the metric data will be segmented in the
        /// order the dimensions are listed in the parameter.
        /// </param>
        /// <param name='top'>
        /// The number of segments to return.  This value is only valid when
        /// segment is specified.
        /// </param>
        /// <param name='orderby'>
        /// The aggregation function and direction to sort the segments by.
        /// This value is only valid when segment is specified.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the results.  This value should be a
        /// valid OData filter expression where the keys of each clause should
        /// be applicable dimensions for the metric you are retrieving.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<MetricsIntervaledSegmentedResult>> GetIntervaledSegmentedMetricWithHttpMessagesAsync(string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string), string filter = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        #endregion

        #region Event Extensions

        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>> GetCustomEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>> GetCustomEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>> GetPageViewEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>> GetPageViewEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>> GetBrowserTimingEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>> GetBrowserTimingEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsRequestResult>>> GetRequestEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsRequestResult>>> GetRequestEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>> GetDependencyEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>> GetDependencyEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>> GetExceptionEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>> GetExceptionEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>> GetAvailabilityResultEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>> GetAvailabilityResultEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>> GetPerformanceCounterEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>> GetPerformanceCounterEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='filter'>
        /// An expression used to filter the returned events
        /// </param>
        /// <param name='search'>
        /// A free-text search expression to match for whether a particular
        /// event should be returned
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of properties with \"asc\" (the default) or
        /// \"desc\" to control the order of returned events
        /// </param>
        /// <param name='select'>
        /// Limits the properties to just those requested on each returned
        /// event
        /// </param>
        /// <param name='skip'>
        /// The number of items to skip over before returning events
        /// </param>
        /// <param name='top'>
        /// The number of events to return
        /// </param>
        /// <param name='format'>
        /// Format for the returned events
        /// </param>
        /// <param name='count'>
        /// Request a count of matching items included with the returned events
        /// </param>
        /// <param name='apply'>
        /// An expression used for aggregation over returned events
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>> GetCustomMetricEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string), string orderby = default(string), string select = default(string), int? skip = default(int?), int? top = default(int?), string format = default(string), bool? count = default(bool?), string apply = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>> GetCustomMetricEventWithHttpMessagesAsync(string eventId, System.TimeSpan? timespan = default(System.TimeSpan?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
