// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorAdministrationClient.GetHooks"/> or
    /// <see cref="MetricsAdvisorAdministrationClient.GetHooksAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetHooksOptions
    {
        /// <summary>
        /// Filters the result by <see cref="NotificationHook.Name"/>. Only hooks containing the filter as a
        /// substring of their names will be returned. Case insensitive.
        /// </summary>
        public string HookNameFilter { get; set; }

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
