// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Selects the scope of time series in which an anomaly must be to be included in an alert. In
    /// order to instantiate an object of this class, one of the following static methods must be used:
    /// <list type="bullet">
    ///   <item><see cref="CreateScopeForWholeSeries"/></item>
    ///   <item><see cref="CreateScopeForSeriesGroup"/></item>
    ///   <item><see cref="CreateScopeForTopNGroup"/></item>
    /// </list>
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
        /// Defines the set of time series included in this scope. If all possible dimensions are set, the
        /// key uniquely identifies a single time series for the corresponding metric. If only a subset of
        /// dimensions are set, the key uniquely identifies a group of time series.
        /// </summary>
        /// <remarks>
        /// This property is only set when <see cref="ScopeType"/> is <see cref="MetricAnomalyAlertScopeType.SeriesGroup"/>.
        /// </remarks>
        public DimensionKey SeriesGroupInScope { get; }

        /// <summary>
        /// Defines the top N series included in this scope.
        /// </summary>
        /// <remarks>
        /// This property is only set when <see cref="ScopeType"/> is <see cref="MetricAnomalyAlertScopeType.TopN"/>.
        /// </remarks>
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
        /// <param name="seriesGroupKey">
        /// Defines the set of time series included in this scope. If all possible dimensions are set, the
        /// key uniquely identifies a single time series for the corresponding metric. If only a subset of
        /// dimensions are set, the key uniquely identifies a group of time series.
        /// </param>
        /// <returns>A new <see cref="MetricAnomalyAlertScope"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="seriesGroupKey"/> is null.</exception>
        public static MetricAnomalyAlertScope CreateScopeForSeriesGroup(DimensionKey seriesGroupKey)
        {
            Argument.AssertNotNull(seriesGroupKey, nameof(seriesGroupKey));

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.SeriesGroup, seriesGroupKey, topNGroupInScope: default);
        }

        /// <summary>
        /// Creates a <see cref="MetricAnomalyAlertScope"/> instance that has the top N series group as the scope. For a better
        /// definition of what this series group is, see <see cref="TopNGroupScope"/>.
        /// </summary>
        /// <param name="top">The value of N in the top N series group.</param>
        /// <param name="period">The number of latest ingestion timestamps to consider when determining the top N series group.</param>
        /// <param name="minimumTopCount">
        /// The number of times a time series must be ranked among the highest series to be considered part of the top N series
        /// group. This value must be less than or equal to <paramref name="period"/>.
        /// </param>
        /// <returns>A new <see cref="MetricAnomalyAlertScope"/> instance.</returns>
        public static MetricAnomalyAlertScope CreateScopeForTopNGroup(int top, int period, int minimumTopCount)
        {
            var topNGroup = new TopNGroupScope(top, period, minimumTopCount);

            return new MetricAnomalyAlertScope(MetricAnomalyAlertScopeType.TopN, seriesGroupInScope: default, topNGroup);
        }
    }
}
