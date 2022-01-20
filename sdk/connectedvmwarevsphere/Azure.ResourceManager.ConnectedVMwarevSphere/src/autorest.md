# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.ConnectedVMwarevSphere
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/connectedvmware/resource-manager/readme.md
clear-output-folder: true
output-folder: Generated/
skip-csproj: true
mgmt-debug:
  show-request-path: true
directive:
  - rename-model:
      from: Identity
      to: VMwareIdentity
  - rename-model:
      from: Datastore
      to: VMwareDatastore
  - rename-model:
      from: Cluster
      to: VMwareCluster
  - rename-model:
      from: Host
      to: VMwareHost
  - from: swagger-document
    where: "$.definitions.OsType"
    transform: >
      $["x-ms-enum"] = {
        "modelAsString": true,
        "name": "OSType"
      }
  - from: swagger-document
    where: "$.definitions.VirtualMachineTemplateInventoryItem.properties.numCPUs"
    transform: >
      $["x-ms-client-name"] = "numCpus";
  - from: swagger-document
    where: "$.definitions.HardwareProfile.properties.numCPUs"
    transform: >
      $["x-ms-client-name"] = "numCpus";
  - from: swagger-document
    where: "$.definitions.VirtualMachineTemplateProperties.properties.numCPUs"
    transform: >
      $["x-ms-client-name"] = "numCpus";
  - from: swagger-document
    where: "$.definitions.VirtualMachineTemplateProperties.properties.osType"
    transform: >
      $["x-ms-client-name"] = "OSType";
  - from: swagger-document
    where: "$.definitions.VirtualMachineTemplateProperties.properties.osName"
    transform: >
      $["x-ms-client-name"] = "OSName";
  - from: swagger-document
    where: "$.definitions.OsProfile.properties.osType"
    transform: >
      $["x-ms-client-name"] = "OSType";
  - from: swagger-document
    where: "$.definitions.OsProfile.properties.osName"
    transform: >
      $["x-ms-client-name"] = "OSName";
  - rename-model:
      from: OsProfile
      to: OSProfile
  - from: swagger-document
    where: "$.definitions.VirtualMachineProperties.properties.osProfile"
    transform: >
      $["x-ms-client-name"] = "OSProfile";
```
