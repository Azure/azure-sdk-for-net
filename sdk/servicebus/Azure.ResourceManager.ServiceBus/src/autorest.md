# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.ServiceBus
require: https://github.com/Azure/azure-rest-api-specs/blob/c3c93e9102521197fffb02498222aa1c2375d69a/specification/servicebus/resource-manager/Microsoft.ServiceBus/ServiceBus/readme.md
tag: package-2025-05-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}: ServiceBusNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}: ServiceBusDisasterRecoveryAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}: ServiceBusQueueAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}: ServiceBusTopicAuthorizationRule
request-path-is-non-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/networkSecurityPerimeterConfigurations/{resourceAssociationName}

override-operation-name:
  Namespaces_CheckNameAvailability: CheckServiceBusNamespaceNameAvailability
  DisasterRecoveryConfigs_CheckNameAvailability: CheckServiceBusDisasterRecoveryNameAvailability
  Topics_ListKeys: GetKeys
  Queues_ListKeys: GetKeys
  NetworkSecurityPerimeterConfigurations_GetResourceAssociationName: GetNetworkSecurityPerimeterAssociationName

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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

rename-mapping:
  UnavailableReason: ServiceBusNameUnavailableReason
  EntityStatus: ServiceBusMessagingEntityStatus
  FilterType: ServiceBusFilterType
  SqlFilter: ServiceBusSqlFilter
  CorrelationFilter.properties: ApplicationProperties
  CorrelationFilter: ServiceBusCorrelationFilter
  CorrelationFilter.to: sendTo
  CorrelationFilter.label: Subject
  FilterAction: ServiceBusFilterAction
  ServiceBusNamespace.properties.zoneRedundant: IsZoneRedundant
  ServiceBusNetworkRuleSet.properties.trustedServiceAccessEnabled: IsTrustedServiceAccessEnabled
  ServiceBusNameAvailabilityResult.nameAvailable: IsNameAvailable
  PublicNetworkAccess: ServiceBusPublicNetworkAccess
  TlsVersion: ServiceBusMinimumTlsVersion
  MigrationConfigProperties.properties.targetNamespace: targetServiceBusNamespace|arm-id
  MigrationConfigProperties: MigrationConfiguration
  KeyType: ServiceBusAccessKeyType
  RegenerateAccessKeyParameters: ServiceBusRegenerateAccessKeyContent
  ProvisioningStateDR: ServiceBusDisasterRecoveryProvisioningState
  RoleDisasterRecovery: ServiceBusDisasterRecoveryRole
  ArmDisasterRecovery: ServiceBusDisasterRecovery
  AccessKeys: ServiceBusAccessKeys
  AccessRights: ServiceBusAccessRight
  Rule: ServiceBusRule
  Action: ServiceBusFilterAction
  EncryptionKeySource: ServiceBusEncryptionKeySource 
  Encryption: ServiceBusEncryption
  ConnectionState: ServiceBusPrivateLinkServiceConnectionState
  PrivateLinkConnectionStatus: ServiceBusPrivateLinkConnectionStatus
  EndPointProvisioningState: ServiceBusPrivateEndpointConnectionProvisioningState
  PublicNetworkAccessFlag: ServiceBusPublicNetworkAccessFlag
  NWRuleSetIpRules: ServiceBusNetworkRuleSetIPRules
  NetworkRuleIPAction: ServiceBusNetworkRuleIPAction
  NWRuleSetVirtualNetworkRules: ServiceBusNetworkRuleSetVirtualNetworkRules
  DefaultAction: ServiceBusNetworkRuleSetDefaultAction
  SBTopic: ServiceBusTopic
  SBQueue: ServiceBusQueue
  SBSubscription: ServiceBusSubscription
  SBClientAffineProperties: ServiceBusClientAffineProperties
  KeyVaultProperties: ServiceBusKeyVaultProperties
  SBNamespace: ServiceBusNamespace
  SBNamespace.properties.zoneRedundant: IsZoneRedundant
  SBSku: ServiceBusSku
  SBAuthorization: ServiceBusAuthorization
  SBAuthorizationRule: ServiceBusAuthorizationRules
  CheckNameAvailability: ServiceBusNameAvailabilityContent
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  CheckNameAvailabilityResult: ServiceBusNameAvailabilityResult
  NetworkRuleSet: ServiceBusNetworkRuleSet
  NetworkRuleSet.properties.trustedServiceAccessEnabled: IsTrustedServiceAccessEnabled
  NamespaceReplicaLocation: ServiceBusNamespaceReplicaLocation
  NetworkSecurityPerimeter: ServiceBusNetworkSecurityPerimeter
  NetworkSecurityPerimeterConfiguration: ServiceBusNetworkSecurityPerimeterConfiguration
  NetworkSecurityPerimeterConfigurationPropertiesProfile: ServiceBusNetworkSecurityPerimeterConfigurationPropertiesProfile
  NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation: ServiceBusNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation
  NetworkSecurityPerimeterConfigurationProvisioningState: ServiceBusNetworkSecurityPerimeterConfigurationProvisioningState
  NspAccessRule: ServiceBusNspAccessRule
  NspAccessRuleDirection: ServiceBusNspAccessRuleDirection
  NspAccessRuleProperties: ServiceBusNspAccessRuleProperties
  ResourceAssociationAccessMode: ServiceBusResourceAssociationAccessMode
  Mode: ServiceBusConfidentialComputeMode
  ProvisioningIssue: ServiceBusNspConfigurationProvisioningIssue
  ProvisioningIssueProperties: ServiceBusNspConfigurationProvisioningIssueProperties
  FailOver: ServiceBusNamespaceFailOver



directive:
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules'].get.operationId
      transform: return "NamespaceAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "NamespaceAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "NamespaceAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "NamespaceAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "NamespaceAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "NamespaceAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules'].get.operationId
      transform: return "QueueAuthorizationRules_list"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "QueueAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "QueueAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "QueueAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}/ListKeys'].post.operationId
      transform: return "QueueAuthorizationRules_listKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "QueueAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules'].get.operationId
      transform: return "TopicAuthorizationRules_list"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "TopicAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "TopicAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "TopicAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}/ListKeys'].post.operationId
      transform: return "TopicAuthorizationRules_listKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "TopicAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules'].get.operationId
      transform: return "DisasterRecoveryAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "DisasterRecoveryAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "DisasterRecoveryAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.parameters[5]
      transform: $['description'] = 'Parameters supplied to update Status of PrivateEndpoint Connection to namespace resource.'
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.responses.200
      transform: $['description'] = 'Status of PrivateEndpoint Connection Created successfully.'
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.responses.201
      transform: $['description'] = 'Request to update Status of PrivateEndpoint Connection accepted.'
    - from: swagger-document
      where: $.definitions.CorrelationFilter
      transform: >
        $.properties.properties.additionalProperties['x-ms-format'] = 'object';
```
