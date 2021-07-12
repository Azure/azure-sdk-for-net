// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("Response")]
    public partial class MetricQueryResult
    {
        [CodeGenMember("Timespan")]
        private readonly string _timespan;

        /// <summary> Metrics returned as the result of the query. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyList<Metric> Metrics { get; }

        /// <summary>
        /// The timespan for which the data was retrieved.
        /// This may be adjusted in the future and returned back from what was originally requested.
        /// </summary>
        public DateTimeRange TimeSpan => DateTimeRange.Parse(_timespan);

        /// <summary> The region of the resource being queried for metrics. </summary>
        [CodeGenMember("Resourceregion")]
        public string ResourceRegion { get; }
    }
}
