// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> The MetricResultsResponseValuesItem. </summary>
    public partial class MetricResultsResponseValuesItem
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
        public string ResourceRegion { get; }
    }
}
