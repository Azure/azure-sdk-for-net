# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: SelfHelp
namespace: Azure.ResourceManager.SelfHelp
require: https://github.com/Azure/azure-rest-api-specs/blob/2ced92ea3d86dbe78f1927a8c4c89767cb48e46a/specification/help/resource-manager/readme.md
tag: package-2023-06-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
mgmt-debug:
  show-serialized-names: true



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

list-exception:
- /{scope}/providers/Microsoft.Help/diagnostics/{diagnosticsResourceName}

rename-mapping:
  DiagnosticResource: SelfHelpDiagnostic
  Status: SelfHelpDiagnosticStatus
  Insight: SelfHelpDiagnosticInsight
  Error: SelfHelpError
  Diagnostic: SelfHelpDiagnosticInfo
  DiagnosticResource.properties.acceptedAt: acceptedTime
  Insight.id: InsightId
  Insight.title: InsightTitle
  Insight.results: InsightResults
  Insight.importanceLevel: InsightImportanceLevel
  Error.code: ErrorCode
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityResponse.reason: NotAvailableReason
  CheckNameAvailabilityResponse.message: ErrorMessage
  CheckNameAvailabilityRequest.name: ResourceName
  DiscoveryResponse.value: SolutionMetaData
  Diagnostic.status: DiagnosticStatus
  Diagnostic.insights: DiagnosticInsights
  Diagnostic.error: ErrorInfo
  Error.message: ErrorMessage
  Error.details: ErrorDetails
  SolutionMetadataResource.properties.description: SolutionDescription
  DiagnosticResource.properties.insights: DiagnosticInsights
  CheckNameAvailabilityRequest: SelfHelpCheckNameAvailabilityContent
  CheckNameAvailabilityRequest.type: ResourceType
  CheckNameAvailabilityResponse: SelfHelpCheckNameAvailabilityResult
  DiagnosticInvocation: SelfHelpDiagnosticInvocation
  ImportanceLevel: SelfHelpImportanceLevel
  ProvisioningState: SelfHelpProvisioningState
  SolutionMetadataResource: SelfHelpSolutionMetadata

override-operation-name:
  Diagnostics_CheckNameAvailability: CheckSelfHelpNameAvailability
  DiscoverySolution_List: GetSelfHelpDiscoverySolutions

directive:
#resourceType
  - from: types.json
    where: $.definitions.CheckNameAvailabilityRequest.properties.type
    transform: $["x-ms-format"] = "resource-type"
```
