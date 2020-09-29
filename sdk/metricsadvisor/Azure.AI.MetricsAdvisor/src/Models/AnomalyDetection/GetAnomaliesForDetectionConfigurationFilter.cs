// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetAnomaliesForDetectionConfigurationFilter
    {
        private IList<DimensionKey> _seriesKeys;

        /// <summary>
        /// </summary>
        public GetAnomaliesForDetectionConfigurationFilter()
        {
            SeriesKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// </summary>
        public GetAnomaliesForDetectionConfigurationFilter(AnomalySeverity minimumSeverity, AnomalySeverity maximumSeverity)
        {
            MinimumSeverity = minimumSeverity;
            MaximumSeverity = maximumSeverity;
            SeriesKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// </summary>
        public IList<DimensionKey> SeriesKeys
        {
            get => _seriesKeys;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesKeys));
                _seriesKeys = value;
            }
        }

        /// <summary>
        /// </summary>
        public AnomalySeverity? MinimumSeverity { get; }

        /// <summary>
        /// </summary>
        public AnomalySeverity? MaximumSeverity { get; }

        internal DetectionAnomalyFilterCondition GetDetectionAnomalyFilterCondition()
        {
            DetectionAnomalyFilterCondition filterCondition = new DetectionAnomalyFilterCondition();

            if (MinimumSeverity.HasValue)
            {
                filterCondition.SeverityFilter = new SeverityFilterCondition(MinimumSeverity.Value, MaximumSeverity.Value);
            }

            foreach (DimensionKey dimensionKey in SeriesKeys)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
