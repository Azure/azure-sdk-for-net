// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> The MetricsBatchResultValues. </summary>
    [CodeGenModel("MetricResultsResponseValuesItem")]
    public partial class MetricsBatchResultValues
    {
        /// <summary> The start time, in datetime format, for which the data was retrieved. </summary>
        [CodeGenMember("Starttime")]
        public DateTimeOffset StartTime { get; }

        /// <summary> The end time, in datetime format, for which the data was retrieved. </summary>
        [CodeGenMember("Endtime")]
        public DateTimeOffset EndTime { get; }

        /// <summary> The resource that has been queried for metrics. </summary>
        [CodeGenMember("Resourceid")]
        public ResourceIdentifier ResourceId { get; }

        /// <summary> The region of the resource been queried for metrics. </summary>
        [CodeGenMember("Resourceregion")]
        public AzureLocation ResourceRegion { get; }

        /// <summary> The value of the collection. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyList<MetricResult> Metrics { get; }
    }
}
