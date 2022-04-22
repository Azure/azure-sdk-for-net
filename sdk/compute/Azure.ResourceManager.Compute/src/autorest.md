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

override-operation-name:
  VirtualMachines_Start: PowerOn
  VirtualMachineScaleSets_Start: PowerOn
  VirtualMachineScaleSetVMs_Start: PowerOn
  CloudServices_Start: PowerOn
  CloudServicesUpdateDomain_GetUpdateDomain: GetUpdateDomain
  CloudServicesUpdateDomain_ListUpdateDomains: GetUpdateDomains
  CloudServicesUpdateDomain_WalkUpdateDomain: WalkUpdateDomain
  GallerySharingProfile_Update: UpdateSharingProfile
  VirtualMachineImages_ListSkus: GetVirtualMachineImageSkus
  VirtualMachineImagesEdgeZone_ListSkus: GetVirtualMachineImageEdgeZoneSkus
  VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade: StartOSUpgrade

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}: SharedGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}/versions/{galleryImageVersionName}: SharedGalleryImageVersion

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
  - rename-model:
      from: VirtualMachineScaleSetVM
      to: VirtualMachineScaleSetVm
  - rename-model:
      from: VirtualMachineScaleSetVMExtension
      to: VirtualMachineScaleSetVmExtension
  - from: disk.json
    where: $.definitions.PurchasePlan
    transform: $["x-ms-client-name"] = "DiskPurchasePlan"
# problematic word OS
  - from: swagger-document
    where: $.definitions.DiskProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.DiskRestorePointProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.GalleryImageProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.GalleryImageProperties.properties.osState
    transform: $["x-ms-client-name"] = "OSState"
  - from: swagger-document
    where: $.definitions.SharedGalleryImageProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.SharedGalleryImageProperties.properties.osState
    transform: $["x-ms-client-name"] = "OSState"
  - from: swagger-document
    where: $.definitions.SnapshotProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.VirtualMachineProperties.properties.osProfile
    transform: $["x-ms-client-name"] = "OSProfile"
  - from: swagger-document
    where: $.definitions.CloudServiceProperties.properties.osProfile
    transform: $["x-ms-client-name"] = "OSProfile"
  - from: swagger-document
    where: $.definitions.CloudServiceOsProfile
    transform: $["x-ms-client-name"] = "CloudServiceOSProfile"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMProperties.properties.osProfile
    transform: $["x-ms-client-name"] = "OSProfile"
  - from: swagger-document
    where: $.definitions.CommunityGalleryImageProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.CommunityGalleryImageProperties.properties.osState
    transform: $["x-ms-client-name"] = "OSState"
  - from: swagger-document
    where: $.definitions.DiskUpdateProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.EncryptionImages.properties.osDiskImage
    transform: $["x-ms-client-name"] = "OSDiskImage"
  - from: swagger-document
    where: $.definitions.GalleryImageVersionStorageProfile.properties.osDiskImage
    transform: $["x-ms-client-name"] = "OSDiskImage"
  - from: swagger-document
    where: $.definitions.ImageOSDisk.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.ImageOSDisk.properties.osState
    transform: $["x-ms-client-name"] = "OSState"
  - from: swagger-document
    where: $.definitions.ImageStorageProfile.properties.osDisk
    transform: $["x-ms-client-name"] = "OSDisk"
  - from: swagger-document
    where: $.definitions.OSDisk.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.RestorePointSourceMetadata.properties.osProfile
    transform: $["x-ms-client-name"] = "OSProfile"
  - from: swagger-document
    where: $.definitions.RestorePointSourceVMOSDisk
    transform: $["x-ms-client-name"] = "RestorePointSourceVmOSDisk"
  - from: swagger-document
    where: $.definitions.RestorePointSourceVMOSDisk.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.RestorePointSourceVMStorageProfile.properties.osDisk
    transform: $["x-ms-client-name"] = "OSDisk"
  - from: swagger-document
    where: $.definitions.RunCommandDocumentBase.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.SnapshotUpdateProperties.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.StorageProfile.properties.osDisk
    transform: $["x-ms-client-name"] = "OSDisk"
  - from: swagger-document
    where: $.definitions.VirtualMachineImageProperties.properties.osDiskImage
    transform: $["x-ms-client-name"] = "OSDiskImage"
  - from: swagger-document
    where: $.definitions.VirtualMachineInstanceView.properties.osName
    transform: $["x-ms-client-name"] = "OSName"
  - from: swagger-document
    where: $.definitions.VirtualMachineInstanceView.properties.osVersion
    transform: $["x-ms-client-name"] = "OSVersion"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetOSDisk.properties.osType
    transform: $["x-ms-client-name"] = "OSType"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetStorageProfile.properties.osDisk
    transform: $["x-ms-client-name"] = "OSDisk"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetUpdateStorageProfile.properties.osDisk
    transform: $["x-ms-client-name"] = "OSDisk"
  - from: swagger-document
    where: $.definitions.VirtualMachineSize.properties.osDiskSizeInMB
    transform: $["x-ms-client-name"] = "OSDiskSizeInMB"
