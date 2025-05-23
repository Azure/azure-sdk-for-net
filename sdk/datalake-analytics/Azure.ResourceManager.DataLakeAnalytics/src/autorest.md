# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataLakeAnalytics
namespace: Azure.ResourceManager.DataLakeAnalytics
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/066eb8c81e14e0f3b22b6700c67693eef5f79ea9/specification/datalake-analytics/resource-manager/readme.md
tag: package-2016-11
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

mgmt-debug:
  show-serialized-names: true

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}

operation-positions:
  Accounts_ListByResourceGroup: collection

override-operation-name:
  Accounts_ListByResourceGroup: GetAll
  Accounts_CheckNameAvailability: CheckDataLakeAnalyticsAccountNameAvailability

rename-mapping:
  AADObjectType: AadObjectIdentifierType
  AddDataLakeStoreWithAccountParameters: DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent
  AddStorageAccountWithAccountParameters: StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent
  CreateComputePolicyWithAccountParameters: ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent
  CreateFirewallRuleWithAccountParameters: FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent
  UpdateDataLakeStoreWithAccountParameters: DataLakeStoreForDataLakeAnalyticsAccountUpdateContent
  UpdateStorageAccountWithAccountParameters: StorageAccountForDataLakeAnalyticsAccountUpdateContent
  UpdateComputePolicyWithAccountParameters: ComputePolicyForDataLakeAnalyticsAccountUpdateContent
  UpdateFirewallRuleWithAccountParameters: FirewallRuleForDataLakeAnalyticsAccountUpdateContent
  TierType: DataLakeAnalyticsCommitmentTierType
  CheckNameAvailabilityParameters: DataLakeAnalyticsAccountNameAvailabilityContent
  NameAvailabilityInformation: DataLakeAnalyticsAccountNameAvailabilityResult
  CheckNameAvailabilityParametersType: DataLakeAnalyticsResourceType
  FirewallRule.properties.startIpAddress: -|ip-address
  FirewallRule.properties.endIpAddress: -|ip-address
  CreateOrUpdateFirewallRuleParameters.properties.startIpAddress: -|ip-address
  CreateOrUpdateFirewallRuleParameters.properties.endIpAddress: -|ip-address
  UpdateFirewallRuleParameters.properties.startIpAddress: -|ip-address
  UpdateFirewallRuleParameters.properties.endIpAddress: -|ip-address
  CreateFirewallRuleWithAccountParameters.properties.startIpAddress: -|ip-address
  CreateFirewallRuleWithAccountParameters.properties.endIpAddress: -|ip-address
  UpdateFirewallRuleWithAccountParameters.properties.startIpAddress: -|ip-address
  UpdateFirewallRuleWithAccountParameters.properties.endIpAddress: -|ip-address
  CapabilityInformation.migrationState: IsUnderMigrationState
  NameAvailabilityInformation.nameAvailable: IsNameAvailable
  VirtualNetworkRule.properties.subnetId: -|arm-id

prepend-rp-prefix:
  - ComputePolicy
  - ComputePolicyListResult
  - FirewallRule
  - FirewallRuleListResult
  - StorageContainer
  - StorageContainerListResult
  - StorageAccountInformation
  - StorageAccountInformationListResult
  - FirewallState
  - FirewallAllowAzureIpsState
  - CapabilityInformation
  - HiveMetastore
  - SasTokenInformation
  - SasTokenInformationListResult
  - SubscriptionState
  - VirtualNetworkRule
  - VirtualNetworkRuleState

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

```
