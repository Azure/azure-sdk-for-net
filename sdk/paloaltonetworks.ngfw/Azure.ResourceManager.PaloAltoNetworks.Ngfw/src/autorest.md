# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: PaloAltoNetworks.Ngfw
namespace: Azure.ResourceManager.PaloAltoNetworks.Ngfw
require: https://github.com/Azure/azure-rest-api-specs/blob/a65ba8751a75cf016f477ed6cff8062347879047/specification/paloaltonetworks/resource-manager/readme.md
#tag: package-2023-09-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  CertificateObjectGlobalRulestackResource: GlobalRulestackCertificateObject
  CertificateObjectGlobalRulestackResourceListResult: GlobalRulestackCertificateObjectListResult
  CertificateObjectLocalRulestackResource: LocalRulestackCertificateObject
  CertificateObjectLocalRulestackResourceListResult: LocalRulestackCertificateObjectListResult
  FirewallResource: PaloAltoNetworksFirewall
  FirewallResourceListResult: PaloAltoNetworksFirewallListResult
  FirewallStatusResource: PaloAltoNetworksFirewallStatus
  FirewallStatusResourceListResult: PaloAltoNetworksFirewallStatusListResult
  FqdnListGlobalRulestackResource: GlobalRulestackFqdn
  FqdnListGlobalRulestackResourceListResult: GlobalRulestackFqdnListResult
  FqdnListLocalRulestackResource: LocalRulestackFqdn
  FqdnListLocalRulestackResourceListResult: LocalRulestackFqdnListResult
  GlobalRulestackResource: GlobalRulestack
  GlobalRulestackResourceListResult: GlobalRulestackListResult
  LocalRulesResource: LocalRulestackRule
  LocalRulestackResource: LocalRulestack
  LocalRulestackResourceListResult: LocalRulestackListResult
  PostRulesResource: PostRulestackRule
  PrefixListGlobalRulestackResource: GlobalRulestackPrefix
  PrefixListResource: LocalRulestackPrefix
  PreRulesResource: PreRulestackRule
  ActionEnum: RulestackActionType
  AdvSecurityObjectListResponse: AdvancedSecurityObjectListResult
  AdvSecurityObjectModel: AdvancedSecurityObject
  AdvSecurityObjectTypeEnum: AdvancedSecurityObjectType
  ApplicationInsights: FirewallApplicationInsights
  AppSeenData: AppSeenInfoList
  BillingCycle: FirewallBillingCycle
  BooleanEnum: FirewallBooleanType
  Category: EdlMatchCategory
  Changelog: RulestackChangelog
  Changelog.lastCommitted: LastCommittedOn
  Changelog.lastModified: LastModifiedOn
  CountriesResponse: RulestackCountryListResult
  Country: RulestackCountry
  DecryptionRuleTypeEnum: DecryptionRuleType
  DefaultMode: RuleCreationDefaultMode
  DestinationAddr: DestinationAddressInfo
  DNSProxy: AllowDnsProxyType
  DNSSettings: FirewallDnsSettings
  EgressNat: AllowEgressNatType
  EndpointConfiguration: FirewallEndpointConfiguration
  EventHub: EventHubConfiguration
  EventHub.id: -|arm-id
  FirewallResourceUpdateProperties: FirewallUpdateProperties
  FrontendSetting: FirewallFrontendSetting
  GlobalRulestackResourceUpdateProperties: GlobalRulestackUpdateProperties
  HealthStatus: FirewallHealthStatus
  HealthStatus.RED: Red
  IPAddress: IPAddressInfo
  IPAddress.resourceId: -|arm-id
  IPAddressSpace: IPAddressSpaceInfo
  IPAddressSpace.resourceId: -|arm-id
  ListAppIdResponse: RulestackAppIdListResult
  ListFirewallsResponse: RulestackFirewallListResult
  LocalRulestackResourceUpdateProperties: LocalRulestackUpdateProperties
  LogDestination: FirewallLogDestination
  LogDestination.storageConfigurations: StorageConfiguration
  LogDestination.eventHubConfigurations: EventHubConfiguration
  LogDestination.monitorConfigurations: MonitorConfiguration
  LogOption: FirewallLogOption
  LogSettings: FirewallLogSettings
  LogType: FirewallLogType
  LogType.DLP: Dlp
  MarketplaceDetails: PanFirewallMarketplaceDetails
  MonitorLog: MonitorLogConfiguration
  MonitorLog.id: -|arm-id
  NetworkProfile: FirewallNetworkProfile
  NetworkType: FirewallNetworkType
  PanoramaConfig: FirewallPanoramaConfiguration
  PanoramaStatus: FirewallPanoramaStatus
  PlanData: FirewallBillingPlanInfo
  PredefinedUrlCategoriesResponse: PredefinedUrlCategoryListResult
  ProtocolType: FirewallProtocolType
  ProvisioningState: FirewallProvisioningState
  ReadOnlyProvisioningState: FirewallProvisioningStateType
  RuleCounter: FirewallRuleCounter
  RuleCounter.requestTimestamp: RequestOn
  RuleCounter.timestamp: ResponseOn
  RuleCounter.lastUpdatedTimestamp: LastUpdatedOn
  RuleCounterReset: FirewallRuleResetConter
  RulestackDetails.resourceId: -|arm-id
  ScopeType: RulestackScopeType
  SecurityServices: RulestackSecurityServices
  SecurityServicesResponse: RulestackSecurityServiceListResult
  SecurityServicesTypeList: RulestackSecurityServiceTypeList
  SecurityServicesTypeEnum: RulestackSecurityServiceType
  ServerStatus: FirewallPanoramaServerStatus
  ServerStatus.UP: Up
  SourceAddr: SourceAddressInfo
  StateEnum: RulestackStateType
  StorageAccount: StorageAccountConfiguration
  StorageAccount.id: -|arm-id
  SupportInfo: FirewallSupportInfo
  TagInfo: RulestackTagInfo
  UsageType: FirewallBillingPlanUsageType
  VnetConfiguration: FirewallVnetConfiguration
  VwanConfiguration: FirewallVwanConfiguration
  VwanConfiguration.vHub: Vhub
  EnableStatus: FreeTrialEnableStatus
  RegistrationStatus: AccountRegistrationStatus
  MetricsObjectFirewallResource: MetricsObjectFirewall

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'PanETag': 'etag'
  'location': 'azure-location'
  'PanLocation': 'azure-location'
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
  SSL: Ssl
  TCP: Tcp
  UDP: Udp

