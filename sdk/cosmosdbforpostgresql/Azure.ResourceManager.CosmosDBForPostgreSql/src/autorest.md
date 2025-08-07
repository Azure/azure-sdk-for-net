# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CosmosDBForPostgreSql
namespace: Azure.ResourceManager.CosmosDBForPostgreSql
require: https://github.com/Azure/azure-rest-api-specs/blob/765b345bc5f1acecc0b122cf8052feca8ebf8de2/specification/postgresqlhsc/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'sourceResourceId': 'arm-id'
  'sourceLocation': 'azure-location'

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

rename-mapping:
  Configuration.properties.requiresRestart: IsRestartRequired
  CheckNameAvailabilityResourceType: CosmosDBForPostgreSqlNameAvailabilityResourceType
  CheckNameAvailabilityResourceType.Microsoft.DBforPostgreSQL/serverGroupsv2: ServerGroupsV2
  Cluster.properties.enableShardsOnCoordinator: IsShardsOnCoordinatorEnabled
  Cluster.properties.enableHa: IsHAEnabled
  Cluster.properties.coordinatorEnablePublicIpAccess: IsCoordinatorPublicIPAccessEnabled
  Cluster.properties.nodeEnablePublicIpAccess: IsNodePublicIPAccessEnabled
  ClusterForUpdate.properties.enableShardsOnCoordinator: IsShardsOnCoordinatorEnabled
  ClusterForUpdate.properties.enableHa: IsHAEnabled
  ClusterForUpdate.properties.coordinatorEnablePublicIpAccess: IsCoordinatorPublicIPAccessEnabled
  ClusterForUpdate.properties.nodeEnablePublicIpAccess: IsNodePublicIPAccessEnabled
  ClusterServer.properties.enableHa: IsHAEnabled
  ClusterServer.properties.enablePublicIpAccess: IsPublicIPAccessEnabled
  FirewallRule.properties.startIpAddress: -|ip-address
  FirewallRule.properties.endIpAddress: -|ip-address
  NameAvailability: CosmosDBForPostgreSqlClusterNameAvailabilityResult
  NameAvailability.nameAvailable: IsNameAvailable
  NameAvailability.type: -|resource-type
  NameAvailabilityRequest: CosmosDBForPostgreSqlClusterNameAvailabilityContent
  ServerConfiguration.properties.requiresRestart: IsRestartRequired

prepend-rp-prefix:
- Cluster
- ClusterConfigurationListResult
- ClusterServerListResult
- ClusterListResult
- ClusterServer
- Configuration
- ConfigurationDataType
- FirewallRule
- FirewallRuleListResult
- MaintenanceWindow
- Role
- RoleListResult
- ServerConfigurationData
- ServerRole
- ServerRoleGroupConfiguration
- SimplePrivateEndpointConnection
- ServerConfiguration
- ServerNameItem
- ServerConfigurationListResult
- ProvisioningState

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/coordinatorConfigurations/{configurationName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/nodeConfigurations/{configurationName}

request-path-to-resource-name:
 /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/coordinatorConfigurations/{configurationName}: CosmosDBForPostgreSqlCoordinatorConfiguration
 /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{clusterName}/nodeConfigurations/{configurationName}: CosmosDBForPostgreSqlNodeConfiguration

override-operation-name:
  Clusters_CheckNameAvailability: CheckCosmosDBForPostgreSqlClusterNameAvailability

directive:
- from: types.json
  where: $.parameters
  transform: >
    delete $.SubscriptionIdParameter.format
```
