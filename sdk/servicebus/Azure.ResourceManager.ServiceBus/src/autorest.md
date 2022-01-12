# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.ServiceBus
require: https://github.com/Azure/azure-rest-api-specs/blob/a5f8ef67c8170e4081527e400473c6deddcfabfd/specification/servicebus/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
directive:
    - rename-model:
        from: SBNamespace
        to: ServiceBusNamespace
    - rename-model:
        from: SBTopic
        to: ServiceBusTopic
    - rename-model:
        from: SBQueue
        to: ServiceBusQueue
    - rename-model:
        from: SBQueue
        to: ServiceBusQueue
    - rename-model:
        from: SBSubscription
        to: ServiceBusSubscription
    - rename-model:
        from: SBAuthorizationRule
        to: ServiceBusAuthorizationRule
    - rename-model:
        from: NWRuleSetIpRules
        to: NetworkRuleSetIpRules
    - rename-model:
        from: NWRuleSetVirtualNetworkRules
        to: NetworkRuleSetVirtualNetworkRules
    - rename-model:
        from: SBAuthorizationRuleListResult
        to: ServiceBusAuthorizationRuleListResult
    - rename-model:
        from: SBClientAffineProperties
        to: ServiceBusClientAffineProperties
    - rename-model:
        from: SBNamespaceListResult
        to: ServiceBusNamespaceListResult
    - rename-model:
        from: SBNamespaceUpdateParameters
        to: ServiceBusNamespaceUpdateParameters
    - rename-model:
        from: SBQueueListResult
        to: ServiceBusQueueListResult
    - rename-model:
        from: SBSku
        to: ServiceBusSku
    - rename-model:
        from: SBSubscriptionListResult
        to: ServiceBusSubscriptionListResult
    - rename-model:
        from: SBTopicListResult
        to: ServiceBusTopicListResult
    - rename-model:
        from: Rule
        to: ServiceBusRule
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
      transform: return "DisasterRecoveryConfigAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_ListKeys"
    - rename-model:
        from: ArmDisasterRecovery
        to: DisasterRecovery
    - rename-model:
        from: ArmDisasterRecoveryListResult
        to: DisasterRecoveryListResult
    - rename-model:
        from: Action
        to: FilterAction
    - rename-model:
        from: Encryption
        to: EncryptionProperties
    - from: swagger-document
      where: $.definitions.PrivateEndpointConnectionProperties.properties.provisioningState
      transform: >
        $['x-ms-enum'] = {
            "name": "EndpointProvisioningState",
            "modelAsString": true
        }
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.parameters[5]
      transform: $['description'] = 'Parameters supplied to update Status of PrivateEndpoint Connection to namespace resource.'
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.responses.200
      transform: $['description'] = 'Status of PrivateEndpoint Connection Created successfully.'
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.responses.201
      transform: $['description'] = 'Request to update Status of PrivateEndpoint Connection accepted.'
    - rename-model:
        from: RegenerateAccessKeyParameters
        to: RegenerateAccessKeyOptions
    - rename-model:
        from: ServiceBusNamespaceUpdateParameters
        to: ServiceBusNamespaceUpdateOptions

```
