# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHubs
tag: package-2021-06-preview
require: https://github.com/Azure/azure-rest-api-specs/blob/a5f8ef67c8170e4081527e400473c6deddcfabfd/specification/eventhub/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.EventHub/namespaces/privateLinkResources
    DisasterRecoveryConfigAuthorizationRules: Microsoft.EventHub/namespaces/disasterRecoveryConfigs/authorizationRules
    NamespaceName: nonresourcetype1
    DisasterRecoveryConfigName: nonresourcetype2
    AvailableClusters: nonresourcetype3
operation-group-to-resource:
    PrivateLinkResources: NonResource
    Regions: NonResource
    Configuration: NonResource
    DisasterRecoveryConfigAuthorizationRules: AuthorizationRule
    NamespaceName: NonResource
    DisasterRecoveryConfigName: NonResource
    AvailableClusters: NonResource
operation-group-to-parent:
    Configuration: Microsoft.EventHub/clusters
    NamespaceAuthorizationRules: Microsoft.EventHub/namespaces
    DisasterRecoveryConfigAuthorizationRules: Microsoft.EventHub/namespaces/disasterRecoveryConfigs
    EventHubAuthorizationRules: Microsoft.EventHub/namespaces/eventhubs
    NamespaceName: subscriptions
    DisasterRecoveryConfigName: Microsoft.EventHub/namespaces
    AvailableClusters: subscriptions
operation-group-is-extension: NamespaceAuthorizationRules;DisasterRecoveryConfigAuthorizationRules;EventHubAuthorizationRules
directive:
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules'].get.operationId
      transform: return "NamespaceAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "NamespaceAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "NamespaceAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "NamespaceAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "NamespaceAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/authorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "NamespaceAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules'].get.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "DisasterRecoveryConfigAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules'].get.operationId
      transform: return "EventHubAuthorizationRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}'].put.operationId
      transform: return "EventHubAuthorizationRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}'].delete.operationId
      transform: return "EventHubAuthorizationRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}'].get.operationId
      transform: return "EventHubAuthorizationRules_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}/listKeys'].post.operationId
      transform: return "EventHubAuthorizationRules_ListKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}/regenerateKeys'].post.operationId
      transform: return "EventHubAuthorizationRules_RegenerateKeys"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/checkNameAvailability'].post.operationId
      transform: return "DisasterRecoveryConfigName_CheckAvailability"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/checkNameAvailability'].post.operationId
      transform: return "NamespaceName_CheckAvailability"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/availableClusterRegions'].get.operationId
      transform: return "AvailableClusters_ListRegion"
```

