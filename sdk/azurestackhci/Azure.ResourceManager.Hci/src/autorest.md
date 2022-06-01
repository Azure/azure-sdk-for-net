# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci
namespace: Azure.ResourceManager.Hci
require: https://github.com/Azure/azure-rest-api-specs/blob/324a148497f28ef7588eee7bdb61dcd28b74f505/specification/azurestackhci/resource-manager/readme.md
tag: package-2022-05
output-folder: Generated/
clear-output-folder: true

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
  Vmos: VmOS
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

directive:
  - from: extensions.json
    where: $.definitions.Extension
    transform: $["x-ms-client-name"] = "ArcExtension"
  - from: extensions.json
    where: $.definitions.Extension.properties.systemData
    transform: $["x-ms-client-flatten"] = false
  - from: clusters.json
    where: $.definitions.Cluster
    transform: $["x-ms-client-name"] = "HciCluster"
  - from: clusters.json
    where: $.definitions.ClusterProperties.properties.status["x-ms-enum"]
    transform: $.name = "HciClusterStatus"
  - from: clusters.json
    where: $.definitions.ClusterProperties.properties
    transform: >
      $.aadClientId.format = "uuid";
      $.aadTenantId.format = "uuid";
      $.cloudId.format = "uuid";
      $.aadApplicationObjectId.format = "uuid";
      $.aadServicePrincipalObjectId.format = "uuid";
  - from: clusters.json
    where: $.definitions.ClusterPatchProperties.properties
    transform: >
      $.aadClientId.format = "uuid";
      $.aadTenantId.format = "uuid";
  - from: clusters.json
    where: $.definitions.ClusterReportedProperties.properties.clusterId
    transform: >
      $.format = "uuid"
  - from: clusters.json
    where: $.definitions.Cluster.properties.systemData
    transform: $["x-ms-client-flatten"] = false
  - from: arcSettings.json
    where: $.definitions.ArcSetting.properties.systemData
    transform: $["x-ms-client-flatten"] = false
  - from: arcSettings.json
    where: $.definitions.ArcSettingProperties.properties
    transform: >
      $.arcApplicationClientId.format = "uuid";
      $.arcApplicationTenantId.format = "uuid";
      $.arcServicePrincipalObjectId.format = "uuid";
      $.arcApplicationObjectId.format = "uuid";
```
