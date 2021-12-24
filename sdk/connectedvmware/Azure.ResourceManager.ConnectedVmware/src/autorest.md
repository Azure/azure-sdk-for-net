# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.ConnectedVmware
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/connectedvmware/resource-manager/readme.md
clear-output-folder: true
output-folder: Generated/
skip-csproj: true
mgmt-debug:
  show-request-path: true
directive:
  - rename-model:
      from: Identity
      to: VmwareIdentity
  - rename-model:
      from: Datastore
      to: VmwareDatastore
  - rename-model:
      from: Cluster
      to: VmwareCluster
  - rename-model:
      from: Host
      to: VmwareHost

```
