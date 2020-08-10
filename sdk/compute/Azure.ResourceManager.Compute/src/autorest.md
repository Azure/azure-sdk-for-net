# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/e25881196fcf84fca4dfaedc9fc45a00db4e0541/specification/compute/resource-manager/readme.md
modelerfour:
  lenient-model-deduplication: true
directive:
  - from: compute.json
    where: $.definitions.VirtualMachineImageProperties.properties.dataDiskImages
    transform: $.description="The list of data disk images information."
  - from: disk.json
    where: $.definitions.GrantAccessData.properties.access
    transform: $.description="The Access Level, accepted values include None, Read, Write."
```