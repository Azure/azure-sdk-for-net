# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
security: AADToken
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c4d6f92d3fd35a69ebce68f4c73c35c4238c2ac5/specification/vmware/resource-manager/readme.md
tag: package-2021-12-01
model-namespace: false
operation-group-to-resource-type:
  Locations: Microsoft.AVS/locations
  VirtualMachines: Microsoft.AVS/privateClouds/clusters/virtualMachines
  ScriptPackages: Microsoft.AVS/privateClouds/scriptPackages
  ScriptCmdlets: Microsoft.AVS/privateClouds/scriptPackages/scriptCmdlets
operation-group-to-parent:
  Locations: subscriptions
  WorkloadNetworks: Microsoft.AVS/privateClouds
operation-group-to-resource:
  Locations: NonResource
  VirtualMachines: NonResource
  ScriptPackages: NonResource
  ScriptCmdlets: NonResource
```
