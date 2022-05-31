# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Workloads
namespace: Azure.ResourceManager.Workloads
require: https://github.com/Azure/azure-rest-api-specs/blob/30b6221c12cc4014ee5142660d09cd48049ee388/specification/workloads/resource-manager/readme.md
tag: package-2021-12-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
flatten-payloads: false

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
  SAP: Sap

directive:
  - from: monitors.json
    where: $.definitions
    transform: >
      $.Monitor['x-ms-client-name'] = 'SapMonitor';
      $.MonitorProperties.properties.appLocation['x-ms-client-name'] = 'sapAppLocation';
```