# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/0ddf6bed82bb62f5b07efb86ef62e74fd63b3fc1/specification/compute/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

update-required-copy:
  GalleryImage: OSType

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

keep-plural-enums:
- IntervalInMins
- VmGuestPatchClassificationForWindows # we have this because the generator will change windows to window which does not make sense

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VirtualMachineScaleSet
  VmScaleSet: VirtualMachineScaleSet
  VmScaleSets: VirtualMachineScaleSets
  VMScaleSets: VirtualMachineScaleSets
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  SSD: Ssd
  SAS: Sas
  VCPUs: VCpus
  LRS: Lrs
  ZRS: Zrs
  RestorePointCollection: RestorePointGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models
  EncryptionSettingsCollection: EncryptionSettingsGroup # the word `collection` is reserved by the SDK, therefore we need to rename all the occurrences of this in all resources and models
  VHD: Vhd
  VHDX: Vhdx

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
  ResourceSkus_List: GetComputeResourceSkus
  VirtualMachineImages_ListWithProperties: GetVirtualMachineImagesWithProperties
  VirtualMachines_MigrateToVmScaleSet: MigrateToVirtualMachineScaleSet

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}: SharedGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}/versions/{galleryImageVersionName}: SharedGalleryImageVersion
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}: CommunityGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}: CommunityGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}: CommunityGalleryImageVersion

prepend-rp-prefix:
- UsageName
- UsageUnit
- ApiError
- ApiErrorBase
- DeleteOptions
- ResourceSku
- ResourceSkuCapacity
- ResourceSkuLocationInfo
- ResourceSkuRestrictions
- ResourceSkuRestrictionInfo
- ResourceSkuRestrictionsReasonCode
- ResourceSkuRestrictionsType
- ResourceSkuZoneDetails
- ResourceSkuCapacityScaleType
- EncryptionType
- PublicIPAddressSku
- PublicIPAddressSkuName
- PublicIPAddressSkuTier
- StatusLevelTypes

