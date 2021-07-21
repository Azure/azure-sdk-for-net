// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Contains details about the data ingested by a time series. To make plotting easier, this data is
    /// scattered across different lists, such as <see cref="Timestamps"/> and <see cref="MetricValues"/>. A
    /// data point is represented by the same index across these lists.
    /// </summary>
    [CodeGenModel("MetricDataItem")]
    public partial class MetricSeriesData
    {
        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> associated with this
        /// time series.
        /// </summary>
        public string MetricId => Definition.MetricId;

        /// <summary>
        /// The key that, within a metric, uniquely identifies a time series. Every dimension
        /// contained in the associated <see cref="DataFeed"/> has been assigned a value.
        /// </summary>
        public DimensionKey SeriesKey => Definition.SeriesKey;

        /// <summary>
        /// The timestamps, in UTC, of the data points present in this time series.
        /// </summary>
        [CodeGenMember("TimestampList")]
        public IReadOnlyList<DateTimeOffset> Timestamps { get; }

        /// <summary>
        /// The values of the data points present in this time series.
        /// </summary>
        [CodeGenMember("ValueList")]
        public IReadOnlyList<double> MetricValues { get; }

        /// <summary>
        /// Uniquely defines a time series within a <see cref="DataFeed"/>.
        /// </summary>
        [CodeGenMember("Id")]
        internal MetricSeriesDefinition Definition { get; }
    }
}
