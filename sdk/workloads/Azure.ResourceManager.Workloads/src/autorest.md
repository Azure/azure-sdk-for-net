# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: Workloads
namespace: Azure.ResourceManager.Workloads
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/519850b125f5b5257c6d73512ac0705dd6f26131/specification/workloads/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  'appLocation': 'azure-location'
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
  SAP: Sap
  ERS: Ers
  Db: DB|db
  LRS: Lrs
  GRS: Grs
  ZRS: Zrs
  SSD: Ssd
  Ha: HA|ha
  ECC: Ecc

directive:
  - from: swagger-document
    where: $.definitions..subnetId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: swagger-document
    where: $.definitions..subnet
    transform: >
      $['x-ms-format'] = 'arm-id';
      $['x-ms-client-name'] = 'subnetId';
  - from: swagger-document
    where: $.definitions..virtualMachineId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: skus.json
    where: $.definitions
    transform: >
      $.SkuRestriction.properties.restrictionInfo = {
            '$ref': '#/definitions/RestrictionInfo',
            'description': 'The restriction information.'
          };
  - from: SAPVirtualInstance.json
    where: $.definitions
    transform: >
      $.ErrorDefinition['x-ms-client-name'] = 'SapVirtualInstanceErrorDetail';
  - from: monitors.json
    where: $.definitions
    transform: >
      $.Monitor['x-ms-client-name'] = 'SapMonitor';
      $.MonitorProperties.properties.logAnalyticsWorkspaceArmId['x-ms-format'] = 'arm-id';
      $.MonitorProperties.properties.monitorSubnet['x-ms-format'] = 'arm-id';
      $.MonitorProperties.properties.monitorSubnet['x-ms-client-name'] = 'monitorSubnetId';
      $.MonitorProperties.properties.msiArmId['x-ms-format'] = 'arm-id';
      $.ProviderInstance['x-ms-client-name'] = 'SapProviderInstance';
```
