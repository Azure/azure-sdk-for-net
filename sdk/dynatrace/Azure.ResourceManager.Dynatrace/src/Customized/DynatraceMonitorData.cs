// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

[assembly:CodeGenSuppressType("DynatraceMonitorData")]
namespace Azure.ResourceManager.Dynatrace
{
    /// <summary> A class representing the DynatraceMonitor data model. </summary>
    public partial class DynatraceMonitorData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of DynatraceMonitorData. </summary>
        /// <param name="location"> The location. </param>
        public DynatraceMonitorData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of DynatraceMonitorData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. Current supported identity types: SystemAssigned, UserAssigned, SystemAndUserAssigned. </param>
        /// <param name="monitoringStatus"> Status of the monitor. </param>
        /// <param name="marketplaceSubscriptionStatus"> Marketplace subscription status. </param>
        /// <param name="dynatraceEnvironmentProperties"> Properties of the Dynatrace environment. </param>
        /// <param name="userInfo"> User info. </param>
        /// <param name="planData"> Billing plan information. </param>
        /// <param name="liftrResourceCategory"> Liftr Resource category. </param>
        /// <param name="liftrResourcePreference"> The priority of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        internal DynatraceMonitorData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, DynatraceMonitoringStatus? monitoringStatus, DynatraceMonitorMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, DynatraceEnvironmentProperties dynatraceEnvironmentProperties, DynatraceMonitorUserInfo userInfo, DynatraceBillingPlanInfo planData, LiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, DynatraceProvisioningState? provisioningState) : base(id, name, resourceType, systemData, tags, location)
        {
            Identity = identity;
            MonitoringStatus = monitoringStatus;
            MarketplaceSubscriptionStatus = marketplaceSubscriptionStatus;
            DynatraceEnvironmentProperties = dynatraceEnvironmentProperties;
            UserInfo = userInfo;
            PlanData = planData;
            LiftrResourceCategory = liftrResourceCategory;
            LiftrResourcePreference = liftrResourcePreference;
            ProvisioningState = provisioningState;
        }

        /// <summary> The managed service identities assigned to this resource. Current supported identity types: SystemAssigned, UserAssigned, SystemAndUserAssigned. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> Status of the monitor. </summary>
        public DynatraceMonitoringStatus? MonitoringStatus { get; set; }
        /// <summary> Marketplace subscription status. </summary>
        public DynatraceMonitorMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get; set; }
        /// <summary> Properties of the Dynatrace environment. </summary>
        public DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get; set; }
        /// <summary> User info. </summary>
        public DynatraceMonitorUserInfo UserInfo { get; set; }
        /// <summary> Billing plan information. </summary>
        public DynatraceBillingPlanInfo PlanData { get; set; }
        /// <summary> Liftr Resource category. </summary>
        public LiftrResourceCategory? LiftrResourceCategory { get; }
        /// <summary> The priority of the resource. </summary>
        public int? LiftrResourcePreference { get; }
        /// <summary> Provisioning state of the resource. </summary>
        public DynatraceProvisioningState? ProvisioningState { get; }
    }
}
