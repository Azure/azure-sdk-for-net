# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CosmosDBForPostgreSql
namespace: Azure.ResourceManager.CosmosDBForPostgreSql
require: https://github.com/Azure/azure-rest-api-specs/blob/84dfc2bed5cd1db42469895b0adaf5738e4802bc/specification/postgresqlhsc/resource-manager/readme.md
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

request-path-to-resource-data:
 /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/coordinatorConfigurations/{configurationName}: ServerConfiguration
 /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/nodeConfigurations/{configurationName}: ServerConfiguration

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/coordinatorConfigurations/{configurationName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/nodeConfigurations/{configurationName}

override-operation-name:
  ServerGroupsv2CoordinatorConfigurations_List: GetAll
  ServerGroupsv2NodeConfigurations_List: GetAll
operation-positions:
  ServerGroupsv2CoordinatorConfigurations_List: collection
  ServerGroupsv2NodeConfigurations_List: collection

directive:
- from: types.json
  where: $.parameters
  transform: >
    delete $.SubscriptionIdParameter.format
```
