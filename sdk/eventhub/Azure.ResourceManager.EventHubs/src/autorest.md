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
directive:
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
```