rename-mapping:
  DiskSecurityTypes.ConfidentialVM_VMGuestStateOnlyEncryptedWithPlatformKey: ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey
  SubResource: ComputeWriteableSubResourceData
  SubResourceReadOnly: ComputeSubResourceData
  HyperVGenerationType: HyperVGeneration
  HyperVGenerationTypes: HyperVGeneration
  VirtualMachineExtension.properties.type: ExtensionType
  VirtualMachineExtensionUpdate.properties.type: ExtensionType
  VirtualMachineScaleSetExtension.properties.type: ExtensionType
  VirtualMachineScaleSetExtensionUpdate.properties.type: ExtensionType
  VirtualMachineScaleSetVMExtension.properties.type: ExtensionType
  VirtualMachineScaleSetVMExtensionUpdate.properties.type: ExtensionType
  RollingUpgradeStatusInfo: VirtualMachineScaleSetRollingUpgrade
  OperatingSystemTypes: SupportedOperatingSystemType
  VirtualMachineImageResource: VirtualMachineImageBase
  RestorePointCollectionSourceProperties: RestorePointCollectionSource
  RestorePointExpandOptions: RestorePointExpand
  RestorePointCollectionExpandOptions: RestorePointCollectionExpand
  ImageReference.sharedGalleryImageId: sharedGalleryImageUniqueId
  UpdateResource: ComputeResourcePatch
  SubResourceWithColocationStatus: ComputeSubResourceDataWithColocationStatus
  SshPublicKey: SshPublicKeyConfiguration
  SshPublicKeyResource: SshPublicKey
  LogAnalyticsOperationResult: LogAnalytics
  PrivateLinkResource: ComputePrivateLinkResourceData
  PrivateLinkResource.properties.groupId: -|arm-id
  Disk: ManagedDisk
  Disk.managedBy: -|arm-id
  Disk.managedByExtended: -|arm-id
  Disk.properties.diskAccessId: -|arm-id
  DiskUpdate.properties.diskAccessId: -|arm-id
  DiskRestorePoint.properties.sourceResourceId: -|arm-id
  DiskRestorePoint.properties.diskAccessId: -|arm-id
  DiskRestorePoint.properties.sourceResourceLocation: -|azure-location
  Encryption: DiskEncryption
  Encryption.diskEncryptionSetId: -|arm-id
  Encryption.type: EncryptionType
  CreationData: DiskCreationData
  CreationData.storageAccountId: -|arm-id
  CreationData.sourceResourceId: -|arm-id
  Architecture: ArchitectureType
  OSFamily: CloudServiceOSFamily
  OSFamily.name: ResourceName
  OSFamily.properties.name: OSFamilyName
  OSVersion: CloudServiceOSVersion
  UpdateDomain: UpdateDomainIdentifier
  UpdateDomain.id: -|arm-id
  Extension: CloudServiceExtension
  RoleInstance: CloudServiceRoleInstance
  UpdateResourceDefinition: GalleryUpdateResourceData
  StorageAccountType: ImageStorageAccountType
  SharingProfile.permissions: permission
  UserArtifactManage: UserArtifactManagement
  GalleryExpandParams: GalleryExpand
  PirResource: PirResourceData
  PirSharedGalleryResource: PirSharedGalleryResourceData
  PirCommunityGalleryResource: PirCommunityGalleryResourceData
  PirCommunityGalleryResource.type: ResourceType|resource-type
  ExpandTypesForGetCapacityReservationGroups: CapacityReservationGroupGetExpand
  ExpandTypesForGetVMScaleSets: VirtualMachineScaleSetGetExpand
  DedicatedHostGroup.properties.hosts: DedicatedHosts
  UefiSettings.secureBootEnabled: IsSecureBootEnabled
  UefiSettings.vTpmEnabled: IsVirtualTpmEnabled
  NetworkProfile: VirtualMachineNetworkProfile
  NetworkInterfaceReference: VirtualMachineNetworkInterfaceReference
  Image: DiskImage
  VMDiskSecurityProfile: VirtualMachineDiskSecurityProfile
  VmDiskTypes: VirtualMachineDiskType
  VMGalleryApplication: VirtualMachineGalleryApplication
  VMSizeProperties: VirtualMachineSizeProperties
  ManagedDiskParameters: VirtualMachineManagedDisk
  VirtualMachineScaleSetManagedDiskParameters: VirtualMachineScaleSetManagedDisk
  StorageProfile: VirtualMachineStorageProfile
  OSProfile: VirtualMachineOSProfile
  OSDisk: VirtualMachineOSDisk
  DataDisk: VirtualMachineDataDisk
  HardwareProfile: VirtualMachineHardwareProfile
  PublicNetworkAccess: DiskPublicNetworkAccess
  LoadBalancerConfiguration: CloudServiceLoadBalancerConfiguration
  LoadBalancerConfiguration.id: -|arm-id
  ReplicationMode: GalleryReplicationMode
  ReplicationState: RegionalReplicationState
  RunCommandResult: VirtualMachineRunCommandResult
  UpgradeMode: VirtualMachineScaleSetUpgradeMode
  UpgradePolicy: VirtualMachineScaleSetUpgradePolicy
  ResourceSkuCapabilities: ComputeResourceSkuCapabilities
  ProtocolTypes: WinRMListenerProtocolType
  VMGuestPatchClassificationLinux: VmGuestPatchClassificationForLinux
  VMGuestPatchClassificationWindows: VmGuestPatchClassificationForWindows
  VirtualMachineScaleSetExtension.type: ResourceType|resource-type
  VirtualMachineScaleSetExtensionUpdate.type: ResourceType|resource-type
  VirtualMachineScaleSetVMExtension.type: ResourceType|resource-type
  VirtualMachineScaleSetVMExtensionUpdate.type: ResourceType|resource-type
  VirtualMachineScaleSetSku.resourceType: ResourceType|resource-type
  VirtualMachineScaleSetVMInstanceView.assignedHost: -|arm-id
  RestorePointCollectionSourceProperties.id: -|arm-id
  SshPublicKeyGenerateKeyPairResult.id: -|arm-id
  Snapshot.properties.diskAccessId: -|arm-id
  SnapshotUpdate.properties.diskAccessId: -|arm-id
  DiskSecurityProfile.secureVMDiskEncryptionSetId: -|arm-id
  ImageDiskReference.id: -|arm-id
  DiskImageEncryption.diskEncryptionSetId: -|arm-id
  GalleryDiskImage.source: GallerySource
  GalleryDiskImageSource.storageAccountId: -|arm-id
  GalleryImageVersionStorageProfile.source: GallerySource
  GalleryArtifactVersionSource.id: -|arm-id
  VirtualMachineExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetVMExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetVMExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  Disk.properties.optimizedForFrequentAttach: IsOptimizedForFrequentAttach
  DiskUpdate.properties.optimizedForFrequentAttach: IsOptimizedForFrequentAttach
  CreationData.performancePlus: IsPerformancePlusEnabled
  GalleryApplicationCustomActionParameter.required: IsRequired
  GalleryImageVersionSafetyProfile.reportedForPolicyViolation: IsReportedForPolicyViolation
  LinuxConfiguration.disablePasswordAuthentication: IsPasswordAuthenticationDisabled
  LinuxConfiguration.enableVMAgentPlatformUpdates: IsVMAgentPlatformUpdatesEnabled
  WindowsConfiguration.enableAutomaticUpdates: IsAutomaticUpdatesEnabled
  WindowsConfiguration.enableVMAgentPlatformUpdates: IsVMAgentPlatformUpdatesEnabled
  PolicyViolation: GalleryImageVersionPolicyViolation
  PolicyViolationCategory: GalleryImageVersionPolicyViolationCategory
  PriorityMixPolicy: VirtualMachineScaleSetPriorityMixPolicy
  CommunityGalleryImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  SharedGalleryImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  GalleryArtifactPublishingProfileBase.excludeFromLatest: IsExcludedFromLatest
  TargetRegion.excludeFromLatest: IsExcludedFromLatest
  VirtualMachineNetworkInterfaceConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetNetworkConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetUpdateNetworkConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  AlternativeOption: ImageAlternativeOption
  AlternativeType: ImageAlternativeType
  VirtualMachineScaleSetProperties.constrainedMaximumCapacity : IsMaximumCapacityConstrained
  VirtualMachineScaleSetUpdateProperties: VirtualMachineScaleSetPatchProperties
  RollingUpgradePolicy.maxSurge : IsMaxSurgeEnabled
  ScheduledEventsProfile: ComputeScheduledEventsProfile
  ExpandTypeForListVMs: GetVirtualMachineExpandType
  ExpandTypesForListVm: GetVirtualMachineExpandType
  RestorePointSourceVmStorageProfile.dataDisks: DataDiskList
  SecurityPostureReference.id: -|arm-id
  CommunityGalleryImage.properties.identifier: ImageIdentifier
  GalleryTargetExtendedLocation.storageAccountType: GalleryStorageAccountType
  FileFormat: DiskImageFileFormat
  CreationData.elasticSanResourceId: -|arm-id
  NetworkInterfaceAuxiliarySku: ComputeNetworkInterfaceAuxiliarySku
  NetworkInterfaceAuxiliaryMode: ComputeNetworkInterfaceAuxiliaryMode
  CommunityGalleryInfo.publisherUri: PublisherUriString
  GalleryArtifactVersionFullSource.virtualMachineId: -|arm-id
  SecurityPostureReference: ComputeSecurityPostureReference
  SecurityPostureReference.excludeExtensions: ExcludeExtensionNames
  SkuProfile : ComputeSkuProfile
  SkuProfileVMSize : ComputeSkuProfileVMSize
  AllocationStrategy : ComputeAllocationStrategy
  GalleryImageVersion.properties.restore: IsRestoreEnabled
  EndpointAccess: ComputeGalleryEndpointAccess
  EndpointTypes: ComputeGalleryEndpointTypes
  GallerySoftDeletedResource : GallerySoftDeletedResourceDetails
  GallerySoftDeletedResource.properties.softDeletedTime: -|date-time
  PlatformAttribute: ComputeGalleryPlatformAttribute
  ValidationStatus: ComputeGalleryValidationStatus
  AccessControlRules: GalleryInVmAccessControlRules
  AccessControlRulesIdentity: GalleryInVmAccessControlRulesIdentity
  AccessControlRulesMode: GalleryInVmAccessControlRulesMode
  AccessControlRulesPrivilege: GalleryInVmAccessControlRulesPrivilege
  AccessControlRulesRole: GalleryInVmAccessControlRulesRole
  AccessControlRulesRoleAssignment: GalleryInVmAccessControlRulesRoleAssignment
  ValidationsProfile: GalleryImageValidationsProfile
  SoftDeletedArtifactTypes: GallerySoftDeletedArtifactType
  GalleryImageVersionSafetyProfile.blockDeletionBeforeEndOfLife: IsBlockedDeletionBeforeEndOfLife
  ExecutedValidation: GalleryImageExecutedValidation
  Placement: VirtualMachinePlacement
  Modes: HostEndpointSettingsMode
  Expand: GetVirtualMachineImagesWithPropertiesExpand
  RebalanceBehavior: VmssRebalanceBehavior
  RebalanceStrategy: VmssRebalanceStrategy
  EventGridAndResourceGraph.enable: IsEventGridAndResourceGraphEnabled
  ReservationType : CapacityReservationType

