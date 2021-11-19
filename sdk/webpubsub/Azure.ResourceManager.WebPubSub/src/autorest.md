# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
require: https://raw.githubusercontent.com/zackliu/azure-rest-api-specs/7c3f2e716b99c0583964ec98b92da320b0de9df8/specification/webpubsub/resource-manager/readme.md
tag: package-2021-10-01
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.WebPubSub
modelerfour:
  lenient-model-deduplication: true
model-namespace: false
no-property-type-replacement: PrivateEndpoint
list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}/eventHandlers/eventHandlerName
```
