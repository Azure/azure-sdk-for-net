# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHubs
output-folder: $(this-folder)/Generated
require: https://github.com/Azure/azure-rest-api-specs/blob/412364b282e52b50eadc3cd88d56d283b6c8712a/specification/eventhub/resource-manager/readme.md
tag: package-2024-01
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-resource-name:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}: EventHubsDisasterRecovery
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}: EventHubsDisasterRecoveryAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}: EventHubAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}: EventHubsNamespaceAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/consumergroups/{consumerGroupName}: EventHubsConsumerGroup
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/applicationGroups/{applicationGroupName}: EventHubsApplicationGroup

override-operation-name:
    Namespaces_CheckNameAvailability: CheckEventHubsNamespaceNameAvailability
    DisasterRecoveryConfigs_CheckNameAvailability: CheckEventHubsDisasterRecoveryNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  ETag: ETag|eTag

prepend-rp-prefix:
  - TlsVersion
  - PublicNetworkAccess
  - ProvisioningIssueProperties
  - ProvisioningIssue
  - MetricId
  - NetworkSecurityPerimeter
  - NetworkSecurityPerimeterConfiguration
  - NetworkSecurityPerimeterConfigurationPropertiesProfile
  - NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation
  - NetworkSecurityPerimeterConfigurationProvisioningState
  - NspAccessRule
  - NspAccessRuleDirection
  - NspAccessRuleProperties
  - ResourceAssociationAccessMode
  - Cluster
  - ClusterSku
  - ClusterSkuName
  - NetworkRuleSet
  - Encryption
  - KeyVaultProperties
  - CaptureIdentity
  - CaptureIdentityType
  - ThrottlingPolicy
  - ApplicationGroup
  - AuthorizationRule
  - AccessKeys
  - AccessRights
  - ConsumerGroup
  - SchemaGroup

rename-mapping:
  SchemaType: EventHubsSchemaType
  SchemaCompatibility: EventHubsSchemaCompatibility
  KeySource: EventHubsKeySource
  Cluster.properties.createdAt: CreatedOn | datetime
  Cluster.properties.updatedAt: UpdatedOn | datetime
  EHNamespace: EventHubsNamespace
  EHNamespace.properties.clusterArmId: -|arm-id
  DefaultAction: EventHubsNetworkRuleSetDefaultAction
  PublicNetworkAccessFlag: EventHubsPublicNetworkAccessFlag
  NWRuleSetIpRules: EventHubsNetworkRuleSetIPRules
  NetworkRuleIPAction: EventHubsNetworkRuleIPAction
  NWRuleSetVirtualNetworkRules: EventHubsNetworkRuleSetVirtualNetworkRules
  EndPointProvisioningState: EventHubsPrivateEndpointConnectionProvisioningState
  ConnectionState: EventHubsPrivateLinkServiceConnectionState
  PrivateLinkConnectionStatus: EventHubsPrivateLinkConnectionStatus
  PrivateLinkResource: EventHubsPrivateLinkResourceData
  ProvisioningState: EventHubsClusterProvisioningState
  CleanupPolicyRetentionDescription.Compact: Compaction
  NetworkSecurityPerimeterConfiguration.properties.sourceResourceId: -|arm-id
  ApplicationGroupPolicy: EventHubsApplicationGroupPolicy
  ApplicationGroupListResult: EventHubsApplicationGroupListResult
  RegenerateAccessKeyParameters: EventHubsRegenerateAccessKeyContent
  KeyType: EventHubsAccessKeyType
  ArmDisasterRecovery: EventHubsDisasterRecovery
  ProvisioningStateDR: EventHubsDisasterRecoveryProvisioningState
  RoleDisasterRecovery: EventHubsDisasterRecoveryRole
  Eventhub: EventHub
  Destination: EventHubDestination
  Destination.properties.storageAccountResourceId: -|arm-id
  EntityStatus: EventHubEntityStatus
  CheckNameAvailabilityParameter: EventHubsNameAvailabilityContent
  CheckNameAvailabilityResult: EventHubsNameAvailabilityResult
  UnavailableReason: EventHubsNameUnavailableReason
  FailOver: NamespaceFailOverContent
  FailOver.properties.primaryLocation: -|azure-location
  GeoDataReplicationProperties: NamespaceGeoDataReplicationProperties
  GeoDRRoleType: NamespaceGeoDRRoleType
  NamespaceReplicaLocation.clusterArmId: -|arm-id

directive:
    - from: eventhubs.json
      where: $.definitions
      transform: >
        delete $.Eventhub.properties.properties.properties.messageRetentionInDays;
    - from: SchemaRegistry.json
      where: $.definitions
      transform: >
        delete $.SchemaGroup.properties.properties.properties.eTag['format'];
    # solve dup ErrorResponse error
    - from: namespaces-preview.json
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/failover'].post
      transform: >
        $.responses.default['schema']['$ref'] = '../../../common/v2/definitions.json#/definitions/ErrorResponse';
```

