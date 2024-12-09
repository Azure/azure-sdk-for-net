# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataLakeStore
namespace: Azure.ResourceManager.DataLakeStore
require: https://github.com/Azure/azure-rest-api-specs/blob/3817b12e57f613a0dfd65c81fe9e8cd97af7d8c5/specification/datalake-store/resource-manager/readme.md
tag: package-2016-11
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeStore/accounts: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeStore/accounts/{accountName}

operation-positions:
  Accounts_ListByResourceGroup: collection

override-operation-name:
  Accounts_ListByResourceGroup: GetAll
  Accounts_CheckNameAvailability: CheckDataLakeStoreAccountNameAvailability
  Locations_GetCapability: GetCapabilityByLocation
  Locations_GetUsage: GetUsagesByLocation

rename-mapping:
  CheckNameAvailabilityParameters: DataLakeStoreAccountNameAvailabilityContent
  CheckNameAvailabilityParametersType: DataLakeStoreResourceType
  CreateFirewallRuleWithAccountParameters: FirewallRuleForDataLakeStoreAccountCreateOrUpdateContent
  CreateVirtualNetworkRuleWithAccountParameters: VirtualNetworkRuleForDataLakeStoreAccountCreateOrUpdateContent
  CreateTrustedIdProviderWithAccountParameters: TrustedIdProviderForDataLakeStoreAccountCreateOrUpdateContent
  UpdateFirewallRuleWithAccountParameters: FirewallRuleForDataLakeStoreAccountUpdateContent
  UpdateTrustedIdProviderWithAccountParameters: TrustedIdProviderForDataLakeStoreAccountUpdateContent
  UpdateVirtualNetworkRuleWithAccountParameters: VirtualNetworkRuleForDataLakeStoreAccountUpdateContent
  TierType: DataLakeStoreCommitmentTierType
  EncryptionConfig: DataLakeStoreAccountEncryptionConfig
  EncryptionConfigType: DataLakeStoreAccountEncryptionConfigType
  KeyVaultMetaInfo: DataLakeStoreAccountKeyVaultMetaInfo
  NameAvailabilityInformation: DataLakeStoreAccountNameAvailabilityResult
  Usage.id: -|arm-id
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
  NameAvailabilityInformation.nameAvailable: IsNameAvailable
  VirtualNetworkRule.properties.subnetId: -|arm-id
  CreateOrUpdateVirtualNetworkRuleParameters.properties.subnetId: -|arm-id
  UpdateVirtualNetworkRuleParameters.properties.subnetId: -|arm-id
  CreateVirtualNetworkRuleWithAccountParameters.properties.subnetId: -|arm-id
  UpdateVirtualNetworkRuleWithAccountParameters.properties.subnetId: -|arm-id
  TrustedIdProvider.properties.idProvider: -|uri
  CreateOrUpdateTrustedIdProviderParameters.properties.idProvider: -|uri
  UpdateTrustedIdProviderParameters.properties.idProvider: -|uri
  CreateTrustedIdProviderWithAccountParameters.properties.idProvider: -|uri
  UpdateTrustedIdProviderWithAccountParameters.properties.idProvider: -|uri
  CapabilityInformation.migrationState: IsUnderMigrationState
  DataLakeStoreAccountBasic: DataLakeStoreAccountBasicData

prepend-rp-prefix:
  - FirewallRule
  - TrustedIdProvider
  - VirtualNetworkRule
  - VirtualNetworkRuleListResult
  - CapabilityInformation
  - FirewallState
  - FirewallAllowAzureIpsState
  - EncryptionProvisioningState
  - EncryptionState
  - FirewallRuleListResult
  - TrustedIdProviderListResult
  - TrustedIdProviderState
  - SubscriptionState
  - UsageListResult
  - UsageName
  - UsageUnit

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

directive:
  - from: account.json
    where: $.paths..parameters[?(@.name === '$orderby')]
    transform: >
      $['x-ms-client-name'] = 'orderBy';

```
