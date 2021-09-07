# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.EventHub
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/eventhub/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
    lenient-model-deduplication: true
operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.EventHub/namespaces/privateLinkResources
    Regions: Microsoft.EventHub/sku/regions
    Configuration: Microsoft.EventHub/clusters/quotaConfiguration/default
operation-group-to-resource:
    PrivateLinkResources: NonResource
    Regions: NonResource
    Configuration: ClusterQuotaConfigurationProperties
operation-group-to-parent:
    Namespaces: resourceGroups
    Configuration: Microsoft.EventHub/clusters
    ConsumerGroups: Microsoft.EventHub/namespaces/eventhubs
    EHNamespaceAuthorizationRules: Microsoft.EventHub/namespaces
    ArmDisasterRecoveryAuthorizationRules: Microsoft.EventHub/namespaces/disasterRecoveryConfigs
    EventhubAuthorizationRules: Microsoft.EventHub/namespaces/eventhubs
operation-group-is-extension: EHNamespaceAuthorizationRules;ArmDisasterRecoveryAuthorizationRules;EventhubAuthorizationRules
directive:
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/ipfilterrules'].get.operationId
      transform: return "IpFilterRules_List"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/ipfilterrules/{ipFilterRuleName}'].put.operationId
      transform: return "IpFilterRules_CreateOrUpdate"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/ipfilterrules/{ipFilterRuleName}'].delete.operationId
      transform: return "IpFilterRules_Delete"
    - from: swagger-document
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/ipfilterrules/{ipFilterRuleName}'].get.operationId
      transform: return "IpFilterRules_Get"
```
