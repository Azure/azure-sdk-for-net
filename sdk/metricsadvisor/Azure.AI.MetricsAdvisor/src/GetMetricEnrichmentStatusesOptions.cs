// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetMetricEnrichmentStatuses"/> or
    /// <see cref="MetricsAdvisorClient.GetMetricEnrichmentStatusesAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetMetricEnrichmentStatusesOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GetMetricEnrichmentStatusesOptions"/>.
        /// </summary>
        /// <param name="startsOn">The start point of time range to query enrichment status.</param>
        /// <param name="endsOn">The end point of time range to query enrichment status.</param>
        public GetMetricEnrichmentStatusesOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
        }

        /// <summary>
        /// The start point of time range to query enrichment status.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// The end point of time range to query enrichment status.
        /// </summary>
        public DateTimeOffset EndsOn { get; }

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
