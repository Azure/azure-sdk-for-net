// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class MetricAnomalyAlertScope
    {
        internal MetricAnomalyAlertScope(MetricAnomalyAlertScopeType scopeType, DimensionKey seriesGroupInScope, TopNGroupScope topNGroupInScope)
        {
            ScopeType = scopeType;
            SeriesGroupInScope = seriesGroupInScope;
            TopNGroupInScope = topNGroupInScope;
        }

        /// <summary>
        /// </summary>
        public MetricAnomalyAlertScopeType ScopeType { get; }

        /// <summary>
        /// </summary>
        public DimensionKey SeriesGroupInScope { get; }

        /// <summary>
        /// </summary>
        public TopNGroupScope TopNGroupInScope { get; }

        /// <summary>
        /// </summary>
        public static MetricAnomalyAlertScope GetScopeForWholeSeries() =>
            new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.WholeSeries, seriesGroupInScope: default, topNGroupInScope: default);

        /// <summary>
        /// </summary>
        public static MetricAnomalyAlertScope GetScopeForSeriesGroup(DimensionKey seriesGroupKey)
        {
            Argument.AssertNotNull(seriesGroupKey, nameof(seriesGroupKey));

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.SeriesGroup, seriesGroupKey, topNGroupInScope: default);
        }

        /// <summary>
        /// </summary>
        public static MetricAnomalyAlertScope GetScopeForTopNGroup(TopNGroupScope topNGroup)
        {
            Argument.AssertNotNull(topNGroup, nameof(topNGroup));

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.TopN, seriesGroupInScope: default, topNGroup);
        }
    }
}
