// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ProviderHub.Models;

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: restores model factory overloads whose baseline signatures no longer match
    // the generated constructors after migration. These overloads require custom object wiring, so
    // they cannot be recovered with TypeSpec decorators alone.
    public static partial class ArmProviderHubModelFactory
    {
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
                tokenAuthConfiguration: null,
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

        /// <param name="serviceId"> The service id. </param>
        /// <param name="componentId"> The component id. </param>
        /// <param name="readiness"> The readiness. </param>
        /// <returns> A new <see cref="Models.ServiceTreeInfo"/> instance for mocking. </returns>
        public static ServiceTreeInfo ServiceTreeInfo(string serviceId = default, string componentId = default, ServiceTreeReadiness? readiness = default)
        {
            return new ServiceTreeInfo(serviceId, componentId, readiness, default);
        }

        /// <param name="serviceName"> The service name. </param>
        /// <param name="serviceDnsName"> This is a URI property. </param>
        /// <returns> A new <see cref="Models.ProviderDstsConfiguration"/> instance for mocking. </returns>
        public static ProviderDstsConfiguration ProviderDstsConfiguration(string serviceName = default, string serviceDnsName = default)
        {
            return new ProviderDstsConfiguration(serviceName, serviceDnsName, default);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="operationsContentContents"> Operations content. </param>
        /// <returns> A new <see cref="Models.OperationsPutContent"/> instance for mocking. </returns>
        public static OperationsPutContent OperationsPutContent(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IEnumerable<LocalizedOperationDefinition> operationsContentContents = default)
        {
            return new OperationsPutContent(
                id,
                name,
                resourceType,
                systemData,
                operationsContentContents is null ? default : new OperationsContentProperties((operationsContentContents ?? new ChangeTrackingList<LocalizedOperationDefinition>()).ToList(), default),
                default);
        }

        /// <param name="properties"> Properties of the frontload payload. </param>
        /// <returns> A new <see cref="Models.ProviderFrontloadPayload"/> instance for mocking. </returns>
        public static ProviderFrontloadPayload ProviderFrontloadPayload(ProviderFrontloadPayloadProperties properties = default)
        {
            return new ProviderFrontloadPayload(properties, default);
        }

        /// <param name="operationType"> The operation type. </param>
        /// <param name="providerNamespace"> The provider namespace. </param>
        /// <param name="frontloadLocation"> The frontload location. </param>
        /// <param name="copyFromLocation"> The copy from location. </param>
        /// <param name="environmentType"> The environment type. </param>
        /// <param name="serviceFeatureFlag"> The service feature flag. </param>
        /// <param name="includeResourceTypes"> The resource types to include. </param>
        /// <param name="excludeResourceTypes"> The resource types to exclude. </param>
        /// <param name="overrideManifestLevelFieldsResourceHydrationAccounts"> The resource hydration accounts. </param>
        /// <param name="overrideEndpointLevelFields"> The endpoint level fields to override. </param>
        /// <param name="ignoreFields"> The fields to ignore. </param>
        /// <returns> A new <see cref="Models.ProviderFrontloadPayloadProperties"/> instance for mocking. </returns>
        public static ProviderFrontloadPayloadProperties ProviderFrontloadPayloadProperties(string operationType = default, string providerNamespace = default, string frontloadLocation = default, string copyFromLocation = default, AvailableCheckInManifestEnvironment environmentType = default, ServiceFeatureFlagAction serviceFeatureFlag = default, IEnumerable<string> includeResourceTypes = default, IEnumerable<string> excludeResourceTypes = default, IEnumerable<ResourceHydrationAccount> overrideManifestLevelFieldsResourceHydrationAccounts = default, ResourceTypeEndpointBase overrideEndpointLevelFields = default, IEnumerable<string> ignoreFields = default)
        {
            includeResourceTypes ??= new ChangeTrackingList<string>();
            excludeResourceTypes ??= new ChangeTrackingList<string>();
            ignoreFields ??= new ChangeTrackingList<string>();

            return new ProviderFrontloadPayloadProperties(
                operationType,
                providerNamespace,
                frontloadLocation,
                copyFromLocation,
                environmentType,
                serviceFeatureFlag,
                (includeResourceTypes ?? new ChangeTrackingList<string>()).ToList(),
                (excludeResourceTypes ?? new ChangeTrackingList<string>()).ToList(),
                overrideManifestLevelFieldsResourceHydrationAccounts is null ? default : new ManifestLevelPropertyBag((overrideManifestLevelFieldsResourceHydrationAccounts ?? new ChangeTrackingList<ResourceHydrationAccount>()).ToList(), default),
                overrideEndpointLevelFields,
                (ignoreFields ?? new ChangeTrackingList<string>()).ToList(),
                default);
        }

        /// <param name="resourceHydrationAccounts"> The resource hydration accounts. </param>
        /// <returns> A new <see cref="Models.ManifestLevelPropertyBag"/> instance for mocking. </returns>
        public static ManifestLevelPropertyBag ManifestLevelPropertyBag(IEnumerable<ResourceHydrationAccount> resourceHydrationAccounts = default)
        {
            resourceHydrationAccounts ??= new ChangeTrackingList<ResourceHydrationAccount>();

            return new ManifestLevelPropertyBag((resourceHydrationAccounts ?? new ChangeTrackingList<ResourceHydrationAccount>()).ToList(), default);
        }

        /// <param name="enabled"> Whether it's enabled. </param>
        /// <param name="apiVersions"> The api versions. </param>
        /// <param name="endpointUri"> The endpoint uri. </param>
        /// <param name="locations"> The locations. </param>
        /// <param name="requiredFeatures"> The required features. </param>
        /// <param name="requiredFeaturesPolicy"> The required feature policy. </param>
        /// <param name="timeout"> This is a TimeSpan property. </param>
        /// <param name="endpointType"> The endpoint type. </param>
        /// <param name="dstsConfiguration"> The dsts configuration. </param>
        /// <param name="skuLink"> The sku link. </param>
        /// <param name="apiVersion"> The api version. </param>
        /// <param name="zones"> The zones. </param>
        /// <returns> A new <see cref="Models.ResourceTypeEndpointBase"/> instance for mocking. </returns>
        public static ResourceTypeEndpointBase ResourceTypeEndpointBase(bool enabled = default, IEnumerable<string> apiVersions = default, Uri endpointUri = default, IEnumerable<string> locations = default, IEnumerable<string> requiredFeatures = default, FeaturesPolicy requiredFeaturesPolicy = default, TimeSpan timeout = default, ProviderEndpointType endpointType = default, ProviderDstsConfiguration dstsConfiguration = default, string skuLink = default, string apiVersion = default, IEnumerable<string> zones = default)
        {
            apiVersions ??= new ChangeTrackingList<string>();
            locations ??= new ChangeTrackingList<string>();
            requiredFeatures ??= new ChangeTrackingList<string>();
            zones ??= new ChangeTrackingList<string>();

            return new ResourceTypeEndpointBase(
                enabled,
                (apiVersions ?? new ChangeTrackingList<string>()).ToList(),
                endpointUri,
                (locations ?? new ChangeTrackingList<string>()).ToList(),
                (requiredFeatures ?? new ChangeTrackingList<string>()).ToList(),
                new ProviderFeaturesRule(requiredFeaturesPolicy, default),
                timeout,
                endpointType,
                dstsConfiguration,
                skuLink,
                apiVersion,
                (zones ?? new ChangeTrackingList<string>()).ToList(),
                default);
        }
    }
}
