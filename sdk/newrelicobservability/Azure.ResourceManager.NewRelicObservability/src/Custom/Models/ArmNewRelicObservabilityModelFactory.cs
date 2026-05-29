// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    // Backward compatibility: The old AutoRest-generated ModelFactory had overloads with fewer
    // parameters. The new TypeSpec generator produces different signatures (added publisherId,
    // offerId, subscriptionState, etc.). These shims delegate to the new overloads to avoid
    // breaking existing callers that use the old parameter lists.
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

        /// <summary> Initializes a new instance of NewRelicAccountResourceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NewRelicAccountResourceData NewRelicAccountResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string organizationId = null, string accountId = null, string accountName = null, AzureLocation? region = default)
        {
            return new NewRelicAccountResourceData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new AccountProperties(organizationId, accountId, accountName, region, additionalBinaryDataProperties: null));
        }

        /// <summary> Initializes a new instance of NewRelicOrganizationResourceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NewRelicOrganizationResourceData NewRelicOrganizationResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string organizationId = null, string organizationName = null, NewRelicObservabilityBillingSource? billingSource = default)
        {
            return new NewRelicOrganizationResourceData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new OrganizationProperties(organizationId, organizationName, billingSource, additionalBinaryDataProperties: null));
        }

        /// <summary> Initializes a new instance of NewRelicPlanData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NewRelicPlanData NewRelicPlanData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, NewRelicPlanDetails planData = null, NewRelicObservabilityOrgCreationSource? orgCreationSource = default, NewRelicObservabilityAccountCreationSource? accountCreationSource = default)
        {
            return new NewRelicPlanData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new PlanDataProperties(planData, orgCreationSource, accountCreationSource, additionalBinaryDataProperties: null));
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
