# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.Compute

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: Compute
namespace: Azure.ResourceManager.Compute
require: https://github.com/Azure/azure-rest-api-specs/blob/7b956d28f9182fe7ddc319d43495e19fff57457b/specification/compute/resource-manager/readme.md
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
  CloudServices_Start: PowerOn
  CloudServicesUpdateDomain_GetUpdateDomain: GetUpdateDomain
  CloudServicesUpdateDomain_ListUpdateDomains: GetUpdateDomains
  CloudServicesUpdateDomain_WalkUpdateDomain: WalkUpdateDomain
  GallerySharingProfile_Update: UpdateSharingProfile
  LogAnalytics_ExportRequestRateByInterval: ExportLogAnalyticsRequestRateByInterval
  LogAnalytics_ExportThrottledRequests: ExportLogAnalyticsThrottledRequests
  ResourceSkus_List: GetComputeResourceSkus
  VirtualMachineImages_ListOffers: GetVirtualMachineImageOffers
  VirtualMachineImages_ListPublishers: GetVirtualMachineImagePublishers
  VirtualMachineImages_ListSkus: GetVirtualMachineImageSkus
  VirtualMachineImages_ListWithProperties: GetVirtualMachineImagesWithProperties
  VirtualMachineImagesEdgeZone_ListSkus: GetVirtualMachineImageEdgeZoneSkus
  VirtualMachines_MigrateToVmScaleSet: MigrateToVirtualMachineScaleSet
  VirtualMachines_Start: PowerOn
  VirtualMachineScaleSets_Start: PowerOn
  VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade: StartOSUpgrade
  VirtualMachineScaleSetVMs_Start: PowerOn

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}: CommunityGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}: CommunityGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}: CommunityGalleryImageVersion
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}: SharedGalleryImage
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}/images/{galleryImageName}/versions/{galleryImageVersionName}: SharedGalleryImageVersion

prepend-rp-prefix:
- ApiError
- ApiErrorBase
- DeleteOptions
- EncryptionType
- PublicIPAddressSku
- PublicIPAddressSkuName
- PublicIPAddressSkuTier
- ResourceSku
- ResourceSkuCapacity
- ResourceSkuCapacityScaleType
- ResourceSkuLocationInfo
- ResourceSkuRestrictionInfo
- ResourceSkuRestrictions
- ResourceSkuRestrictionsReasonCode
- ResourceSkuRestrictionsType
- ResourceSkuZoneDetails
- StatusLevelTypes
- UsageName
- UsageUnit

