//
// Copyright (c) Microsoft.  All rights reserved.
//

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// EmptyMetricRetriever always returns a metric for every definition passed in. These metrics will have an empty list of MetricValues
    /// EmptyMetricRetriever ignores dimensions
    /// </summary>
    internal class EmptyMetricRetriever : IMetricRetriever
    {
        private static readonly EmptyMetricRetriever _instance = new EmptyMetricRetriever();

        private EmptyMetricRetriever()
        {
        }

        public static EmptyMetricRetriever Instance
        {
            get { return _instance; }
        }

        public Task<MetricListResponse> GetMetricsAsync(string resourceId, string filterString, IEnumerable<MetricDefinition> definitions, string invocationId)
        {
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            return Task.Factory.StartNew(() => new MetricListResponse()
            {
                RequestId = invocationId,
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = definitions == null ? new List<Metric>() : definitions.Select(d => new Metric()
                    {
                        Name = d.Name,
                        Unit = d.Unit,
                        ResourceId = resourceId,
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        TimeGrain = filter.TimeGrain,
                        MetricValues = new List<MetricValue>(),
                        Properties = new Dictionary<string, string>()
                    }).ToList()
                }
            });
        }
    }
}
