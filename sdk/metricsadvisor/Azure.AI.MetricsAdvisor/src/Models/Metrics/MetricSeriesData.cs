// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("MetricDataItem")]
    public partial class MetricSeriesData
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("Id")]
        public MetricSeriesDefinition Definition { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("TimestampList")]
        public IReadOnlyList<DateTimeOffset> Timestamps { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("ValueList")]
        public IReadOnlyList<double> Values { get; }
    }
}
