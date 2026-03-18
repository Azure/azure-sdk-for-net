// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    // Backward compatibility: The old AutoRest-generated ModelFactory had overloads with fewer
    // parameters. The new TypeSpec generator produces different signatures (added publisherId,
    // offerId, subscriptionState, etc.). These shims delegate to the new overloads to avoid
    // breaking existing callers that use the old parameter lists.
    // Also suppress generated factory methods that expose internal property types.
    [CodeGenSuppress("NewRelicAccountResourceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(AccountProperties))]
    [CodeGenSuppress("NewRelicOrganizationResourceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(OrganizationProperties))]
    [CodeGenSuppress("NewRelicPlanData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(PlanDataProperties))]
    public static partial class ArmNewRelicObservabilityModelFactory
    {
        /// <summary> Initializes a new instance of MarketplaceSaaSInfo (5-param overload). </summary>
        public static MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId, string marketplaceSubscriptionName, string marketplaceResourceId, string marketplaceStatus, string billedAzureSubscriptionId)
        {
            return MarketplaceSaaSInfo(
                marketplaceSubscriptionId: marketplaceSubscriptionId,
                marketplaceSubscriptionName: marketplaceSubscriptionName,
                marketplaceResourceId: marketplaceResourceId,
                marketplaceStatus: marketplaceStatus,
                billedAzureSubscriptionId: billedAzureSubscriptionId,
                publisherId: default,
                offerId: default);
        }

        /// <summary> Initializes a new instance of NewRelicMonitorResourceData (17-param overload). </summary>
        public static NewRelicMonitorResourceData NewRelicMonitorResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, NewRelicProvisioningState? provisioningState, NewRelicObservabilityMonitoringStatus? monitoringStatus, NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, string marketplaceSubscriptionId, NewRelicAccountProperties newRelicAccountProperties, NewRelicObservabilityUserInfo userInfo, NewRelicPlanDetails planData, NewRelicLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, NewRelicObservabilityOrgCreationSource? orgCreationSource, NewRelicObservabilityAccountCreationSource? accountCreationSource)
        {
            return NewRelicMonitorResourceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                provisioningState: provisioningState,
                monitoringStatus: monitoringStatus,
                marketplaceSubscriptionStatus: marketplaceSubscriptionStatus,
                marketplaceSubscriptionId: marketplaceSubscriptionId,
                newRelicAccountProperties: newRelicAccountProperties,
                userInfo: userInfo,
                planData: planData,
                liftrResourceCategory: liftrResourceCategory,
                liftrResourcePreference: liftrResourcePreference,
                orgCreationSource: orgCreationSource,
                accountCreationSource: accountCreationSource,
                subscriptionState: default,
                saaSAzureSubscriptionStatus: default,
                saaSResourceId: default,
                identity: identity);
        }

        /// <summary> Initializes a new instance of NewRelicMonitorResourceData (19-param overload). </summary>
        public static NewRelicMonitorResourceData NewRelicMonitorResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, NewRelicProvisioningState? provisioningState, NewRelicObservabilityMonitoringStatus? monitoringStatus, NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, string marketplaceSubscriptionId, NewRelicAccountProperties newRelicAccountProperties, NewRelicObservabilityUserInfo userInfo, NewRelicPlanDetails planData, NewRelicLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, NewRelicObservabilityOrgCreationSource? orgCreationSource, NewRelicObservabilityAccountCreationSource? accountCreationSource, string subscriptionState, string saaSAzureSubscriptionStatus)
        {
            return NewRelicMonitorResourceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                provisioningState: provisioningState,
                monitoringStatus: monitoringStatus,
                marketplaceSubscriptionStatus: marketplaceSubscriptionStatus,
                marketplaceSubscriptionId: marketplaceSubscriptionId,
                newRelicAccountProperties: newRelicAccountProperties,
                userInfo: userInfo,
                planData: planData,
                liftrResourceCategory: liftrResourceCategory,
                liftrResourcePreference: liftrResourcePreference,
                orgCreationSource: orgCreationSource,
                accountCreationSource: accountCreationSource,
                subscriptionState: subscriptionState,
                saaSAzureSubscriptionStatus: saaSAzureSubscriptionStatus,
                saaSResourceId: default,
                identity: identity);
        }
    }
}
