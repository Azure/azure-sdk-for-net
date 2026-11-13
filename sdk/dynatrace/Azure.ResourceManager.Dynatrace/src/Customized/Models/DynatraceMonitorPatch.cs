// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Dynatrace.Models
{
    public partial class DynatraceMonitorPatch
    {
        /// <summary> User info. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo UserInfo { get; set; }
        /// <summary> Billing plan information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus? MonitoringStatus { get; set; }
        /// <summary> Marketplace subscription status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get; set; }
        /// <summary> Properties of the Dynatrace environment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get; set; }

        /// <summary> The new Billing plan information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo PlanData { get => MonitorUpdatePlanData; set => MonitorUpdatePlanData = value; }
    }
}
