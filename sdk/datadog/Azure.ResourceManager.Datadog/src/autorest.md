# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Datadog
namespace: Azure.ResourceManager.Datadog
require: https://github.com/Azure/azure-rest-api-specs/blob/278d4cb813510d2963592eb2aee9c64325a80007/specification/datadog/resource-manager/readme.md
#tag: package-2025-06
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

rename-mapping:
  AgentRules: DatadogMonitorAgentRules
  AgentRules.enableAgentMonitoring: IsAgentMonitoringEnabled
  BillingInfoResponse: DatadogBillingInfoResult
  CreateResourceSupportedProperties: DatadogSubscriptionStatusProperties
  CreateResourceSupportedProperties.creationSupported: IsCreationSupported
  CreateResourceSupportedResponse: DatadogSubscriptionStatusResult
  DatadogAgreementResource: DatadogAgreement
  DatadogAgreementProperties.accepted: IsAccepted
  DatadogMonitorResource: DatadogMonitor
  DatadogOrganizationProperties.cspm: IsCspm
  DatadogOrganizationProperties.resourceCollection: IsResourceCollection
  DatadogSingleSignOnResource: DatadogSingleSignOn
  FilteringTag: DatadogMonitorFilteringTag
  LiftrResourceCategories: DatadogLiftrResourceCategory
  LinkedResource: DatadogLinkedResourceResult
  LinkedResource.id: -|arm-id
  LogRules: DatadogMonitorLogRules
  LogRules.sendAadLogs: IsAadLogsSent
  LogRules.sendResourceLogs: IsResourceLogsSent
  LogRules.sendSubscriptionLogs: IsSubscriptionLogsSent
  MarketplaceSaaSInfo.subscribed: IsSubscribed
  MetricRules: DatadogMonitorMetricRules
  MonitoredResource: DatadogMonitoredResourceResult
  MonitoredResource.id: -|arm-id
  MonitoredResource.sendingLogs: IsSendingLogsEnabled
  MonitoredResource.sendingMetrics: IsSendingMetricsEnabled
  MonitoredSubscription: DatadogMonitoredSubscriptionItem
  MonitoredSubscriptionProperties: DatadogMonitoredSubscription
  MonitoringStatus: DatadogMonitoringStatus
  MonitoringTagRules: DataMonitoringTagRule
  MonitoringTagRulesProperties: MonitoringTagRuleProperties
  MonitoringTagRulesProperties.automuting: IsAutomutingEnabled
  MonitoringTagRulesProperties.customMetrics: IsCustomMetricsEnabled
  MonitorProperties: DatadogMonitorProperties
  MonitorUpdateProperties: DatadogMonitorResourcePatchProperties
  MonitorUpdateProperties.cspm: IsCspm
  MonitorUpdateProperties.resourceCollection: IsResourceCollection
  Operation: DatadogOperation
  ProvisioningState: DatadogProvisioningState
  ResourceSku: DatadogSku
  ResubscribeProperties: ResubscribeOrganizationContent
  SingleSignOnStates: DatadogSingleSignOnState
  Status: DatadogMonitorStatus
  SubscriptionList: DatadogSubscriptionProperties
  TagAction: DatadogMonitorTagAction
  UserInfo: DatadogUserInfo

override-operation-name:
  CreationSupported_List: GetSubscriptionStatuses
  CreationSupported_Get: GetSubscriptionStatus

```