directive:
# copy the systemData from common-types here so that it will be automatically replaced
  - from: common.json
    where: $.definitions
    transform: >
      $.SubResource.properties.id["x-ms-format"] = "arm-id";
      $.SubResourceReadOnly.properties.id["x-ms-format"] = "arm-id";
      $.SystemData = {
        "description": "Metadata pertaining to creation and last modification of the resource.",
        "type": "object",
        "readOnly": true,
        "properties": {
            "createdBy": {
            "type": "string",
            "description": "The identity that created the resource."
            },
            "createdByType": {
            "type": "string",
            "description": "The type of identity that created the resource.",
            "enum": [
                "User",
                "Application",
                "ManagedIdentity",
                "Key"
            ],
            "x-ms-enum": {
                "name": "createdByType",
                "modelAsString": true
            }
            },
            "createdAt": {
            "type": "string",
            "format": "date-time",
            "description": "The timestamp of resource creation (UTC)."
            },
            "lastModifiedBy": {
            "type": "string",
            "description": "The identity that last modified the resource."
            },
            "lastModifiedByType": {
            "type": "string",
            "description": "The type of identity that last modified the resource.",
            "enum": [
                "User",
                "Application",
                "ManagedIdentity",
                "Key"
            ],
            "x-ms-enum": {
                "name": "createdByType",
                "modelAsString": true
            }
            },
            "lastModifiedAt": {
            "type": "string",
            "format": "date-time",
            "description": "The timestamp of resource last modification (UTC)"
            }
          }
        };
  - from: ComputeRP.json
    where: $.definitions
    transform: >
      $.VirtualMachineInstallPatchesParameters.properties.maximumDuration["format"] = "duration";
  - from: ComputeRP.json
    where: $.definitions
    transform: >
      $.VirtualMachineImageProperties.properties.dataDiskImages.description = "The list of data disk images information.";
  - from: DiskRP.json
    where: $.definitions
    transform: >
      $.Disk.properties.managedByExtended.items["x-ms-format"] = "arm-id";
  - from: cloudService.json
    where: $.definitions
    transform: >
      $.CloudService.properties.properties["x-ms-client-flatten"] = true;
      $.OSFamily.properties.properties["x-ms-client-flatten"] = true;
      $.OSVersion.properties.properties["x-ms-client-flatten"] = true;
      $.Extension.properties.properties["x-ms-client-flatten"] = true;
      $.CloudServiceRole.properties.properties["x-ms-client-flatten"] = true;
      $.RoleInstance.properties.properties["x-ms-client-flatten"] = true;
      $.LoadBalancerConfiguration.properties.properties["x-ms-client-flatten"] = true;
      $.LoadBalancerFrontendIpConfiguration.properties.properties["x-ms-client-flatten"] = true;
  # rename the expand parameter in this operation to expandOption to avoid the breaking change of its type
  - from: ComputeRP.json
    where: $["x-ms-paths"]["/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions?$expand=Properties"].get
    transform: >
      $.parameters[6]["x-ms-client-name"] = "expandOption";
  # this makes the name in VirtualMachineScaleSetExtension to be readonly so that our inheritance chooser could properly make it inherit from Azure.ResourceManager.ResourceData. We have some customized code to add the setter for name back (as in constructor)
  - from: ComputeRP.json
    where: $.definitions.VirtualMachineScaleSetExtension.properties.name
    transform: $["readOnly"] = true;
  # add a json converter to this model
  - from: swagger-document
    where: $.definitions.KeyVaultSecretReference
    transform: $["x-csharp-usage"] = "converter";
  # TODO -- to be removed. This is a temporary workaround because the rename-mapping configuration is not working properly on arrays.
  - from: ComputeRP.json
    where: $.definitions.RestorePointSourceVMStorageProfile.properties.dataDisks
    transform: $["x-ms-client-name"] = "DataDiskList";
  # Add a dummy property because generator tries to flatten automaticallyApprove in both UserInitiatedRedeploy and AllInstancesDown
  - from: ComputeRP.json
    where: $.definitions.UserInitiatedRedeploy.properties
    transform: >
      $.dummyProperty = {
        "type": "string",
        "description": "This is a dummy property to prevent flattening."
      };
  - from: ComputeRP.json
    where: $.definitions.AllInstancesDown.properties
    transform: >
      $.dummyPropertyTwo = {
        "type": "string",
        "description": "This is a dummy property two to prevent flattening."
      };
  # add additionalproperties to a few models to support private properties supported by the service
  - from: ComputeRP.json
    where: $.definitions
    transform: >
      $.VirtualMachineScaleSetProperties.additionalProperties = true;
      $.VirtualMachineScaleSet.properties.properties["x-ms-client-flatten"] = false;
      $.VirtualMachineScaleSetUpdate.properties.properties["x-ms-client-flatten"] = false;
      $.VirtualMachineScaleSetVM.properties.properties["x-ms-client-flatten"] = false;
      $.VirtualMachineScaleSetVMProperties.additionalProperties = true;
      $.UpgradePolicy.additionalProperties = true;
  - from: ComputeRP.json
    where: $.definitions.VMSizeProperties
    transform: >
      $.additionalProperties = true;
  - from: ComputeRP.json
    where: $.definitions.Placement.properties.zonePlacementPolicy
    transform: >
      delete $["$ref"];
      $["type"] = "string";
  - from: ComputeRP.json
    where: $.definitions
    transform: delete $["Expand"]
  - from: ComputeRP.json
    where: $.definitions.VirtualMachineScaleSetStorageProfile.properties.diskControllerType
    transform: >
      delete $["$ref"];
      $["type"] = "string";
  - from: ComputeRP.json
    where: $.definitions.VirtualMachineScaleSetUpdateStorageProfile.properties.diskControllerType
    transform: >
      delete $["$ref"];
      $["type"] = "string";
```
