// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.ProviderHub.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmProviderHubModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.CheckinManifestInfo"/>. </summary>
        /// <param name="isCheckedIn"></param>
        /// <param name="statusMessage"></param>
        /// <param name="pullRequest"></param>
        /// <param name="commitId"></param>
        /// <returns> A new <see cref="Models.CheckinManifestInfo"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CheckinManifestInfo CheckinManifestInfo(bool isCheckedIn = default, string statusMessage = null, string pullRequest = null, string commitId = null)
            => new CheckinManifestInfo(isCheckedIn, statusMessage, pullRequest, commitId, null);

        /// <summary> Initializes a new instance of <see cref="Models.LinkedOperationRule"/>. </summary>
        /// <param name="linkedOperation"></param>
        /// <param name="linkedAction"></param>
        /// <returns> A new <see cref="Models.LinkedOperationRule"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LinkedOperationRule LinkedOperationRule(LinkedOperation linkedOperation = default, LinkedAction linkedAction = default)
            => new LinkedOperationRule(linkedOperation, linkedAction, new ChangeTrackingList<string>(), null);

        /// <summary> Initializes a new instance of <see cref="Models.ProviderResourceType"/>. </summary>
        /// <param name="name"></param>
        /// <param name="routingType"></param>
        /// <param name="resourceValidation"></param>
        /// <param name="allowedUnauthorizedActions"></param>
        /// <param name="authorizationActionMappings"></param>
        /// <param name="linkedAccessChecks"></param>
        /// <param name="defaultApiVersion"></param>
        /// <param name="loggingRules"></param>
        /// <param name="throttlingRules"></param>
        /// <param name="endpoints"></param>
        /// <param name="marketplaceType"></param>
        /// <param name="managementType"></param>
        /// <param name="metadata"> Anything. </param>
        /// <param name="requiredFeatures"></param>
        /// <param name="requiredFeaturesPolicy"></param>
        /// <param name="subscriptionStateRules"></param>
        /// <param name="serviceTreeInfos"></param>
        /// <param name="optInHeaders"></param>
        /// <param name="skuLink"></param>
        /// <param name="disallowedActionVerbs"></param>
        /// <param name="templateDeploymentPolicy"></param>
        /// <param name="extendedLocations"></param>
        /// <param name="linkedOperationRules"></param>
        /// <param name="resourceDeletionPolicy"></param>
        /// <returns> A new <see cref="Models.ProviderResourceType"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ProviderResourceType ProviderResourceType(string name = null, ResourceRoutingType? routingType = null, ResourceValidation? resourceValidation = null, IEnumerable<string> allowedUnauthorizedActions = null, IEnumerable<AuthorizationActionMapping> authorizationActionMappings = null, IEnumerable<LinkedAccessCheck> linkedAccessChecks = null, string defaultApiVersion = null, IEnumerable<LoggingRule> loggingRules = null, IEnumerable<ThrottlingRule> throttlingRules = null, IEnumerable<ResourceProviderEndpoint> endpoints = null, MarketplaceType? marketplaceType = null, IdentityManagementType? managementType = null, BinaryData metadata = null, IEnumerable<string> requiredFeatures = null, FeaturesPolicy? requiredFeaturesPolicy = null, IEnumerable<ProviderSubscriptionStateRule> subscriptionStateRules = null, IEnumerable<ServiceTreeInfo> serviceTreeInfos = null, OptInHeaderType? optInHeaders = null, string skuLink = null, IEnumerable<string> disallowedActionVerbs = null, TemplateDeploymentPolicy templateDeploymentPolicy = null, IEnumerable<ProviderHubExtendedLocationOptions> extendedLocations = null, IEnumerable<LinkedOperationRule> linkedOperationRules = null, ManifestResourceDeletionPolicy? resourceDeletionPolicy = null)
            => new ProviderResourceType(name, routingType, null, null, resourceValidation, allowedUnauthorizedActions.ToList(), null, authorizationActionMappings.ToList(), linkedAccessChecks.ToList(), defaultApiVersion, loggingRules.ToList(), throttlingRules.ToList(), endpoints.ToList(), marketplaceType, null, metadata, requiredFeatures.ToList(), null, subscriptionStateRules.ToList(), null, null, skuLink, disallowedActionVerbs.ToList(), templateDeploymentPolicy, extendedLocations.ToList(), linkedOperationRules.ToList(), resourceDeletionPolicy, null, null, null, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.ResourceProviderEndpoint"/>. </summary>
        /// <param name="isEnabled"></param>
        /// <param name="apiVersions"></param>
        /// <param name="endpointUri"></param>
        /// <param name="locations"></param>
        /// <param name="requiredFeatures"></param>
        /// <param name="requiredFeaturesPolicy"></param>
        /// <param name="timeout"></param>
        /// <returns> A new <see cref="Models.ResourceProviderEndpoint"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceProviderEndpoint ResourceProviderEndpoint(bool? isEnabled = null, IEnumerable<string> apiVersions = null, Uri endpointUri = null, IEnumerable<AzureLocation> locations = null, IEnumerable<string> requiredFeatures = null, FeaturesPolicy? requiredFeaturesPolicy = null, TimeSpan? timeout = null)
            => new ResourceProviderEndpoint(isEnabled, apiVersions.ToList(), endpointUri, locations.ToList(), requiredFeatures.ToList(), null, timeout, null, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.ResourceProviderManifest"/>. </summary>
        /// <param name="providerAuthenticationAllowedAudiences"></param>
        /// <param name="providerAuthorizations"></param>
        /// <param name="namespace"></param>
        /// <param name="providerVersion"></param>
        /// <param name="providerType"></param>
        /// <param name="requiredFeatures"></param>
        /// <param name="requiredFeaturesPolicy"></param>
        /// <param name="optInHeaders"></param>
        /// <param name="resourceTypes"></param>
        /// <param name="management"></param>
        /// <param name="capabilities"></param>
        /// <param name="metadata"> Anything. </param>
        /// <param name="globalNotificationEndpoints"></param>
        /// <param name="reRegisterSubscriptionMetadata"></param>
        /// <returns> A new <see cref="Models.ResourceProviderManifest"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceProviderManifest ResourceProviderManifest(IEnumerable<string> providerAuthenticationAllowedAudiences = null, IEnumerable<ResourceProviderAuthorization> providerAuthorizations = null, string @namespace = null, string providerVersion = null, ResourceProviderType? providerType = null, IEnumerable<string> requiredFeatures = null, FeaturesPolicy? requiredFeaturesPolicy = null, OptInHeaderType? optInHeaders = null, IEnumerable<ProviderResourceType> resourceTypes = null, ResourceProviderManagement management = null, IEnumerable<ResourceProviderCapabilities> capabilities = null, BinaryData metadata = null, IEnumerable<ResourceProviderEndpoint> globalNotificationEndpoints = null, ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null)
            => new ResourceProviderManifest(null, providerAuthorizations.ToList(), @namespace, null, null, providerVersion, providerType, requiredFeatures.ToList(), null, null, resourceTypes.ToList(), management, capabilities.ToList(), null, metadata, globalNotificationEndpoints.ToList(), reRegisterSubscriptionMetadata, null, null, null, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.TemplateDeploymentPolicy"/>. </summary>
        /// <param name="capabilities"></param>
        /// <param name="preflightOptions"></param>
        /// <returns> A new <see cref="Models.TemplateDeploymentPolicy"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TemplateDeploymentPolicy TemplateDeploymentPolicy(TemplateDeploymentCapability capabilities = default, TemplateDeploymentPreflightOption preflightOptions = default)
            => new TemplateDeploymentPolicy(capabilities, preflightOptions, null, null);
    }
}
