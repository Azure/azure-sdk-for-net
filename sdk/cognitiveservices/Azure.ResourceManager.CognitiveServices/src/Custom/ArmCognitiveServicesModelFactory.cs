// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public static partial class ArmCognitiveServicesModelFactory
    {
        // The regenerated factory adds parameters; retain the 1.7.0 signature for binary compatibility.
        /// <summary> Creates Cognitive Services account properties for mocking. </summary>
        /// <param name="provisioningState"> The account provisioning state. </param>
        /// <param name="endpoint"> The account endpoint. </param>
        /// <param name="capabilities"> The account capabilities. </param>
        /// <param name="isMigrated"> Whether the account was migrated. </param>
        /// <param name="migrationToken"> The migration token. </param>
        /// <param name="skuChangeInfo"> The SKU change information. </param>
        /// <param name="customSubDomainName"> The custom subdomain. </param>
        /// <param name="networkAcls"> The network rules. </param>
        /// <param name="encryption"> The encryption properties. </param>
        /// <param name="userOwnedStorage"> The user-owned storage accounts. </param>
        /// <param name="amlWorkspace"> The user-owned AML workspace. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="apiProperties"> The API properties. </param>
        /// <param name="createdOn"> The creation time. </param>
        /// <param name="callRateLimit"> The call rate limit. </param>
        /// <param name="enableDynamicThrottling"> Whether dynamic throttling is enabled. </param>
        /// <param name="isStoredCompletionsDisabled"> Whether stored completions are disabled. </param>
        /// <param name="isA365LoggingEnabled"> Whether A365 logging is enabled. </param>
        /// <param name="quotaLimit"> The quota limit. </param>
        /// <param name="restrictOutboundNetworkAccess"> Whether outbound network access is restricted. </param>
        /// <param name="allowedFqdnList"> The allowed FQDNs. </param>
        /// <param name="disableLocalAuth"> Whether local authentication is disabled. </param>
        /// <param name="endpoints"> The account endpoints. </param>
        /// <param name="restore"> Whether the account is being restored. </param>
        /// <param name="deletedOn"> The deletion time. </param>
        /// <param name="scheduledPurgeDate"> The scheduled purge date. </param>
        /// <param name="locations"> The multiregion settings. </param>
        /// <param name="commitmentPlanAssociations"> The commitment plan associations. </param>
        /// <param name="abusePenalty"> The abuse penalty. </param>
        /// <param name="raiMonitorConfig"> The RAI monitor configuration. </param>
        /// <param name="aiFoundryNetworkInjections"> The AI Foundry network injections. </param>
        /// <param name="allowProjectManagement"> Whether project management is allowed. </param>
        /// <param name="defaultProject"> The default project. </param>
        /// <param name="associatedProjects"> The associated projects. </param>
        /// <param name="trustedCertificateSources"> The trusted certificate sources. </param>
        /// <returns> A new account properties instance. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountProperties CognitiveServicesAccountProperties(ServiceAccountProvisioningState? provisioningState, string endpoint, IEnumerable<CognitiveServicesSkuCapability> capabilities, bool? isMigrated, string migrationToken, CognitiveServicesSkuChangeInfo skuChangeInfo, string customSubDomainName, CognitiveServicesNetworkRuleSet networkAcls, ServiceAccountEncryptionProperties encryption, IEnumerable<ServiceAccountUserOwnedStorage> userOwnedStorage, UserOwnedAmlWorkspace amlWorkspace, IEnumerable<CognitiveServicesPrivateEndpointConnectionData> privateEndpointConnections, ServiceAccountPublicNetworkAccess? publicNetworkAccess, ServiceAccountApiProperties apiProperties, DateTimeOffset? createdOn, ServiceAccountCallRateLimit callRateLimit, bool? enableDynamicThrottling, bool? isStoredCompletionsDisabled, bool? isA365LoggingEnabled, ServiceAccountQuotaLimit quotaLimit, bool? restrictOutboundNetworkAccess, IEnumerable<string> allowedFqdnList, bool? disableLocalAuth, IReadOnlyDictionary<string, string> endpoints, bool? restore, DateTimeOffset? deletedOn, string scheduledPurgeDate, CognitiveServicesMultiRegionSettings locations, IEnumerable<CommitmentPlanAssociation> commitmentPlanAssociations, AbusePenalty abusePenalty, RaiMonitorConfig raiMonitorConfig, IEnumerable<AIFoundryNetworkInjection> aiFoundryNetworkInjections, bool? allowProjectManagement, string defaultProject, IEnumerable<string> associatedProjects, IEnumerable<CognitiveServicesTrustedCertificateSource> trustedCertificateSources)
        {
            return CognitiveServicesAccountProperties(provisioningState, endpoint, capabilities, isMigrated, migrationToken, skuChangeInfo, customSubDomainName, networkAcls, encryption, userOwnedStorage, amlWorkspace, privateEndpointConnections, publicNetworkAccess, apiProperties, createdOn, callRateLimit, enableDynamicThrottling, isStoredCompletionsDisabled, isA365LoggingEnabled, quotaLimit, restrictOutboundNetworkAccess, allowedFqdnList, disableLocalAuth, endpoints, restore, deletedOn, scheduledPurgeDate, locations, commitmentPlanAssociations, abusePenalty, raiMonitorConfig, aiFoundryNetworkInjections, default, allowProjectManagement, defaultProject, associatedProjects, default, default, trustedCertificateSources, default);
        }

        // The regenerated factory adds a parameter; retain the 1.7.0 signature for binary compatibility.
        /// <summary> Creates Cognitive Services account deployment properties for mocking. </summary>
        /// <param name="provisioningState"> The deployment provisioning state. </param>
        /// <param name="model"> The deployment model. </param>
        /// <param name="contextCacheContainerId"> The context cache container resource ID. </param>
        /// <param name="scaleSettings"> The deployment scale settings. </param>
        /// <param name="capabilities"> The deployment capabilities. </param>
        /// <param name="raiPolicyName"> The RAI policy name. </param>
        /// <param name="callRateLimit"> The call rate limit. </param>
        /// <param name="rateLimits"> The throttling rules. </param>
        /// <param name="versionUpgradeOption"> The model version upgrade option. </param>
        /// <param name="isDynamicThrottlingEnabled"> Whether dynamic throttling is enabled. </param>
        /// <param name="currentCapacity"> The current capacity. </param>
        /// <param name="capacitySettings"> The capacity settings. </param>
        /// <param name="parentDeploymentName"> The parent deployment name. </param>
        /// <param name="spilloverDeploymentName"> The spillover deployment name. </param>
        /// <param name="serviceTier"> The deployment service tier. </param>
        /// <param name="deploymentState"> The deployment state. </param>
        /// <param name="routing"> The deployment routing configuration. </param>
        /// <returns> A new deployment properties instance. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountDeploymentProperties CognitiveServicesAccountDeploymentProperties(CognitiveServicesAccountDeploymentProvisioningState? provisioningState, CognitiveServicesAccountDeploymentModel model, ResourceIdentifier contextCacheContainerId, CognitiveServicesAccountDeploymentScaleSettings scaleSettings, IReadOnlyDictionary<string, string> capabilities, string raiPolicyName, ServiceAccountCallRateLimit callRateLimit, IEnumerable<ServiceAccountThrottlingRule> rateLimits, DeploymentModelVersionUpgradeOption? versionUpgradeOption, bool? isDynamicThrottlingEnabled, int? currentCapacity, DeploymentCapacitySettings capacitySettings, string parentDeploymentName, string spilloverDeploymentName, CognitiveServicesDeploymentServiceTier? serviceTier, CognitiveServicesDeploymentState? deploymentState, CognitiveServicesDeploymentRouting routing)
        {
            return CognitiveServicesAccountDeploymentProperties(provisioningState, model, contextCacheContainerId, default, scaleSettings, capabilities, raiPolicyName, callRateLimit, rateLimits, versionUpgradeOption, isDynamicThrottlingEnabled, currentCapacity, capacitySettings, parentDeploymentName, spilloverDeploymentName, serviceTier, deploymentState, routing);
        }

        // The regenerated factory adds parameters; retain the 1.7.0 signature for binary compatibility.
        /// <summary> Creates RAI policy properties for mocking. </summary>
        /// <param name="policyType"> The policy type. </param>
        /// <param name="mode"> The policy mode. </param>
        /// <param name="basePolicyName"> The base policy name. </param>
        /// <param name="contentFilters"> The content filters. </param>
        /// <param name="customBlocklists"> The custom blocklists. </param>
        /// <param name="safetyProviders"> The safety providers. </param>
        /// <param name="egressPolicy"> The egress policy. </param>
        /// <returns> A new RAI policy properties instance. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RaiPolicyProperties RaiPolicyProperties(RaiPolicyType? policyType, RaiPolicyMode? mode, string basePolicyName, IEnumerable<RaiPolicyContentFilter> contentFilters, IEnumerable<CustomBlocklistConfig> customBlocklists, IEnumerable<RaiSafetyProviderSourceConfig> safetyProviders, RaiEgressPolicyConfig egressPolicy)
        {
            return RaiPolicyProperties(default, default, default, policyType, mode, basePolicyName, contentFilters, customBlocklists, safetyProviders, default, egressPolicy);
        }

        /// <summary> Cognitive Services account is an Azure resource representing the provisioned account, its type, location and SKU. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="kind"> The account kind. </param>
        /// <param name="sku"> The account SKU. </param>
        /// <param name="identity"> The account identity. </param>
        /// <param name="properties"> The account properties. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesAccountData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountData CognitiveServicesAccountData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, string kind = default, CognitiveServicesSku sku = default, ManagedServiceIdentity identity = default, CognitiveServicesAccountProperties properties = default, ETag? etag = default)
        {
            return CognitiveServicesAccountData(id, name, resourceType, systemData, tags, location, properties, etag, kind, sku, identity);
        }

        /// <summary> The Private Endpoint Connection resource. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="location"> The private endpoint connection location. </param>
        /// <param name="privateEndpointId"> The private endpoint resource ID. </param>
        /// <param name="connectionState"> The private link connection state. </param>
        /// <param name="provisioningState"> The connection provisioning state. </param>
        /// <param name="groupIds"> The private link resource group IDs. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesPrivateEndpointConnectionData CognitiveServicesPrivateEndpointConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, AzureLocation? location = default, ResourceIdentifier privateEndpointId = default, CognitiveServicesPrivateLinkServiceConnectionState connectionState = default, CognitiveServicesPrivateEndpointConnectionProvisioningState? provisioningState = default, IEnumerable<string> groupIds = default, ETag? etag = default)
        {
            return CognitiveServicesPrivateEndpointConnectionData(id, name, resourceType, systemData, connectionState, provisioningState, groupIds, privateEndpointId, etag, location);
        }

        /// <summary> Cognitive Services account Model. </summary>
        /// <param name="publisher"> Deployment model publisher. </param>
        /// <param name="format"> Deployment model format. </param>
        /// <param name="name"> Deployment model name. </param>
        /// <param name="version"> Deployment model version. </param>
        /// <param name="source"> Deployment model source ARM resource ID. </param>
        /// <param name="sourceAccount"> Source account ARM resource ID. </param>
        /// <param name="callRateLimit"> The model call rate limit. </param>
        /// <param name="baseModel"> The base deployment model. </param>
        /// <param name="isDefaultVersion"> Whether this is the default model version. </param>
        /// <param name="skus"> The model SKUs. </param>
        /// <param name="maxCapacity"> The maximum capacity. </param>
        /// <param name="capabilities"> The model capabilities. </param>
        /// <param name="finetuneCapabilities"> The finetuning capabilities. </param>
        /// <param name="deprecation"> Model deprecation information. </param>
        /// <param name="lifecycleStatus"> The model lifecycle status. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <returns> A new <see cref="Models.CognitiveServicesAccountModel"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountModel CognitiveServicesAccountModel(string publisher = default, string format = default, string name = default, string version = default, string source = default, ResourceIdentifier sourceAccount = default, ServiceAccountCallRateLimit callRateLimit = default, CognitiveServicesAccountDeploymentModel baseModel = default, bool? isDefaultVersion = default, IEnumerable<CognitiveServicesModelSku> skus = default, int? maxCapacity = default, IDictionary<string, string> capabilities = default, IDictionary<string, string> finetuneCapabilities = default, ServiceAccountModelDeprecationInfo deprecation = default, ModelLifecycleStatus? lifecycleStatus = default, SystemData systemData = default)
        {
            return CognitiveServicesAccountModel(publisher, format, name, version, source, sourceAccount, callRateLimit, baseModel, isDefaultVersion, skus, maxCapacity, capabilities, finetuneCapabilities, deprecation, default, default, lifecycleStatus, systemData);
        }

        /// <summary> Cognitive Services account deployment. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="sku"> The deployment SKU. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="properties"> The deployment properties. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesAccountDeploymentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountDeploymentData CognitiveServicesAccountDeploymentData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, CognitiveServicesSku sku = default, ETag? etag = default, IDictionary<string, string> tags = default, CognitiveServicesAccountDeploymentProperties properties = default)
        {
            return CognitiveServicesAccountDeploymentData(id, name, resourceType, systemData, properties, sku, etag, tags);
        }

        /// <summary> Cognitive Services account commitment plan. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="kind"> The commitment plan kind. </param>
        /// <param name="sku"> The commitment plan SKU. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="properties"> The commitment plan properties. </param>
        /// <returns> A new <see cref="CognitiveServices.CommitmentPlanData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommitmentPlanData CommitmentPlanData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, string kind = default, CognitiveServicesSku sku = default, IDictionary<string, string> tags = default, AzureLocation? location = default, CommitmentPlanProperties properties = default)
        {
            return CommitmentPlanData(id, name, resourceType, systemData, properties, tags, location, etag, kind, sku);
        }

        /// <summary> Cognitive Services EncryptionScope. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="properties"> The encryption scope properties. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesEncryptionScopeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesEncryptionScopeData CognitiveServicesEncryptionScopeData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, CognitiveServicesEncryptionScopeProperties properties = default)
        {
            return CognitiveServicesEncryptionScopeData(id, name, resourceType, systemData, properties, etag, tags);
        }

        /// <summary> Cognitive Services RaiPolicy. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="properties"> The RAI policy properties. </param>
        /// <returns> A new <see cref="CognitiveServices.RaiPolicyData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RaiPolicyData RaiPolicyData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, RaiPolicyProperties properties = default)
        {
            return RaiPolicyData(id, name, resourceType, systemData, properties, etag, tags);
        }

        /// <summary> Cognitive Services RaiBlocklist. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="raiBlocklistDescription"> Description of the block list. </param>
        /// <returns> A new <see cref="CognitiveServices.RaiBlocklistData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RaiBlocklistData RaiBlocklistData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, string raiBlocklistDescription = default)
        {
            return RaiBlocklistData(id, name, resourceType, systemData, raiBlocklistDescription, etag, tags);
        }

        /// <summary> Cognitive Services RaiBlocklist Item. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="properties"> The blocklist item properties. </param>
        /// <returns> A new <see cref="CognitiveServices.RaiBlocklistItemData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RaiBlocklistItemData RaiBlocklistItemData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, RaiBlocklistItemProperties properties = default)
        {
            return RaiBlocklistItemData(id, name, resourceType, systemData, properties, etag, tags);
        }

        /// <summary> The commitment plan association. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="accountId"> The Azure resource ID of the account. </param>
        /// <returns> A new <see cref="CognitiveServices.CommitmentPlanAccountAssociationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommitmentPlanAccountAssociationData CommitmentPlanAccountAssociationData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, string accountId = default)
        {
            return CommitmentPlanAccountAssociationData(id, name, resourceType, systemData, accountId, etag, tags);
        }

        /// <summary> The Defender for AI resource. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="state"> Defender for AI state on the AI resource. </param>
        /// <returns> A new <see cref="CognitiveServices.DefenderForAISettingData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DefenderForAISettingData DefenderForAISettingData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> tags = default, DefenderForAISettingState? state = default)
        {
            return DefenderForAISettingData(id, name, resourceType, systemData, state, etag, tags);
        }

        /// <summary> Cognitive Services project is an Azure resource representing the provisioned account's project. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> Resource creation and modification metadata. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="identity"> The project identity. </param>
        /// <param name="properties"> The project properties. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesProjectData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesProjectData CognitiveServicesProjectData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ManagedServiceIdentity identity = default, CognitiveServicesProjectProperties properties = default, ETag? etag = default)
        {
            return CognitiveServicesProjectData(id, name, resourceType, systemData, tags, location, properties, etag, identity);
        }

        /// <summary> The CognitiveServicesCapabilityHostProperties. </summary>
        /// <param name="description"> The asset description text. </param>
        /// <param name="tags"> The tag dictionary. </param>
        /// <param name="aiServicesConnections"> The AI services connections. </param>
        /// <param name="capabilityHostKind"> The capability host kind. </param>
        /// <param name="customerSubnet"> The customer subnet. </param>
        /// <param name="provisioningState"> The capability host provisioning state. </param>
        /// <param name="storageConnections"> The storage connections. </param>
        /// <param name="threadStorageConnections"> The thread storage connections. </param>
        /// <param name="vectorStoreConnections"> The vector store connections. </param>
        /// <returns> A new <see cref="Models.CognitiveServicesCapabilityHostProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesCapabilityHostProperties CognitiveServicesCapabilityHostProperties(string description = default, IDictionary<string, string> tags = default, IEnumerable<string> aiServicesConnections = default, CapabilityHostKind? capabilityHostKind = default, string customerSubnet = default, CapabilityHostProvisioningState? provisioningState = default, IEnumerable<string> storageConnections = default, IEnumerable<string> threadStorageConnections = default, IEnumerable<string> vectorStoreConnections = default)
        {
            return CognitiveServicesCapabilityHostProperties(description, tags, aiServicesConnections, capabilityHostKind, customerSubnet, provisioningState, storageConnections, threadStorageConnections, vectorStoreConnections, default);
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServices.CognitiveServicesAccountDeploymentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The resource model definition representing SKU. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="properties"> Properties of Cognitive Services account deployment. </param>
        /// <returns> A new <see cref="CognitiveServices.CognitiveServicesAccountDeploymentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CognitiveServicesAccountDeploymentData CognitiveServicesAccountDeploymentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CognitiveServicesSku sku, ETag? etag, CognitiveServicesAccountDeploymentProperties properties)
        {
            return CognitiveServicesAccountDeploymentData(id, name, resourceType, systemData, sku, etag, default, properties);
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServices.CommitmentPlanAccountAssociationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="accountId"> The Azure resource id of the account. </param>
        /// <returns> A new <see cref="CognitiveServices.CommitmentPlanAccountAssociationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommitmentPlanAccountAssociationData CommitmentPlanAccountAssociationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, string accountId)
        {
            return CommitmentPlanAccountAssociationData(id, name, resourceType, systemData, etag, default, accountId);
        }
    }
}
