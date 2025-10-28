# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DevTestLabs
namespace: Azure.ResourceManager.DevTestLabs
require: https://github.com/Azure/azure-rest-api-specs/blob/471eab645d7bb83a4f54d283db5690f58d04a670/specification/devtestlabs/resource-manager/readme.md
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
  ArmTemplate.properties.enabled: IsEnabled
  LabAnnouncementProperties.expired: IsExpired
  CustomImagePropertiesCustom.sysPrep: IsSysPrepEnabled
  Disk.properties.managedDiskId: -|arm-id
  Disk.properties.leasedByLabVmId: -|arm-id
  LabVirtualMachineCreationParameter.properties.labVirtualNetworkId: -|arm-id
  DetachDataDiskProperties.existingLabDiskId: -|arm-id

directive:
  - remove-operation: ProviderOperations_List
  - from: swagger-document
    where: $.definitions.ArmTemplateProperties.properties.contents
    transform: >
      delete $["additionalProperties"];
  - from: swagger-document
    where: $.definitions.ArmTemplateInfo.properties.parameters
    transform: >
      delete $["additionalProperties"];
  - from: swagger-document
    where: $.definitions.ParametersValueFileInfo.properties.parametersValueInfo
    transform: >
      delete $["additionalProperties"];
  - from: swagger-document
    where: $.definitions.ArtifactProperties.properties.parameters
    transform: >
      delete $["additionalProperties"];
  - from: swagger-document
    where: $.definitions.ArmTemplateInfo.properties.template
    transform: >
      delete $["additionalProperties"];
  # Bulk update for all 'name' parameters in paths
  - from: swagger-document
    where: $.paths[*][*].parameters[?(@.name == "name" && @.in == "path")]
    transform: >
      if ($["description"] && $["description"].includes("LabCost")) {
        $["description"] = " The name of the cost";
      }
      if ($["description"] && $["description"].includes("CustomImage")) {
        $["description"] = " The name of the custom image";
      }
      if ($["description"] && $["description"].includes("DtlEnvironment")) {
        $["description"] = " The name of the environment";
      }
      if ($["description"] && $["description"].includes("Disk")) {
        $["description"] = " The name of the disk";
      }
      if ($["description"] && $["description"].includes("ArtifactSource")) {
        $["description"] = " The name of the artifact source";
      }
      if ($["description"] && $["description"].includes("Artifact")) {
        $["description"] = " The name of the artifact";
      }
      if ($["description"] && $["description"].includes("ArmTemplate")) {
        $["description"] = "The name of the azure resource manager template";
      }
      if ($["description"] && $["description"].includes("Formula")) {
        $["description"] = "The name of the formula";
      }
      if ($["description"] && $["description"].includes("Schedule")) {
        $["description"] = "The name of the schedule";
      }
      if ($["description"] && $["description"].includes("NotificationChannel")) {
        $["description"] = "The name of the notification channel";
      }
      if ($["description"] && $["description"].includes("LabVirtualMachine")) {
        $["description"] = "The name of the virtual machine";
      }
      if ($["description"] && $["description"].includes("VirtualNetwork")) {
        $["description"] = "The name of the virtual network";
      }
      if ($["description"] && $["description"].includes("Secret")) {
        $["description"] = "The name of the secret";
      }
      if ($["description"] && $["description"].includes("ServiceFabric")) {
        $["description"] = "The name of the service fabric";
      }
      if ($["description"] && $["description"].includes("User")) {
        $["description"] = "The name of the user profile";
      }
      if ($["description"] && $["description"].includes("ServiceRunner")) {
        $["description"] = "The name of the service runner";
      }
      if ($["description"] && $["description"].includes("PolicySet")) {
        $["description"] = "The name of the policy set";
      }
  # Fix policySetName parameter specifically
  - from: swagger-document
    where: $.paths[*][*].parameters[?(@.name == "policySetName")]
    transform: >
      $["description"] = "The name of the policy set";
  # Fix specific policy name parameter
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/policysets/{policySetName}/policies/{name}"][*].parameters[?(@.name == "name")]
    transform: >
      $["description"] = "The name of the policy";
```
