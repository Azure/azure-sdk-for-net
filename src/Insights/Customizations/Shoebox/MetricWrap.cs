//
// Copyright (c) Microsoft.  All rights reserved.
//

using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// For internal use of ShoeboxClient. It group together InstanceMetrics and GlobalMetrics. At the end of GetMetric calls
    /// ShoeboxClient evealuates which one needs to be used, and puts it inside the metric.
    /// </summary>
    internal class MetricWrap
    {
        public Metric Metric { get; set; }
        public List<MetricValue> InstanceMetrics { get; set; }
        public List<DynamicTableEntity> GlobalMetrics { get; set; }
    }
}
