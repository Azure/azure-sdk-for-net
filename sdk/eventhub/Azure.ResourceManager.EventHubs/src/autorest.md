# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHubs
tag: package-2021-11
require: https://github.com/Azure/azure-rest-api-specs/blob/8fb0263a6adbb529a9a7bf3e56110f3abdd55c72/specification/eventhub/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true

request-path-to-resource-name:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}: EventHubDisasterRecovery
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}: EventHubDisasterRecoveryAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}: EventHubAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}: EventHubNamespaceAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/consumergroups/{consumerGroupName}: EventHubConsumerGroup
override-operation-name:
    Namespaces_CheckNameAvailability: CheckEventHubNamespaceNameAvailability
    DisasterRecoveryConfigs_CheckNameAvailability: CheckEventHubDisasterRecoveryNameAvailability
rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

directive:
    - from: namespaces-preview.json
      where: $.definitions.Encryption
      transform: $['x-ms-client-flatten'] = false
    - from: namespaces-preview.json
      where: $.definitions.Identity
      transform: $['x-ms-client-flatten'] = false
    - from: namespaces-preview.json
      where: $.definitions.userAssignedIdentityProperties
      transform: $['x-ms-client-flatten'] = false
# change the type name of Identity so that it can be replaced by ResourceIdentity
    - from: swagger-document
      where: $.definitions.Identity.properties.type["x-ms-enum"]["name"]
      transform: return "ResourceIdentityType"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}'].put.operationId
      transform: return "EventHubClusters_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}'].patch.operationId
      transform: return "EventHubClusters_Update"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/clusters/{clusterName}'].delete.operationId
      transform: return "EventHubClusters_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].put.operationId
      transform: return "EventHubNamespaces_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].patch.operationId
      transform: return "EventHubNamespaces_Update"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].delete.operationId
      transform: return "EventHubNamespaces_Delete"
    - from: AuthorizationRules.json
      where: $.definitions
      transform: >
        $.AuthorizationRule['x-ms-client-name'] = 'EventHubAuthorizationRule';
        $.AuthorizationRule.properties.properties.properties.rights.items['x-ms-enum'].name = 'EventHubAccessRight';
        $.AccessKeys['x-ms-client-name'] = 'EventHubAccessKeys';
        $.RegenerateAccessKeyParameters['x-ms-client-name'] = 'EventHubsRegenerateAccessKeyContent';
        $.RegenerateAccessKeyParameters.properties.keyType['x-ms-enum'].name = 'EventHubsAccessKeyType';
    - from: consumergroups.json
      where: $.definitions
      transform: >
        $.ConsumerGroup['x-ms-client-name'] = 'EventHubConsumerGroup';
    - from: disasterRecoveryConfigs.json
      where: $.definitions
      transform: >
        $.ArmDisasterRecovery['x-ms-client-name'] = 'EventHubDisasterRecovery';
        $.ArmDisasterRecovery.properties.properties.properties.provisioningState['x-ms-enum'].name = 'EventHubDisasterRecoveryProvisioningState';
        $.ArmDisasterRecovery.properties.properties.properties.role['x-ms-enum'].name = 'EventHubDisasterRecoveryRole';
        $.CheckNameAvailabilityParameter['x-ms-client-name'] = 'EventHubNameAvailabilityContent';
        $.CheckNameAvailabilityResult['x-ms-client-name'] = 'EventHubNameAvailabilityResult';
    - from: Clusters-preview.json
      where: $.definitions
      transform: >
        $.Cluster['x-ms-client-name'] = 'EventHubCluster';
        $.Cluster.properties.properties.properties.createdAt['format'] = 'date-time';
        $.Cluster.properties.properties.properties.updatedAt['format'] = 'date-time';
        $.ClusterSku['x-ms-client-name'] = 'EventHubClusterSku';
        $.ClusterSku.properties.name['x-ms-enum'].name = 'EventHubClusterSkuName';
    - from: eventhubs.json
      where: $.definitions
      transform: >
        $.Eventhub['x-ms-client-name'] = 'EventHub';
        $.Eventhub.properties.properties.properties.status['x-ms-enum'].name = 'EventHubEntityStatus';
        $.Destination['x-ms-client-name'] = 'EventHubDestination';
        $.Destination.properties.properties.properties.storageAccountResourceId['x-ms-format'] = 'arm-id';
    - from: namespaces-preview.json
      where: $.definitions
      transform: >
        $.EHNamespace['x-ms-client-name'] = 'EventHubNamespace';
        $.EHNamespace.properties.properties.properties.clusterArmId['x-ms-format'] = 'arm-id';
        $.PrivateLinkResource['x-ms-client-name'] = 'EventHubPrivateLinkResourceData';
        $.PrivateEndpointConnectionProperties.properties.provisioningState['x-ms-enum'].name = 'EventHubPrivateEndpointConnectionProvisioningState';
        $.ConnectionState['x-ms-client-name'] = 'EventHubPrivateLinkServiceConnectionState';
        $.ConnectionState.properties.status['x-ms-enum'].name = 'EventHubPrivateLinkConnectionStatus';
        $.Encryption['x-ms-client-name'] = 'EventHubEncryption';
        $.KeyVaultProperties['x-ms-client-name'] = 'EventHubKeyVaultProperties';
    - from: CheckNameAvailability.json
      where: $.definitions
      transform: >
        $.CheckNameAvailabilityParameter['x-ms-client-name'] = 'EventHubNameAvailabilityContent';
        $.CheckNameAvailabilityResult['x-ms-client-name'] = 'EventHubNameAvailabilityResult';
        $.UnavailableReason['x-ms-client-name'] = 'EventHubNameUnavailableReason';
    - from: networkrulessets-preview.json
      where: $.definitions
      transform: >
        $.NetworkRuleSet['x-ms-client-name'] = 'EventHubNetworkRuleSet';
        $.NetworkRuleSet.properties.properties.properties.defaultAction['x-ms-enum'].name = 'EventHubNetworkRuleSetDefaultAction';
        $.NetworkRuleSet.properties.properties.properties.publicNetworkAccess['x-ms-enum'].name = 'EventHubPublicNetworkAccessFlag';
        $.NWRuleSetIpRules['x-ms-client-name'] = 'EventHubsNetworkRuleSetIPRules';
        $.NWRuleSetIpRules.properties.action['x-ms-enum'].name = 'EventHubNetworkRuleIPAction';
        $.NWRuleSetVirtualNetworkRules['x-ms-client-name'] = 'EventHubsNetworkRuleSetVirtualNetworkRules';
    - from: SchemaRegistry.json
      where: $.definitions
      transform: >
        $.SchemaGroup['x-ms-client-name'] = 'EventHubsSchemaGroup';
        delete $.SchemaGroup.properties.properties.properties.eTag['format'];
        $.SchemaGroup.properties.properties.properties.eTag['x-ms-format'] = 'etag';
    - from: AvailableClusterRegions-preview.json
      where: $.definitions
      transform: >
        $.AvailableCluster.properties.location['x-ms-format'] = 'azure-location';
```

