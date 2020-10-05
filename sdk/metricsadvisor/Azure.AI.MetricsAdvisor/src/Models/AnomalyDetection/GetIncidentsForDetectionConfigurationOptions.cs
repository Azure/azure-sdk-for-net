// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetIncidentsForDetectionConfiguration"/>
    /// or <see cref="MetricsAdvisorClient.GetIncidentsForDetectionConfigurationAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetIncidentsForDetectionConfigurationOptions
    {
        private IList<DimensionKey> _seriesGroupKeys;

        /// <summary>
        /// Creates a new instance of the <see cref="GetIncidentsForDetectionConfigurationOptions"/> class.
        /// </summary>
        /// <param name="startTime">Filters the result. Only incidents detected after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only incidents detected before this point in time, in UTC, will be returned.</param>
        public GetIncidentsForDetectionConfigurationOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            SeriesGroupKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Filters the result. Only incidents detected after this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Filters the result. Only incidents detected before this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// Filters the result by series. Only incidents detected in the time series groups specified will
        /// be returned.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="SeriesGroupKeys"/> is null.</exception>
        public IList<DimensionKey> SeriesGroupKeys
        {
            get => _seriesGroupKeys;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesGroupKeys));
                _seriesGroupKeys = value;
            }
        }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        internal int? SkipCount { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned by each service call. Note: all items will
        /// returned, even if more service calls are required.
        /// </summary>
        public int? TopCount { get; set; }

        internal DetectionIncidentFilterCondition GetDetectionIncidentFilterCondition()
        {
            DetectionIncidentFilterCondition filterCondition = new DetectionIncidentFilterCondition();

            foreach (DimensionKey dimensionKey in SeriesGroupKeys)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
