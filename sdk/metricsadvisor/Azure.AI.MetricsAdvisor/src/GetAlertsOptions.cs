// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetAlerts"/> or
    /// <see cref="MetricsAdvisorClient.GetAlertsAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetAlertsOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlertsOptions"/> class.
        /// </summary>
        /// <param name="startOn">Filters the result. Only alerts triggered from this point in time, in UTC, will be returned.</param>
        /// <param name="endOn">Filters the result. Only alerts triggered up to this point in time, in UTC, will be returned.</param>
        /// <param name="timeMode">Specifies to which time property of an <see cref="AnomalyAlert"/> the filters <paramref name="startOn"/> and <paramref name="endOn"/> will be applied.</param>
        public GetAlertsOptions(DateTimeOffset startOn, DateTimeOffset endOn, AlertQueryTimeMode timeMode)
        {
            StartOn = startOn;
            EndOn = endOn;
            TimeMode = timeMode;
        }

        /// <summary>
        /// Filters the result. Only alerts triggered from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartOn { get; }

        /// <summary>
        /// Filters the result. Only alerts triggered up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndOn { get; }

        /// <summary>
        /// Specifies to which time property of an <see cref="AnomalyAlert"/> the filters <see cref="StartOn"/>
        /// and <see cref="EndOn"/> will be applied.
        /// </summary>
        public AlertQueryTimeMode TimeMode { get; }

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
