# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: SelfHelp
namespace: Azure.ResourceManager.SelfHelp
require: https://github.com/Azure/azure-rest-api-specs/blob/4f6418dca8c15697489bbe6f855558bb79ca5bf5/specification/help/resource-manager/readme.md
tag: package-2023-01-01-preview
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
  DiagnosticResource: SelfHelpDiagnosticResource
  Status: DiagnosticStatus
  Insight: DiagnosticInsight
  Error: SelfHelpError
  Diagnostic: SelfHelpDiagnostic
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

```
