# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci
namespace: Azure.ResourceManager.Hci
require: https://github.com/Azure/azure-rest-api-specs/blob/d99f18b18405cd446f7abc2c9e6b3884f5c549f8/specification/azurestackhci/resource-manager/readme.md
tag: package-preview-2022-12-15
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  '*TenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ClientId': 'uuid'
  '*ApplicationObjectId': 'uuid'
  '*ServicePrincipalObjectId': 'uuid'

rename-rules:
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
  VMScaleSet: VmScaleSet
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

prepend-rp-prefix:
  - Cluster
  - ProvisioningState
  - ClusterDesiredProperties
  - ClusterNode
  - ClusterReportedProperties
  - AvailabilityType
  - HealthState
  - OfferList
  - PackageVersionInfo
  - PrecheckResult
  - PrecheckResultTags
  - PublisherList
  - SkuList
  - SkuMappings
  - UpdateList
  - PublisherCollection
  - ExtensionInstanceView
  - StatusLevelTypes
  - GalleryImages
  - GalleryImageIdentifier
  - GalleryImageStatus
  - GalleryImageVersion
  - MarketplaceGalleryImages
  - MarketplaceGalleryImageStatus
  - GuestAgent
  - GuestAgentProfile
  - GuestCredential
  - NetworkInterfaces
  - StorageContainers
  - StorageContainerStatus
  - VirtualMachines
  - VirtualNetworks
  - VirtualHardDisks
  - VirtualHardDiskStatus
  - HybridIdentityMetadata
  - MachineExtension
  - DiskFileFormat
  - ExtendedLocation
  - ExtendedLocationTypes
  - HyperVGeneration
  - IPConfiguration
  - IPConfigurationProperties
  - IPPool
  - IPPoolInfo
  - MachineExtensionInstanceView
  - NetworkInterfaceStatus
  - OperatingSystemType
  - ResourcePatch
  - VirtualMachineStatus
  - VirtualNetworkStatus

