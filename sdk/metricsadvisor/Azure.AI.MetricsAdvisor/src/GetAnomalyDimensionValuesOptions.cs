// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetAnomalyDimensionValues"/>
    /// or <see cref="MetricsAdvisorClient.GetAnomalyDimensionValuesAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetAnomalyDimensionValuesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAnomalyDimensionValuesOptions"/> class.
        /// </summary>
        /// <param name="startsOn">Filters the result. Only dimension values for anomalies created from this point in time, in UTC, will be returned.</param>
        /// <param name="endsOn">Filters the result. Only dimension values for anomalies created up to this point in time, in UTC, will be returned.</param>
        public GetAnomalyDimensionValuesOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
        }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// Filters the result. Only dimension values for anomalies created up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndsOn { get; }

        /// <summary>
        /// Filters the result by time series. Only dimension values for anomalies detected in the time series
        /// group specified will be returned. This key represents a group of time series for the corresponding
        /// metric, so only a subset of dimensions must be set.
        /// </summary>
        public DimensionKey SeriesGroupKey { get; set; }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned in each page of results. Note:
        /// unless the number of pages enumerated from the service is limited, the service will
        /// return an unlimited number of total items.
        /// </summary>
        public int? MaxPageSize { get; set; }
    }
}
