# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/readme.md
tag: package-2021-03-01-selected
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
  Locations: Microsoft.Compute/locations/runCommands
  ResourceSkus: Microsoft.Compute/skus
  DiskRestorePoint: Microsoft.Compute/restorePointCollections/restorePoints/diskRestorePoints
  GallerySharingProfile: Microsoft.Compute/galleries/share
  SharedGalleries: Microsoft.Compute/locations/sharedGalleries
  SharedGalleryImages: Microsoft.Compute/locations/sharedGalleries/images
  SharedGalleryImageVersions: Microsoft.Compute/locations/sharedGalleries/images/versions
operation-group-to-resource:
  CloudServiceRoleInstances: NonResource
  CloudServiceRoles: NonResource
  CloudServiceOperatingSystems: NonResource
  VirtualMachineImages: NonResource
  VirtualMachineExtensionImages: NonResource
  VirtualMachineImagesEdgeZone: NonResource
  VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
  LogAnalytics: NonResource
  Locations: NonResource
  DiskRestorePoint: NonResource
  GallerySharingProfile: NonResource
  SharedGalleries: NonResource
  SharedGalleryImages: NonResource
  SharedGalleryImageVersions: NonResource
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
  GallerySharingProfile: Microsoft.Compute/galleries
  ResourceSkus: subscriptions
  DiskRestorePoint: resourceGroups
  SharedGalleries: subscriptions
#   SharedGalleryImages: Microsoft.Compute/locations/sharedGalleries # how could we keep this hierarchy if its parent is not a resource?
  SharedGalleryImages: subscriptions
#   SharedGalleryImageVersions: Microsoft.Compute/locations/sharedGalleries/images # how could we keep this hierarchy if its parent is not a resource?
  SharedGalleryImageVersions: subscriptions # how could we keep this hierarchy?
  Locations: subscriptions ## this operation group comes from directive
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
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/runCommands/{commandId}'].get.operationId
    transform: return "Locations_GetVirtualMachineRunCommand";
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/runCommands'].get.operationId
    transform: return "VirtualMachineRunCommands_ListBySubscription";
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/runCommands'].get.operationId
    transform: return "VirtualMachineRunCommands_List";
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/runCommands'].get.operationId
    transform: return "Locations_ListVirtualMachineRunCommands"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.operationId
    transform: return "PrivateEndpointConnections_CreateOrUpdate"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].get.operationId
    transform: return "PrivateEndpointConnections_Get"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].delete.operationId
    transform: return "PrivateEndpointConnections_Delete"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections'].get.operationId
    transform: return "PrivateEndpointConnections_List"
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/galleries'].get.operationId
    transform: return "Galleries_ListBySubscription"
  ## temporary approach
  - from: swagger-document
    where: $.paths
    transform:  delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains']
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains/{updateDomain}']
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateLinkResources']
```

```yaml $(tag) == 'package-2021-03-01-selected'
input-file:
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2021-03-01/compute.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2021-03-01/runCommands.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2021-03-01/cloudService.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2019-04-01/skus.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2020-12-01/disk.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2020-09-30/gallery.json
- C:/Users/dapzhang/Documents/workspace/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2020-09-30/sharedGallery.json
```
