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
output-folder: ./Generated

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  SSD: Ssd
  SAS: Sas

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
  LogAnalytics_ExportRequestRateByInterval: ExportLogAnalyticsRequestRateByInterval
  LogAnalytics_ExportThrottledRequests: ExportLogAnalyticsThrottledRequests

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}: SharedGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}/versions/{galleryImageVersionName}: SharedGalleryImageVersion

directive:
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
      from: Disk
      to: ManagedDisk
  - rename-model:
      from: EncryptionSettingsCollection
      to: EncryptionSettingGroup
#   - rename-model:
#       from: SubResourceReadOnly
#       to: ComputeSubResource
#   - rename-model:
#       from: SubResource
#       to: ComputeWriteableSubResource
  - rename-model:
      from: UpdateResource
      to: ComputeUpdateResourceData
  - rename-model:
      from: SubResourceWithColocationStatus
      to: ComputeSubResourceDataWithColocationStatus
  - rename-model:
      from: PrivateLinkResource
      to: PrivateLinkResourceData
# transform enum values
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[1]
    transform: $["name"] = "ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey"
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[2]
    transform: $["name"] = "ConfidentialVmDiskEncryptedWithPlatformKey"
  - from: swagger-document
    where: $.definitions.DiskSecurityType["x-ms-enum"].values[3]
    transform: $["name"] = "ConfidentialVmDiskEncryptedWithCustomerKey"
  - from: skus.json
    where: $.definitions
    transform: >
      $.ResourceSku["x-ms-client-name"] = "ComputeResourceSku";
      $.ResourceSkuCapacity["x-ms-client-name"] = "ComputeResourceSkuCapacity";
  - from: compute.json
    where: $.definitions
    transform: >
      $.VirtualMachineImageProperties.properties.dataDiskImages.description = "The list of data disk images information.";
      $.VirtualMachineInstallPatchesParameters.properties.maximumDuration["format"] = "duration";
      $.VirtualMachineExtensionUpdateProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineExtensionProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineScaleSetExtensionProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineScaleSetExtension.properties.type["x-ms-format"] = "resource-type";
      $.VirtualMachineNetworkInterfaceIPConfigurationProperties.properties.privateIPAddressVersion["x-ms-enum"].name = "IPVersion";
      $.VirtualMachinePublicIPAddressConfigurationProperties.properties.publicIPAddressVersion["x-ms-enum"].name = "IPVersion";
      $.SubResource["x-ms-client-name"] = "ComputeWriteableSubResourceData";
      $.SubResource.properties.id["x-ms-format"] = "arm-id";
      $.SubResourceReadOnly["x-ms-client-name"] = "ComputeSubResourceData";
      $.SubResourceReadOnly.properties.id["x-ms-format"] = "arm-id";
      $.RestorePointCollectionSourceProperties.properties.id["x-ms-format"] = "arm-id";
      $.RestorePointCollectionSourceProperties.properties.location["x-ms-format"] = "azure-location";
      $.RestorePointCollectionProperties.properties.restorePointCollectionId["x-ms-client-name"] = "restorePointGroupId";
  - from: disk.json
    where: $.definitions
    transform: >
      $.PurchasePlan["x-ms-client-name"] = "DiskPurchasePlan";
      $.GrantAccessData.properties.access.description = "The Access Level, accepted values include None, Read, Write.";
      $.DiskProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
      $.DiskRestorePointProperties.properties.sourceResourceId["x-ms-format"] = "arm-id";
      $.DiskProperties.properties.encryptionSettingsCollection["x-ms-client-name"] = "encryptionSettingGroup";
      $.DiskUpdateProperties.properties.encryptionSettingsCollection["x-ms-client-name"] = "encryptionSettingGroup";
      $.SnapshotProperties.properties.encryptionSettingsCollection["x-ms-client-name"] = "encryptionSettingGroup";
      $.SnapshotUpdateProperties.properties.encryptionSettingsCollection["x-ms-client-name"] = "encryptionSettingGroup";
      $.Encryption["x-ms-client-name"] = "DiskEncryption";
  - from: cloudService.json
    where: $.definitions
    transform: >
      $.UpdateDomain["x-ms-client-name"] = "UpdateDomainIdentifier";
      $.Extension["x-ms-client-name"] = "CloudServiceExtension";
      $.SubResource["x-ms-client-name"] = "ComputeWriteableSubResourceData";
      $.SubResource.properties.id["x-ms-format"] = "arm-id";
  - from: sharedGallery.json
    where: $.definitions
    transform: >
      $.PirResource["x-ms-client-name"] = "PirResourceData";
      $.PirResource.properties.location["x-ms-format"] = "azure-location";
      $.PirSharedGalleryResource["x-ms-client-name"] = "PirSharedGalleryResourceData";
  - from: communityGallery.json
    where: $.definitions
    transform: >
      $.PirCommunityGalleryResource["x-ms-client-name"] = "PirCommunityGalleryResourceData";
      $.PirCommunityGalleryResource.properties.type["x-ms-client-name"] = "ResourceType";
      $.PirCommunityGalleryResource.properties.location["x-ms-format"] = "azure-location";
      $.PirCommunityGalleryResource.properties.type["x-ms-format"] = "resource-type";
  - from: cloudService.json
    where: $.definitions.LoadBalancerConfigurationProperties
    transform: >
      $.properties.frontendIpConfigurations = $.properties.frontendIPConfigurations;
      $.properties.frontendIpConfigurations["x-ms-client-name"] = "frontendIPConfigurations";
      $.required = ["frontendIpConfigurations"];
      $.properties.frontendIPConfigurations = undefined;
    reason: Service returns response with property name as frontendIpConfigurations.
```
