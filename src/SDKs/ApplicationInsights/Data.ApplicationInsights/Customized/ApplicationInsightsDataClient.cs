using Microsoft.Azure.ApplicationInsights.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights
{
    public partial class ApplicationInsightsDataClient : ServiceClient<ApplicationInsightsDataClient>, IApplicationInsightsDataClient
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationInsightsDataClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public ApplicationInsightsDataClient(ServiceClientCredentials credentials) : this(credentials, (DelegatingHandler[])null)
        {
        }

        partial void CustomInitialize()
        {
            var firstHandler = this.FirstMessageHandler as DelegatingHandler;
            if (firstHandler == null) return;

            var customHandler = new CustomDelegatingHandler
            {
                InnerHandler = firstHandler.InnerHandler,
                Client = this,
            };

            firstHandler.InnerHandler = customHandler;
        }

        public IList<string> AdditionalApplications { get; set; } = new List<string>();

        public ApiPreferences Preferences { get; set; } = new ApiPreferences();

        public string NameHeader { get; set; }

        public string RequestId { get; set; }

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
        public async Task<HttpOperationResponse<MetricsSummaryResult>> GetMetricSummaryWithHttpMessagesAsync(string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string), Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetMetricWithHttpMessagesAsync(metricId, timespan, null, aggregation, null, top, orderby, filter, customHeaders, cancellationToken);
            var realBody = realResult.Body.Value;
            return new HttpOperationResponse<MetricsSummaryResult>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new MetricsSummaryResult
                {
                    Start = realBody.Start,
                    End = realBody.End,
                    Sum = realBody.GetSum(),
                    Average = realBody.GetAverage(),
                    Min = realBody.GetMin(),
                    Max = realBody.GetMax(),
                    Count = realBody.GetCount()
                }
            };
        }

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
        public async Task<HttpOperationResponse<MetricsIntervaledResult>> GetIntervaledMetricWithHttpMessagesAsync(string metricId,
            System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetMetricWithHttpMessagesAsync(metricId, timespan, interval, aggregation, null, top, orderby, filter, customHeaders, cancellationToken);
            var realBody = realResult.Body.Value;
            return new HttpOperationResponse<MetricsIntervaledResult>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new MetricsIntervaledResult
                {
                    Start = realBody.Start,
                    End = realBody.End,
                    Interval = realBody.Interval,
                    Intervals = realBody.Segments?.Select(inter =>
                        new MetricsIntervaledData
                        {
                            Sum = inter.GetSum(),
                            Average = inter.GetAverage(),
                            Min = inter.GetMin(),
                            Max = inter.GetMax(),
                            Count = inter.GetCount()
                        }
                    ).ToList()
                }
            };
        }

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
        public async Task<HttpOperationResponse<MetricsSegmentedResult>> GetSegmentedMetricWithHttpMessagesAsync(string metricId,
            System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string), Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetMetricWithHttpMessagesAsync(metricId, timespan, null, aggregation, segment, top, orderby, filter, customHeaders, cancellationToken);
            var realBody = realResult.Body.Value;
            return new HttpOperationResponse<MetricsSegmentedResult>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new MetricsSegmentedResult
                {
                    Start = realBody.Start,
                    End = realBody.End,
                    Segments= GetSegmentInfo(realBody.Segments),
                }
            };
        }

        private static IList<IMetricsBaseSegmentInfo> GetSegmentInfo(IList<MetricsSegmentInfo> segments)
        {
            return segments?.Select(seg =>
            {
                IMetricsBaseSegmentInfo result;
                if (seg.Segments != null && seg.Segments.Count != 0)
                {
                    result = new MetricsNestedSegment()
                    {
                        SegmentId = seg.SegmentId,
                        SegmentValue = seg.SegmentValue,
                        Segments = GetSegmentInfo(seg.Segments),
                    };
                }
                else
                {
                    result = new MetricsSegmentedData
                    {
                        SegmentId = seg.SegmentId,
                        SegmentValue = seg.SegmentValue,
                        Sum = seg.GetSum(),
                        Average = seg.GetAverage(),
                        Min = seg.GetMin(),
                        Max = seg.GetMax(),
                        Count = seg.GetCount()
                    };
                }

                return result;
            }).ToList();
        }

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
        public async Task<HttpOperationResponse<MetricsIntervaledSegmentedResult>> GetIntervaledSegmentedMetricWithHttpMessagesAsync(string metricId,
            System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetMetricWithHttpMessagesAsync(metricId, timespan, interval, aggregation, segment, top, orderby, filter, customHeaders, cancellationToken);
            var realBody = realResult.Body.Value;
            return new HttpOperationResponse<MetricsIntervaledSegmentedResult>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new MetricsIntervaledSegmentedResult
                {
                    Start = realBody.Start,
                    End = realBody.End,
                    Interval = realBody.Interval,
                    Intervals = realBody.Segments?.Select(inter =>
                        new MetricsSegmentedIntervalData
                        {
                            Start = inter.Start,
                            End = inter.End,
                            Segments = GetSegmentInfo(inter.Segments),
                        }
                    ).ToList()
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventsWithHttpMessagesAsync(
            System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string),
            string orderby = default(string), string select = default(string), int? skip = default(int?),
            int? top = default(int?), string format = default(string), bool? count = default(bool?),
            string apply = default(string), Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.Traces, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsTraceResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsTraceResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsTraceResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsTraceResult>>> GetTraceEventWithHttpMessagesAsync(
            System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.Traces, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsTraceResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsTraceResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsTraceResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>>
            GetCustomEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.CustomEvents, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsCustomEventResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsCustomEventResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsCustomEventResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsCustomEventResult>>>
            GetCustomEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.CustomEvents, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsCustomEventResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsCustomEventResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsCustomEventResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>>
            GetPageViewEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.PageViews, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsPageViewResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsPageViewResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsPageViewResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsPageViewResult>>>
            GetPageViewEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.PageViews, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsPageViewResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsPageViewResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsPageViewResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>>
            GetBrowserTimingEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.BrowserTimings, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsBrowserTimingResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsBrowserTimingResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>>
            GetBrowserTimingEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.BrowserTimings, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsBrowserTimingResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsBrowserTimingResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsBrowserTimingResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsRequestResult>>>
            GetRequestEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.Requests, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsRequestResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsRequestResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsRequestResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsRequestResult>>>
            GetRequestEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.Requests, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsRequestResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsRequestResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsRequestResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>>
            GetDependencyEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.Dependencies, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsDependencyResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsDependencyResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsDependencyResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsDependencyResult>>>
            GetDependencyEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.Dependencies, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsDependencyResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsDependencyResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsDependencyResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>>
            GetExceptionEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string),
                string search = default(string), string orderby = default(string), string select = default(string),
                int? skip = default(int?), int? top = default(int?), string format = default(string),
                bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.Exceptions, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsExceptionResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsExceptionResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsExceptionResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsExceptionResult>>>
            GetExceptionEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.Exceptions, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsExceptionResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsExceptionResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsExceptionResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>>
            GetAvailabilityResultEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.AvailabilityResults, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsAvailabilityResultResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsAvailabilityResultResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>>
            GetAvailabilityResultEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.AvailabilityResults, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsAvailabilityResultResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsAvailabilityResultResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsAvailabilityResultResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>>
            GetPerformanceCounterEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.PerformanceCounters, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsPerformanceCounterResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsPerformanceCounterResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>>
            GetPerformanceCounterEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.PerformanceCounters, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsPerformanceCounterResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsPerformanceCounterResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsPerformanceCounterResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>>
            GetCustomMetricEventsWithHttpMessagesAsync(System.TimeSpan? timespan = default(System.TimeSpan?),
                string filter = default(string), string search = default(string), string orderby = default(string),
                string select = default(string), int? skip = default(int?), int? top = default(int?),
                string format = default(string), bool? count = default(bool?), string apply = default(string),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventsWithHttpMessagesAsync(EventType.CustomMetrics, timespan, filter, search, orderby, select,
                skip, top, format, count, apply, customHeaders, cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsCustomMetricResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsCustomMetricResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsCustomMetricResult>().ToList(),
                }
            };
        }

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
        public async Task<HttpOperationResponse<EventsResults<EventsCustomMetricResult>>>
            GetCustomMetricEventWithHttpMessagesAsync(System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
                Dictionary<string, List<string>> customHeaders = null,
                CancellationToken cancellationToken = default(CancellationToken))
        {
            var realResult = await GetEventWithHttpMessagesAsync(EventType.CustomMetrics, eventId, timespan, customHeaders,
                cancellationToken);
            var realBody = realResult.Body;
            return new HttpOperationResponse<EventsResults<EventsCustomMetricResult>>
            {
                Request = realResult.Request,
                Response = realResult.Response,
                Body = new EventsResults<EventsCustomMetricResult>
                {
                    Aimessages = realBody.Aimessages,
                    Value = realBody.Value.OfType<EventsCustomMetricResult>().ToList(),
                }
            };
        }

        #endregion
    }
}
