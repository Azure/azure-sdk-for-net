// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Uniquely defines a time series within a <see cref="DataFeed"/>.
    /// </summary>
    [CodeGenModel("MetricSeriesItem")]
    public partial class MetricSeriesDefinition
    {
        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> associated with this
        /// time series.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// The key that, within a metric, uniquely identifies a time series. Every dimension
        /// contained in the associated <see cref="DataFeed"/> has been assigned a value.
        /// </summary>
        public DimensionKey SeriesKey { get; private set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        private IReadOnlyDictionary<string, string> Dimension
        {
            set => SeriesKey = new DimensionKey(value);
        }
    }
}
