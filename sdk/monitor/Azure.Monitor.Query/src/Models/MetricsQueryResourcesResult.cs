// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("MetricResultsResponse")]
    public partial class MetricsQueryResourcesResult
    {
        /// <summary> The collection of metric data responses per resource, per metric. </summary>
        public IReadOnlyList<MetricsQueryResult> Values { get; }
    }
}
