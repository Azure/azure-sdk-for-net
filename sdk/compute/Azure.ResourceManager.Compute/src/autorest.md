# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/76f8e0c50629ef12aa338d55782278ceca46212a/specification/compute/resource-manager/readme.md
tag: package-2021-03-01
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
  
#TODO: remove after we resolve why RestorePoint has no list
list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointCollectionName}/restorePoints/{restorePointName}
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsFamilies/{osFamilyName}

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
```
