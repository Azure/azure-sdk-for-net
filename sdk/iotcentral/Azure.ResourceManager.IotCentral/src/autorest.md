# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: IotCentral
namespace: Azure.ResourceManager.IotCentral
require: https://github.com/Azure/azure-rest-api-specs/blob/6cb07747e61d4068750cb2666ab1b32197037dbf/specification/iotcentral/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

override-operation-name:
  Apps_CheckNameAvailability: CheckIotCentralAppNameAvailability
  Apps_CheckSubdomainAvailability: CheckIotCentralAppSubdomainAvailability

rename-mapping:
  AppAvailabilityInfo.nameAvailable: IsNameAvailable
  AppTemplateLocations: IotCentralAppTemplateLocation
  OperationInputs: IotCentralAppNameAvailabilityContent
  AppAvailabilityInfo: IotCentralAppNameAvailabilityResponse
  AppAvailabilityInfo.reason: IotCentralAppNameUnavailableReason
  NetworkRuleSets.applyToIoTCentral: ApplyToIotCentral
  AppTemplateLocations.id: location

prepend-rp-prefix:
  - App
  - Applications
  - AppListResult
  - AppSku
  - AppSkuInfo
  - AppState
  - AppTemplate
  - AppTemplatesResult
  - NetworkAction
  - NetworkRuleSetIpRule
  - NetworkRuleSets
  - ProvisioningState
  - PublicNetworkAccess

format-by-name-rules:
  'tenantId': 'uuid'
  'applicationId': 'uuid'
  'etag': 'etag'
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

directive:
  - from: iotcentral.json
    where: $.definitions
    transform: >
      $.AppTemplate.properties.order['type'] = 'integer';

```
