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
    Agent: NewrelicAgent
    AgentData.ArcResourceId: -|arm-id
    AgentData.ArcVmUuid: -|uuid
    AppServicesListResponse: AppServicesListResult
    AzureStorageBlobContainerEndpointProperties: StorageBlobContainerEndpointProperties
    AzureStorageBlobContainerNewrelicEndpointProperties.StorageAccountResourceId: -|arm-id
    Endpoint: NewrelicEndpoint
    JobDefinitionData: NewrelicJobDefinitionData
    JobRun: NewrelicJobRun
    JobDefinitionData.AgentResourceId: -|arm-id
    JobDefinitionData.LatestJobRunResourceId: -|arm-id
    JobDefinitionData.SourceResourceId: -|arm-id
    JobDefinitionData.TargetResourceId: -|arm-id
    JobRunData.AgentResourceId: -|arm-id
    JobRunData.SourceResourceId: -|arm-id
    NewRelicMonitorResource.properties.marketplaceSubscriptionId: -|arm-id
    MetricsStatusResponse: MetricsStatusResult
    MonitoredResource: ResourceMonitoredByNewRelic
    MonitoredResource.id: -|arm-id
    MonitoredResourceListResponse: MonitoredResourceListResult
    MonitoringStatus.Disabled: IsDisabled
    MonitoringStatus.Enabled: IsEnabled
    NewrelicAgentData.LocalIPAddress: -|ip-address
    OrganizationsListResponse: OrganizationsListResult
    ProvisioningState: NewrelicProvisioningState
    Project: NewrelicProject
    PlanDataListResponse: PlanDataListResult
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
    StorageMover: NewrelicStorageMover
    VMInfo.vmId: -|arm-id

```
