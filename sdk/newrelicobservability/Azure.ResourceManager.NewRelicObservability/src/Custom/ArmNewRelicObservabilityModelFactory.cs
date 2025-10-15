// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmNewRelicObservabilityModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicObservability.NewRelicMonitorResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="provisioningState"> Provisioning State of the resource. </param>
        /// <param name="monitoringStatus"> MonitoringStatus of the resource. </param>
        /// <param name="marketplaceSubscriptionStatus"> NewRelic Organization properties of the resource. </param>
        /// <param name="marketplaceSubscriptionId"> Marketplace Subscription Id. </param>
        /// <param name="newRelicAccountProperties"> MarketplaceSubscriptionStatus of the resource. </param>
        /// <param name="userInfo"> User Info. </param>
        /// <param name="planData"> Plan details. </param>
        /// <param name="liftrResourceCategory"> Liftr resource category. </param>
        /// <param name="liftrResourcePreference"> Liftr resource preference. The priority of the resource. </param>
        /// <param name="orgCreationSource"> Source of org creation. </param>
        /// <param name="accountCreationSource"> Source of account creation. </param>
        /// <param name="subscriptionState"> State of the Azure Subscription containing the monitor resource. </param>
        /// <param name="saaSAzureSubscriptionStatus"> Status of Azure Subscription where Marketplace SaaS is located. </param>
        /// <returns> A new <see cref="NewRelicObservability.NewRelicMonitorResourceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NewRelicMonitorResourceData NewRelicMonitorResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity = null, NewRelicProvisioningState? provisioningState = null, NewRelicObservabilityMonitoringStatus? monitoringStatus = null, NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = null, string marketplaceSubscriptionId = null, NewRelicAccountProperties newRelicAccountProperties = null, NewRelicObservabilityUserInfo userInfo = null, NewRelicPlanDetails planData = null, NewRelicLiftrResourceCategory? liftrResourceCategory = null, int? liftrResourcePreference = null, NewRelicObservabilityOrgCreationSource? orgCreationSource = null, NewRelicObservabilityAccountCreationSource? accountCreationSource = null, string subscriptionState = null, string saaSAzureSubscriptionStatus = null)
        {
            return NewRelicMonitorResourceData(id, name, resourceType, systemData, tags, location, identity, provisioningState, monitoringStatus, marketplaceSubscriptionStatus, marketplaceSubscriptionId, newRelicAccountProperties, userInfo, planData, saaSResourceId: default, liftrResourceCategory, liftrResourcePreference, orgCreationSource, accountCreationSource);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <param name="provisioningState"> Provisioning State of the resource. </param>
        /// <param name="monitoringStatus"> MonitoringStatus of the resource. </param>
        /// <param name="marketplaceSubscriptionStatus"> NewRelic Organization properties of the resource. </param>
        /// <param name="marketplaceSubscriptionId"> Marketplace Subscription Id. </param>
        /// <param name="newRelicAccountProperties"> MarketplaceSubscriptionStatus of the resource. </param>
        /// <param name="userInfo"> User Info. </param>
        /// <param name="planData"> Plan details. </param>
        /// <param name="liftrResourceCategory"> Liftr resource category. </param>
        /// <param name="liftrResourcePreference"> Liftr resource preference. The priority of the resource. </param>
        /// <param name="orgCreationSource"> Source of org creation. </param>
        /// <param name="accountCreationSource"> Source of account creation. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NewRelicMonitorResourceData NewRelicMonitorResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, NewRelicProvisioningState? provisioningState, NewRelicObservabilityMonitoringStatus? monitoringStatus, NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, string marketplaceSubscriptionId, NewRelicAccountProperties newRelicAccountProperties, NewRelicObservabilityUserInfo userInfo, NewRelicPlanDetails planData, NewRelicLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, NewRelicObservabilityOrgCreationSource? orgCreationSource, NewRelicObservabilityAccountCreationSource? accountCreationSource)
        {
            return NewRelicMonitorResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, identity: identity, provisioningState: provisioningState, monitoringStatus: monitoringStatus, marketplaceSubscriptionStatus: marketplaceSubscriptionStatus, marketplaceSubscriptionId: marketplaceSubscriptionId, newRelicAccountProperties: newRelicAccountProperties, userInfo: userInfo, planData: planData, liftrResourceCategory: liftrResourceCategory, liftrResourcePreference: liftrResourcePreference, orgCreationSource: orgCreationSource, accountCreationSource: accountCreationSource, subscriptionState: default, saaSAzureSubscriptionStatus: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MarketplaceSaaSInfo"/>. </summary>
        /// <param name="marketplaceSubscriptionId"> Marketplace Subscription Id. This is a GUID-formatted string. </param>
        /// <param name="marketplaceSubscriptionName"> Marketplace Subscription Details: SAAS Name. </param>
        /// <param name="marketplaceResourceId"> Marketplace Subscription Details: Resource URI. </param>
        /// <param name="marketplaceStatus"> Marketplace Subscription Details: SaaS Subscription Status. </param>
        /// <param name="billedAzureSubscriptionId"> The Azure Subscription ID to which the Marketplace Subscription belongs and gets billed into. </param>
        /// <returns> A new <see cref="Models.MarketplaceSaaSInfo"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId, string marketplaceSubscriptionName, string marketplaceResourceId, string marketplaceStatus, string billedAzureSubscriptionId)
        {
            return MarketplaceSaaSInfo(marketplaceSubscriptionId, marketplaceSubscriptionName, marketplaceResourceId, marketplaceStatus, billedAzureSubscriptionId, publisherId: default, offerId: default);
        }
    }
}