directive:
  # This change replaces the `ManagedIdentityProperties` with the `ManagedServiceIdentity` from the common library, which have the same structure.
  - from: PaloAltoNetworks.Cloudngfw.json
    where: $.definitions
    transform: >
      $['Azure.ResourceManager.ManagedIdentityProperties'].properties.type = {
          'type': 'string',
          'description': 'Type of the managed identity.',
          'enum': [
            'None',
            'SystemAssigned',
            'UserAssigned',
            'SystemAssigned,UserAssigned'
          ],
          'x-ms-enum': {
            'name': 'ManagedServiceIdentityType',
            'modelAsString': true
          }
        };
  # This change replaces pagination for List api's since operationName is incorrect
  - from: PaloAltoNetworks.Cloudngfw.json
    where: $.paths
    transform: >
      for (const pathKey in $) {
        const path = $[pathKey];
        for (const methodKey in path) {
          const method = path[methodKey];
          if (method['x-ms-pageable'] && (method['x-ms-pageable']['operationName'] === 'LocalRulestacks_listAppIds' || method['x-ms-pageable']['operationName'] === 'LocalRulestacks_listCountries' || method['x-ms-pageable']['operationName'] === 'LocalRulestacks_listPredefinedUrlCategories')) {
            delete method['x-ms-pageable'];
          }
        }
      }
  - from: PaloAltoNetworks.Cloudngfw.json
    where: $.definitions
    transform: >
      $['ProductSerialStatusValues']['x-ms-enum'].modelAsString = true

```
