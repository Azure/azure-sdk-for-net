using Microsoft.Azure.ApplicationInsights.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights
{
    public static partial class ApplicationInsightsDataClientExtensions
    {
        #region Metric Extensions

        /// <summary>
        /// Retrieve summary metric data
        /// </summary>
        /// <remarks>
        /// Gets summary metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static MetricsSummaryResult GetMetricSummary(this IApplicationInsightsDataClient operations, string metricId, System.TimeSpan? timespan = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), int? top = default(int?),
            string orderby = default(string), string filter = default(string))
        {
            return operations.GetMetricSummaryAsync(metricId, timespan, aggregation, top, orderby, filter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve summary metric data
        /// </summary>
        /// <remarks>
        /// Gets summary metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<MetricsSummaryResult> GetMetricSummaryAsync(this IApplicationInsightsDataClient operations, string metricId, System.TimeSpan? timespan = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), int? top = default(int?),
            string orderby = default(string), string filter = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetMetricSummaryWithHttpMessagesAsync(metricId, timespan, aggregation, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static MetricsIntervaledResult GetIntervaledMetric(this IApplicationInsightsDataClient operations,
            string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string))
        {
            return operations
                .GetIntervaledMetricAsync(metricId, timespan, interval, aggregation, segment, top, orderby, filter)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<MetricsIntervaledResult> GetIntervaledMetricAsync(this IApplicationInsightsDataClient operations,
            string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetIntervaledMetricWithHttpMessagesAsync(metricId, timespan, interval, aggregation, segment, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static MetricsSegmentedResult GetSegmentedMetric(this IApplicationInsightsDataClient operations,
            string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string))
        {
            return operations.GetSegmentedMetricAsync(metricId, timespan, aggregation, segment, top, orderby, filter)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<MetricsSegmentedResult> GetSegmentedMetricAsync(this IApplicationInsightsDataClient operations,
            string metricId, System.TimeSpan? timespan = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetSegmentedMetricWithHttpMessagesAsync(metricId, timespan, aggregation,
                segment, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static MetricsIntervaledSegmentedResult GetIntervaledSegmentedMetric(
            this IApplicationInsightsDataClient operations, string metricId, System.TimeSpan? timespan = default(System.TimeSpan?),
            System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string))
        {
            return operations
                .GetIntervaledSegmentedMetricAsync(metricId, timespan, interval, aggregation, segment, top, orderby,
                    filter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieve metric data
        /// </summary>
        /// <remarks>
        /// Gets metric values for a single metric
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<MetricsIntervaledSegmentedResult> GetIntervaledSegmentedMetricAsync(
            this IApplicationInsightsDataClient operations, string metricId, System.TimeSpan? timespan = default(System.TimeSpan?),
            System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetIntervaledSegmentedMetricWithHttpMessagesAsync(metricId, timespan,
                interval, aggregation, segment, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        #endregion

        #region Event Extensions

        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsTraceResult> GetTraceEvents(this IApplicationInsightsDataClient operations,
            System.TimeSpan? timespan = default(System.TimeSpan?), string filter = default(string), string search = default(string),
            string orderby = default(string), string select = default(string), int? skip = default(int?),
            int? top = default(int?), string format = default(string), bool? count = default(bool?),
            string apply = default(string))
        {
            return operations
                .GetTraceEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for trace events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for trace events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsTraceResult>> GetTraceEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetTraceEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsTraceResult> GetTraceEvent(this IApplicationInsightsDataClient operations,
            System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetTraceEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a trace event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single trace event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsTraceResult>> GetTraceEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetTraceEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomEventResult> GetCustomEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetCustomEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for custom events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomEventResult>> GetCustomEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsCustomEventResult> GetCustomEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetCustomEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a custom event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomEventResult>> GetCustomEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPageViewResult> GetPageViewEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetPageViewEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for page view events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for page view events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPageViewResult>> GetPageViewEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPageViewEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsPageViewResult> GetPageViewEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetPageViewEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a page view event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single page view event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPageViewResult>> GetPageViewEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPageViewEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsBrowserTimingResult> GetBrowserTimingEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetBrowserTimingEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for browser timing events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for browser timing events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsBrowserTimingResult>> GetBrowserTimingEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetBrowserTimingEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsBrowserTimingResult> GetBrowserTimingEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetBrowserTimingEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a browser timing event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single browser timing event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsBrowserTimingResult>> GetBrowserTimingEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetBrowserTimingEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsRequestResult> GetRequestEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetRequestEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for request events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for request events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsRequestResult>> GetRequestEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetRequestEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsRequestResult> GetRequestEvent(this IApplicationInsightsDataClient operations,
            System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetRequestEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a request event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single request event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsRequestResult>> GetRequestEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetRequestEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsDependencyResult> GetDependencyEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetDependencyEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for dependency events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for dependency events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsDependencyResult>> GetDependencyEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetDependencyEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsDependencyResult> GetDependencyEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetDependencyEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a dependency event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single dependency event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsDependencyResult>> GetDependencyEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetDependencyEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsExceptionResult> GetExceptionEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetExceptionEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for exception events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for exception events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsExceptionResult>> GetExceptionEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetExceptionEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsExceptionResult> GetExceptionEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetExceptionEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an exception event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single exception event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsExceptionResult>> GetExceptionEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetExceptionEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsAvailabilityResultResult> GetAvailabilityResultEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetAvailabilityResultEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for availability result events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for availability result events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsAvailabilityResultResult>> GetAvailabilityResultEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetAvailabilityResultEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsAvailabilityResultResult> GetAvailabilityResultEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetAvailabilityResultEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get an availability result event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single availability result event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsAvailabilityResultResult>> GetAvailabilityResultEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetAvailabilityResultEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsPerformanceCounterResult> GetPerformanceCounterEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetPerformanceCounterEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for performance counter events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for performance counter events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPerformanceCounterResult>> GetPerformanceCounterEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPerformanceCounterEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsPerformanceCounterResult> GetPerformanceCounterEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetPerformanceCounterEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a performance counter event
        /// </summary>
        /// <remarks>
        /// Gets the data for a single performance counter event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsPerformanceCounterResult>> GetPerformanceCounterEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetPerformanceCounterEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        public static EventsResults<EventsCustomMetricResult> GetCustomMetricEvents(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string))
        {
            return operations
                .GetCustomMetricEventsAsync(timespan, filter, search, orderby, select, skip, top, format, count, apply)
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// Execute OData query for custom metric events
        /// </summary>
        /// <remarks>
        /// Executes an OData query for custom metric events
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomMetricResult>> GetCustomMetricEventsAsync(
            this IApplicationInsightsDataClient operations, System.TimeSpan? timespan = default(System.TimeSpan?),
            string filter = default(string), string search = default(string), string orderby = default(string),
            string select = default(string), int? skip = default(int?), int? top = default(int?),
            string format = default(string), bool? count = default(bool?), string apply = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomMetricEventsWithHttpMessagesAsync(timespan, filter, search, orderby,
                select, skip, top, format, count, apply, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        public static EventsResults<EventsCustomMetricResult> GetCustomMetricEvent(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?))
        {
            return operations.GetCustomMetricEventAsync(eventId, timespan).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a custom metricevent
        /// </summary>
        /// <remarks>
        /// Gets the data for a single custom metric event
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='eventId'>
        /// ID of event.
        /// </param>
        /// <param name='timespan'>
        /// Optional. The timespan over which to retrieve events. This is an
        /// ISO8601 time period value.  This timespan is applied in addition to
        /// any that are specified in the Odata expression.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EventsResults<EventsCustomMetricResult>> GetCustomMetricEventAsync(
            this IApplicationInsightsDataClient operations, System.Guid eventId, System.TimeSpan? timespan = default(System.TimeSpan?),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetCustomMetricEventWithHttpMessagesAsync(eventId, timespan, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        #endregion
    }
}
