# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Analysiservices
namespace: Azure.ResourceManager.Analysis
require: https://github.com/Azure/azure-rest-api-specs/blob/c2d2b523575031790b8672640ea762bdf9ad4964/specification/analysisservices/resource-manager/readme.md
tag: package-2017-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  State: AnalysisState
  Status: AnalysisStatus
  OperationStatus: AnalysisOperationStatus
  AnalysisServicesServers.value: AnalysisResources
#   SkuEnumerationForNewResourceResult.value: SKUs
  Resource.sku: AnalysisSku
  AnalysisServicesServer.properties.sku: AnalysisServerSku
  ServerAdministrators.members: AsAdministratorIdentities
  CheckServerNameAvailabilityResult.nameAvailable: IsNameAvailable
  IPv4FirewallSettings.enablePowerBIService: IsPowerBIServiceEnabled
  SkuDetailsForExistingResource: AnalysisExistingSku
  SkuEnumerationForExistingResourceResult: ExistingResourceResultSkuEnumeration
  SkuEnumerationForNewResourceResult: NewResourceResultSkuEnumeration
  CheckServerNameAvailabilityContent: AnalysisServicesServerNameAvailabilityContent
#   SkuEnumerationForExistingResourceResult.value: ExistingResources
  AnalysisServicesServer.properties.ipV4FirewallSettings: IPv4FirewallSettings
  AnalysisServicesServer.properties.querypoolConnectionMode: QueryPoolConnectionMode
  CheckServerNameAvailabilityParameters: AnalysisServerNameAvailabilityContent
  CheckServerNameAvailabilityResult: AnalysisServerNameAvailabilityResult
  ConnectionMode: AnalysisConnectionMode
  GatewayDetails: AnalysisGatewayDetails
  IPv4FirewallRule: AnalysisIPv4FirewallRule
  IPv4FirewallSettings: AnalysisIPv4FirewallSettings
  ManagedMode: AnalysisManagedMode
  ProvisioningState: AnalysisProvisioningState
  ResourceSku: AnalysisResourceSku
  AnalysisServicesServerUpdateParameters: AnalysisServerPatch
  AnalysisServicesServers: AnalysisServers
  AnalysisServicesServer: AnalysisServer
  AnalysisServicesServerData: AnalysisServerData
  AnalysisServicesServerResource: AnalysisServerResource
  AnalysisServicesServerCollection: AnalysisServerCollection
  GatewayListStatusLive: AnalysisGatewayStatus
  Status.0: Zero


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
  Servers_ListSkusForExisting: GetExistingSkus
  Servers_CheckNameAvailability: CheckAnalysisServerNameAvailability
  Servers_ListSkusForNew: GetEligibleSkus

directive:
  - remove-operation: Servers_ListOperationResults
  - remove-operation: Servers_ListOperationStatuses
  - from: analysisservices.json
    where: $.definitions
    transform: >
      $.AnalysisServicesServerMutableProperties.properties.managedMode['x-ms-enum'] = {
          "name": "ManagedMode",
          "modelAsString": true
        }
      $.AnalysisServicesServerMutableProperties.properties.serverMonitorMode['x-ms-enum'] = {
          "name": "ServerMonitorMode",
          "modelAsString": true
        }
  - from: analysisservices.json
    where: $.definitions.SkuDetailsForExistingResource.properties.resourceType
    transform: $["x-ms-format"] = "resource-type"

```
