// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("DimensionGroupConfiguration")]
    public partial class MetricSeriesGroupAnomalyDetectionConditions : MetricAnomalyDetectionConditions
    {
        /// <summary>
        /// </summary>
        public MetricSeriesGroupAnomalyDetectionConditions(DimensionKey seriesGroupKey)
        {
            Argument.AssertNotNull(seriesGroupKey, nameof(seriesGroupKey));

            SeriesGroupKey = seriesGroupKey;
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("Group")]
        public DimensionKey SeriesGroupKey { get; }
    }
}
