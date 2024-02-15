# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: DataBoxEdge
namespace: Azure.ResourceManager.DataBoxEdge
require: https://github.com/Azure/azure-rest-api-specs/blob/df70965d3a207eb2a628c96aa6ed935edc6b7911/specification/databoxedge/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/jobs/{name}

prepend-rp-prefix:
  - Job
  - JobStatus
  - JobErrorDetails
  - JobErrorItem
  - JobType
  - Alert
  - AlertSeverity
  - Order
  - OrderStatus
  - OrderState
  - Role
  - Share
  - StorageAccount
  - StorageAccountCredential
  - StorageAccountStatus
  - Trigger
  - User
  - DayOfWeek
  - Node
  - NodeList
  - NodeStatus
  - EncryptionAlgorithm
  - AuthenticationType
  - ContactDetails
  - DataPolicy
  - DataResidencyType
  - DeviceType
  - DownloadPhase
  - EtcdInfo
  - LoadBalancerConfig
  - MetricConfiguration
  - MetricCounter
  - MetricCounterSet
  - MetricDimension
  - MountPointMap
  - MountType
  - NetworkAdapter
  - NetworkGroup
  - RefreshDetails
  - ResourceMoveDetails
  - ResourceMoveStatus
  - RoleStatus
  - RoleTypes
  - RoleSinkInfo
  - SecuritySettings
  - ShipmentType
  - SkuAvailability
  - SkuCapability
  - SkuCost
  - SkuLocationInfo
  - SkuSignupOption
  - SkuVersion
  - SubscriptionState
  - SymmetricKey
  - TrackingInfo
  - UpdateDetails
  - UpdateOperation
  - UpdateStatus
  - UpdateType
  - UserType
  - VmMemory
  - AlertErrorDetails

rename-mapping:
  DataBoxEdgeSku: AvailableDataBoxEdgeSku
  DataBoxEdgeSkuList: AvailableDataBoxEdgeSkuList
  Addon: DataBoxEdgeRoleAddon
  AddonState: DataBoxEdgeRoleAddonProvisioningState
  Alert.properties.appearedAtDateTime: AppearedOn
  BandwidthSchedule.properties.start: StartOn
  BandwidthSchedule.properties.stop: StopOn
  Container: DataBoxEdgeStorageContainer
  DataBoxEdgeDevice.properties.systemData: SystemData
  DCAccessCode: DataBoxEdgeDataCenterAccessCode
  SSLStatus: DataBoxEdgeStorageAccountSslStatus
  AccessLevel: EdgeRemoteApplicationAccessLevel
  AccountType: DataBoxEdgeStorageAccountType
  Address: DataBoxEdgeShippingAddress
  ClusterMemoryCapacity.clusterFailoverMemoryMb: ClusterFailoverMemoryInMB
  ClusterMemoryCapacity.clusterFreeMemoryMb: ClusterFreeMemoryInMB
  ClusterMemoryCapacity.clusterUsedMemoryMb: ClusterUsedMemoryInMB
  ClusterMemoryCapacity.clusterFragmentationMemoryMb: ClusterFragmentationMemoryInMB
  ClusterMemoryCapacity.clusterHyperVReserveMemoryMb: ClusterHyperVReserveMemoryInMB
  ClusterMemoryCapacity.clusterInfraVmMemoryMb: ClusterInfraVmMemoryInMB
  ClusterMemoryCapacity.clusterTotalMemoryMb: ClusterTotalMemoryInMB
  ClusterMemoryCapacity.clusterNonFailoverVmMb: ClusterNonFailoverVmInMB
  ClusterMemoryCapacity.clusterMemoryUsedByVmsMb: ClusterMemoryUsedByVmsInMB
  ClusterStorageViewData.clusterFreeStorageMb: ClusterFreeStorageInMB
  ClusterStorageViewData.clusterTotalStorageMb: ClusterTotalStorageInMB
  GenerateCertResponse: GenerateCertResult
  GenerateCertResponse.expiryTimeInUTC: ExpireOn
  HostCapacity.effectiveAvailableMemoryMbOnHost: EffectiveAvailableMemoryInMBOnHost
  NodeInfo: EdgeKubernetesNodeInfo
  NumaNodeData.effectiveAvailableMemoryInMb: EffectiveAvailableMemoryInMB
  NumaNodeData.totalMemoryInMb: TotalMemoryInMB
  NumaNodeData: NumaNodeInfo
  PlatformType: DataBoxEdgeOSPlatformType
  RemoteSupportSettings.expirationTimeStampInUTC: ExpireOn
  Secret: DataBoxEdgeDeviceSecret
  UpdateDetails.updateSize: UpdateSizeInBytes
  UserAccessRight.userId: -|arm-id
  VmMemory.startupMemoryMB: StartupMemoryInMB
  VmMemory.currentMemoryUsageMB: CurrentMemoryUsageInMB
  UpdateSummary: DataBoxEdgeDeviceUpdateSummary
  NetworkSettings: DataBoxEdgeDeviceNetworkSettings
  DeviceCapacityInfo: DataBoxEdgeDeviceCapacityInfo
  Ipv4Config.ipAddress: -|ip-address
  IoTDeviceInfo.ioTHostHubId: -|arm-id
  AzureContainerDataFormat: DataBoxEdgeStorageContainerDataFormat
  AzureContainerInfo: DataBoxEdgeStorageContainerInfo
  ContainerStatus: DataBoxEdgeStorageContainerStatus
  ComputeResource: EdgeComputeResourceInfo
  MonitoringStatus: DataBoxEdgeShareMonitoringStatus
  MetricConfiguration.resourceId: -|arm-id
  ArcAddon: EdgeArcAddon
  IoTAddon: EdgeIotAddon
  IoTDeviceInfo: EdgeIotDeviceInfo
  IoTRole: EdgeIotRole
  Ipv4Config: DataBoxEdgeIPv4Config
  Ipv6Config: DataBoxEdgeIPv6Config
  ClientPermissionType: EdgeClientPermissionType
  ClusterMemoryCapacity: EdgeClusterMemoryCapacity
  ClusterCapacityViewData: EdgeClusterCapacityViewInfo
  ClusterStorageViewData: EdgeClusterStorageViewInfo
  ClusterGpuCapacity: EdgeClusterGpuCapacity
  ClusterWitnessType: EdgeClusterWitnessType
  EdgeProfileSubscription.id: -|arm-id
  FileSourceInfo: EdgeFileSourceInfo
  FileEventTrigger: EdgeFileEventTrigger
  KeyVaultSyncStatus: EdgeKeyVaultSyncStatus
  KubernetesClusterInfo: EdgeKubernetesClusterInfo
  KubernetesIPConfiguration: EdgeKubernetesIPConfiguration
  KubernetesNodeType: EdgeKubernetesNodeType
  KubernetesRole: EdgeKubernetesRole
  KubernetesRoleCompute: EdgeKubernetesRoleCompute
  KubernetesRoleNetwork: EdgeKubernetesRoleNetwork
  KubernetesRoleResources: EdgeKubernetesRoleResources
  KubernetesRoleStorage: EdgeKubernetesRoleStorage
  KubernetesRoleStorageClassInfo: EdgeKubernetesRoleStorageClassInfo
  KubernetesState: EdgeKubernetesState
  NetworkAdapterDhcpStatus: DataBoxEdgeNetworkAdapterDhcpStatus
  NetworkAdapterPosition: DataBoxEdgeNetworkAdapterPosition
  NetworkAdapterRdmaStatus: DataBoxEdgeNetworkAdapterRdmaStatus
  NetworkAdapterStatus: DataBoxEdgeNetworkAdapterStatus
  RemoteSupportSettings: EdgeRemoteSupportSettings
  RemoteApplicationType: EdgeRemoteApplicationType

