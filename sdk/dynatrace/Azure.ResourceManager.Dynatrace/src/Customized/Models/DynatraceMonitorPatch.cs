// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace.Models
{
    public partial class DynatraceMonitorPatch
    {
        /// <summary> User info. </summary>
        public DynatraceMonitorUserInfo UserInfo { get; set; }
        /// <summary> Billing plan information. </summary>
        public DynatraceBillingPlanInfo PlanData { get; set; }
        /// <summary> Status of the monitor. </summary>
        public DynatraceMonitoringStatus? MonitoringStatus { get; set; }
        /// <summary> Marketplace subscription status. </summary>
        public DynatraceMonitorMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get; set; }
        /// <summary> Properties of the Dynatrace environment. </summary>
        public DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get; set; }
    }
}
