//
// Copyright (c) Microsoft.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Metric retriever for delivering proxy metrics by calling RP via REST
    /// ProxyMetricRetriever supports dimensions (if the RP supports them)
    /// </summary>
    internal class ProxyMetricRetriever : IMetricRetriever
    {
        private readonly MetricOperations metricOperations;

        public ProxyMetricRetriever(MetricOperations operations)
        {
            this.metricOperations = operations;
        }

        public Task<MetricListResponse> GetMetricsAsync(string resourceId, string filterString, IEnumerable<MetricDefinition> definitions, string invocationId)
        {
            ShoeboxHelper.EncodeUriSegments(resourceId);
            return this.metricOperations.GetMetricsInternalAsync(resourceId, filterString, CancellationToken.None);
        }
    }
}
