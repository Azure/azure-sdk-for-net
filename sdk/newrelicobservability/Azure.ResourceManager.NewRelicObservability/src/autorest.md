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
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
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
- VMExtensionPayload
- VMHostsListResponse
- VMInfo

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
  AccountInfo.region: -|azure-location
  AccountResource: NewRelicAccountResourceData
  AccountResource.properties.region: -|azure-location
  AccountsListResponse: NewRelicAccountsListResult
  AgentData.ArcResourceId: -|arm-id
  AgentData.ArcVmUuid: -|uuid
  AppServicesGetRequest: NewRelicAppServicesGetContent
  AppServicesGetRequest.azureResourceIds: -|arm-id
  AppServiceInfo.azureResourceId: -|arm-id
  AppServicesListResponse: NewRelicAppServicesListResult
  AzureStorageBlobContainerEndpointProperties: StorageBlobContainerEndpointProperties
  AzureStorageBlobContainerNewrelicEndpointProperties.StorageAccountResourceId: -|arm-id
  HostsGetRequest: NewRelicHostsGetContent
  HostsGetRequest.vmIds: -|arm-id
  JobDefinitionData: NewRelicJobDefinitionData
  JobRun: NewRelicJobRun
  JobDefinitionData.AgentResourceId: -|arm-id
  JobDefinitionData.LatestJobRunResourceId: -|arm-id
  JobDefinitionData.SourceResourceId: -|arm-id
  JobDefinitionData.TargetResourceId: -|arm-id
  JobRunData.AgentResourceId: -|arm-id
  JobRunData.SourceResourceId: -|arm-id
  LiftrResourceCategories: NewRelicLiftrResourceCategory
  MetricsRequest: NewRelicMetricsContent
  MetricsStatusRequest: NewRelicMetricsStatusContent
  MetricsStatusResponse: NewRelicMetricsStatusResult
  MonitoredResource: NewRelicResourceMonitorResult
  MonitoredResource.id: -|arm-id
  MonitoredResourceListResponse: NewRelicObservabilityMonitoredResourceListResult
  MonitoringStatus.Disabled: IsDisabled
  MonitoringStatus.Enabled: IsEnabled
  NewrelicAgentData.LocalIPAddress: -|ip-address
  OrganizationsListResponse: NewRelicOrganizationsListResult
  ProvisioningState: NewRelicProvisioningState
  Project: NewRelicProject
  PlanDataListResponse: NewRelicPlanDataListResult
  PlanData: NewRelicPlanDetails
  PlanDataResource: NewRelicPlanData
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
  StorageMover: NewRelicStorageMover
  SwitchBillingRequest: NewRelicSwitchBillingContent
  SwitchBillingRequest.azureResourceId: -|arm-id
  VMInfo.vmId: -|arm-id

override-operation-name:
  Accounts_List: GetNewRelicAccounts
  Organizations_List: GetNewRelicOrganizations
  Plans_List: GetNewRelicPlans

```
