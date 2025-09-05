# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataShare
namespace: Azure.ResourceManager.DataShare
require: https://github.com/Azure/azure-rest-api-specs/blob/df70965d3a207eb2a628c96aa6ed935edc6b7911/specification/datashare/resource-manager/readme.md
tag: package-2021-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'sourceShareLocation': 'azure-location'
  'dataSetLocation': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'invitationId': 'uuid'
  'dataSetId': 'uuid'
  'synchronizationId': 'uuid'
  '*ResourceId': 'arm-id'

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

list-exception:
  - /providers/Microsoft.DataShare/locations/{location}/consumerInvitations/{invitationId}

prepend-rp-prefix:
  - Account
  - Invitation
  - InvitationStatus
  - Trigger
  - TriggerStatus
  - EmailRegistration
  - ProvisioningState
  - SynchronizationSetting
  - ConsumerInvitation

rename-mapping:
  Share: DataShare
  ShareKind: DataShareKind
#   ShareSubscription: ConsumerShareSubscription
  AccountUpdateParameters: DataShareAccountPatch
  EmailRegistration.activationExpirationDate: ActivationExpireOn
  OperationResponse: DataShareOperationResult
  Status: DataShareOperationStatus
  OutputType: DataShareOutputType
  ScheduledSourceSynchronizationSetting.properties.synchronizationTime: SynchronizeOn
  ScheduledSynchronizationSetting.properties.synchronizationTime: SynchronizeOn
  ScheduledTrigger.properties.synchronizationTime: SynchronizeOn
  ShareSubscriptionSynchronization.durationMs: DurationInMilliSeconds
  ShareSynchronization.durationMs: DurationInMilliSeconds
  SynchronizationDetails.durationMs: DurationInMilliSeconds
  Synchronize: DataShareSynchronizeContent
  DataSet: ShareDataSet
  DataSetMapping: ShareDataSetMapping
  DataSetType: ShareDataSetType
  RecurrenceInterval: DataShareSynchronizationRecurrenceInterval
  RegistrationStatus: DataShareEmailRegistrationStatus

override-operation-name:
  EmailRegistrations_ActivateEmail: ActivateEmail
  EmailRegistrations_RegisterEmail: RegisterEmail
  ConsumerInvitations_ListInvitations: GetAll
  ConsumerInvitations_RejectInvitation: RejectConsumerInvitation

request-path-to-parent:
  /providers/Microsoft.DataShare/listInvitations: /providers/Microsoft.DataShare/locations/{location}/consumerInvitations/{invitationId}

operation-positions:
  ConsumerInvitations_ListInvitations: collection

suppress-abstract-base-class:
- ShareDataSetMappingData
- DataShareTriggerData
- ShareDataSetData
- DataShareSynchronizationSettingData

directive:
  - from: DataShare.json
    where: $.definitions
    transform: >
      $.Identity.properties.type['x-ms-enum']['name'] = 'ServiceIdentityType';
  - from: DataShare.json
    where: $.paths..parameters[?(@.name == 'invitationId')]
    transform: >
      $.format = 'uuid';

```
