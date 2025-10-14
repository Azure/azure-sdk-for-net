# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: Support
namespace: Azure.ResourceManager.Support
require: https://github.com/Azure/azure-rest-api-specs/blob/9edc30686813e52c7f027eb8ea1c56c3d6dc5d1f/specification/support/resource-manager/readme.md
#tag: package-preview-2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
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
  SecondaryConsentEnabled.description: LocalDescription
  SecondaryConsentEnabled.type: LocalSecondaryConsentEnabledType

models-to-treat-empty-string-as-null:
  - LookUpResourceIdResult
  - ServiceProblemClassificationResult
  - ClassificationService

override-operation-name:
  Communications_CheckNameAvailability: CheckCommunicationNameAvailability
  SupportTickets_CheckNameAvailability: CheckSupportTicketNameAvailability

directive:
  # It was found during the Swagger comparison that the contentType is missing the 'x-ms-enum' object content,
  # so it is supplemented here.
  - from: support.json
    where: $.definitions
    transform: >
      $.MessageProperties['properties']['contentType']['x-ms-enum'] = {
          name: 'TranscriptContentType',
          modelAsString: true
      };
  - from: support.json
    where: $.definitions
    transform: >
      $.ProblemClassificationProperties.properties.displayName['x-ms-client-name'] = 'LocalDisplayName';
      $.ProblemClassificationProperties.properties.secondaryConsentEnabled['x-ms-client-name'] = 'LocalSecondaryConsentEnabled';
      $.ServiceProperties.properties.displayName['x-ms-client-name'] = 'LocalDisplayName';
      $.ServiceProperties.properties.resourceTypes['x-ms-client-name'] = 'LocalResourceTypes';
 
```
