# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
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

prepend-rp-prefix:
  - Advisor
  - Configuration
  - Database
  - FirewallRule
  - QueryStatistic
  - QueryText
  - RecommendationAction
  - Server
  - ServerKey
  - ServerSecurityAlertPolicy
  - ServerVersion
  - VirtualNetworkRule
  - WaitStatistic
  - AdministratorType
  - AdvisorResultList
  - ConfigurationListContent
  - ConfigurationListResult
  - CreateMode
  - DatabaseListResult
  - FirewallRuleListResult
  - LogFile
  - LogFileListResult
  - MinimalTlsVersionEnum
  - GeoRedundantBackup
  - InfrastructureEncryption
  - NameAvailability
  - NameAvailabilityRequest
  - PerformanceTierListResult
  - PerformanceTierProperties
  - PerformanceTierServiceLevelObjectives
  - PrivateEndpointProvisioningState
  - PrivateLinkServiceConnectionStateStatus
  - PublicNetworkAccessEnum
  - QueryPerformanceInsightResetDataResult
  - QueryPerformanceInsightResetDataResultState
  - RecommendedActionSessionsOperationStatus
  - StorageProfile
  - ServerPropertiesForCreate
  - ServerPropertiesForDefaultCreate
  - ServerPropertiesForRestore
  - ServerPropertiesForGeoRestore
  - ServerPropertiesForReplica
  - SecurityAlertPolicyName
  - ServerKeyListResult
  - ServerKeyType
  - ServerListResult
  - ServerPrivateEndpointConnection
  - ServerPrivateEndpointConnectionProperties
  - ServerPrivateLinkServiceConnectionStateProperty
  - ServerSecurityAlertPolicyListResult
  - ServerSecurityAlertPolicyState
  - ServerState
  - ServerUpgradeParameters
  - SslEnforcementEnum
  - StorageAutogrow
  - TopQueryStatisticsInput
  - VirtualNetworkRuleListResult
  - VirtualNetworkRuleState
  - WaitStatisticsInput
rename-mapping:
  ServerAdministratorResource: MySqlServerAdministrator
  ServerAdministratorResourceListResult: MySqlServerAdministratorListResult
  AdvisorsResultList: MySqlAdvisorListResult
  QueryTextsResultList: MySqlQueryTextListResult
  TopQueryStatisticsResultList: MySqlTopQueryStatisticsListResult
  RecommendationActionsResultList: MySqlRecommendationActionListResult
  WaitStatisticsResultList: MySqlWaitStatisticsListResult
  PrivateLinkServiceConnectionStateActionsRequire: MySqlPrivateLinkServiceConnectionStateRequiredActions
  RecoverableServerResource: MySqlRecoverableServerResourceData

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
    reason: The generator will not treat the model as the schema for a list method without value being a IReadOnlyList. Need to have separate models for input and output.
  - from: mysql.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/updateConfigurations'].post.parameters[?(@.name === 'value')]
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

# rename-mapping:
#   Configuration: MySqlFlexibleServerConfiguration
#   Database: MySqlFlexibleServerDatabase
#   FirewallRule: MySqlFlexibleServerFirewallRule
#   ServerBackup: MySqlFlexibleServerBackup
#   Server: MySqlFlexibleServer
```
