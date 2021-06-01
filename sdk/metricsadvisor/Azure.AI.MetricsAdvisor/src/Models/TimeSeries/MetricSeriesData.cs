// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Contains details about the data ingested by a time series. To make plotting easier, this data is
    /// scattered across different lists, such as <see cref="Timestamps"/> and <see cref="Values"/>. A
    /// data point is represented by the same index across these lists.
    /// </summary>
    [CodeGenModel("MetricDataItem")]
    public partial class MetricSeriesData
    {
        /// <summary>
        /// Uniquely defines a time series within a <see cref="DataFeed"/>.
        /// </summary>
        [CodeGenMember("Id")]
        public MetricSeriesDefinition Definition { get; }

        /// <summary>
        /// The timestamps, in UTC, of the data points present in this time series.
        /// </summary>
        [CodeGenMember("TimestampList")]
        public IReadOnlyList<DateTimeOffset> Timestamps { get; }

        /// <summary>
        /// The values of the data points present in this time series.
        /// </summary>
        [CodeGenMember("ValueList")]
        public IReadOnlyList<double> Values { get; }
    }
}
