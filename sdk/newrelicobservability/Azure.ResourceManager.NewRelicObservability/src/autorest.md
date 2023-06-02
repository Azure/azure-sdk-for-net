# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Newrelic
namespace: Azure.ResourceManager.NewRelicObservability
require: https://github.com/Azure/azure-rest-api-specs/blob/fd0b301360d7f83dee9dec5afe3fff77b90b79f6/specification/newrelic/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# mgmt-debug:
#   show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

prepend-rp-prefix:
- AccountCreationSource
- AccountInfo
- Agent
- AppServiceInfo
- AppServicesGetContent
- AppServicesListResult
- BillingCycle
- BillingSource
- Endpoint
- FilteringTag
- HostsGetContent
- LogRules
- MarketplaceSubscriptionStatus
- MetricRules
- MetricsContent
- MetricsStatusContent
- MetricsStatusResult
- MonitoredResourceListResult
- MonitoringStatus
- OrganizationInfo
- OrgCreationSource
- SendAadLogsStatus
- SendActivityLogsStatus
- SendingLogsStatus
- SendingMetricsStatus
- SendMetricsStatus
- SendSubscriptionLogsStatus
- SingleSignOnState
- SwitchBillingContent
- TagAction
- TagRuleListResult
- TagRule
- UsageType
- UserInfo
- VmExtensionPayload
- VmHostsListResponse
- VmInfo

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

rename-mapping:
  AccountResource: NewRelicAccountResourceData
  AccountsListResponse: NewRelicAccountsListResult
  AgentData.ArcResourceId: -|arm-id
  AgentData.ArcVmUuid: -|uuid
  AppServicesGetRequest: NewrelicAppServicesGetContent
  AppServicesListResponse: NewrelicAppServicesListResult
  AzureStorageBlobContainerEndpointProperties: StorageBlobContainerEndpointProperties
  AzureStorageBlobContainerNewrelicEndpointProperties.StorageAccountResourceId: -|arm-id
  HostsGetRequest: NewrelicHostsGetContent
  JobDefinitionData: NewrelicJobDefinitionData
  JobRun: NewrelicJobRun
  JobDefinitionData.AgentResourceId: -|arm-id
  JobDefinitionData.LatestJobRunResourceId: -|arm-id
  JobDefinitionData.SourceResourceId: -|arm-id
  JobDefinitionData.TargetResourceId: -|arm-id
  JobRunData.AgentResourceId: -|arm-id
  JobRunData.SourceResourceId: -|arm-id
  NewRelicMonitorResource.properties.marketplaceSubscriptionId: -|arm-id
  MetricsRequest: NewrelicMetricsContent
  MetricsStatusRequest: NewrelicMetricsStatusContent
  MetricsStatusResponse: NewrelicMetricsStatusResult
  MonitoredResource: ResourceMonitoredByNewRelic
  MonitoredResource.id: -|arm-id
  MonitoredResourceListResponse: MonitoredResourceListResult
  MonitoringStatus.Disabled: IsDisabled
  MonitoringStatus.Enabled: IsEnabled
  NewrelicAgentData.LocalIPAddress: -|ip-address
  OrganizationsListResponse: NewrelicOrganizationsListResult
  ProvisioningState: NewrelicProvisioningState
  Project: NewrelicProject
  PlanDataListResponse: NewrelicPlanDataListResult
  PlanData: NewRelicPlan
  PlanDataResource: NewRelicPlanResourceData
  OrganizationResource: NewRelicOrganizationResourceData
  SendAadLogsStatus.Disabled: IsDisabled
  SendAadLogsStatus.Enabled: IsEnabled
  SendingLogsStatus.Disabled: IsDisabled
  SendingLogsStatus.Enabled: IsEnabled
  SendActivityLogsStatus.Disabled: IsDisabled
  SendActivityLogsStatus.Enabled: IsEnabled
  SendingMetricsStatus.Disabled: IsDisabled
  SendingMetricsStatus.Enabled: IsEnabled
  SendSubscriptionLogsStatus.Disabled: IsDisabled
  SendSubscriptionLogsStatus.Enabled: IsEnabled
  SingleSignOnStates: NewRelicSingleSignOnState
  StorageMover: NewrelicStorageMover
  SwitchBillingRequest: NewrelicSwitchBillingContent
  VMInfo.vmId: -|arm-id

override-operation-name:
  Accounts_List: GetNewrelicAccounts
  Organizations_List: GetNewrelicOrganizations
  Plans_List: GetNewrelicPlans

```
