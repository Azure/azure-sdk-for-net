# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: Support
namespace: Azure.ResourceManager.Support
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/support/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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

prepend-rp-prefix:
  - ContactProfile
  - ServiceLevelAgreement
  - SeverityLevel

rename-mapping:
  CommunicationDetails: SupportTicketCommunication
  CommunicationDirection: SupportTicketCommunicationDirection
  CommunicationType: SupportTicketCommunicationType
  SupportTicketDetails: SupportTicket
  CheckNameAvailabilityInput: SupportNameAvailabilityContent
  CheckNameAvailabilityOutput: SupportNameAvailabilityResult
  CheckNameAvailabilityOutput.nameAvailable: IsNameAvailable
  QuotaChangeRequest: SupportQuotaChangeContent
  ServiceLevelAgreement.slaMinutes: SlaInMinutes
  Status: SupportTicketStatus
  UpdateContactProfile: SupportContactProfileContent
  Type: SupportResourceType
  Service: SupportAzureService
  TechnicalTicketDetails.resourceId: -|arm-id

override-operation-name:
  Communications_CheckNameAvailability: CheckCommunicationNameAvailability
  SupportTickets_CheckNameAvailability: CheckSupportTicketNameAvailability

```
