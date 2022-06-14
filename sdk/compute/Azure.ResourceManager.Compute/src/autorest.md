# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/2d6cb29af754f48a08f94cb6113bb1f01a4e0eb9/specification/compute/resource-manager/readme.md
tag: package-2022-03-02
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
  VCPUs: VCpus
  RestorePointCollection: RestorePointGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models
  EncryptionSettingsCollection: EncryptionSettingsGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointGroupName}/restorePoints/{restorePointName} # compute RP did not provide an API for listing this resource
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/runCommands/{runCommandName}: VirtualMachineScaleSetVmRunCommand

override-operation-name:
  VirtualMachines_Start: PowerOn
  VirtualMachineScaleSets_Start: PowerOn
  VirtualMachineScaleSetVMs_Start: PowerOn
  CloudServices_Start: PowerOn
  CloudServicesUpdateDomain_GetUpdateDomain: GetUpdateDomain
  CloudServicesUpdateDomain_ListUpdateDomains: GetUpdateDomains
  CloudServicesUpdateDomain_WalkUpdateDomain: WalkUpdateDomain
  GallerySharingProfile_Update: UpdateSharingProfile
  VirtualMachineImages_ListPublishers: GetVirtualMachineImagePublishers
  VirtualMachineImages_ListSkus: GetVirtualMachineImageSkus
  VirtualMachineImages_ListOffers: GetVirtualMachineImageOffers
  VirtualMachineImagesEdgeZone_ListSkus: GetVirtualMachineImageEdgeZoneSkus
  VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade: StartOSUpgrade
  LogAnalytics_ExportRequestRateByInterval: ExportLogAnalyticsRequestRateByInterval
  LogAnalytics_ExportThrottledRequests: ExportLogAnalyticsThrottledRequests

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}: SharedGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}/versions/{galleryImageVersionName}: SharedGalleryImageVersion
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}: CommunityGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}: CommunityGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}: CommunityGalleryImageVersion

