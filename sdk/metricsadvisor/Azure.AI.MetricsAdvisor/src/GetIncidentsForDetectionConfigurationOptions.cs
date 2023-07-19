// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetIncidentsForDetectionConfiguration(string, GetIncidentsForDetectionConfigurationOptions, CancellationToken)"/>
    /// or <see cref="MetricsAdvisorClient.GetIncidentsForDetectionConfigurationAsync(string, GetIncidentsForDetectionConfigurationOptions, CancellationToken)"/>
    /// to configure the behavior of the request.
    /// </summary>
    public class GetIncidentsForDetectionConfigurationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetIncidentsForDetectionConfigurationOptions"/> class.
        /// </summary>
        /// <param name="startsOn">Filters the result. Only incidents detected from this point in time, in UTC, will be returned.</param>
        /// <param name="endsOn">Filters the result. Only incidents detected up to this point in time, in UTC, will be returned.</param>
        public GetIncidentsForDetectionConfigurationOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
            DimensionKeys = new ChangeTrackingList<DimensionKey>();
        }

        /// <summary>
        /// Filters the result. Only incidents detected from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// Filters the result. Only incidents detected up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndsOn { get; }

        /// <summary>
        /// Filters the result by time series. Each element in this list represents a set of time series, and only
        /// incidents detected in at least one of these sets will be returned. For each element, if all possible
        /// dimensions are set, the key uniquely identifies a single time series for the corresponding metric. If
        /// only a subset of dimensions are set, the key uniquely identifies a group of time series.
        /// </summary>
        public IList<DimensionKey> DimensionKeys { get; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned in each page of results. Note:
        /// unless the number of pages enumerated from the service is limited, the service will
        /// return an unlimited number of total items.
        /// </summary>
        public int? MaxPageSize { get; set; }

        internal DetectionIncidentFilterCondition GetDetectionIncidentFilterCondition()
        {
            DetectionIncidentFilterCondition filterCondition = new DetectionIncidentFilterCondition();

            foreach (DimensionKey dimensionKey in DimensionKeys)
            {
                filterCondition.DimensionFilter.Add(dimensionKey.Clone());
            }

            return filterCondition;
        }
    }
}
