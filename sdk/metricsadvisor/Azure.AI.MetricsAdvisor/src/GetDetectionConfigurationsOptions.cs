// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorAdministrationClient.GetDetectionConfigurations"/>
    /// or <see cref="MetricsAdvisorAdministrationClient.GetDetectionConfigurationsAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetDetectionConfigurationsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDetectionConfigurationsOptions"/> class.
        /// </summary>
        public GetDetectionConfigurationsOptions()
        {
        }

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
