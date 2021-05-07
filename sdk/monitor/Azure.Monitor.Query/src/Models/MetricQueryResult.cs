// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("Response")]
    public partial class MetricQueryResult
    {
        /// <summary> Metrics returned as the result of the query. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyList<Metric> Metrics { get; }
    }
}