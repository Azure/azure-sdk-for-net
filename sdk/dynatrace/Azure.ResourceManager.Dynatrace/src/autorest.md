# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Dynatrace
namespace: Azure.ResourceManager.Dynatrace
require: https://github.com/Azure/azure-rest-api-specs/blob/df6a22e29f0eca5b4a89372eb66db94cb1659c0c/specification/dynatrace/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  URL: Uri
  PRE: Pre

rename-mapping:
  DynatraceSingleSignOnResource: DynatraceSingleSignOn
  DynatraceSingleSignOnResource.properties.enterpriseAppId: -|uuid
  DynatraceSingleSignOnProperties.enterpriseAppId: -|uuid
  ProvisioningState: DynatraceProvisioningState
  SingleSignOnStates: DynatraceSingleSignOnState
  MonitorResource: DynatraceMonitor
  AccountInfoSecure: DynatraceAccountCredentialsInfo
  AppServiceInfo: DynatraceOneAgentEnabledAppServiceInfo
  AppServiceInfo.resourceId: -|arm-id
  VMInfo: DynatraceMonitorVmInfo
  VMInfo.resourceId: -|arm-id
  SSODetailsResponse: DynatraceSsoDetailsResult
  SSODetailsRequest: DynatraceSsoDetailsContent
  LinkableEnvironmentResponse: LinkableEnvironmentResult
  LinkableEnvironmentRequest.region: -|azure-location
  MonitoredResource: DynatraceMonitoredResourceDetails
  MonitoredResource.id: -|arm-id
  MonitoredResource.sendingMetrics: SendingMetricsStatus
  MonitoredResource.sendingLogs: SendingLogsStatus
  VMExtensionPayload: DynatraceVmExtensionPayload
  MarketplaceSubscriptionStatus: DynatraceMonitorMarketplaceSubscriptionStatus
  MonitoringStatus: DynatraceMonitoringStatus
  PlanData: DynatraceBillingPlanInfo
  UserInfo: DynatraceMonitorUserInfo
  TagRule: DynatraceTagRule
  LogRules: DynatraceMonitorResourceLogRules
  MetricRules: DynatraceMonitorResourceMetricRules
  FilteringTag: DynatraceMonitorResourceFilteringTag
  TagAction: DynatraceMonitorResourceTagAction
  AccountInfo: DynatraceAccountInfo
  AutoUpdateSetting: DynatraceOneAgentAutoUpdateSetting
  AvailabilityState: DynatraceOneAgentAvailabilityState
  LogModule: DynatraceLogModuleState
  MonitoringType: DynatraceOneAgentMonitoringType
  UpdateStatus: DynatraceOneAgentUpdateStatus
  UpdateStatus.UP2DATE: UpToDate
  UpdateStatus.UPDATE_IN_PROGRESS: UpdateInProgress
  EnvironmentInfo: DynatraceEnvironmentInfo
  EnvironmentInfo.logsIngestionEndpoint: -|Uri
  SSOStatus: DynatraceSsoStatus
  SendAadLogsStatus: AadLogsSendingStatus
  SendSubscriptionLogsStatus: SubscriptionLogsSendingStatus
  SendActivityLogsStatus: ActivityLogsSendingStatus
  SendingLogsStatus: LogsSendingStatus
  SendingMetricsStatus: MetricsSendingStatus

```
