# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/readme.md
tag: package-2021-03-01-only
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
operation-group-to-resource-type:
  Operations: Microsoft.Compute/operations
  CloudServiceRoles: Microsoft.Compute/cloudServices/roles
  CloudServiceOperatingSystems: Microsoft.Compute/locations/cloudServiceOsFamilies
  VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
  VirtualMachineImages: Microsoft.Compute/locations/publishers/vmimage
  Usage: Microsoft.Compute/locations/usages
  VirtualMachineSizes: Microsoft.Compute/locations/vmSizes
  VirtualMachineImagesEdgeZone: Microsoft.Compute/locations/edgeZones/publishers/artifacttypes/offers/skus/versions
  VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades
  LogAnalytics: Microsoft.Compute/locations/logAnalytics
operation-group-to-resource:
  CloudServiceRoleInstances: NonResource
  CloudServiceRoles: NonResource
  CloudServiceOperatingSystems: NonResource
  VirtualMachineImages: NonResource
  VirtualMachineExtensionImages: NonResource
  VirtualMachineImagesEdgeZone: NonResource
  VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
  LogAnalytics: NonResource
operation-group-to-parent:
  Operations: tenant
  Usage: subscriptions
  LogAnalytics: subscriptions
  CloudServiceRoleInstances: Microsoft.Compute/cloudServices
  CloudServiceRoles: Microsoft.Compute/cloudServices
  CloudServiceOperatingSystems: subscriptions
  VirtualMachineSizes: subscriptions
  VirtualMachineImages: subscriptions
  VirtualMachineExtensionImages: subscriptions
  VirtualMachineImagesEdgeZone: subscriptions
  VirtualMachineExtensions: Microsoft.Compute/virtualMachines
  VirtualMachineScaleSetVMExtensions: Microsoft.Compute/virtualMachineScaleSets
  VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets
  VirtualMachineRunCommands: Microsoft.Compute/virtualMachines
  VirtualMachineScaleSetVMRunCommands: Microsoft.Compute/virtualMachineScaleSets/virtualMachines ## there is a casing inconsistency !!!
# operation-group-is-tuple: VirtualMachineImages;VirtualMachineExtensionImages
operation-group-is-extension: VirtualMachineRunCommands;VirtualMachineScaleSetVMRunCommands;VirtualMachineScaleSetVMExtensions;VirtualMachineExtensions
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
      from: ComputeOperationValue
      to: RestApi
  - rename-model:
      from: RollingUpgradeStatusInfo
      to: VirtualMachineScaleSetRollingUpgrade
  - from: swagger-document
    where: $.paths
    transform: >
      for (var key in $) {
          const newKey = key.replace('virtualmachines', 'virtualMachines');
          if (newKey !== key) {
              $[newKey] = $[key]
              delete $[key]
          }
      }
```
