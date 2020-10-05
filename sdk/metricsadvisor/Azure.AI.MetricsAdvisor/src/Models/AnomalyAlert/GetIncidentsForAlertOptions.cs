// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetIncidentsForAlert"/>
    /// or <see cref="MetricsAdvisorClient.GetIncidentsForAlertAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetIncidentsForAlertOptions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GetIncidentsForAlertOptions"/> class.
        /// </summary>
        public GetIncidentsForAlertOptions()
        {
        }

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
