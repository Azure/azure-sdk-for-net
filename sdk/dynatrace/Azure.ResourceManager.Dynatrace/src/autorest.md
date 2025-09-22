# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Dynatrace
namespace: Azure.ResourceManager.Dynatrace
require: https://github.com/Azure/azure-rest-api-specs/blob/3b2afb5c94cfb3dd5345f1bdbd029bfbb265d218/specification/dynatrace/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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

override-operation-name:
  CreationSupported_List: GetAllCreationSupported
  CreationSupported_Get: GetCreationSupported

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
  MetricsStatusResponse: MetricsStatusResult
  MarketplaceSaaSResourceDetailsResponse: MarketplaceSaaSResourceDetailsResult
  ConnectedResourcesCountResponse: ConnectedResourcesCountResult

directive:
  - from: swagger-document
    where: $.definitions.ManagedIdentityType
    transform: >
      $ = {
          "type": "string",
          "description": "The kind of managed identity assigned to this resource.",
          "enum": [
            "SystemAssigned",
            "UserAssigned",
            "SystemAndUserAssigned"
          ],
          "x-ms-enum": {
            "name": "ManagedIdentityType",
            "modelAsString": true
          }
        }
```
