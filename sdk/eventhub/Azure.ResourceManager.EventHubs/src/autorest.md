# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHubs
output-folder: $(this-folder)/Generated
require: https://github.com/Azure/azure-rest-api-specs/blob/969e0846e56a0869203bcc52773415c71115f59e/specification/eventhub/resource-manager/readme.md
# tag: package-2022-10-preview
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true

modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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

rename-mapping:
  SchemaType: EventHubsSchemaType
  SchemaCompatibility: EventHubsSchemaCompatibility
  KeySource: EventHubsKeySource
  UnavailableReason: EventHubsNameUnavailableReason

directive:
    - from: ApplicationGroups.json
      where: $.definitions
      transform: >
        $.ApplicationGroupPolicy['x-ms-client-name'] = 'EventHubsApplicationGroupPolicy';
        $.ApplicationGroupListResult['x-ms-client-name'] = 'EventHubsApplicationGroupListResult';
        $.ThrottlingPolicy['x-ms-client-name'] = 'EventHubsThrottlingPolicy';
        $.ApplicationGroup['x-ms-client-name'] = 'EventHubsApplicationGroup';
    - from: AuthorizationRules.json
      where: $.definitions
      transform: >
        $.AuthorizationRule['x-ms-client-name'] = 'EventHubsAuthorizationRule';
        $.AuthorizationRule.properties.properties.properties.rights.items['x-ms-enum'].name = 'EventHubsAccessRight';
        $.AccessKeys['x-ms-client-name'] = 'EventHubsAccessKeys';
        $.RegenerateAccessKeyParameters['x-ms-client-name'] = 'EventHubsRegenerateAccessKeyContent';
        $.RegenerateAccessKeyParameters.properties.keyType['x-ms-enum'].name = 'EventHubsAccessKeyType';
    - from: consumergroups.json
      where: $.definitions
      transform: >
        $.ConsumerGroup['x-ms-client-name'] = 'EventHubsConsumerGroup';
    - from: disasterRecoveryConfigs.json
      where: $.definitions
      transform: >
        $.ArmDisasterRecovery['x-ms-client-name'] = 'EventHubsDisasterRecovery';
        $.ArmDisasterRecovery.properties.properties.properties.provisioningState['x-ms-enum'].name = 'EventHubsDisasterRecoveryProvisioningState';
        $.ArmDisasterRecovery.properties.properties.properties.role['x-ms-enum'].name = 'EventHubsDisasterRecoveryRole';
        $.CheckNameAvailabilityParameter['x-ms-client-name'] = 'EventHubsNameAvailabilityContent';
        $.CheckNameAvailabilityResult['x-ms-client-name'] = 'EventHubsNameAvailabilityResult';
    - from: Clusters-preview.json
      where: $.definitions
      transform: >
        $.Cluster['x-ms-client-name'] = 'EventHubsCluster';
        $.Cluster.properties.properties.properties.createdAt['format'] = 'date-time';
        $.Cluster.properties.properties.properties.updatedAt['format'] = 'date-time';
        $.ClusterSku['x-ms-client-name'] = 'EventHubsClusterSku';
        $.ClusterSku.properties.name['x-ms-enum'].name = 'EventHubsClusterSkuName';
    - from: eventhubs.json
      where: $.definitions
      transform: >
        $.Eventhub['x-ms-client-name'] = 'EventHub';
        $.Eventhub.properties.properties.properties.status['x-ms-enum'].name = 'EventHubEntityStatus';
        $.Destination['x-ms-client-name'] = 'EventHubDestination';
        $.Destination.properties.properties.properties.storageAccountResourceId['x-ms-format'] = 'arm-id';
        delete $.Eventhub.properties.properties.properties.messageRetentionInDays;
    - from: namespaces-preview.json
      where: $.definitions
      transform: >
        $.EHNamespace['x-ms-client-name'] = 'EventHubsNamespace';
        $.EHNamespace.properties.properties.properties.clusterArmId['x-ms-format'] = 'arm-id';
        $.PrivateLinkResource['x-ms-client-name'] = 'EventHubsPrivateLinkResourceData';
        $.PrivateEndpointConnectionProperties.properties.provisioningState['x-ms-enum'].name = 'EventHubsPrivateEndpointConnectionProvisioningState';
        $.ConnectionState['x-ms-client-name'] = 'EventHubsPrivateLinkServiceConnectionState';
        $.ConnectionState.properties.status['x-ms-enum'].name = 'EventHubsPrivateLinkConnectionStatus';
        $.Encryption['x-ms-client-name'] = 'EventHubsEncryption';
        $.KeyVaultProperties['x-ms-client-name'] = 'EventHubsKeyVaultProperties';
        $.KeyVaultProperties['x-ms-client-name'] = 'EventHubsKeyVaultProperties';
        $.NetworkSecurityPerimeterConfiguration.allOf[0]['$ref'] = '../../../common/v1/definitions.json#/definitions/TrackedResource';
    - from: CheckNameAvailability.json
      where: $.definitions
      transform: >
        $.CheckNameAvailabilityParameter['x-ms-client-name'] = 'EventHubsNameAvailabilityContent';
        $.CheckNameAvailabilityResult['x-ms-client-name'] = 'EventHubsNameAvailabilityResult';
        $.UnavailableReason['x-ms-client-name'] = 'EventHubsNameUnavailableReason';
    - from: networkrulessets-preview.json
      where: $.definitions
      transform: >
        $.NetworkRuleSet['x-ms-client-name'] = 'EventHubsNetworkRuleSet';
        $.NetworkRuleSet.properties.properties.properties.defaultAction['x-ms-enum'].name = 'EventHubsNetworkRuleSetDefaultAction';
        $.NetworkRuleSet.properties.properties.properties.publicNetworkAccess['x-ms-enum'].name = 'EventHubsPublicNetworkAccessFlag';
        $.NWRuleSetIpRules['x-ms-client-name'] = 'EventHubsNetworkRuleSetIPRules';
        $.NWRuleSetIpRules.properties.action['x-ms-enum'].name = 'EventHubsNetworkRuleIPAction';
        $.NWRuleSetVirtualNetworkRules['x-ms-client-name'] = 'EventHubsNetworkRuleSetVirtualNetworkRules';
    - from: SchemaRegistry.json
      where: $.definitions
      transform: >
        $.SchemaGroup['x-ms-client-name'] = 'EventHubsSchemaGroup';
        delete $.SchemaGroup.properties.properties.properties.eTag['format'];
#        $.SchemaGroup.properties.properties.properties.eTag['x-ms-format'] = 'etag';
    - from: AvailableClusterRegions-preview.json
      where: $.definitions
      transform: >
        $.AvailableCluster.properties.location['x-ms-format'] = 'azure-location';
```

