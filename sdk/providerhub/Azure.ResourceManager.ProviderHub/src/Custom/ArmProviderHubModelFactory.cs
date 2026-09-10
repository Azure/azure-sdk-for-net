// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.ProviderHub.Models;

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: restores model factory overloads whose baseline signatures no longer match
    // the generated constructors after migration. These overloads require custom object wiring, so
    // they cannot be recovered with TypeSpec decorators alone.
    public static partial class ArmProviderHubModelFactory
    {
        /// <summary> Backward-compat factory method for ProviderRegistrationProperties (34 params). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ProviderRegistrationProperties ProviderRegistrationProperties(
            IEnumerable<string> providerAuthenticationAllowedAudiences = null,
            IEnumerable<ResourceProviderAuthorization> providerAuthorizations = null,
            string @namespace = null,
            IEnumerable<ResourceProviderService> services = null,
            string serviceName = null,
            string providerVersion = null,
            ResourceProviderType? providerType = null,
            IEnumerable<string> requiredFeatures = null,
            FeaturesPolicy? requiredFeaturesPolicy = null,
            ProviderRequestHeaderOptions requestHeaderOptions = null,
            ResourceProviderManagement management = null,
            IEnumerable<ResourceProviderCapabilities> capabilities = null,
            CrossTenantTokenValidation? crossTenantTokenValidation = null,
            BinaryData metadata = null,
            TemplateDeploymentOptions templateDeploymentOptions = null,
            IEnumerable<ResourceProviderEndpoint> globalNotificationEndpoints = null,
            bool? enableTenantLinkedNotification = null,
            IEnumerable<ProviderNotification> notifications = null,
            IEnumerable<FanoutLinkedNotificationRule> linkedNotificationRules = null,
            AsyncOperationPollingRules asyncOperationPollingRules = null,
            ProviderDstsConfiguration dstsConfiguration = null,
            ProviderNotificationOption? notificationOptions = null,
            IEnumerable<ResourceHydrationAccount> resourceHydrationAccounts = null,
            IEnumerable<SubscriberSetting> notificationSubscriberSettings = null,
            IEnumerable<ResourceProviderEndpoint> managementGroupGlobalNotificationEndpoints = null,
            IEnumerable<string> optionalFeatures = null,
            BlockActionVerb? resourceGroupLockOptionDuringMoveBlockActionVerb = null,
            ServiceClientOptionsType? serviceClientOptionsType = null,
            string legacyNamespace = null,
            IEnumerable<string> legacyRegistrations = null,
            string customManifestVersion = null,
            ProviderHubMetadata providerHubMetadata = null,
            ProviderHubProvisioningState? provisioningState = null,
            SubscriptionLifecycleNotificationSpecifications subscriptionLifecycleNotificationSpecifications = null,
            IEnumerable<string> privateResourceProviderAllowedSubscriptions = null,
            TokenAuthConfiguration tokenAuthConfiguration = null)
        {
            return new ProviderRegistrationProperties(
                providerAuthenticationAllowedAudiences is null ? null : new ResourceProviderAuthentication(providerAuthenticationAllowedAudiences.ToList(), null),
                providerAuthorizations?.ToList(),
                @namespace,
                services?.ToList(),
                serviceName,
                providerVersion,
                providerType,
                requiredFeatures?.ToList(),
                requiredFeaturesPolicy is null ? default : new ProviderFeaturesRule(requiredFeaturesPolicy.Value, null),
                requestHeaderOptions,
                management,
                capabilities?.ToList(),
                crossTenantTokenValidation,
                metadata,
                templateDeploymentOptions,
                globalNotificationEndpoints?.ToList(),
                enableTenantLinkedNotification,
                notifications?.ToList(),
                linkedNotificationRules?.ToList(),
                asyncOperationPollingRules is null ? default : new ResourceProviderAuthorizationRules(asyncOperationPollingRules, null),
                dstsConfiguration,
                notificationOptions,
                resourceHydrationAccounts?.ToList(),
                notificationSubscriberSettings is null ? default : new ResourceProviderManifestNotificationSettings(notificationSubscriberSettings.ToList(), null),
                managementGroupGlobalNotificationEndpoints?.ToList(),
                optionalFeatures?.ToList(),
                resourceGroupLockOptionDuringMoveBlockActionVerb is null ? default : new ResourceProviderManifestResourceGroupLockOptionDuringMove(resourceGroupLockOptionDuringMoveBlockActionVerb, null),
                serviceClientOptionsType is null ? default : new ResourceProviderManifestResponseOptions(serviceClientOptionsType, null),
                legacyNamespace,
                legacyRegistrations?.ToList(),
                customManifestVersion,
                additionalBinaryDataProperties: null,
                providerHubMetadata,
                provisioningState,
                subscriptionLifecycleNotificationSpecifications,
                privateResourceProviderAllowedSubscriptions is null ? default : new PrivateResourceProviderConfiguration(privateResourceProviderAllowedSubscriptions.ToList(), null),
                tokenAuthConfiguration);
        }

        /// <summary> Backward-compat factory method for ResourceProviderManifest (20 params). </summary>
        public static ResourceProviderManifest ResourceProviderManifest(
            IEnumerable<string> providerAuthenticationAllowedAudiences = null,
            IEnumerable<ResourceProviderAuthorization> providerAuthorizations = null,
            string @namespace = null,
            IEnumerable<ResourceProviderService> services = null,
            string serviceName = null,
            string providerVersion = null,
            ResourceProviderType? providerType = null,
            IEnumerable<string> requiredFeatures = null,
            FeaturesPolicy? requiredFeaturesPolicy = null,
            ProviderRequestHeaderOptions requestHeaderOptions = null,
            IEnumerable<ProviderResourceType> resourceTypes = null,
            ResourceProviderManagement management = null,
            IEnumerable<ResourceProviderCapabilities> capabilities = null,
            CrossTenantTokenValidation? crossTenantTokenValidation = null,
            BinaryData metadata = null,
            IEnumerable<ResourceProviderEndpoint> globalNotificationEndpoints = null,
            ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null,
            bool? isTenantLinkedNotificationEnabled = null,
            IEnumerable<ProviderNotification> notifications = null,
            IEnumerable<FanoutLinkedNotificationRule> linkedNotificationRules = null,
            AsyncOperationPollingRules asyncOperationPollingRules = null)
        {
            var resourceProviderAuthorizationRules = asyncOperationPollingRules is null
                ? default
                : new ResourceProviderAuthorizationRules(asyncOperationPollingRules, null);
            return new ResourceProviderManifest(
                providerAuthenticationAllowedAudiences is null ? null : new ResourceProviderAuthentication(providerAuthenticationAllowedAudiences.ToList(), null),
                providerAuthorizations?.ToList(),
                @namespace,
                services?.ToList(),
                serviceName,
                providerVersion,
                providerType,
                requiredFeatures?.ToList(),
                requiredFeaturesPolicy is null ? default : new ProviderFeaturesRule(requiredFeaturesPolicy.Value, null),
                requestHeaderOptions,
                resourceTypes?.ToList(),
                management,
                capabilities?.ToList(),
                crossTenantTokenValidation,
                metadata,
                globalNotificationEndpoints?.ToList(),
                reRegisterSubscriptionMetadata,
                isTenantLinkedNotificationEnabled,
                notifications?.ToList(),
                linkedNotificationRules?.ToList(),
                resourceProviderAuthorizationRules,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Backward-compat factory method for ResourceProviderManifest (14 params with OptInHeaderType). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceProviderManifest ResourceProviderManifest(
            IEnumerable<string> providerAuthenticationAllowedAudiences = null,
            IEnumerable<ResourceProviderAuthorization> providerAuthorizations = null,
            string @namespace = null,
            string providerVersion = null,
            ResourceProviderType? providerType = null,
            IEnumerable<string> requiredFeatures = null,
            FeaturesPolicy? requiredFeaturesPolicy = null,
            OptInHeaderType? optInHeaders = null,
            IEnumerable<ProviderResourceType> resourceTypes = null,
            ResourceProviderManagement management = null,
            IEnumerable<ResourceProviderCapabilities> capabilities = null,
            BinaryData metadata = null,
            IEnumerable<ResourceProviderEndpoint> globalNotificationEndpoints = null,
            ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null)
        {
            var requestHeaderOptions = optInHeaders is null
                ? default
                : new ProviderRequestHeaderOptions { OptInHeaders = optInHeaders };
            return ResourceProviderManifest(
                providerAuthenticationAllowedAudiences: providerAuthenticationAllowedAudiences,
                providerAuthorizations: providerAuthorizations,
                @namespace: @namespace,
                providerVersion: providerVersion,
                providerType: providerType,
                requiredFeatures: requiredFeatures,
                requiredFeaturesPolicy: requiredFeaturesPolicy,
                requestHeaderOptions: requestHeaderOptions,
                resourceTypes: resourceTypes,
                management: management,
                capabilities: capabilities,
                metadata: metadata,
                globalNotificationEndpoints: globalNotificationEndpoints,
                reRegisterSubscriptionMetadata: reRegisterSubscriptionMetadata);
        }
    }
}
