# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: ResourceManager
namespace: Azure.ResourceManager
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac3be41ee22ada179ab7b970e98f1289188b3bae/specification/common-types/resource-management/v2/types.json

modelerfour:
  lenient-model-deduplication: true
skip-csproj: true

directive:
  from: types.json
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.ResourceManager.Common"
```
