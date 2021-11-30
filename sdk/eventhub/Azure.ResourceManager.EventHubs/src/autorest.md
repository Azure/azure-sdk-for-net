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
modelerfour:
    lenient-model-deduplication: true
request-path-to-resource-name:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}: DisasterRecoveryAuthorizationRule
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/authorizationRules/{authorizationRuleName}: EventHubAuthorizationRule
directive:
    - rename-model:
        from: ArmDisasterRecovery
        to: DisasterRecovery
    - rename-model:
        from: Eventhub
        to: EventHub
    - rename-model:
        from: EHNamespace
        to: EventHubNamespace
    - rename-model:
        from: Cluster
        to: EventHubCluster
    - rename-model:
        from: EHNamespaceIdListResult
        to: EventHubNamespaceIdListResult
    - rename-model:
        from: EHNamespaceListResult
        to: EventHubNamespaceListResult
    - rename-model:
        from: NWRuleSetIpRules
        to: NetworkRuleSetIpRules
    - rename-model:
        from: NWRuleSetVirtualNetworkRules
        to: NetworkRuleSetVirtualNetworkRules
    - rename-model:
        from: CheckNameAvailabilityParameter
        to: CheckNameAvailabilityOptions
    - rename-model:
        from: RegenerateAccessKeyParameters
        to: RegenerateAccessKeyOptions
    - rename-model:
        from: Destination
        to: EventHubDestination
    - rename-model:
        from: Encryption
        to: EventHubEncryption
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
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}'].put.operationId
      transform: return "DisasterRecoveries_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}'].delete.operationId
      transform: return "DisasterRecoveries_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].put.operationId
      transform: return "EventHubNamespaces_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].patch.operationId
      transform: return "EventHubNamespaces_Update"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}'].delete.operationId
      transform: return "EventHubNamespaces_Delete"
```

