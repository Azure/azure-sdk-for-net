// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Suppress the generated ModelFactory method that takes internal WebhookProperties
    // as a parameter (causes CS0051: inconsistent accessibility).
    // The backward-compatible method with flat parameters is still generated.
    [CodeGenSuppress("ContainerRegistryWebhookData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WebhookProperties))]
    public static partial class ArmContainerRegistryModelFactory
    {
        /// <summary> Backward compatibility overload — positional ConnectedRegistryData (17 params, activationStatus at pos 10). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistryData ConnectedRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ContainerRegistryProvisioningState? provisioningState, ConnectedRegistryMode? mode, string version, ConnectedRegistryConnectionState? connectionState, DateTimeOffset? lastActivityOn, ConnectedRegistryActivationStatus? activationStatus, ConnectedRegistryParent parent, IEnumerable<ResourceIdentifier> clientTokenIds, ConnectedRegistryLoginServer loginServer, ConnectedRegistryLogging logging, IEnumerable<ConnectedRegistryStatusDetail> statusDetails, IEnumerable<string> notificationsList, GarbageCollectionProperties garbageCollection)
        {
            // Position 10 in new method is ConnectedRegistryParent (vs ConnectedRegistryActivationStatus? here), so pass parent positionally to disambiguate
            return ConnectedRegistryData(id, name, resourceType, systemData, provisioningState, mode, version, connectionState, lastActivityOn, parent,
                clientTokenIds: clientTokenIds, loginServer: loginServer, logging: logging, statusDetails: statusDetails, notificationsList: notificationsList, garbageCollection: garbageCollection, registrySyncResult: default, activationStatus: activationStatus);
        }

        /// <summary> Backward compatibility overload — optional ConnectedRegistryData (18 params, activationStatus at pos 10). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectedRegistryData ConnectedRegistryData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?), ConnectedRegistryMode? mode = default(ConnectedRegistryMode?), string version = null, ConnectedRegistryConnectionState? connectionState = default(ConnectedRegistryConnectionState?), DateTimeOffset? lastActivityOn = default(DateTimeOffset?), ConnectedRegistryActivationStatus? activationStatus = default(ConnectedRegistryActivationStatus?), ConnectedRegistryParent parent = null, IEnumerable<ResourceIdentifier> clientTokenIds = null, ConnectedRegistryLoginServer loginServer = null, ConnectedRegistryLogging logging = null, IEnumerable<ConnectedRegistryStatusDetail> statusDetails = null, IEnumerable<string> notificationsList = null, GarbageCollectionProperties garbageCollection = null, ContainerRegistrySyncResult registrySyncResult = null)
        {
            return ConnectedRegistryData(id, name, resourceType, systemData, provisioningState, mode, version, connectionState, lastActivityOn, parent,
                clientTokenIds: clientTokenIds, loginServer: loginServer, logging: logging, statusDetails: statusDetails, notificationsList: notificationsList, garbageCollection: garbageCollection, registrySyncResult: registrySyncResult, activationStatus: activationStatus);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryCacheRuleData (9 params, no identity). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCacheRuleData ContainerRegistryCacheRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier credentialSetResourceId, string sourceRepository, string targetRepository, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState)
        {
            return ContainerRegistryCacheRuleData(id, name, resourceType, systemData, credentialSetResourceId,
                sourceRepository: sourceRepository, targetRepository: targetRepository, createdOn: createdOn, provisioningState: provisioningState, identity: default);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryCacheRuleData (10 params, identity at pos 5). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCacheRuleData ContainerRegistryCacheRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, ManagedServiceIdentity identity = null, ResourceIdentifier credentialSetResourceId = null, string sourceRepository = null, string targetRepository = null, DateTimeOffset? createdOn = default(DateTimeOffset?), ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?))
        {
            // Position 5 in new is ResourceIdentifier credentialSetResourceId (vs ManagedServiceIdentity here)
            return ContainerRegistryCacheRuleData(id, name, resourceType, systemData, credentialSetResourceId,
                sourceRepository: sourceRepository, targetRepository: targetRepository, createdOn: createdOn, provisioningState: provisioningState, identity: identity);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryCredentialSetData (9 params, identity at pos 5). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryCredentialSetData ContainerRegistryCredentialSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, ManagedServiceIdentity identity = null, string loginServer = null, IEnumerable<ContainerRegistryAuthCredential> authCredentials = null, DateTimeOffset? createdOn = default(DateTimeOffset?), ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?))
        {
            // Position 5 in new is string loginServer (vs ManagedServiceIdentity here)
            return ContainerRegistryCredentialSetData(id, name, resourceType, systemData, loginServer,
                authCredentials: authCredentials, createdOn: createdOn, provisioningState: provisioningState, identity: identity);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryData (22 params, sku/identity at pos 7-8). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, ContainerRegistryZoneRedundancy? zoneRedundancy)
        {
            // Position 7 in new is string loginServer (vs ContainerRegistrySku here)
            return ContainerRegistryData(id, name, resourceType, systemData, tags, location, loginServer,
                createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, regionalEndpoints: default, regionalEndpointHostNames: default, endpointProtocol: default, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, isNetworkRuleBypassAllowedForTasks: default, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: default, metadataSearch: default, autoGeneratedDomainNameLabelScope: default, roleAssignmentMode: default, sku: sku, identity: identity);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryData (23 params, adds isAnonymousPullEnabled). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, ContainerRegistryZoneRedundancy? zoneRedundancy, bool? isAnonymousPullEnabled)
        {
            return ContainerRegistryData(id, name, resourceType, systemData, tags, location, loginServer,
                createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, regionalEndpoints: default, regionalEndpointHostNames: default, endpointProtocol: default, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, isNetworkRuleBypassAllowedForTasks: default, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: isAnonymousPullEnabled, metadataSearch: default, autoGeneratedDomainNameLabelScope: default, roleAssignmentMode: default, sku: sku, identity: identity);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryData (26 params, adds isNetworkRuleBypass/autoGenerated/roleAssignment). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ContainerRegistrySku sku, ManagedServiceIdentity identity, string loginServer, DateTimeOffset? createdOn, ContainerRegistryProvisioningState? provisioningState, ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, ContainerRegistryNetworkRuleSet networkRuleSet, ContainerRegistryPolicies policies, ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, IEnumerable<string> dataEndpointHostNames, IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, ContainerRegistryPublicNetworkAccess? publicNetworkAccess, ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, bool? isNetworkRuleBypassAllowedForTasks, ContainerRegistryZoneRedundancy? zoneRedundancy, bool? isAnonymousPullEnabled, AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope, ContainerRegistryRoleAssignmentMode? roleAssignmentMode)
        {
            return ContainerRegistryData(id, name, resourceType, systemData, tags, location, loginServer,
                createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, regionalEndpoints: default, regionalEndpointHostNames: default, endpointProtocol: default, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, isNetworkRuleBypassAllowedForTasks: isNetworkRuleBypassAllowedForTasks, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: isAnonymousPullEnabled, metadataSearch: default, autoGeneratedDomainNameLabelScope: autoGeneratedDomainNameLabelScope, roleAssignmentMode: roleAssignmentMode, sku: sku, identity: identity);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryData (30 params, sku/identity at pos 7-8). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryData ContainerRegistryData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), ContainerRegistrySku sku = null, ManagedServiceIdentity identity = null, string loginServer = null, DateTimeOffset? createdOn = default(DateTimeOffset?), ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?), ContainerRegistryResourceStatus status = null, bool? isAdminUserEnabled = default(bool?), ContainerRegistryNetworkRuleSet networkRuleSet = null, ContainerRegistryPolicies policies = null, ContainerRegistryEncryption encryption = null, bool? isDataEndpointEnabled = default(bool?), IEnumerable<string> dataEndpointHostNames = null, RegionalEndpoint? regionalEndpoints = default(RegionalEndpoint?), IEnumerable<string> regionalEndpointHostNames = null, ContainerRegistryEndpointProtocol? endpointProtocol = default(ContainerRegistryEndpointProtocol?), IEnumerable<ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections = null, ContainerRegistryPublicNetworkAccess? publicNetworkAccess = default(ContainerRegistryPublicNetworkAccess?), ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions = default(ContainerRegistryNetworkRuleBypassOption?), bool? isNetworkRuleBypassAllowedForTasks = default(bool?), ContainerRegistryZoneRedundancy? zoneRedundancy = default(ContainerRegistryZoneRedundancy?), bool? isAnonymousPullEnabled = default(bool?), ContainerRegistryMetadataSearch? metadataSearch = default(ContainerRegistryMetadataSearch?), AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(AutoGeneratedDomainNameLabelScope?), ContainerRegistryRoleAssignmentMode? roleAssignmentMode = default(ContainerRegistryRoleAssignmentMode?))
        {
            // Position 7 in new is string loginServer (vs ContainerRegistrySku here)
            return ContainerRegistryData(id, name, resourceType, systemData, tags, location, loginServer,
                createdOn: createdOn, provisioningState: provisioningState, status: status, isAdminUserEnabled: isAdminUserEnabled, networkRuleSet: networkRuleSet, policies: policies, encryption: encryption, isDataEndpointEnabled: isDataEndpointEnabled, dataEndpointHostNames: dataEndpointHostNames, regionalEndpoints: regionalEndpoints, regionalEndpointHostNames: regionalEndpointHostNames, endpointProtocol: endpointProtocol, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, networkRuleBypassOptions: networkRuleBypassOptions, isNetworkRuleBypassAllowedForTasks: isNetworkRuleBypassAllowedForTasks, zoneRedundancy: zoneRedundancy, isAnonymousPullEnabled: isAnonymousPullEnabled, metadataSearch: metadataSearch, autoGeneratedDomainNameLabelScope: autoGeneratedDomainNameLabelScope, roleAssignmentMode: roleAssignmentMode, sku: sku, identity: identity);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryExportPipelineData (location/identity at pos 5-6). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryExportPipelineData ContainerRegistryExportPipelineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, AzureLocation? location = default(AzureLocation?), ManagedServiceIdentity identity = null, ContainerRegistryExportPipelineTargetProperties target = null, IEnumerable<PipelineOption> options = null, ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?))
        {
            // Position 5 in new is ContainerRegistryExportPipelineTargetProperties target (vs AzureLocation? here)
            return ContainerRegistryExportPipelineData(id, name, resourceType, systemData, target,
                options: options, provisioningState: provisioningState, location: location, identity: identity);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryImportPipelineData (location/identity at pos 5-6). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportPipelineData ContainerRegistryImportPipelineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, AzureLocation? location = default(AzureLocation?), ManagedServiceIdentity identity = null, ContainerRegistryImportPipelineSourceProperties source = null, ContainerRegistryTriggerStatus? sourceTriggerStatus = default(ContainerRegistryTriggerStatus?), IEnumerable<PipelineOption> options = null, ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?))
        {
            // Position 5 in new is ContainerRegistryImportPipelineSourceProperties source (vs AzureLocation? here)
            return ContainerRegistryImportPipelineData(id, name, resourceType, systemData, source,
                options: options, provisioningState: provisioningState, sourceTriggerStatus: sourceTriggerStatus, location: location, identity: identity);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryImportSource (registryAddress -> registryUri). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryImportSource ContainerRegistryImportSource(ResourceIdentifier resourceId = null, string registryAddress = null, ContainerRegistryImportSourceCredentials credentials = null, string sourceImage = null)
        {
            return ContainerRegistryImportSource(resourceId: resourceId, registryUri: default, credentials: credentials, sourceImage: sourceImage);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryNameAvailabilityContent (2 params). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name, ContainerRegistryResourceType resourceType)
        {
            return ContainerRegistryNameAvailabilityContent(name: name, resourceType: resourceType, resourceGroupName: default, autoGeneratedDomainNameLabelScope: default);
        }

        /// <summary> Backward compatibility overload — positional ContainerRegistryNameAvailableResult (3 params). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(bool? isNameAvailable, string reason, string message)
        {
            return ContainerRegistryNameAvailableResult(availableLoginServerName: default, isNameAvailable: isNameAvailable, reason: reason, message: message);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryPrivateEndpointConnectionData (privateEndpointId at pos 5). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryPrivateEndpointConnectionData ContainerRegistryPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, ResourceIdentifier privateEndpointId = null, ContainerRegistryPrivateLinkServiceConnectionState connectionState = null, ContainerRegistryProvisioningState? provisioningState = default(ContainerRegistryProvisioningState?))
        {
            // Position 5 in new is ContainerRegistryPrivateLinkServiceConnectionState (vs ResourceIdentifier here)
            return ContainerRegistryPrivateEndpointConnectionData(id, name, resourceType, systemData, connectionState,
                provisioningState: provisioningState, privateEndpointId: privateEndpointId);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryPrivateLinkResourceData (7 params, no groupName). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryPrivateLinkResourceData ContainerRegistryPrivateLinkResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default(ResourceType), SystemData systemData = null, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            return ContainerRegistryPrivateLinkResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, groupId: groupId, requiredMembers: requiredMembers, requiredZoneNames: requiredZoneNames, groupName: default);
        }

        /// <summary> Backward compatibility overload — optional ContainerRegistryWebhookCreateOrUpdateContent (serviceUri at pos 3). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ContainerRegistryWebhookCreateOrUpdateContent ContainerRegistryWebhookCreateOrUpdateContent(IDictionary<string, string> tags = null, AzureLocation location = default(AzureLocation), Uri serviceUri = null, IDictionary<string, string> customHeaders = null, ContainerRegistryWebhookStatus? status = default(ContainerRegistryWebhookStatus?), string scope = null, IEnumerable<ContainerRegistryWebhookAction> actions = null)
        {
            // Position 3 in new is IDictionary customHeaders (vs Uri serviceUri here)
            return ContainerRegistryWebhookCreateOrUpdateContent(tags, location, customHeaders,
                status: status, scope: scope, actions: actions, serviceUri: serviceUri);
        }
    }
}
