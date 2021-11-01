# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/654c237832960c2753b7a4a4459a434af6d57a4a/specification/compute/resource-manager/readme.md
tag: package-2021-03-01
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointCollectionName}/restorePoints/{restorePointName}: RestorePointItem
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}: VirtualMachineExtension
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}: VirtualMachineScaleSetVMExtension
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}: SshPublicKey
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/runCommands/{runCommandName}: VirtualMachineRunCommand
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/runCommands/{runCommandName}: VirtualMachineScaleSetVMRunCommand
directive:
  - from: compute.json
    where: $.definitions.VirtualMachineImageProperties.properties.dataDiskImages
    transform: $.description="The list of data disk images information."
  - from: disk.json
    where: $.definitions.GrantAccessData.properties.access
    transform: $.description="The Access Level, accepted values include None, Read, Write."
  - rename-operation:
      from: VirtualMachines_Start
      to: VirtualMachines_PowerOn
  - rename-operation:
      from: VirtualMachineScaleSets_Start
      to: VirtualMachineScaleSets_PowerOn
  - rename-operation:
      from: VirtualMachineScaleSetVMs_Start
      to: VirtualMachineScaleSetVMs_PowerOn;
  - rename-operation:
      from: CloudServices_Start
      to: CloudServices_PowerOn
```
