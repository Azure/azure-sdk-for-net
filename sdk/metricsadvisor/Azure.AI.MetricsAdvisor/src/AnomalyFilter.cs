// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Filters the result of the <see cref="MetricsAdvisorClient.GetAnomaliesForDetectionConfiguration(string, GetAnomaliesForDetectionConfigurationOptions, CancellationToken)"/> and
    /// <see cref="MetricsAdvisorClient.GetAnomaliesForDetectionConfigurationAsync(string, GetAnomaliesForDetectionConfigurationOptions, CancellationToken)"/> operations.
    /// </summary>
    public class AnomalyFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyFilter"/> class.
        /// </summary>
        public AnomalyFilter()
        {
            DimensionKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyFilter"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity level an anomaly must have to be returned.</param>
        /// <param name="maximumSeverity">The maximum severity level an anomaly must have to be returned.</param>
        public AnomalyFilter(AnomalySeverity minimumSeverity, AnomalySeverity maximumSeverity)
        {
            MinimumSeverity = minimumSeverity;
            MaximumSeverity = maximumSeverity;
            DimensionKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Filters the result by time series. Each element in this list represents a set of time series, and only
        /// anomalies detected in at least one of these sets will be returned. For each element, if all possible
        /// dimensions are set, the key uniquely identifies a single time series for the corresponding metric. If
        /// only a subset of dimensions are set, the key uniquely identifies a group of time series.
        /// </summary>
        public IList<DimensionKey> DimensionKeys { get; }

        /// <summary>
        /// The minimum severity level an anomaly must have to be returned.
        /// </summary>
        public AnomalySeverity? MinimumSeverity { get; }

        /// <summary>
        /// The maximum severity level an anomaly must have to be returned.
        /// </summary>
        public AnomalySeverity? MaximumSeverity { get; }

        internal DetectionAnomalyFilterCondition GetDetectionAnomalyFilterCondition()
        {
            DetectionAnomalyFilterCondition filterCondition = new DetectionAnomalyFilterCondition();

            if (MinimumSeverity.HasValue)
            {
                filterCondition.SeverityFilter = new SeverityFilterCondition(MinimumSeverity.Value, MaximumSeverity.Value);
            }

            foreach (DimensionKey dimensionKey in DimensionKeys)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
