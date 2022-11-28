# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Analysiservices
namespace: Azure.ResourceManager.Analysiservices
require: https://github.com/Azure/azure-rest-api-specs/blob/c2d2b523575031790b8672640ea762bdf9ad4964/specification/analysisservices/resource-manager/readme.md
tag: package-2017-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false


rename-mapping:
  State: AnalysisServicesState
  Status: AnalysisServicesStatus
  AnalysisServicesServers.value: AnalysisServicesResources
#   SkuEnumerationForNewResourceResult.value: SKUs
  Resource.sku: AnalysisServicesSKU
  AnalysisServicesServer.properties.sku: AnalysisServicesServerSKU
  ServerAdministrators.members: AsAdministratorIdentities
  CheckServerNameAvailabilityResult.nameAvailable: IsNameAvailable
  IPv4FirewallSettings.enablePowerBIService: IsPowerBIServiceEnabled
  SkuDetailsForExistingResource: ExistingResourceSkuDetails
  SkuEnumerationForExistingResourceResult: ExistingResourceResultSkuEnumeration
  SkuEnumerationForNewResourceResult: NewResourceResultSkuEnumeration
#   SkuEnumerationForExistingResourceResult.value: ExistingResources

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

directive:
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
