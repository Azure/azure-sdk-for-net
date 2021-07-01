// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Selects which set of time series should trigger alerts in a <see cref="MetricAlertConfiguration"/>. It
    /// must be instantiated by one of its static methods.
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
        /// The type of scope.
        /// </summary>
        public MetricAnomalyAlertScopeType ScopeType { get; }

        /// <summary>
        /// Alerts will only be triggered for anomalies in specific dimensions of the series group.
        /// The number of specified dimensions should be smaller than the total number dimensions.
        /// This property is set when <see cref="ScopeType"/> is <see cref="MetricAnomalyAlertScopeType.SeriesGroup"/>.
        /// </summary>
        public DimensionKey SeriesGroupInScope { get; }

        /// <summary>
        /// Alerts will only be triggered for anomalies in the top N series.
        /// Specify the number of timestamps to take into account, and how many anomalies must be in them to send the alert.
        /// This property is set when <see cref="ScopeType"/> is <see cref="MetricAnomalyAlertScopeType.TopN"/>.
        /// </summary>
        public TopNGroupScope TopNGroupInScope { get; }

        /// <summary>
        /// Creates a <see cref="MetricAnomalyAlertScope"/> instance that has all time series within the associated
        /// metric as the scope.
        /// </summary>
        /// <returns>A new <see cref="MetricAnomalyAlertScope"/> instance.</returns>
        public static MetricAnomalyAlertScope CreateScopeForWholeSeries() =>
            new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.WholeSeries, seriesGroupInScope: default, topNGroupInScope: default);

        /// <summary>
        /// Creates a <see cref="MetricAnomalyAlertScope"/> instance that has a fixed group of time series as the scope.
        /// </summary>
        /// <param name="seriesGroupKey">The key that identifies the group of fixed time series that constitutes the scope.
        /// A subset of the possible dimensions of the associated data feed must be set.</param>
        /// <returns>A new <see cref="MetricAnomalyAlertScope"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="seriesGroupKey"/> is null.</exception>
        public static MetricAnomalyAlertScope CreateScopeForSeriesGroup(DimensionKey seriesGroupKey)
        {
            Argument.AssertNotNull(seriesGroupKey, nameof(seriesGroupKey));

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.SeriesGroup, seriesGroupKey, topNGroupInScope: default);
        }

        /// <summary>
        /// Creates a <see cref="MetricAnomalyAlertScope"/> instance in which alerts will only be triggered for anomalies in the top N series.
        /// </summary>
        /// <param name="top">The number of timestamps to take into account when choosing the top N series.</param>
        /// <param name="period">The number of items a period contains.</param>
        /// <param name="minimumTopCount">The number of anomalies that must be in the specified <paramref name="top"/> number of timestamps to send an alert.</param>
        /// <returns>A new <see cref="MetricAnomalyAlertScope"/> instance.</returns>
        public static MetricAnomalyAlertScope CreateScopeForTopNGroup(int top, int period, int minimumTopCount)
        {
            var topNGroup = new TopNGroupScope(top, period, minimumTopCount);

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.TopN, seriesGroupInScope: default, topNGroup);
        }
    }
}
