// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetValuesOfDimensionWithAnomalies"/>
    /// or <see cref="MetricsAdvisorClient.GetValuesOfDimensionWithAnomaliesAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetValuesOfDimensionWithAnomaliesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetValuesOfDimensionWithAnomaliesOptions"/> class.
        /// </summary>
        /// <param name="startTime">Filters the result. Only dimension values for anomalies created from this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only dimension values for anomalies created up to this point in time, in UTC, will be returned.</param>
        public GetValuesOfDimensionWithAnomaliesOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            DimensionToFilter = new DimensionKey();
        }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// Filters the result by series. Only anomalies detected in the time series group specified will
        /// be returned.
        /// </summary>
        public DimensionKey DimensionToFilter { get; }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned in each page of results. Note:
        /// unless the number of pages enumerated from the service is limited, the service will
        /// return an unlimited number of total items.
        /// </summary>
        public int? TopCount { get; set; }
    }
}
