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
# csharpgen:
#   attach: true
operation-group-to-resource-type:
  CloudServiceRoles: Microsoft.Compute/cloudServices/roles
  CloudServiceRoleInstances: Microsoft.Compute/cloudServices/roleInstances
  CloudServiceOperatingSystems: Microsoft.Compute/locations/cloudServiceOsFamilies
  VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/artifacttypes/types/versions
  VirtualMachineImages: Microsoft.Compute/locations/publishers/artifacttypes/offers/skus/versions
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
  RunCommandDocuments: Microsoft.Compute/no/a/resource
operation-group-to-resource:
  CloudServiceRoleInstances: CloudServiceRoleInstance
  CloudServiceRoles: CloudServiceRole
  CloudServiceOperatingSystems: OSVersion
  CloudServicesUpdateDomain: NonResource
  VirtualMachineImages: NonResource
  VirtualMachineExtensionImages: VirtualMachineExtensionImage
  VirtualMachineImagesEdgeZone: NonResource # this is a resource with the same model as VirtualMachineImage, but we cannot handle that case, therefore temporarily we mark this as a non-resource to let the sdk properly generate
  VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
  LogAnalytics: NonResource
  Locations: NonResource
  DiskRestorePoint: DiskRestorePoint
  GallerySharingProfile: NonResource
#   SharedGalleries: SharedGallery
#   SharedGalleryImages: SharedGalleryImage
#   SharedGalleryImageVersions: SharedGalleryImageVersion
  SharedGalleries: NonResource
  SharedGalleryImages: NonResource
  SharedGalleryImageVersions: NonResource
  RunCommandDocuments: NonResource
operation-group-to-parent:
  Usage: subscriptions
  LogAnalytics: subscriptions
  CloudServiceRoleInstances: Microsoft.Compute/cloudServices
  CloudServiceRoles: Microsoft.Compute/cloudServices
  CloudServiceOperatingSystems: subscriptions
  CloudServicesUpdateDomain: Microsoft.Compute/cloudServices
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
  DiskRestorePoint: Microsoft.Compute/restorePointCollections/restorePoints
  SharedGalleries: subscriptions
  SharedGalleryImages: subscriptions
  SharedGalleryImageVersions: subscriptions
#   SharedGalleryImages: Microsoft.Compute/locations/sharedGalleries
#   SharedGalleryImageVersions: Microsoft.Compute/locations/sharedGalleries/images
  RunCommandDocuments: subscriptions
operation-group-is-extension: VirtualMachineRunCommands;VirtualMachineScaleSetVMRunCommands;VirtualMachineScaleSetVMExtensions;VirtualMachineExtensions
# this corresponds to a resource with the same model as VirtualMachineImage, but we cannot handle that case, therefore temporarily we mark this as a non-resource to let the sdk properly generate
directive:
  ## first we need to unify all the paths by changing `virtualmachines` to `virtualMachines` so that every path could have consistent casing
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
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains/{updateDomain}'].put.parameters
    transform: >
        $[2] = {
            "in": "path",
            "name": "updateDomain",
            "description": "Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.",
            "required": true,
            "type": "string"
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains/{updateDomain}'].get.parameters
    transform: >
        $[2] = {
            "in": "path",
            "name": "updateDomain",
            "description": "Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.",
            "required": true,
            "type": "string"
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/start'].post.operationId
    transform: return 'VirtualMachines_PowerOn';
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/start'].post.operationId
    transform: return 'VirtualMachineScaleSets_PowerOn';
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/start'].post.operationId
    transform: return 'VirtualMachineScaleSetVMs_PowerOn';
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/start'].post.operationId
    transform: return 'CloudServices_PowerOn';
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/runCommands/{commandId}'].get.operationId
    transform: return 'RunCommandDocuments_Get'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/runCommands'].get.operationId
    transform: return 'RunCommandDocuments_List'
```