format-by-name-rules:
  'tenantId': 'uuid'
  'aadTenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'resourceLocation': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'refreshedEntityId': 'arm-id'
  'storageAccountId': 'arm-id'
  'storageAccountCredentialId': 'arm-id'
  'clientSecretStoreId': 'arm-id'
  'roleId': 'arm-id'
  'shareId': 'arm-id'
  '*JobId': 'arm-id'
  'registrationId': 'uuid'
  'nodeId': 'uuid'
  'nodeInstanceId': 'uuid'
  'servicePrincipalObjectId': 'uuid'
  'servicePrincipalClientId': 'uuid'

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
  Hyperv: HyperV
  VPUW: VpuW
  IoT: Iot
  IOT: IoT
  MRTCP: MRTcp
  UPS: Ups
  GPU: Gpu
  GPU1: Gpu1
  GPU2: Gpu2
  AES256: Aes256
  UTC: Utc
  WAC: Wac
  ASA: Asa
  MEC: Mec
  NFS: Nfs
  SMB: Smb
  ARM: Arm
  TEA1: Tea1
  TEA4: Tea4
  TMA: Tma
  TDC: Tdc
  TCA: Tca
  RCA: Rca
  RDC: Rdc


override-operation-name:
  DeviceCapacityCheck_CheckResourceCreationFeasibility: CheckResourceCreationFeasibility
  SupportPackages_TriggerSupportPackage: TriggerSupportPackage
  Orders_ListDCAccessCode: GetDataCenterAccessCode
  DeviceCapacityInfo_GetDeviceCapacityInfo: GetDeviceCapacityInfo
  Nodes_ListByDataBoxEdgeDevice: GetEdgeNodes

request-path-is-non-resource:
  # make singleton resource with only get operation to be nonresource
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/deviceCapacityInfo/default
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/networkSettings/default
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{deviceName}/updateSummary/default

suppress-abstract-base-class:
- DataBoxEdgeRoleAddonData
- DataBoxEdgeRoleData
- DataBoxEdgeTriggerData

directive:
  - remove-operation: OperationsStatus_Get
  - from: databoxedge.json
    where: $.definitions.DataBoxEdgeSku.properties
    transform: >
      $.locations.items['x-ms-format'] = 'azure-location';
  - from: databoxedge.json
    where: $.definitions
    transform: >
      $.GenerateCertResponse.properties.expiryTimeInUTC['format'] = 'date-time';
      $.BandwidthScheduleProperties.properties.start['format'] = 'time';
      $.BandwidthScheduleProperties.properties.stop['format'] = 'time';
```
