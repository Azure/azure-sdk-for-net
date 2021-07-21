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
    public class GetAnomaliesForDetectionConfigurationFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAnomaliesForDetectionConfigurationFilter"/> class.
        /// </summary>
        public GetAnomaliesForDetectionConfigurationFilter()
        {
            SeriesGroupKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAnomaliesForDetectionConfigurationFilter"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity level an anomaly must have to be returned.</param>
        /// <param name="maximumSeverity">The maximum severity level an anomaly must have to be returned.</param>
        public GetAnomaliesForDetectionConfigurationFilter(AnomalySeverity minimumSeverity, AnomalySeverity maximumSeverity)
        {
            MinimumSeverity = minimumSeverity;
            MaximumSeverity = maximumSeverity;
            SeriesGroupKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Filters the result by series. Only anomalies detected in the time series groups specified will
        /// be returned.
        /// </summary>
        public IList<DimensionKey> SeriesGroupKeys { get; }

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

            foreach (DimensionKey dimensionKey in SeriesGroupKeys)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
