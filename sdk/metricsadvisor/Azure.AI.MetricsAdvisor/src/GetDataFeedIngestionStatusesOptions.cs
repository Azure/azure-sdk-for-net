// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorAdministrationClient.GetDataFeedIngestionStatuses"/> or
    /// <see cref="MetricsAdvisorAdministrationClient.GetDataFeedIngestionStatusesAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetDataFeedIngestionStatusesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataFeedIngestionStatusesOptions"/> class.
        /// </summary>
        /// <param name="startsOn">The start point of time range to query data ingestion status.</param>
        /// <param name="endsOn">The end point of time range to query data ingestion status.</param>
        public GetDataFeedIngestionStatusesOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            StartsOn = startsOn;
            EndsOn = endsOn;
        }

        /// <summary>
        /// Filters the result. Only status of data being ingested from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// Filters the result. Only status of data being ingested up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndsOn { get; }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the count of items to be skipped.
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
