# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/ac40996ab146d1360a4783665bb6c0b13f345aec/specification/compute/resource-manager/readme.md
tag: package-2021-08-01
clear-output-folder: true
skip-csproj: true
  
#TODO: remove after we resolve why RestorePoint has no list
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointCollectionName}/restorePoints/{restorePointName}

mgmt-debug:
  show-request-path: true

override-operation-name:
  VirtualMachineScaleSets_Start: PowerOn
  VirtualMachineScaleSetVMs_Start: PowerOn
  CloudServices_Start: PowerOn

directive:
  - from: compute.json
    where: $.definitions.VirtualMachineImageProperties.properties.dataDiskImages
    transform: $.description="The list of data disk images information."
  - from: disk.json
    where: $.definitions.GrantAccessData.properties.access
    transform: $.description="The Access Level, accepted values include None, Read, Write."
  - rename-model:
      from: SshPublicKey
      to: SshPublicKeyInfo
  - rename-model:
      from: LogAnalyticsOperationResult
      to: LogAnalytics
  - rename-model:
      from: SshPublicKeyResource
      to: SshPublicKey
  - rename-model:
      from: RollingUpgradeStatusInfo
      to: VirtualMachineScaleSetRollingUpgrade
  - rename-model:
      from: RestorePointCollection
      to: RestorePointGroup
  - from: disk.json
    where: $.definitions.PurchasePlan
    transform: $["x-ms-client-name"] = "DiskPurchasePlan"
```