directive:
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
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'location')]
    transform: $['x-ms-format'] = 'azure-location';
  - from: swagger-document
    where: $..parameters[?(@.name === 'location')]
    transform: $['x-ms-format'] = 'azure-location'
  - from: skus.json
    where: $.definitions
    transform: >
      $.ResourceSku["x-ms-client-name"] = "ComputeResourceSku";
      $.ResourceSku.properties.locations.items["x-ms-format"] = "azure-location";
      $.ResourceSkuCapacity["x-ms-client-name"] = "ComputeResourceSkuCapacity";
      $.ResourceSkuLocationInfo["x-ms-client-name"] = "ComputeResourceSkuLocationInfo";
      $.ResourceSkuLocationInfo.properties.location["x-ms-format"] = "azure-location";
      $.ResourceSkuRestrictionInfo["x-ms-format"] = "ComputeResourceSkuRestrictionInfo";
      $.ResourceSkuRestrictionInfo.properties.locations.items["x-ms-format"] = "azure-location";
  - from: common.json
    where: $.definitions
    transform: >
      $.SubResource["x-ms-client-name"] = "ComputeWriteableSubResourceData";
      $.SubResource.properties.id["x-ms-format"] = "arm-id";
      $.SubResourceReadOnly["x-ms-client-name"] = "ComputeSubResourceData";
      $.SubResourceReadOnly.properties.id["x-ms-format"] = "arm-id";
  - from: virtualMachine.json
    where: $.definitions
    transform: >
      $.VirtualMachineInstallPatchesParameters.properties.maximumDuration["format"] = "duration";
      $.VirtualMachineExtensionProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineExtensionUpdateProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineNetworkInterfaceIPConfigurationProperties.properties.privateIPAddressVersion["x-ms-enum"].name = "IPVersion";
      $.VirtualMachinePublicIPAddressConfigurationProperties.properties.publicIPAddressVersion["x-ms-enum"].name = "IPVersion";
  - from: virtualMachineImage.json
    where: $.definitions
    transform: >
      $.VirtualMachineImageProperties.properties.dataDiskImages.description = "The list of data disk images information.";
      $.VirtualMachineImageResource["x-ms-client-name"] = "VirtualMachineImageBase";
      $.VirtualMachineImageResource.properties.location["x-ms-format"] = "azure-location";
  - from: virtualMachineScaleSet.json
    where: $.definitions
    transform: >
      $.VirtualMachineScaleSetExtensionProperties.properties.type["x-ms-client-name"] = "ExtensionType";
      $.VirtualMachineScaleSetExtension.properties.type["x-ms-format"] = "resource-type";
      $.VirtualMachineScaleSetExtensionUpdate.properties.type["x-ms-format"] = "resource-type";
      $.VirtualMachineScaleSetVMExtension.properties.type["x-ms-format"] = "resource-type";
      $.VirtualMachineScaleSetVMExtensionUpdate.properties.type["x-ms-format"] = "resource-type";
      $.UpgradeOperationHistoricalStatusInfo.properties.location["x-ms-format"] = "azure-location";
      $.RollingUpgradeStatusInfo["x-ms-client-name"] = "VirtualMachineScaleSetRollingUpgrade";
      $.VirtualMachineScaleSetSku.properties.resourceType["x-ms-format"] = "resource-type";
      $.VirtualMachineScaleSetVMInstanceView.properties.assignedHost["x-ms-format"] = "arm-id";
  - from: restorePoint.json
    where: $.definitions
    transform: >
      $.RestorePointCollectionSourceProperties["x-ms-client-name"] = "RestorePointCollectionSource";
      $.RestorePointCollectionSourceProperties.properties.id["x-ms-format"] = "arm-id";
      $.RestorePointCollectionSourceProperties.properties.location["x-ms-format"] = "azure-location";
      $.RestorePointSourceMetadata.properties.location["x-ms-format"] = "azure-location";
  - from: restorePoint.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointCollectionName}/restorePoints/{restorePointName}"].get.parameters
    transform: >
      $[4]["x-ms-enum"].name = "RestorePointExpand";
  - from: restorePoint.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/restorePointCollections/{restorePointCollectionName}"].get.parameters
    transform: >
      $[3]["x-ms-enum"].name = "RestorePointCollectionExpand";
  - from: computeRPCommon.json
    where: $.definitions
    transform: >
      $.ImageReference.properties.sharedGalleryImageId["x-ms-client-name"] = "sharedGalleryImageUniqueId";
      $.SshPublicKey["x-ms-client-name"] = "SshPublicKeyInfo";
      $.UpdateResource["x-ms-client-name"] = "ComputeUpdateResourceData";
      $.SubResourceWithColocationStatus["x-ms-client-name"] = "ComputeSubResourceDataWithColocationStatus";
  - from: sshPublicKey.json
    where: $.definitions
    transform: >
      $.SshPublicKeyResource["x-ms-client-name"] = "SshPublicKey";
      $.SshPublicKeyGenerateKeyPairResult.properties.id["x-ms-format"] = "arm-id";
  - from: logAnalytic.json
    where: $.definitions
    transform: >
      $.LogAnalyticsOperationResult["x-ms-client-name"] = "LogAnalytics";
  - from: diskRPCommon.json
    where: $.definitions
    transform: >
      $.PurchasePlan["x-ms-client-name"] = "DiskPurchasePlan";
      $.GrantAccessData.properties.access.description = "The Access Level, accepted values include None, Read, Write.";
  - from: disk.json
    where: $.definitions
    transform: >
      $.Disk["x-ms-client-name"] = "ManagedDisk";
      $.Disk.properties.managedBy["x-ms-format"] = "arm-id";
      $.Disk.properties.managedByExtended.items["x-ms-format"] = "arm-id";
      $.DiskProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
      $.DiskUpdateProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
  - from: diskAccess.json
    where: $.definitions
    transform: >
      $.PrivateLinkResource["x-ms-client-name"] = "ComputePrivateLinkResourceData";
      $.PrivateLinkResourceProperties.properties.groupId["x-ms-format"] = "arm-id";
  - from: diskRestorePoint.json
    where: $.definitions
    transform: >
      $.DiskRestorePointProperties.properties.sourceResourceId["x-ms-format"] = "arm-id";
      $.DiskRestorePointProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
      $.DiskRestorePointProperties.properties.sourceResourceLocation["x-ms-format"] = "azure-location";
  - from: snapshot.json
    where: $.definitions
    transform: >
      $.SnapshotProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
      $.SnapshotUpdateProperties.properties.diskAccessId["x-ms-format"] = "arm-id";
  - from: diskRPCommon.json
    where: $.definitions
    transform: >
      $.Encryption["x-ms-client-name"] = "DiskEncryption";
      $.Encryption.properties.diskEncryptionSetId["x-ms-format"] = "arm-id";
      $.CreationData["x-ms-client-name"] = "DiskCreationData";
      $.CreationData.properties.storageAccountId["x-ms-format"] = "arm-id";
      $.CreationData.properties.sourceResourceId["x-ms-format"] = "arm-id";
      $.DiskSecurityProfile.properties.secureVMDiskEncryptionSetId["x-ms-format"] = "arm-id";
      $.ImageDiskReference.properties.id["x-ms-format"] = "arm-id";
      $.SupportedCapabilities.properties.architecture["x-ms-enum"].name = "ArchitectureTypes";
  - from: cloudService.json
    where: $.definitions
    transform: >
      $.CloudService.properties.properties["x-ms-client-flatten"] = true;
      $.OSFamily["x-ms-client-name"] = "CloudServiceOSFamily";
      $.OSFamily.properties.location["x-ms-format"] = "azure-location";
      $.OSFamily.properties.properties["x-ms-client-flatten"] = true;
      $.OSVersion["x-ms-client-name"] = "CloudServiceOSVersion";
      $.OSVersion.properties.properties["x-ms-client-flatten"] = true;
      $.OSVersion.properties.location["x-ms-format"] = "azure-location";
      $.UpdateDomain["x-ms-client-name"] = "UpdateDomainIdentifier";
      $.UpdateDomain.properties.id["x-ms-format"] = "arm-id";
      $.Extension["x-ms-client-name"] = "CloudServiceExtension";
      $.Extension.properties.properties["x-ms-client-flatten"] = true;
      $.SubResource["x-ms-client-name"] = "ComputeWriteableSubResourceData";
      $.SubResource.properties.id["x-ms-format"] = "arm-id";
      $.CloudServiceRole.properties.location["x-ms-format"] = "azure-location";
      $.CloudServiceRole.properties.properties["x-ms-client-flatten"] = true;
      $.RoleInstance["x-ms-client-name"] = "CloudServiceRoleInstance";
      $.RoleInstance.properties.location["x-ms-format"] = "azure-location";
      $.RoleInstance.properties.properties["x-ms-client-flatten"] = true;
      $.LoadBalancerConfiguration.properties.id["x-ms-format"] = "arm-id";
      $.LoadBalancerConfiguration.properties.properties["x-ms-client-flatten"] = true;
      $.LoadBalancerFrontendIPConfiguration.properties.properties["x-ms-client-flatten"] = true;
  - from: galleryRPCommon.json
    where: $.definitions
    transform: >
      $.Architecture["x-ms-enum"].name = "ArchitectureTypes";
  - from: gallery.json
    where: $.definitions
    transform: >
      $.DiskImageEncryption.properties.diskEncryptionSetId["x-ms-format"] = "arm-id";
      $.GalleryArtifactVersionSource.properties.id["x-ms-format"] = "arm-id";
      $.UpdateResourceDefinition["x-ms-client-name"] = "GalleryUpdateResourceData";
  - from: gallery.json
    where: $.parameters
    transform: >
      $.GalleryODataExpandQueryParameter["x-ms-enum"].name = "GalleryExpand";
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
