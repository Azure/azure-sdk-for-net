# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: LabServices
namespace: Azure.ResourceManager.LabServices
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/labservices/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  AvailableLabServicesSku.locations: -|azure-location
  Image.properties.availableRegions: -|azure-location
  InviteBody.text: -|any
  LabPlan.properties.allowedRegions: -|azure-location
  LabPlanUpdate.properties.allowedRegions: -|azure-location
  RosterProfile.lmsInstance: -|uri
  RosterProfile.ltiRosterEndpoint: -|uri
  ScheduleUpdate.properties.notes: -|any
  Usage.id: -|arm-id
  User.properties.invitationSent: InvitationSentOn
  VirtualMachineConnectionProfile.privateIpAddress: -|ip-address
  AutoShutdownProfile: LabAutoShutdownProfile
  ConnectionProfile: LabConnectionProfile
  ConnectionType: LabVirtualMachineConnectionType
  CreateOption: LabVirtualMachineCreateOption
  Credentials: LabVirtualMachineCredential
  Image: LabVirtualMachineImage
  ImageReference: LabVirtualMachineImageReference
  InviteBody: LabUserInviteRequestContent
  InvitationState: LabUserInvitationState
  LabServicesSkuCapacity: AvailableLabServicesSkuCapacity
  LabServicesSkuCapabilities: AvailableLabServicesSkuCapability
  LabServicesSkuCost: AvailableLabServicesSkuCost
  LabServicesSkuRestrictions: AvailableLabServicesSkuRestrictions
  ListUsagesResult: LabServicesUsageListResult
  OsState: LabVirtualMachineImageOSState
  OsType: LabVirtualMachineImageOSType
  ResetPasswordBody: LabVirtualMachineResetPasswordContent
  RegistrationState: LabUserRegistrationState
  RestrictionReasonCode: LabServicesSkuRestrictionReasonCode
  RestrictionType: LabServicesSkuRestrictionType
  RosterProfile: LabRosterProfile
  SaveImageBody: LabVirtualMachineImageContent
  ScaleType: LabServicesSkuCapacityScaleType
  SecurityProfile: LabSecurityProfile
  ShutdownOnIdleMode: LabVirtualMachineShutdownOnIdleMode
  SupportInfo: LabPlanSupportInfo
  TrackedResourceUpdate: LabServicesPatchBaseInfo
  User: LabUser
  VirtualMachine: LabVirtualMachine
  VirtualMachineAdditionalCapabilities: LabVirtualMachineAdditionalCapability
  VirtualMachineConnectionProfile: LabVirtualMachineConnectionProfile
  VirtualMachineProfile: LabVirtualMachineProfile
  VirtualMachineState: LabVirtualMachineState
  VirtualMachineType: LabVirtualMachineType
  WeekDay: LabServicesDayOfWeek

prepend-rp-prefix:
  - EnableState
  - Image
  - ProvisioningState
  - RecurrenceFrequency
  - RecurrencePattern
  - Schedule
  - UsageName
  - UsageUnit

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

override-operation-name:
  Usages_ListByLocation: GetUsages

directive:
  - remove-operation: OperationResults_Get
  - from: LabServices.json
    where: $.definitions
    transform: >
      $['arm-id'] = {
            'type': 'string',
            'x-ms-format': 'arm-id',
            'description': 'A resource identifier.'
          };
      $.url['format'] = 'url';
  - from: Skus.json
    where: $.definitions
    transform: >
      $.LabServicesSku.properties.tier['x-ms-enum']['name'] = 'AvailableLabServicesSkuTier';
      $.LabServicesSku['x-ms-client-name'] = 'AvailableLabServicesSku';
  - from: Images.json
    where: $.definitions
    transform: >
      $.ImageProperties.properties.sharedGalleryId['$ref'] = 'LabServices.json#/definitions/arm-id';
  - from: LabPlans.json
    where: $.definitions
    transform: >
      $.LabPlanNetworkProfile.properties.subnetId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.LabPlanUpdateProperties.properties.sharedGalleryId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.SaveImageBody.properties.labVirtualMachineId['$ref'] = 'LabServices.json#/definitions/arm-id';
  - from: Labs.json
    where: $.definitions
    transform: >
      $.LabNetworkProfile.properties.subnetId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.LabNetworkProfile.properties.loadBalancerId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.LabNetworkProfile.properties.publicIpId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.LabUpdateProperties.properties.labPlanId['$ref'] = 'LabServices.json#/definitions/arm-id';
      $.ImageReference.properties.id['$ref'] = 'LabServices.json#/definitions/arm-id';
```
