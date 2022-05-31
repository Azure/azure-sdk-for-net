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
  PHP: Php
  ERS: Ers
  DB2: Db2
  LRS: Lrs
  GRS: Grs
  ZRS: Zrs
  SSD: Ssd

directive:
  - from: monitors.json
    where: $.definitions
    transform: >
      $.Monitor['x-ms-client-name'] = 'SapMonitor';
      $.MonitorProperties.properties.appLocation['x-ms-client-name'] = 'sapAppLocation';
      $.MonitorProperties.properties.logAnalyticsWorkspaceArmId['x-ms-format'] = 'arm-id';
      $.MonitorProperties.properties.msiArmId['x-ms-format'] = 'arm-id';
      $.ProviderInstance['x-ms-client-name'] = 'SapProviderInstance';
  - from: phpWorkloads.json
    where: $.definitions
    transform: >
      $.phpWorkloadResourceProperties.properties.appLocation['x-ms-client-name'] = 'phpAppLocation';
      $.nodeProfile.properties.nodeResourceIds.items['x-ms-format'] = 'arm-id';
      $.networkProfile.properties.vNetResourceId['x-ms-format'] = 'arm-id';
      $.networkProfile.properties.loadBalancerResourceId['x-ms-format'] = 'arm-id';
      $.networkProfile.properties.azureFrontDoorResourceId['x-ms-format'] = 'arm-id';
      $.networkProfile.properties.frontEndPublicIpResourceId['x-ms-format'] = 'arm-id';
      $.networkProfile.properties.outboundPublicIpResourceIds['x-ms-format'] = 'arm-id';
      $.databaseProfile.properties.serverResourceId['x-ms-format'] = 'arm-id';
      $.fileshareProfile.properties.storageResourceId['x-ms-format'] = 'arm-id';
      $.cacheProfile.properties.cacheResourceId['x-ms-format'] = 'arm-id';
      $.backupProfile.properties.vaultResourceId['x-ms-format'] = 'arm-id';
  - from: SAPVirtualInstance.json
    where: $.definitions
    transform: >
      $.SingleServerConfiguration.properties.subnetId['x-ms-format'] = 'arm-id';
      $.CentralServerConfiguration.properties.subnetId['x-ms-format'] = 'arm-id';
      $.DatabaseConfiguration.properties.subnetId['x-ms-format'] = 'arm-id';
      $.ApplicationServerConfiguration.properties.subnetId['x-ms-format'] = 'arm-id';
```