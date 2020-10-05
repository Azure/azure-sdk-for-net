// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetValuesOfDimensionWithAnomalies"/>
    /// or <see cref="MetricsAdvisorClient.GetValuesOfDimensionWithAnomaliesAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetValuesOfDimensionWithAnomaliesOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GetValuesOfDimensionWithAnomaliesOptions"/> class.
        /// </summary>
        /// <param name="startTime">Filters the result. Only dimension values for anomalies created after this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only dimension values for anomalies created before this point in time, in UTC, will be returned.</param>
        public GetValuesOfDimensionWithAnomaliesOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created after this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created before this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// Filters the result by series. Only anomalies detected in the time series group specified will
        /// be returned.
        /// </summary>
        public DimensionKey DimensionFilter { get; set; }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned by each service call. Note: all items will
        /// returned, even if more service calls are required.
        /// </summary>
        public int? TopCount { get; set; }
    }
}
