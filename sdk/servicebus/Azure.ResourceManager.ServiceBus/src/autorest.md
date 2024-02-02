# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.ServiceBus
require: https://github.com/Azure/azure-rest-api-specs/blob/f69c52dd603c79a8b29ba51483e3aa7fe1b56212/specification/servicebus/resource-manager/readme.md
tag: package-2022-10-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/AuthorizationRules/{authorizationRuleName}: ServiceBusNamespaceAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}: ServiceBusDisasterRecoveryAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}: ServiceBusQueueAuthorizationRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}: ServiceBusTopicAuthorizationRule
override-operation-name:
  Namespaces_CheckNameAvailability: CheckServiceBusNamespaceNameAvailability
  DisasterRecoveryConfigs_CheckNameAvailability: CheckServiceBusDisasterRecoveryNameAvailability

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
  CorrelationFilter: ServiceBusCorrelationFilter
  CorrelationFilter.label: Subject
  CorrelationFilter.properties: ApplicationProperties
  FilterAction: ServiceBusFilterAction
  ServiceBusNamespace.properties.zoneRedundant: IsZoneRedundant
  ServiceBusNetworkRuleSet.properties.trustedServiceAccessEnabled: IsTrustedServiceAccessEnabled
  ServiceBusNameAvailabilityResult.nameAvailable: IsNameAvailable
  PublicNetworkAccess: ServiceBusPublicNetworkAccess
  TlsVersion: ServiceBusMinimumTlsVersion

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
      transform: return "QueueAuthorizationRules_List"
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
      transform: return "QueueAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/queues/{queueName}/authorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "QueueAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules'].get.operationId
      transform: return "TopicAuthorizationRules_List"
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
      transform: return "TopicAuthorizationRules_ListKeys"
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
    - from: DisasterRecoveryConfig.json
      where: $.definitions
      transform: >
        $.ArmDisasterRecovery['x-ms-client-name'] = 'ServiceBusDisasterRecovery';
        $.ArmDisasterRecovery.properties.properties.properties.provisioningState['x-ms-enum'].name = 'ServiceBusDisasterRecoveryProvisioningState';
        $.ArmDisasterRecovery.properties.properties.properties.role['x-ms-enum'].name = 'ServiceBusDisasterRecoveryRole';
    - from: migrationconfigs.json
      where: $.definitions
      transform: >
        $.MigrationConfigProperties['x-ms-client-name'] = 'MigrationConfiguration';
        $.MigrationConfigProperties.properties.properties.properties.targetNamespace['x-ms-client-name'] = 'targetServiceBusNamespace';
        $.MigrationConfigProperties.properties.properties.properties.targetNamespace['x-ms-format'] = 'arm-id';
    - from: AuthorizationRules.json
      where: $.definitions
      transform: >
        $.RegenerateAccessKeyParameters['x-ms-client-name'] = 'ServiceBusRegenerateAccessKeyContent';
        $.RegenerateAccessKeyParameters.properties.keyType['x-ms-enum'].name = 'ServiceBusAccessKeyType';
        $.AccessKeys['x-ms-client-name'] = 'ServiceBusAccessKeys';
        $.SBAuthorizationRule['x-ms-client-name'] = 'ServiceBusAuthorizationRule';
        $.SBAuthorizationRule.properties.properties.properties.rights.items['x-ms-enum'].name = 'ServiceBusAccessRight';
    - from: networksets.json
      where: $.definitions
      transform: >
        $.NetworkRuleSet['x-ms-client-name'] = 'ServiceBusNetworkRuleSet';
        $.NetworkRuleSet.properties.properties.properties.defaultAction['x-ms-enum'].name = 'ServiceBusNetworkRuleSetDefaultAction';
        $.NWRuleSetIpRules['x-ms-client-name'] = 'ServiceBusNetworkRuleSetIPRules';
        $.NWRuleSetIpRules.properties.action['x-ms-enum'].name = 'ServiceBusNetworkRuleIPAction';
        $.NetworkRuleSet.properties.properties.properties.publicNetworkAccess['x-ms-enum'].name = 'ServiceBusPublicNetworkAccessFlag';
        $.NWRuleSetVirtualNetworkRules['x-ms-client-name'] = 'ServiceBusNetworkRuleSetVirtualNetworkRules';
    - from: namespace-preview.json
      where: $.definitions
      transform: >
        $.SBNamespace['x-ms-client-name'] = 'ServiceBusNamespace';
        $.SBSku['x-ms-client-name'] = 'Sku';
        $.SBNamespaceUpdateParameters['x-ms-client-name'] = 'ServiceBusNamespaceUpdateParameters';
        $.Encryption['x-ms-client-name'] = 'ServiceBusEncryption';
        $.Encryption.properties.keySource['x-ms-enum'].name = 'ServiceBusEncryptionKeySource';
        $.ConnectionState['x-ms-client-name'] = 'ServiceBusPrivateLinkServiceConnectionState';
        $.ConnectionState.properties.status['x-ms-enum'].name = 'ServiceBusPrivateLinkConnectionStatus';
        $.PrivateEndpointConnectionProperties.properties.provisioningState['x-ms-enum'].name = 'ServiceBusPrivateEndpointConnectionProvisioningState';
        $.KeyVaultProperties['x-ms-client-name'] = 'ServiceBusKeyVaultProperties';
    - from: CheckNameAvailability.json
      where: $.definitions
      transform: >
        $.CheckNameAvailability['x-ms-client-name'] = 'ServiceBusNameAvailabilityContent';
        $.CheckNameAvailabilityResult['x-ms-client-name'] = 'ServiceBusNameAvailabilityResult';
    - from: Rules.json
      where: $.definitions
      transform: >
        $.Rule['x-ms-client-name'] = 'ServiceBusRule';
        $.Action['x-ms-client-name'] = 'FilterAction';
        $.CorrelationFilter.properties.to['x-ms-client-name'] = 'sendTo';
        $.CorrelationFilter.properties.properties.additionalProperties['x-ms-format'] = 'object';
    - from: topics.json
      where: $.definitions
      transform: >
        $.SBTopic['x-ms-client-name'] = 'ServiceBusTopic';
    - from: Queue.json
      where: $.definitions
      transform: >
        $.SBQueue['x-ms-client-name'] = 'ServiceBusQueue';
    - from: subscriptions.json
      where: $.definitions
      transform: >
        $.SBSubscription['x-ms-client-name'] = 'ServiceBusSubscription';
        $.SBClientAffineProperties['x-ms-client-name'] = 'ServiceBusClientAffineProperties';
```
