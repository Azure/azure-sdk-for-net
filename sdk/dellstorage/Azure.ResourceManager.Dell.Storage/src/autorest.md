# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Dell.Storage
namespace: Azure.ResourceManager.Dell.Storage
require: https://github.com/Azure/azure-rest-api-specs/blob/5351ac8e1e6fdf48933bae2cd879434b93b36ac0/specification/dell/resource-manager/readme.md
#tag: package-2025-03-21-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true
```
