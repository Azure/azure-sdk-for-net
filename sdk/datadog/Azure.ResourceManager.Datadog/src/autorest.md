# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Datadog
namespace: Azure.ResourceManager.Datadog
require: https://github.com/Azure/azure-rest-api-specs/blob/c37407dc4b8c49dd01fe73d9278e5c21beea169c/specification/datadog/resource-manager/readme.md
# tag: package-2023-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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
  DatadogAgreementResource: DatadogAgreementResourceContent
  MonitoredResource: MonitoredResourceContent
  BillingInfoResponse: DatadogBillingInfoResult
  CreateResourceSupportedResponse: DatadogCreateResourceSupportedResult
  DatadogMonitorResourceUpdateParameters: DatadogMonitorResourceUpdateContent
  DatadogApiKey: DatadogApiKeyContent
  LinkedResource: LinkedInfo
  Status: MonitoredStatus
  DatadogAgreementResourceListResponse: DatadogAgreementResourceListResult
  DatadogApiKeyListResponse: DatadogApiKeyListResult
  DatadogHostListResponse: DatadogHostListResult
  DatadogMonitorResourceListResponse: DatadogMonitorResourceListResult
  DatadogSingleSignOnResourceListResponse: DatadogSingleSignOnResourceListResult
  LinkedResourceListResponse: LinkedResourceListResult
  MonitoredResourceListResponse: MonitoredResourceListResult
  MonitoringTagRulesListResponse: MonitoringTagRulesListResult
  CreateResourceSupportedResponseList: CreateResourceSupportedResultList
  Operation: OperationData
  CreateResourceSupportedProperties.creationSupported: IsCreationSupported
  MarketplaceSaaSInfo.subscribed: IsSubscribed
  DatadogAgreementProperties.accepted: IsAccepted
  DatadogOrganizationProperties.cspm: IsCspm
  LogRules.sendAadLogs: IsSendAadLogs
  LogRules.sendSubscriptionLogs: IsSendSubscriptionLogs
  LogRules.sendResourceLogs: IsSendResourceLogs
  MonitorUpdateProperties.cspm: IsCspm
  MonitoredResource.sendingMetrics: IsSendingMetrics
  MonitoredResource.sendingLogs: IsSendingLogs
  MonitoringTagRulesProperties.automuting: IsAutomuting
  MonitoringTagRulesProperties.customMetrics: IsCustomMetrics

```