rename-mapping:
  Extension: ArcExtension
  Extension.properties.extensionParameters.autoUpgradeMinorVersion: ShouldAutoUpgradeMinorVersion
  Extension.properties.extensionParameters.type: ArcExtensionType
  Status: HciClusterStatus
  ClusterReportedProperties.clusterId: -|uuid
  Cluster.properties.cloudId: -|uuid
  ArcIdentityResponse: ArcIdentityResult
  ClusterIdentityResponse: HciClusterIdentityResult
  ClusterReportedProperties.lastUpdated: LastUpdatedOn
  ClusterList: HciClusterListResult
  DiagnosticLevel: HciClusterDiagnosticLevel
  ExtensionAggregateState: ArcExtensionAggregateState
  ExtensionList: ArcExtensionListResult
  ImdsAttestation: ImdsAttestationState
  PasswordCredential: ArcPasswordCredential
  UploadCertificateRequest: HciClusterCertificateContent
  RawCertificateData: HciClusterRawCertificate
  PerNodeState: PerNodeArcState
  RebootRequirement: HciNodeRebootRequirement
  Severity: UpdateSeverity
  State: HciUpdateState
  Step: HciUpdateStep
  OfferCollection: HciOfferCollection
  OfferData: HciOfferData
  GalleryImageStatusProvisioningStatus: HciGalleryImageProvisioningStatus
  MarketplaceGalleryImageStatusProvisioningStatus: HciMarketplaceGalleryImageProvisioningStatus
  HardwareProfileUpdate: HciHardwareProfilePatch
  IpAllocationMethodEnum: HciIPAllocationMethodType
  IPPoolTypeEnum: HciIPPoolType
  MachineExtensionInstanceViewStatus: HciInstanceViewStatus
  NetworkInterfaceStatusProvisioningStatus: HciNetworkInterfaceProvisioningStatus
  NetworkTypeEnum: HciNetworkType
  NetworkTypeEnum.ICS: Ics
  OsTypeEnum: HciOSType
  PowerStateEnum: HciPowerState
  PrivateIPAllocationMethodEnum: HciPrivateIPAllocationMethodType
  ProvisioningAction: HciAgentProvisioningAction
  ProvisioningStateEnum: HciGenericProvisioningState
  StatusTypes: HciAgentStatusType
  StorageContainerStatusProvisioningStatus: HciStorageContainerProvisioningStatus
  VirtualHardDiskStatusProvisioningStatus: HciVirtualHardDiskProvisioningStatus
  VirtualMachinePropertiesHardwareProfile: HciHardwareProfile
  VirtualMachinePropertiesHardwareProfileDynamicMemoryConfig: DynamicMemoryConfiguration
  VirtualMachinePropertiesOsProfile: HciOSProfile
  VirtualMachinePropertiesOsProfileLinuxConfiguration: HciLinuxConfiguration
  VirtualMachinePropertiesOsProfileLinuxConfigurationSshPublicKeysItem: HciLinuxSshPublicKey
  VirtualMachinePropertiesOsProfileWindowsConfiguration: HciWindowsConfiguration
  VirtualMachinePropertiesOsProfileWindowsConfigurationSshPublicKeysItem: HciWindowsSshPublicKey
  VirtualMachinePropertiesSecurityProfile: HciSecurityProfile
  VirtualMachinePropertiesStorageProfile: HciStorageProfile
  VirtualMachineStatusProvisioningStatus: HciVirtualMachineProvisioningStatus
  VirtualMachineUpdateProperties: HciVirtualMachinePatchProperties
  VirtualNetworkPropertiesSubnetsItem: HciSubnet
  VirtualNetworkPropertiesSubnetsPropertiesItemsItem: HciSubnetRoute
  ComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable: HciSubnetRouteTable
  VirtualNetworkStatusProvisioningStatus: HciVirtualNetworkProvisioningStatus
  VmSizeEnum: HciVirtualMachineSize

directive:
  # Common type should not be flatten
  - from: swagger-document
    where: $.definitions..systemData
    transform: $['x-ms-client-flatten'] = false
  - from: swagger-document
    where: $.definitions..identity
    transform: $['x-ms-client-flatten'] = false
  # Fix the format of duration
  - from: updateRuns.json
    where: $.definitions.UpdateRunProperties.properties
    transform: >
      $.duration['x-ms-format'] = 'string';
  # Dup SystemData
  - from: arcSettings.json
    where: $.definitions
    transform: >
      delete $.ArcSetting.properties.systemData;
  - from: clusters.json
    where: $.definitions
    transform: >
      delete $.Cluster.properties.systemData;
  - from: extensions.json
    where: $.definitions
    transform: >
      delete $.Extension.properties.systemData;
  - from: updates.json
    where: $.definitions
    transform: >
      delete $.Update.properties.systemData;
  - from: virtualMachines.json
    where: $.definitions
    transform: >
      delete $.HybridIdentityMetadata.properties.systemData;
      delete $.GuestAgent.properties.systemData;
  # Fix the enum
  - from: updateSummaries.json
    where: $.definitions
    transform: >
      $.PrecheckResult.properties.severity.enum = [
            'Critical',
            'Warning',
            'Informational',
            'Hidden'
          ];
  # Fix operation ids for GuestAgents
  - from: virtualMachines.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/virtualMachines/{virtualMachineName}/guestAgents/{name}']
    transform: >
      $.put.operationId = 'GuestAgents_Create';
      $.get.operationId = 'GuestAgents_Get';
      $.delete.operationId = 'GuestAgents_Delete';
  # Change allof to ref
  - from: virtualMachines.json
    where: $.definitions
    transform: >
      delete $.MachineExtensionProperties.properties.instanceView.allof;
      $.MachineExtensionProperties.properties.instanceView['$ref'] = '#/definitions/MachineExtensionInstanceView';

```
