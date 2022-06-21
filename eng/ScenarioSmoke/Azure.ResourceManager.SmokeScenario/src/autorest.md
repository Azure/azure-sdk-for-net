# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: SmokeScenario
require:
- $(this-folder)/../specification/readme.md
- $(this-folder)/../../readme.md
clear-output-folder: true
namespace: Azure.ResourceManager.SmokeScenario
modelerfour:
  lenient-model-deduplication: true
model-namespace: false
list-exception:
-  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/signalR/{resourceName}/privateEndpointConnections/{privateEndpointConnectionName}
```
