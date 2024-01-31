# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: Support
namespace: Azure.ResourceManager.Support
require: https://github.com/Azure/azure-rest-api-specs/blob/e0583a2cb882c7c6d88d455bd20bacf0de3a82d4/specification/support/resource-manager/readme.md
#tag: package-preview-2022-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-resource-name:
    /subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}/communications/{communicationName}: SupportTicketCommunication
    /providers/Microsoft.Support/supportTickets/{supportTicketName}/communications/{communicationName}: SupportTicketNoSubCommunication
    /subscriptions/{subscriptionId}/providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts/{chatTranscriptName}: SupportTicketChatTranscript
    /providers/Microsoft.Support/supportTickets/{supportTicketName}/chatTranscripts/{chatTranscriptName}: SupportTicketNoSubChatTranscript
    /subscriptions/{subscriptionId}/providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}/files/{fileName}: SupportTicketFile
    /providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}/files/{fileName}: SupportTicketNoSubFile

list-exception:
    - /subscriptions/{subscriptionId}/providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}
    - /providers/Microsoft.Support/fileWorkspaces/{fileWorkspaceName}

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

prepend-rp-prefix:
  - ContactProfile
  - ServiceLevelAgreement
  - SeverityLevel
  - FileDetails

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
  Consent: AdvancedDiagnosticConsent
  MessageProperties: ChatTranscriptMessageProperties
  UploadFile: UploadFileContent

override-operation-name:
  Communications_CheckNameAvailability: CheckCommunicationNameAvailability
  SupportTickets_CheckNameAvailability: CheckSupportTicketNameAvailability
```
