using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    public partial interface IMetricOperations
    {
        /// <summary>
        /// Get Metrics function that takes in the MetricDefinitions (rather than names in the filter string) to allow users to cache the definitions themselves
        /// </summary>
        /// <param name="resourceUri">The Resource Uri for the metrics</param>
        /// <param name="filterString">The filter string (no name specification allowed in this one)</param>
        /// <param name="definitions">The MetricDefinitions</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions, CancellationToken cancellationToken);
    }
}
