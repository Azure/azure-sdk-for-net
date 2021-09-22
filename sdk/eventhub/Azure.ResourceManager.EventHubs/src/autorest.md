# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHubs
tag: package-2017-04
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c9992af7235a6550087d4fed8f081ed35019f605/specification/eventhub/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.EventHub/namespaces/privateLinkResources
    Regions: Microsoft.EventHub/sku/regions
    DisasterRecoveryConfigAuthorizationRules: Microsoft.EventHub/namespaces/disasterRecoveryConfigs/authorizationRules
    NamespaceName: nonresourcetype1
    DisasterRecoveryConfigName: nonresourcetype2
operation-group-to-resource:
    PrivateLinkResources: NonResource
    Regions: NonResource
    Configuration: ClusterQuotaConfigurationProperties
    DisasterRecoveryConfigAuthorizationRules: AuthorizationRule
    NamespaceName: NonResource
    DisasterRecoveryConfigName: NonResource
operation-group-to-parent:
    Namespaces: resourceGroups
    ConsumerGroups: Microsoft.EventHub/namespaces/eventhubs
    NetworkRuleSets: Microsoft.EventHub/namespaces
    NamespaceAuthorizationRules: Microsoft.EventHub/namespaces
    DisasterRecoveryConfigAuthorizationRules: Microsoft.EventHub/namespaces/disasterRecoveryConfigs
    EventHubAuthorizationRules: Microsoft.EventHub/namespaces/eventhubs
    NamespaceName: subscriptions
    DisasterRecoveryConfigName: Microsoft.EventHub/namespaces
operation-group-is-extension: NamespaceAuthorizationRules;DisasterRecoveryConfigAuthorizationRules;EventHubAuthorizationRules
directive:
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets/default'].put.operationId
      transform: return "NetworkRuleSets_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets/default'].delete.operationId
      transform: return "NetworkRuleSets_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets/default'].get.operationId
      transform: return "NetworkRuleSets_Get"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/networkRuleSets'].get.operationId
      transform: return "NetworkRuleSets_List"
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
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys'].get.operationId
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
```

