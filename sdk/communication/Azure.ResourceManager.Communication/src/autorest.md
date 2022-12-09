# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
title: communication
namespace: Azure.ResourceManager.Communication
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/7168ecde052e9797d31d74c40ad00ac68c74ec6a/specification/communication/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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

```
