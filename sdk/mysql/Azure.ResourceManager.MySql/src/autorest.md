# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
# use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
# csharpgen:
#   attach: true
clear-output-folder: true
skip-csproj: true
library-name: MySql

batch:
  - tag: package-2020-01-01
  - tag: package-flexibleserver-2021-05-01
```

``` yaml $(tag) == 'package-2020-01-01'
namespace: Azure.ResourceManager.MySql
require: https://github.com/Azure/azure-rest-api-specs/blob/9d85adf7eb1bf9877be1e7a7991b7f1e2252a0e2/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/MySql/Generated
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
  ServerParameters_ListUpdateConfigurations: UpdateConfigurations

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
  - from: mysql.json
    where: $.definitions
    transform: >
      $.ConfigurationListContent = {
          "properties": {
            "value": {
              "type": "array",
              "items": {
                "$ref": "#/definitions/Configuration"
              },
              "description": "The list of server configurations."
            }
          },
          "description": "A list of server configurations."
        };
      $.ConfigurationListResult.properties.value.readOnly = true;
    reason: The generator will not treat the model as the schema for a list method without value being a IReadOnlyList.
  - from: mysql.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/updateConfigurations'].post.parameters[?(@.name === 'value')]
    debug: true
    transform: >
      $.schema['$ref'] = $.schema['$ref'].replace('ConfigurationListResult', 'ConfigurationListContent');
```

``` yaml $(tag) == 'package-flexibleserver-2021-05-01'
namespace: Azure.ResourceManager.MySql.FlexibleServers
require: https://github.com/Azure/azure-rest-api-specs/blob/9d85adf7eb1bf9877be1e7a7991b7f1e2252a0e2/specification/mysql/resource-manager/readme.md
output-folder: $(this-folder)/MySqlFlexibleServers/Generated
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

```
