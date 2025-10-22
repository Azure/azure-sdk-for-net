# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DevTestLabs
namespace: Azure.ResourceManager.DevTestLabs
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/devtestlabs/resource-manager/readme.md
#tag: package-2018-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/costs/{name}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/servicerunners/{name}

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'UniqueIdentifier': 'uuid'

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
  VirtualMachine: Vm
  SSD: Ssd

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}: DevTestLabSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules/{name}: DevTestLabGlobalSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/servicefabrics/{serviceFabricName}/schedules/{name}: DevTestLabServiceFabricSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualmachines/{virtualMachineName}/schedules/{name}: DevTestLabVmSchedule

override-operation-name:
  PolicySets_EvaluatePolicies: EvaluatePolicies

rename-mapping:
  ArmTemplate: DevTestLabArmTemplate
  Artifact: DevTestLabArtifact
  ArtifactSource: DevTestLabArtifactSource
  CustomImage: DevTestLabCustomImage
  Disk: DevTestLabDisk
  DtlEnvironment: DevTestLabEnvironment
  Formula: DevTestLabFormula
  Lab: DevTestLab
  LabCost: DevTestLabCost
  Schedule: DevTestLabSchedule
  LabVirtualMachine: DevTestLabVm
  LabVirtualMachine.properties.computeId: -|arm-id
  LabVirtualMachine.properties.labVirtualNetworkId: -|arm-id
  LabVirtualMachine.properties.environmentId: -|arm-id
  NotificationChannel: DevTestLabNotificationChannel
  Policy: DevTestLabPolicy
  Secret: DevTestLabSecret
  ServiceFabric: DevTestLabServiceFabric
  ServiceRunner: DevTestLabServiceRunner
  User: DevTestLabUser
  VirtualNetwork: DevTestLabVirtualNetwork
  ApplicableSchedule: DevTestLabApplicableSchedule
  ApplyArtifactsRequest: DevTestLabVmApplyArtifactsContent
  ArmTemplateInfo: DevTestLabArmTemplateInfo
  ArmTemplateParameterProperties: DevTestLabArmTemplateParameter
  ArtifactDeploymentStatusProperties: DevTestLabArtifactDeploymentStatus
  ArtifactInstallProperties: DevTestLabArtifactInstallInfo
  ArtifactParameterProperties: DevTestLabArtifactParameter
  AttachDiskProperties: DevTestLabDiskAttachContent
  AttachDiskProperties.leasedByLabVmId: -|arm-id
  AttachNewDataDiskOptions: AttachNewDataDiskDetails
  TargetCostProperties: DevTestLabTargetCost
  CostThresholdProperties: DevTestLabCostThreshold
  CostThresholdStatus: DevTestLabCostThresholdStatus
  CostType: DevTestLabCostType
  LabCostDetailsProperties: DevTestLabCostDetails
  CustomImageOsType: DevTestLabCustomImageOsType
  CustomImagePropertiesCustom: DevTestLabCustomImageVhd
  CustomImagePropertiesFromVm: DevTestLabCustomImageVm
  CustomImagePropertiesFromPlan: DevTestLabCustomImagePlan
  DataDiskStorageTypeInfo: DevTestLabDataDiskStorageTypeInfo
  StorageType: DevTestLabStorageType
  DataDiskProperties: DevTestLabDataDiskProperties
  DataDiskProperties.existingLabDiskId: -|arm-id
  DetachDataDiskProperties: DevTestLabVmDetachDataDiskContent
  DetachDiskProperties: DevTestLabDiskDetachContent
  DetachDiskProperties.leasedByLabVmId: -|arm-id
  UpdateResource: DevTestLabResourcePatch
  EnableStatus: DevTestLabEnableStatus
  EnvironmentDeploymentProperties: DevTestLabEnvironmentDeployment
  EnvironmentDeploymentProperties.armTemplateId: -|arm-id
  EnvironmentPermission: DevTestLabEnvironmentPermission
  EvaluatePoliciesRequest: DevTestLabEvaluatePoliciesContent
  EvaluatePoliciesProperties: DevTestLabEvaluatePolicy
  EvaluatePoliciesResponse: DevTestLabEvaluatePoliciesResult
  PolicySetResult: DevTestLabPolicySetResult
  Event: DevTestLabNotificationChannelEvent
  NotificationChannelEventType: DevTestLabNotificationChannelEventType
  ExportResourceUsageParameters: DevTestLabExportResourceUsageContent
  ExternalSubnet: DevTestLabExternalSubnet
  ExternalSubnet.id: -|arm-id
  SubnetOverride: DevTestLabSubnetOverride
  SubnetOverride.resourceId: -|arm-id
  FileUploadOptions: DevTestLabFileUploadOption
  GalleryImage: DevTestLabGalleryImage
  GalleryImage.properties.enabled: IsEnabled
  GalleryImageReference: DevTestLabGalleryImageReference
  GenerateArmTemplateRequest: DevTestLabArtifactGenerateArmTemplateContent
  ParameterInfo: DevTestLabParameter
  GenerateUploadUriParameter: DevTestLabGenerateUploadUriContent
  GenerateUploadUriResponse: DevTestLabGenerateUploadUriResult
  HostCachingOptions: DevTestLabHostCachingOption
  IdentityProperties: DevTestLabManagedIdentity
  IdentityProperties.principalId: -|uuid
  ImportLabVirtualMachineRequest: DevTestLabImportVmContent
  ImportLabVirtualMachineRequest.sourceVirtualMachineResourceId: -|arm-id
  InboundNatRule: DevTestLabInboundNatRule
  LabAnnouncementProperties: DevTestLabAnnouncement
  LabResourceCostProperties: DevTestLabResourceCost
  LabResourceCostProperties.resourcename: ResourceName
  LabResourceCostProperties.resourceUId: ResourceUniqueId
  LabSupportProperties: DevTestLabSupport
  LabVirtualMachineCreationParameter: DevTestLabVmCreationContent
  LinuxOsState: DevTestLabLinuxOsState
  NetworkInterfaceProperties: DevTestLabNetworkInterface
  NetworkInterfaceProperties.virtualNetworkId: -|arm-id
  NetworkInterfaceProperties.subnetId: -|arm-id
  NetworkInterfaceProperties.publicIpAddressId: -|arm-id
  NotificationSettings: DevTestLabNotificationSettings
  NotifyParameters: DevTestLabNotificationChannelNotifyContent
  ParametersValueFileInfo: DevTestLabParametersValueFileInfo
  PolicyEvaluatorType: DevTestLabPolicyEvaluatorType
  PolicyFactName: DevTestLabPolicyFactName
  PolicyStatus: DevTestLabPolicyStatus
  PolicyViolation: DevTestLabPolicyViolation
  Port: DevTestLabPort
  TransportProtocol: DevTestLabTransportProtocol
  PremiumDataDisk: DevTestLabPremiumDataDisk
  RdpConnection: DevTestLabRdpConnection
  ReportingCycleType: DevTestLabReportingCycleType
  ResizeLabVirtualMachineProperties: DevTestLabVmResizeContent
  RetargetScheduleProperties: DevTestLabGlobalScheduleRetargetContent
  RetargetScheduleProperties.currentResourceId: -|arm-id
  RetargetScheduleProperties.targetResourceId: -|arm-id
  ScheduleCreationParameter: DevTestLabScheduleCreationParameter
  ScheduleCreationParameter.properties.targetResourceId: -|arm-id
  ScheduleFragment: DevTestLabSchedulePatch
  SourceControlType: DevTestLabSourceControlType
  Subnet: DevTestLabSubnet
  Subnet.resourceId: -|arm-id
  TargetCostStatus: DevTestLabTargetCostStatus
  UsagePermissionType: DevTestLabUsagePermissionType
  UserIdentity: DevTestLabUserIdentity
  UserSecretStore: DevTestLabUserSecretStore
  UserSecretStore.keyVaultId: -|arm-id
  VirtualMachineCreationSource: DevTestLabVmCreationSource
  WeekDetails: DevTestLabWeekDetails
  WindowsOSState: DevTestLabWindowsOSState
  ArmTemplate.properties.enabled: IsEnabled
  LabAnnouncementProperties.expired: IsExpired
  CustomImagePropertiesCustom.sysPrep: IsSysPrepEnabled
  Disk.properties.managedDiskId: -|arm-id
  Disk.properties.leasedByLabVmId: -|arm-id
  LabVirtualMachineCreationParameter.properties.labVirtualNetworkId: -|arm-id
  DetachDataDiskProperties.existingLabDiskId: -|arm-id

directive:
  - remove-operation: ProviderOperations_List

```