# problematic word Vm
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[1]
    transform: $["name"] = "ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey"
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[2]
    transform: $["name"] = "ConfidentialVmDiskEncryptedWithPlatformKey"
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[3]
    transform: $["name"] = "ConfidentialVmDiskEncryptedWithCustomerKey"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMProfile
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmProfile"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetProperties.properties.doNotRunExtensionsOnOverprovisionedVMs
    transform: $["x-ms-client-name"] = "DoNotRunExtensionsOnOverprovisionedVms"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetUpdateProperties.properties.doNotRunExtensionsOnOverprovisionedVMs
    transform: $["x-ms-client-name"] = "DoNotRunExtensionsOnOverprovisionedVms"
  - from: swagger-document
    where: $.definitions.VMScaleSetConvertToSinglePlacementGroupInput
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetConvertToSinglePlacementGroupOptions"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMInstanceIDs
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmInstanceIds"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMInstanceRequiredIDs
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmInstanceRequiredIds"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}"].get.parameters[4]
    transform: $["x-ms-enum"].name = "ExpandTypesForGetVirtualMachineScaleSets"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMInstanceView
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmInstanceView"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMReimageParameters
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmReimageOptions"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMNetworkProfileConfiguration
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmNetworkProfileConfiguration"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMProtectionPolicy
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmProtectionPolicy"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMExtensionUpdate
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmExtensionUpdateOptions"
  - from: swagger-document
    where: $.definitions.VMGalleryApplication
    transform: $["x-ms-client-name"] = "VmGalleryApplication"
  - from: swagger-document
    where: $.definitions.DedicatedHostAllocatableVM
    transform: $["x-ms-client-name"] = "DedicatedHostAllocatableVm"
  - from: swagger-document
    where: $.definitions.DiskSecurityProfile.properties.secureVMDiskEncryptionSetId
    transform: $["x-ms-client-name"] = "SecureVmDiskEncryptionSetId"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups"].get.parameters[3]
    transform: >
        $["x-ms-enum"].values = [
            { "name": "VirtualMachineScaleSetVmsRef", "value": "virtualMachineScaleSetVMs/$ref" },
            { "name": "VirtualMachinesRef", "value": "virtualMachines/$ref" }
        ];
  - from: swagger-document
    where: $.definitions.DedicatedHostAvailableCapacity.properties.allocatableVMs
    transform: $["x-ms-client-name"] = "AllocatableVms"
  - from: swagger-document
    where: $.definitions.GrantAccessData.properties.getSecureVMGuestStateSAS
    transform: $["x-ms-client-name"] = "GetSecureVmGuestStateSAS"
  - from: swagger-document
    where: $.definitions.VMSizeProperties
    transform: $["x-ms-client-name"] = "VmSizeProperties"
  - from: swagger-document
    where: $.definitions.LinuxConfiguration.properties.provisionVMAgent
    transform: $["x-ms-client-name"] = "ProvisionVmAgent"
  - from: swagger-document
    where: $.definitions.VMGuestPatchClassificationLinux
    transform: $["x-ms-client-name"] = "VmGuestPatchClassificationLinux"
  - from: swagger-document
    where: $.definitions.LinuxPatchSettings.properties.patchMode["x-ms-enum"].name
    transform: return "LinuxVmGuestPatchMode"
  - from: swagger-document
    where: $.definitions.LinuxParameters.properties.classificationsToInclude.items["x-ms-enum"].name
    transform: return "VmGuestPatchClassification_Linux"
  - from: swagger-document
    where: $.definitions.PatchSettings.properties.patchMode["x-ms-enum"].name
    transform: return "WindowsVmGuestPatchMode"
  - from: swagger-document
    where: $.definitions.WindowsParameters.properties.classificationsToInclude.items["x-ms-enum"].name
    transform: return "VmGuestPatchClassification_Windows"
  - from: swagger-document
    where: $.definitions.RestorePointSourceVMStorageProfile
    transform: $["x-ms-client-name"] = "RestorePointSourceVmStorageProfile"
  - from: swagger-document
    where: $.definitions.RestorePointSourceVMDataDisk
    transform: $["x-ms-client-name"] = "RestorePointSourceVmDataDisk"
  - from: swagger-document
    where: $.definitions.VirtualMachineInstallPatchesParameters.properties.rebootSetting["x-ms-enum"].name
    transform: return "VmGuestPatchRebootSetting"
  - from: swagger-document
    where: $.definitions.VirtualMachineInstallPatchesResult.properties.rebootStatus["x-ms-enum"].name
    transform: return "VmGuestPatchRebootStatus"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMExtensionsSummary
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmExtensionsSummary"
  - from: swagger-document
    where: $.definitions.ScaleInPolicy.properties.rules.items["x-ms-enum"]
    transform: >
        $.values = [
            { "name": "Default", "value": "Default" },
            { "name": "OldestVm", "value": "OldestVM" },
            { "name": "NewestVm", "value": "NewestVM" }
        ]
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetUpdateVMProfile
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetUpdateVmProfile"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMExtensionsListResult
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmExtensionsListResult"
  - from: swagger-document
    where: $.definitions.VirtualMachineScaleSetVMExtensionsSummary
    transform: $["x-ms-client-name"] = "VirtualMachineScaleSetVmExtensionsSummary"
  - from: swagger-document
    where: $.definitions.VirtualMachineSoftwarePatchProperties.properties.rebootBehavior["x-ms-enum"].name
    transform: return "VmGuestPatchRebootBehavior"
  - from: swagger-document
    where: $.definitions.WindowsConfiguration.properties.provisionVMAgent
    transform: $["x-ms-client-name"] = "ProvisionVmAgent"
```
