# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AlertsManagement
namespace: Azure.ResourceManager.AlertsManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/0077b4a8c5071d3ab33fd9f9ba013581c9a66b8f/specification/alertsmanagement/resource-manager/readme.md
tag: package-2021-08
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
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Etag: ETag

directive:
  - from: SmartGroups.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'SmartGroupErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'SmartGroupErrorResponseBody';
  - from: AlertProcessingRules.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertProcessingRuleErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertProcessingRuleErrorResponseBody';
  - from: AlertsManagement.json
    where: $.definitions
    transform: >
      $.errorResponse['x-ms-client-name'] = 'AlertsManagementErrorResponse';
      $.errorResponseBody['x-ms-client-name'] = 'AlertsManagementErrorResponseBody';
```