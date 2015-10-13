//
// Copyright (c) Microsoft.  All rights reserved.
//

using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Metric retriever for getting metrics in "shoebox" storage accounts using provided SAS keys
    /// ShoeboxMetricRetriever ignores dimensions
    /// </summary>
    /// TODO: Refactor shoebox client to inherit table operations and diminsions support from SasMetricRetriever
    internal class ShoeboxMetricRetriever : SasMetricRetriever
    {
        internal override async Task<MetricListResponse> GetMetricsInternalAsync(MetricFilter filter, MetricLocation location, string invocationId)
        {
            return await ShoeboxClient.GetMetricsInternalAsync(filter, location, invocationId);
        }
    }
}
