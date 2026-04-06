// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.ProviderHub.Models;

namespace Azure.ResourceManager.ProviderHub.Models
{
    public static partial class ArmProviderHubModelFactory
    {
        /// <summary> Backward-compat factory method for ProviderRegistrationProperties (34 params). </summary>
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
            var result = new ProviderRegistrationProperties();
            if (providerAuthenticationAllowedAudiences != null)
            {
                foreach (var item in providerAuthenticationAllowedAudiences)
                    result.ProviderAuthenticationAllowedAudiences.Add(item);
            }
            if (providerAuthorizations != null)
            {
                foreach (var item in providerAuthorizations)
                    result.ProviderAuthorizations.Add(item);
            }
            result.Namespace = @namespace;
            if (services != null)
            {
                foreach (var item in services)
                    result.Services.Add(item);
            }
            result.ServiceName = serviceName;
            result.ProviderVersion = providerVersion;
            result.ProviderType = providerType;
            if (requiredFeatures != null)
            {
                foreach (var item in requiredFeatures)
                    result.RequiredFeatures.Add(item);
            }
            result.RequiredFeaturesPolicy = requiredFeaturesPolicy;
            result.RequestHeaderOptions = requestHeaderOptions;
            result.Management = management;
            if (capabilities != null)
            {
                foreach (var item in capabilities)
                    result.Capabilities.Add(item);
            }
            result.CrossTenantTokenValidation = crossTenantTokenValidation;
            result.Metadata = metadata;
            result.TemplateDeploymentOptions = templateDeploymentOptions;
            if (globalNotificationEndpoints != null)
            {
                foreach (var item in globalNotificationEndpoints)
                    result.GlobalNotificationEndpoints.Add(item);
            }
            result.EnableTenantLinkedNotification = enableTenantLinkedNotification;
            if (notifications != null)
            {
                foreach (var item in notifications)
                    result.Notifications.Add(item);
            }
            if (linkedNotificationRules != null)
            {
                foreach (var item in linkedNotificationRules)
                    result.LinkedNotificationRules.Add(item);
            }
            result.DstsConfiguration = dstsConfiguration;
            result.NotificationOptions = notificationOptions;
            if (resourceHydrationAccounts != null)
            {
                foreach (var item in resourceHydrationAccounts)
                    result.ResourceHydrationAccounts.Add(item);
            }
            if (managementGroupGlobalNotificationEndpoints != null)
            {
                foreach (var item in managementGroupGlobalNotificationEndpoints)
                    result.ManagementGroupGlobalNotificationEndpoints.Add(item);
            }
            if (optionalFeatures != null)
            {
                foreach (var item in optionalFeatures)
                    result.OptionalFeatures.Add(item);
            }
            result.LegacyNamespace = legacyNamespace;
            if (legacyRegistrations != null)
            {
                foreach (var item in legacyRegistrations)
                    result.LegacyRegistrations.Add(item);
            }
            result.CustomManifestVersion = customManifestVersion;
            result.ProviderHubMetadata = providerHubMetadata;
            result.ProvisioningState = provisioningState;
            result.SubscriptionLifecycleNotificationSpecifications = subscriptionLifecycleNotificationSpecifications;
            result.TokenAuthConfiguration = tokenAuthConfiguration;
            return result;
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
                default,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Backward-compat factory method for ResourceProviderManifest (14 params with OptInHeaderType). </summary>
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
            return new ResourceProviderManifest(
                providerAuthenticationAllowedAudiences is null ? null : new ResourceProviderAuthentication(providerAuthenticationAllowedAudiences.ToList(), null),
                providerAuthorizations?.ToList(),
                @namespace,
                default,
                default,
                providerVersion,
                providerType,
                requiredFeatures?.ToList(),
                requiredFeaturesPolicy is null ? default : new ProviderFeaturesRule(requiredFeaturesPolicy.Value, null),
                default,
                resourceTypes?.ToList(),
                management,
                capabilities?.ToList(),
                default,
                metadata,
                globalNotificationEndpoints?.ToList(),
                reRegisterSubscriptionMetadata,
                default,
                default,
                default,
                default,
                additionalBinaryDataProperties: null);
        }
    }
}