rename-mapping:
  AccessControlRules: GalleryInVmAccessControlRules
  AccessControlRulesIdentity: GalleryInVmAccessControlRulesIdentity
  AccessControlRulesMode: GalleryInVmAccessControlRulesMode
  AccessControlRulesPrivilege: GalleryInVmAccessControlRulesPrivilege
  AccessControlRulesRole: GalleryInVmAccessControlRulesRole
  AccessControlRulesRoleAssignment: GalleryInVmAccessControlRulesRoleAssignment
  AllocationStrategy : ComputeAllocationStrategy
  AlternativeOption: ImageAlternativeOption
  AlternativeType: ImageAlternativeType
  Architecture: ArchitectureType
  CommunityGalleryImage.properties.identifier: ImageIdentifier
  CommunityGalleryImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  CommunityGalleryInfo.publisherUri: PublisherUriString
  CreationData: DiskCreationData
  CreationData.elasticSanResourceId: -|arm-id
  CreationData.performancePlus: IsPerformancePlusEnabled
  CreationData.sourceResourceId: -|arm-id
  CreationData.storageAccountId: -|arm-id
  DataDisk: VirtualMachineDataDisk
  DedicatedHostGroup.properties.hosts: DedicatedHosts
  Disk: ManagedDisk
  Disk.managedBy: -|arm-id
  Disk.managedByExtended: -|arm-id
  Disk.properties.diskAccessId: -|arm-id
  Disk.properties.optimizedForFrequentAttach: IsOptimizedForFrequentAttach
  DiskImageEncryption.diskEncryptionSetId: -|arm-id
  DiskRestorePoint.properties.diskAccessId: -|arm-id
  DiskRestorePoint.properties.sourceResourceId: -|arm-id
  DiskRestorePoint.properties.sourceResourceLocation: -|azure-location
  DiskSecurityProfile.secureVMDiskEncryptionSetId: -|arm-id
  DiskSecurityTypes.ConfidentialVM_VMGuestStateOnlyEncryptedWithPlatformKey: ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey
  DiskUpdate.properties.diskAccessId: -|arm-id
  DiskUpdate.properties.optimizedForFrequentAttach: IsOptimizedForFrequentAttach
  EndpointAccess: ComputeGalleryEndpointAccess
  EndpointTypes: ComputeGalleryEndpointTypes
  Encryption: DiskEncryption
  Encryption.diskEncryptionSetId: -|arm-id
  Encryption.type: EncryptionType
  EventGridAndResourceGraph.enable: IsEnabled
  ExecutedValidation: GalleryImageExecutedValidation
  Expand: GetVirtualMachineImagesWithPropertiesExpand
  ExpandTypeForListVMs: GetVirtualMachineExpandType
  ExpandTypesForGetCapacityReservationGroups: CapacityReservationGroupGetExpand
  ExpandTypesForGetVMScaleSets: VirtualMachineScaleSetGetExpand
  ExpandTypesForListVm: GetVirtualMachineExpandType
  Extension: CloudServiceExtension
  FileFormat: DiskImageFileFormat
  GalleryArtifactPublishingProfileBase.excludeFromLatest: IsExcludedFromLatest
  GalleryArtifactVersionFullSource.virtualMachineId: -|arm-id
  GalleryArtifactVersionSource.id: -|arm-id
  GalleryApplicationCustomActionParameter.required: IsRequired
  GalleryDiskImage.source: GallerySource
  GalleryDiskImageSource.storageAccountId: -|arm-id
  GalleryExpandParams: GalleryExpand
  GalleryImageVersion.properties.restore: IsRestoreEnabled
  GalleryImageVersionSafetyProfile.blockDeletionBeforeEndOfLife: IsBlockedDeletionBeforeEndOfLife
  GalleryImageVersionSafetyProfile.reportedForPolicyViolation: IsReportedForPolicyViolation
  GalleryImageVersionStorageProfile.source: GallerySource
  GallerySoftDeletedResource : GallerySoftDeletedResourceDetails
  GallerySoftDeletedResource.properties.softDeletedTime: -|date-time
  GalleryTargetExtendedLocation.storageAccountType: GalleryStorageAccountType
  HardwareProfile: VirtualMachineHardwareProfile
  HyperVGenerationType: HyperVGeneration
  HyperVGenerationTypes: HyperVGeneration
  Image: DiskImage
  ImageDiskReference.id: -|arm-id
  ImageReference.sharedGalleryImageId: sharedGalleryImageUniqueId
  LinuxConfiguration.disablePasswordAuthentication: IsPasswordAuthenticationDisabled
  LinuxConfiguration.enableVMAgentPlatformUpdates: IsVMAgentPlatformUpdatesEnabled
  LoadBalancerConfiguration: CloudServiceLoadBalancerConfiguration
  LoadBalancerConfiguration.id: -|arm-id
  LogAnalyticsOperationResult: LogAnalytics
  ManagedDiskParameters: VirtualMachineManagedDisk
  Modes: HostEndpointSettingsMode
  NetworkInterfaceAuxiliaryMode: ComputeNetworkInterfaceAuxiliaryMode
  NetworkInterfaceAuxiliarySku: ComputeNetworkInterfaceAuxiliarySku
  NetworkInterfaceReference: VirtualMachineNetworkInterfaceReference
  NetworkProfile: VirtualMachineNetworkProfile
  OperatingSystemTypes: SupportedOperatingSystemType
  OrchestrationServiceSummary.lastStatusChangeTime: LastStatusChangedOn
  OSFamily: CloudServiceOSFamily
  OSFamily.name: ResourceName
  OSFamily.properties.name: OSFamilyName
  OSDisk: VirtualMachineOSDisk
  OSProfile: VirtualMachineOSProfile
  OSVersion: CloudServiceOSVersion
  PirCommunityGalleryResource: PirCommunityGalleryResourceData
  PirCommunityGalleryResource.type: ResourceType|resource-type
  PirResource: PirResourceData
  PirSharedGalleryResource: PirSharedGalleryResourceData
  Placement: VirtualMachinePlacement
  PlatformAttribute: ComputeGalleryPlatformAttribute
  PolicyViolation: GalleryImageVersionPolicyViolation
  PolicyViolationCategory: GalleryImageVersionPolicyViolationCategory
  PriorityMixPolicy: VirtualMachineScaleSetPriorityMixPolicy
  PrivateLinkResource: ComputePrivateLinkResourceData
  PrivateLinkResource.properties.groupId: -|arm-id
  ProtocolTypes: WinRMListenerProtocolType
  PublicNetworkAccess: DiskPublicNetworkAccess
  RebalanceBehavior: VmssRebalanceBehavior
  RebalanceStrategy: VmssRebalanceStrategy
  ReplicationMode: GalleryReplicationMode
  ReplicationState: RegionalReplicationState
  ReservationType : CapacityReservationType
  RestorePointCollectionExpandOptions: RestorePointCollectionExpand
  RestorePointCollectionSourceProperties: RestorePointCollectionSource
  RestorePointCollectionSourceProperties.id: -|arm-id
  RestorePointExpandOptions: RestorePointExpand
  RestorePointSourceVmStorageProfile.dataDisks: DataDiskList
  ResourceSkuCapabilities: ComputeResourceSkuCapabilities
  RoleInstance: CloudServiceRoleInstance
  RollingUpgradePolicy.maxSurge : IsMaxSurgeEnabled
  RollingUpgradeStatusInfo: VirtualMachineScaleSetRollingUpgrade
  RunCommandResult: VirtualMachineRunCommandResult
  ScheduledEventsProfile: ComputeScheduledEventsProfile
  SecurityPostureReference: ComputeSecurityPostureReference
  SecurityPostureReference.excludeExtensions: ExcludeExtensionNames
  SecurityPostureReference.id: -|arm-id
  SharedGalleryImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  SharingProfile.permissions: permission
  SkuProfile : ComputeSkuProfile
  SkuProfileVMSize : ComputeSkuProfileVMSize
  Snapshot.properties.diskAccessId: -|arm-id
  SnapshotUpdate.properties.diskAccessId: -|arm-id
  SoftDeletedArtifactTypes: GallerySoftDeletedArtifactType
  SshPublicKey: SshPublicKeyConfiguration
  SshPublicKeyGenerateKeyPairResult.id: -|arm-id
  SshPublicKeyResource: SshPublicKey
  StorageAccountType: ImageStorageAccountType
  StorageProfile: VirtualMachineStorageProfile
  SubResource: ComputeWriteableSubResourceData
  SubResourceReadOnly: ComputeSubResourceData
  SubResourceWithColocationStatus: ComputeSubResourceDataWithColocationStatus
  TargetRegion.excludeFromLatest: IsExcludedFromLatest
  UefiSettings.secureBootEnabled: IsSecureBootEnabled
  UefiSettings.vTpmEnabled: IsVirtualTpmEnabled
  UpdateDomain: UpdateDomainIdentifier
  UpdateDomain.id: -|arm-id
  UpdateResource: ComputeResourcePatch
  UpdateResourceDefinition: GalleryUpdateResourceData
  UpgradeMode: VirtualMachineScaleSetUpgradeMode
  UpgradePolicy: VirtualMachineScaleSetUpgradePolicy
  UserArtifactManage: UserArtifactManagement
  ValidationStatus: ComputeGalleryValidationStatus
  ValidationsProfile: GalleryImageValidationsProfile
  VirtualMachineExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineExtension.properties.type: ExtensionType
  VirtualMachineExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineExtensionUpdate.properties.type: ExtensionType
  VirtualMachineImageResource: VirtualMachineImageBase
  VirtualMachineNetworkInterfaceConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetExtension.properties.type: ExtensionType
  VirtualMachineScaleSetExtension.type: ResourceType|resource-type
  VirtualMachineScaleSetExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetExtensionUpdate.properties.type: ExtensionType
  VirtualMachineScaleSetExtensionUpdate.type: ResourceType|resource-type
  VirtualMachineScaleSetManagedDiskParameters: VirtualMachineScaleSetManagedDisk
  VirtualMachineScaleSetNetworkConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetProperties.constrainedMaximumCapacity : IsMaximumCapacityConstrained
  VirtualMachineScaleSetSku.resourceType: ResourceType|resource-type
  VirtualMachineScaleSetUpdateNetworkConfiguration.properties.disableTcpStateTracking: IsTcpStateTrackingDisabled
  VirtualMachineScaleSetUpdateProperties: VirtualMachineScaleSetPatchProperties
  VirtualMachineScaleSetVMExtension.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetVMExtension.properties.type: ExtensionType
  VirtualMachineScaleSetVMExtension.type: ResourceType|resource-type
  VirtualMachineScaleSetVMExtensionUpdate.properties.protectedSettingsFromKeyVault: KeyVaultProtectedSettings
  VirtualMachineScaleSetVMExtensionUpdate.properties.type: ExtensionType
  VirtualMachineScaleSetVMExtensionUpdate.type: ResourceType|resource-type
  VirtualMachineScaleSetVMInstanceView.assignedHost: -|arm-id
  VmDiskTypes: VirtualMachineDiskType
  VMDiskSecurityProfile: VirtualMachineDiskSecurityProfile
  VMGalleryApplication: VirtualMachineGalleryApplication
  VMGuestPatchClassificationLinux: VmGuestPatchClassificationForLinux
  VMGuestPatchClassificationWindows: VmGuestPatchClassificationForWindows
  VMSizeProperties: VirtualMachineSizeProperties
  WindowsConfiguration.enableAutomaticUpdates: IsAutomaticUpdatesEnabled
  WindowsConfiguration.enableVMAgentPlatformUpdates: IsVMAgentPlatformUpdatesEnabled

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
