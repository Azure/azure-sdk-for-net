// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetIncidentsForDetectionConfigurationOptions
    {
        private IList<DimensionKey> _dimensionToFilter;

        /// <summary>
        /// </summary>
        public GetIncidentsForDetectionConfigurationOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            DimensionToFilter = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// </summary>
        public IList<DimensionKey> DimensionToFilter
        {
            get => _dimensionToFilter;
            set
            {
                Argument.AssertNotNull(value, nameof(DimensionToFilter));
                _dimensionToFilter = value;
            }
        }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }

        internal DetectionIncidentFilterCondition GetDetectionIncidentFilterCondition()
        {
            DetectionIncidentFilterCondition filterCondition = new DetectionIncidentFilterCondition();

            foreach (DimensionKey dimensionKey in DimensionToFilter)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
