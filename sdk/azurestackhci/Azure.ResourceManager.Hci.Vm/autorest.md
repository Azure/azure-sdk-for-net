# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci.Vm
namespace: Azure.ResourceManager.Hci.Vm
require: https://github.com/Azure/azure-rest-api-specs/tree/195b613c1e7b205baf774c29ba2300dd54d19474/specification/azurestackhci/resource-manager/readme.md
tag: package-2024-01-vm
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true
