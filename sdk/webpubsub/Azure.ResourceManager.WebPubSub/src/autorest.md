# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: WebPubSub
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47b551f58ee1b24f4783c2e927b1673b39d87348/specification/webpubsub/resource-manager/readme.md
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
