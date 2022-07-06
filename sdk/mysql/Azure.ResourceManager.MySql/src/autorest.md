# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: MySql
clear-output-folder: true
skip-csproj: true

batch:
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2021-05-01
```

``` yaml $(tag) == 'package-2020-01-01'

namespace: Azure.ResourceManager.MySql
require: https://github.com/Azure/azure-rest-api-specs/blob/9d85adf7eb1bf9877be1e7a7991b7f1e2252a0e2/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/Generated/mysql
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

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

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/configurations/{configurationName}

directive:
  - rename-operation:
      from: Servers_Start
      to: MySqlServers_Start
  - rename-operation:
      from: Servers_Stop
      to: MySqlServers_Stop
  - rename-operation:
      from: Servers_Upgrade
      to: MySqlServers_Upgrade
```

``` yaml $(tag) == 'package-flexibleserver-2021-05-01'

namespace: Azure.ResourceManager.MySql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/9d85adf7eb1bf9877be1e7a7991b7f1e2252a0e2/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/Generated/mysqlflexibleservers
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

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

```
