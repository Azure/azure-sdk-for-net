// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using GenFactory = Azure.ResourceManager.ContainerRegistry.ArmContainerRegistryModelFactory;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward-compatibility shim. Delegates to the generated factory in
    // <c>Azure.ResourceManager.ContainerRegistry.ArmContainerRegistryModelFactory</c>.
    // All methods are hidden from IntelliSense. 
    public static partial class ArmContainerRegistryModelFactory
    {
        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistryData ConnectedRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ContainerRegistryProvisioningState? provisioningState, ConnectedRegistryMode? mode, string version, ConnectedRegistryConnectionState? connectionState, DateTimeOffset? lastActivityOn, ConnectedRegistryActivationStatus? activationStatus, ConnectedRegistryParent parent, IEnumerable<ResourceIdentifier> clientTokenIds, ConnectedRegistryLoginServer loginServer, ConnectedRegistryLogging logging, IEnumerable<ConnectedRegistryStatusDetail> statusDetails, IEnumerable<string> notificationsList, GarbageCollectionProperties garbageCollection)
            => GenFactory.ConnectedRegistryData(id: id, name: name, resourceType: resourceType, systemData: systemData, provisioningState: provisioningState, mode: mode, version: version, connectionState: connectionState, lastActivityOn: lastActivityOn, parent: parent, clientTokenIds: clientTokenIds, loginServer: loginServer, logging: logging, statusDetails: statusDetails, notificationsList: notificationsList, garbageCollection: garbageCollection, registrySyncResult: default, activationStatus: activationStatus);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCacheRuleData ContainerRegistryCacheRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier credentialSetResourceId, string sourceRepository, string targetRepository, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState)
            => GenFactory.ContainerRegistryCacheRuleData(id: id, name: name, resourceType: resourceType, systemData: systemData, credentialSetResourceId: credentialSetResourceId, sourceRepository: sourceRepository, targetRepository: targetRepository, createdOn: createdOn, provisioningState: provisioningState, identity: default);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCredentialSetData ContainerRegistryCredentialSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, string loginServer, IEnumerable<ContainerRegistryAuthCredential> authCredentials, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState)
            => GenFactory.ContainerRegistryCredentialSetData(id: id, name: name, resourceType: resourceType, systemData: systemData, loginServer: loginServer, authCredentials: authCredentials, createdOn: createdOn, provisioningState: provisioningState, identity: identity);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, ContainerRegistryZoneRedundancy? zoneRedundancy, bool? isAnonymousPullEnabled)
            => GenFactory.ContainerRegistryData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, loginServer: loginServer, createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: isAnonymousPullEnabled, sku: sku, identity: identity);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, ContainerRegistryZoneRedundancy? zoneRedundancy)
            => GenFactory.ContainerRegistryData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, loginServer: loginServer, createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, zoneRedundancy: zoneRedundancy, sku: sku, identity: identity);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, bool? isNetworkRuleBypassAllowedForTasks, ContainerRegistryZoneRedundancy? zoneRedundancy, bool? isAnonymousPullEnabled, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope, ContainerRegistryRoleAssignmentMode? roleAssignmentMode)
            => GenFactory.ContainerRegistryData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, loginServer: loginServer, createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, isNetworkRuleBypassAllowedForTasks: isNetworkRuleBypassAllowedForTasks, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: isAnonymousPullEnabled, autoGeneratedDomainNameLabelScope: autoGeneratedDomainNameLabelScope, roleAssignmentMode: roleAssignmentMode, sku: sku, identity: identity);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryPrivateEndpointConnectionData ContainerRegistryPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, ContainerRegistryPrivateLinkServiceConnectionState connectionState, ContainerRegistryProvisioningState? provisioningState)
            => GenFactory.ContainerRegistryPrivateEndpointConnectionData(id: id, name: name, resourceType: resourceType, systemData: systemData, connectionState: connectionState, provisioningState: provisioningState, privateEndpointId: privateEndpointId);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryPrivateLinkResourceData ContainerRegistryPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string groupId, IEnumerable<string> requiredMembers, IEnumerable<string> requiredZoneNames)
            => GenFactory.ContainerRegistryPrivateLinkResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, groupId: groupId, requiredMembers: requiredMembers, requiredZoneNames: requiredZoneNames);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryReplicationData ContainerRegistryReplicationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isRegionEndpointEnabled, ContainerRegistryZoneRedundancy? zoneRedundancy)
            => GenFactory.ContainerRegistryReplicationData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, provisioningState: provisioningState, status: status, isRegionEndpointEnabled: isRegionEndpointEnabled, zoneRedundancy: zoneRedundancy);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTokenData ContainerRegistryTokenData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ResourceIdentifier scopeMapId, ContainerRegistryTokenCredentials credentials, ContainerRegistryTokenStatus? status)
            => GenFactory.ContainerRegistryTokenData(id: id, name: name, resourceType: resourceType, systemData: systemData, createdOn: createdOn, provisioningState: provisioningState, scopeMapId: scopeMapId, credentials: credentials, status: status);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookData ContainerRegistryWebhookData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistryWebhookStatus? status, string scope, IEnumerable<ContainerRegistryWebhookAction> actions, ContainerRegistryProvisioningState? provisioningState)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            return new ContainerRegistryWebhookData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                status is null && scope is null && actions is null && provisioningState is null ? default : new WebhookProperties(
                    status,
                    scope,
                    (actions ?? new ChangeTrackingList<ContainerRegistryWebhookAction>()).ToList(),
                    provisioningState,
                    null));
        }

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistryLoginServer ConnectedRegistryLoginServer(string host, ContainerRegistryTlsProperties tls)
            => GenFactory.ConnectedRegistryLoginServer(host: host, tls: tls);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistryStatusDetail ConnectedRegistryStatusDetail(string statusDetailType, string code, string description, DateTimeOffset? timestamp, Guid? correlationId)
            => GenFactory.ConnectedRegistryStatusDetail(statusDetailType: statusDetailType, code: code, description: description, timestamp: timestamp, correlationId: correlationId);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistrySyncProperties ConnectedRegistrySyncProperties(ResourceIdentifier tokenId, string schedule, TimeSpan? syncWindow, TimeSpan messageTtl, DateTimeOffset? lastSyncOn, string gatewayEndpoint)
            => GenFactory.ConnectedRegistrySyncProperties(tokenId: tokenId, schedule: schedule, syncWindow: syncWindow, messageTtl: messageTtl, lastSyncOn: lastSyncOn, gatewayEndpoint: gatewayEndpoint);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryAuthCredential ContainerRegistryAuthCredential(ContainerRegistryCredentialName? name, string usernameSecretIdentifier, string passwordSecretIdentifier, ContainerRegistryCredentialHealth credentialHealth)
            => GenFactory.ContainerRegistryAuthCredential(name: name, usernameSecretIdentifier: usernameSecretIdentifier, passwordSecretIdentifier: passwordSecretIdentifier, credentialHealth: credentialHealth);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCredentialHealth ContainerRegistryCredentialHealth(ContainerRegistryCredentialHealthStatus? status, string errorCode, string errorMessage)
            => GenFactory.ContainerRegistryCredentialHealth(status: status, errorCode: errorCode, errorMessage: errorMessage);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryGenerateCredentialsResult ContainerRegistryGenerateCredentialsResult(string username, IEnumerable<ContainerRegistryTokenPassword> passwords)
            => GenFactory.ContainerRegistryGenerateCredentialsResult(username: username, passwords: passwords);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportImageContent ContainerRegistryImportImageContent(ContainerRegistryImportSource source, IEnumerable<string> targetTags, IEnumerable<string> untaggedTargetRepositories, ContainerRegistryImportMode? mode)
            => GenFactory.ContainerRegistryImportImageContent(source: source, targetTags: targetTags, untaggedTargetRepositories: untaggedTargetRepositories, mode: mode);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportSource ContainerRegistryImportSource(ResourceIdentifier resourceId, string registryAddress, ContainerRegistryImportSourceCredentials credentials, string sourceImage)
            => GenFactory.ContainerRegistryImportSource(resourceId: resourceId, registryUri: registryAddress == null ? null : new Uri(registryAddress), credentials: credentials, sourceImage: sourceImage);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportSourceCredentials ContainerRegistryImportSourceCredentials(string username, string password)
            => GenFactory.ContainerRegistryImportSourceCredentials(username: username, password: password);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryKeyVaultProperties ContainerRegistryKeyVaultProperties(string keyIdentifier, string versionedKeyIdentifier, string identity, bool? isKeyRotationEnabled, DateTimeOffset? lastKeyRotationTimestamp)
            => GenFactory.ContainerRegistryKeyVaultProperties(keyIdentifier: keyIdentifier, versionedKeyIdentifier: versionedKeyIdentifier, identity: identity, isKeyRotationEnabled: isKeyRotationEnabled, lastKeyRotationTimestamp: lastKeyRotationTimestamp);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryListCredentialsResult ContainerRegistryListCredentialsResult(string username, IEnumerable<ContainerRegistryPassword> passwords)
            => GenFactory.ContainerRegistryListCredentialsResult(username: username, passwords: passwords);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name, ContainerRegistryResourceType resourceType, string resourceGroupName, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope)
            => GenFactory.ContainerRegistryNameAvailabilityContent(name: name, resourceType: resourceType, resourceGroupName: resourceGroupName, autoGeneratedDomainNameLabelScope: autoGeneratedDomainNameLabelScope);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name, ContainerRegistryResourceType resourceType)
            => GenFactory.ContainerRegistryNameAvailabilityContent(name: name, resourceType: resourceType, resourceGroupName: default, autoGeneratedDomainNameLabelScope: default);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(bool? isNameAvailable, string reason, string message)
            => GenFactory.ContainerRegistryNameAvailableResult(availableLoginServerName: default, isNameAvailable: isNameAvailable, reason: reason, message: message);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(string availableLoginServerName, bool? isNameAvailable, string reason, string message)
            => GenFactory.ContainerRegistryNameAvailableResult(availableLoginServerName: availableLoginServerName, isNameAvailable: isNameAvailable, reason: reason, message: message);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryPassword ContainerRegistryPassword(ContainerRegistryPasswordName? name, string value)
            => GenFactory.ContainerRegistryPassword(name: name, value: value);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryResourceStatus ContainerRegistryResourceStatus(string displayStatus, string message, DateTimeOffset? timestamp)
            => GenFactory.ContainerRegistryResourceStatus(displayStatus: displayStatus, message: message, timestamp: timestamp);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryRetentionPolicy ContainerRegistryRetentionPolicy(int? days, DateTimeOffset? lastUpdatedOn, ContainerRegistryPolicyStatus? status)
            => GenFactory.ContainerRegistryRetentionPolicy(days: days, lastUpdatedOn: lastUpdatedOn, status: status);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistrySku ContainerRegistrySku(ContainerRegistrySkuName name, ContainerRegistrySkuTier? tier)
            => GenFactory.ContainerRegistrySku(name: name, tier: tier);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTlsCertificateProperties ContainerRegistryTlsCertificateProperties(ContainerRegistryCertificateType? certificateType, string certificateLocation)
            => GenFactory.ContainerRegistryTlsCertificateProperties(certificateType: certificateType, certificateLocation: certificateLocation);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTlsProperties ContainerRegistryTlsProperties(ContainerRegistryTlsStatus? status, ContainerRegistryTlsCertificateProperties certificate)
            => GenFactory.ContainerRegistryTlsProperties(status: status, certificate: certificate);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryTokenPassword ContainerRegistryTokenPassword(DateTimeOffset? createdOn, DateTimeOffset? expireOn, ContainerRegistryTokenPasswordName? name, string value)
            => GenFactory.ContainerRegistryTokenPassword(createdOn: createdOn, expireOn: expireOn, name: name, value: value);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryUsage ContainerRegistryUsage(string name, long? limit, long? currentValue, ContainerRegistryUsageUnit? unit)
            => GenFactory.ContainerRegistryUsage(name: name, limit: limit, currentValue: currentValue, unit: unit);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookCallbackConfig ContainerRegistryWebhookCallbackConfig(Uri serviceUri, IReadOnlyDictionary<string, string> customHeaders)
            => GenFactory.ContainerRegistryWebhookCallbackConfig(serviceUri: serviceUri, customHeaders: customHeaders);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookCreateOrUpdateContent ContainerRegistryWebhookCreateOrUpdateContent(IDictionary<string, string> tags, AzureLocation location, Uri serviceUri, IDictionary<string, string> customHeaders, ContainerRegistryWebhookStatus? status, string scope, IEnumerable<ContainerRegistryWebhookAction> actions)
            => GenFactory.ContainerRegistryWebhookCreateOrUpdateContent(tags: tags, location: location, customHeaders: customHeaders, status: status, scope: scope, actions: actions, serviceUri: serviceUri);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEvent ContainerRegistryWebhookEvent(Guid? id, ContainerRegistryWebhookEventRequestMessage eventRequestMessage, ContainerRegistryWebhookEventResponseMessage eventResponseMessage)
            => GenFactory.ContainerRegistryWebhookEvent(id: id, eventRequestMessage: eventRequestMessage, eventResponseMessage: eventResponseMessage);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventContent ContainerRegistryWebhookEventContent(Guid? id, DateTimeOffset? timestamp, string action, ContainerRegistryWebhookEventTarget target, ContainerRegistryWebhookEventRequestContent request, string actorName, ContainerRegistryWebhookEventSource source)
            => GenFactory.ContainerRegistryWebhookEventContent(id: id, timestamp: timestamp, action: action, target: target, request: request, actorName: actorName, source: source);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventInfo ContainerRegistryWebhookEventInfo(Guid? id)
            => GenFactory.ContainerRegistryWebhookEventInfo(id: id);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventRequestContent ContainerRegistryWebhookEventRequestContent(Guid? id, string addr, string host, string method, string userAgent)
            => GenFactory.ContainerRegistryWebhookEventRequestContent(id: id, addr: addr, host: host, @method: method, userAgent: userAgent);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventRequestMessage ContainerRegistryWebhookEventRequestMessage(ContainerRegistryWebhookEventContent content, IReadOnlyDictionary<string, string> headers, string method, Uri requestUri, string version)
            => GenFactory.ContainerRegistryWebhookEventRequestMessage(content: content, headers: headers, @method: method, requestUri: requestUri, version: version);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventResponseMessage ContainerRegistryWebhookEventResponseMessage(string content, IReadOnlyDictionary<string, string> headers, string reasonPhrase, string statusCode, string version)
            => GenFactory.ContainerRegistryWebhookEventResponseMessage(content: content, headers: headers, reasonPhrase: reasonPhrase, statusCode: statusCode, version: version);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventSource ContainerRegistryWebhookEventSource(string addr, string instanceId)
            => GenFactory.ContainerRegistryWebhookEventSource(addr: addr, instanceId: instanceId);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookEventTarget ContainerRegistryWebhookEventTarget(string mediaType, long? size, string digest, long? length, string repository, Uri uri, string tag, string name, string version)
            => GenFactory.ContainerRegistryWebhookEventTarget(mediaType: mediaType, size: size, digest: digest, length: length, repository: repository, uri: uri, tag: tag, name: name, version: version);

        /// <summary> Backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ScopeMapData ScopeMapData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, string scopeMapType, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, IEnumerable<string> actions)
            => GenFactory.ScopeMapData(id: id, name: name, resourceType: resourceType, systemData: systemData, description: description, scopeMapType: scopeMapType, createdOn: createdOn, provisioningState: provisioningState, actions: actions);
    }
}
