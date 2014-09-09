using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    public static partial class MetricOperationsExtensions
    {

        /// <summary>
        /// Non-async version returns the MetricListResponse straight (consistent with overload for get metrics by name functions)
        /// </summary>
        /// <param name="operations">Reference to IMetricOperations</param>
        /// <param name="resourceUri">Resource Uri for the metrics</param>
        /// <param name="filterString">OData filter string (no name specifitations allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <returns>The requested Metrics</returns>
        public static MetricListResponse GetMetrics(this IMetricOperations operations, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            try
            {
                return operations.GetMetricsAsync(resourceUri, filterString, definitions).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }

        /// <summary>
        /// Overload for get metrics by definitions that does not require cancellation token (consistent with overload for get metrics by name functions)
        /// </summary>
        /// <param name="operations">Reference to IMetricOperations</param>
        /// <param name="resourceUri">Resource Uri for the metrics</param>
        /// <param name="filterString">OData filter string (no name specifitations allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <returns>The requested Metrics</returns>
        public static Task<MetricListResponse> GetMetricsAsync(this IMetricOperations operations, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            return operations.GetMetricsAsync(resourceUri, filterString, definitions, CancellationToken.None);
        }
    }
}
