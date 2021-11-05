// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetAnomaliesForDetectionConfiguration(string, GetAnomaliesForDetectionConfigurationOptions, CancellationToken)"/>
    /// or <see cref="MetricsAdvisorClient.GetAnomaliesForDetectionConfigurationAsync(string, GetAnomaliesForDetectionConfigurationOptions, CancellationToken)"/>
    /// to configure the behavior of the request.
    /// </summary>
    public class GetAnomaliesForDetectionConfigurationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAnomaliesForDetectionConfigurationOptions"/> class.
        /// </summary>
        /// <param name="startsOn">Filters the result. Only anomalies created from this point in time, in UTC, will be returned.</param>
        /// <param name="endsOn">Filters the result. Only anomalies created up to this point in time, in UTC, will be returned.</param>
        public GetAnomaliesForDetectionConfigurationOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
        }

        /// <summary>
        /// Filters the result. Only anomalies created from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// Filters the result. Only anomalies created up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndsOn { get; }

        /// <summary>
        /// Optional filters, such as filtering by time series or by severity level.
        /// </summary>
        public AnomalyFilter Filter { get; set; }

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
