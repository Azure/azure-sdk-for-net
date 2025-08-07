# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
title: communication
namespace: Azure.ResourceManager.Communication
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/5a281cf0d538de6dad0c70eda7ee901c60a11e6b/specification/communication/resource-manager/readme.md#tag-package-2023-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

override-operation-name:
  CommunicationServices_CheckNameAvailability: CheckCommunicationNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'immutableResourceId': 'uuid'
  'NotificationHubId': 'arm-id'
  'ResourceId': 'arm-id'
  'ResourceType': 'resource-type'
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
  SPF: Spf

rename-mapping:
  NameAvailabilityParameters: CommunicationServiceNameAvailabilityContent
  TaggedResource: CommunicationAcceptTags
  DomainResource: CommunicationDomainResource
  CheckNameAvailabilityRequest: CommunicationNameAvailabilityContent
  CheckNameAvailabilityResponse: CommunicationNameAvailabilityResult
  CheckNameAvailabilityReason: CommunicationNameAvailabilityReason
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  RegenerateKeyParameters: RegenerateCommunicationServiceKeyContent
  VerificationParameter: DomainsRecordVerificationContent
  VerificationType: DomainRecordVerificationType
  VerificationStatus: DomainRecordVerificationStatus
  VerificationStatusRecord: DomainVerificationStatusRecord
  KeyType: CommunicationServiceKeyType
  DnsRecord.ttl: TimeToLiveInSeconds
  DnsRecord: VerificationDnsRecord
  DomainsProvisioningState: DomainProvisioningState
  ProvisioningState: CommunicationServiceProvisioningState
  SuppressionListResource.properties.createdTimeStamp: -|date-time
  SuppressionListResource.properties.lastUpdatedTimeStamp: -|date-time

directive:
 - from: types.json
   where: $.parameters.SubscriptionIdParameter
   transform: >
     delete $["format"];
```
