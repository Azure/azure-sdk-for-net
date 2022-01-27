# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StackHCI
namespace: Azure.ResourceManager.StackHCI
require: https://github.com/Azure/azure-rest-api-specs/blob/75b53c0708590483bb2166b9e2751f1bdf5adefa/specification/azurestackhci/resource-manager/readme.md
tag: package-2021-09
output-folder: Generated/
clear-output-folder: true
directive:
  - from: extensions.json
    where: $.definitions.Extension
    transform: $["x-ms-client-name"] = "ArcExtension"
  - from: clusters.json
    where: $.definitions.Cluster
    transform: $["x-ms-client-name"] = "HCICluster"

```
