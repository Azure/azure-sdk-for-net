﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorAdministrationClient.GetDataFeeds"/>
    /// or <see cref="MetricsAdvisorAdministrationClient.GetDataFeedsAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetDataFeedsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataFeedsOptions"/> class.
        /// </summary>
        public GetDataFeedsOptions()
        {
        }

        /// <summary>
        /// Optional filters, such as filtering by name or by status.
        /// </summary>
        public GetDataFeedsFilter GetDataFeedsFilter { get; set; }

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
