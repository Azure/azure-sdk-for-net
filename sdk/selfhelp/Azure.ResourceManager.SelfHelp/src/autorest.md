# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: SelfHelp
namespace: Azure.ResourceManager.SelfHelp
require: https://github.com/Azure/azure-rest-api-specs/blob/3eb9ec8e9c8f717c6b461c4c0f49a4662fb948fd/specification/help/resource-manager/readme.md
tag: package-2023-09-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - Diagnostics_CheckNameAvailability
  - DiscoverySolution_List
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

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

list-exception:
- /{scope}/providers/Microsoft.Help/diagnostics/{diagnosticsResourceName}
- /{scope}/providers/Microsoft.Help/solutions/{solutionResourceName}
- /{scope}/providers/Microsoft.Help/troubleshooters/{troubleshooterName}

rename-mapping:
  DiagnosticResource: SelfHelpDiagnostic
  DiagnosticResource.properties.acceptedAt: acceptedOn|date-time
  Status: SelfHelpDiagnosticStatus
  Diagnostic: SelfHelpDiagnosticInfo
  Insight: SelfHelpDiagnosticInsight
  Insight.importanceLevel: InsightImportanceLevel
  CheckNameAvailabilityResponse: SelfHelpNameAvailabilityResult
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityRequest: SelfHelpNameAvailabilityContent
  CheckNameAvailabilityRequest.name: ResourceName
  CheckNameAvailabilityRequest.type: ResourceType|resource-type
  DiscoveryResponse: SelfHelpDiscoverySolutionResult
  SolutionMetadataResource: SelfHelpSolutionMetadata
  Error: SelfHelpError
  DiagnosticInvocation: SelfHelpDiagnosticInvocation
  ImportanceLevel: SelfHelpImportanceLevel
  DiagnosticProvisioningState: SelfHelpProvisioningState
  Filter: SelfHelpFilter
  Confidence: SelfHelpConfidence
  Section: SelfHelpSection
  Video: SelfHelpVideo
  Step: SelfHelpStep
  Type: SelfHelpType
  Name: SelfHelpName
  RestartTroubleshooterResponse: RestartTroubleshooterResult
  TroubleshooterResponse: TroubleshooterResult
  ResponseOption: ResponseConfig

override-operation-name:
  CheckNameAvailability_Post: CheckSelfHelpNameAvailability
  DiscoverySolution_List: GetSelfHelpDiscoverySolutions

directive:
  - from: help.json
    where: $.definitions.MetricsBasedChart
    transform: >
      $.properties.timeSpanDuration['format'] = 'duration';
  - from: help.json
    where: $.definitions.Step.properties.type
    transform: >
      $["x-ms-client-name"] = 'StepType';
```
