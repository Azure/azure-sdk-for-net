using Microsoft.Azure.ApplicationInsights.Query.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights.Query
{
    public partial class MetricsExtensions
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static MetricsSummaryResult GetMetricSummary(this IMetrics operations, string appId, string metricId, string timespan = default(string),
            IList<string> aggregation = default(IList<string>), int? top = default(int?),
            string orderby = default(string), string filter = default(string))
        {
            return operations.GetMetricSummaryAsync(appId, metricId, timespan, aggregation, top, orderby, filter).GetAwaiter().GetResult();
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static async Task<MetricsSummaryResult> GetMetricSummaryAsync(this IMetrics operations, string appId, string metricId, string timespan = default(string),
            IList<string> aggregation = default(IList<string>), int? top = default(int?),
            string orderby = default(string), string filter = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetMetricSummaryWithHttpMessagesAsync(appId, metricId, timespan, aggregation, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static MetricsIntervaledResult GetIntervaledMetric(this IMetrics operations, string appId,
            string metricId, string timespan = default(string), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string))
        {
            return operations
                .GetIntervaledMetricAsync(appId, metricId, timespan, interval, aggregation, segment, top, orderby, filter)
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static async Task<MetricsIntervaledResult> GetIntervaledMetricAsync(this IMetrics operations, string appId,
            string metricId, string timespan = default(string), System.TimeSpan? interval = default(System.TimeSpan?),
            IList<string> aggregation = default(IList<string>), IList<string> segment = default(IList<string>),
            int? top = default(int?), string orderby = default(string), string filter = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetIntervaledMetricWithHttpMessagesAsync(appId, metricId, timespan, interval, aggregation, segment, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static MetricsSegmentedResult GetSegmentedMetric(this IMetrics operations, string appId,
            string metricId, string timespan = default(string), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string))
        {
            return operations.GetSegmentedMetricAsync(appId, metricId, timespan, aggregation, segment, top, orderby, filter)
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
        public static async Task<MetricsSegmentedResult> GetSegmentedMetricAsync(this IMetrics operations, string appId,
            string metricId, string timespan = default(string), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetSegmentedMetricWithHttpMessagesAsync(appId, metricId, timespan, aggregation,
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
            this IMetrics operations, string appId, string metricId, string timespan = default(string),
            System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string))
        {
            return operations
                .GetIntervaledSegmentedMetricAsync(appId, metricId, timespan, interval, aggregation, segment, top, orderby,
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
        /// <param name='appId'>
        /// ID of the application. This is Application ID from the API Access settings
        /// blade in the Azure portal.
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
            this IMetrics operations, string appId, string metricId, string timespan = default(string),
            System.TimeSpan? interval = default(System.TimeSpan?), IList<string> aggregation = default(IList<string>),
            IList<string> segment = default(IList<string>), int? top = default(int?), string orderby = default(string),
            string filter = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var result = await operations.GetIntervaledSegmentedMetricWithHttpMessagesAsync(appId, metricId, timespan,
                interval, aggregation, segment, top, orderby, filter, null, cancellationToken).ConfigureAwait(false))
            {
                return result.Body;
            }
        }

        #endregion
    }
}