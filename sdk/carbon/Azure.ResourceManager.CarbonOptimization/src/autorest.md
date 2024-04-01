# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CarbonOptimization
namespace: Azure.ResourceManager.CarbonOptimization
require: https://github.com/Azure/azure-rest-api-specs/blob/0e1d8ac4d5ca8a76479870db0a04aebe4fc3eab0/specification/carbon/resource-manager/readme.md
#tag: package-2024-02-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  CarbonEmissionData: CarbonEmission
  CarbonEmissionDataAvailableDateRange: CarbonEmissionAvailableDateRange
  CarbonEmissionDataAvailableDateRange.startDate: StartOn|date-time
  CarbonEmissionDataAvailableDateRange.endDate: EndOn|date-time
  CarbonEmissionItemDetailData: CarbonEmissionItemDetail
  CarbonEmissionMonthlySummaryData: CarbonEmissionMonthlySummary
  CarbonEmissionOverallSummaryData: CarbonEmissionOverallSummary
  CarbonEmissionTopItemMonthlySummaryData: CarbonEmissionTopItemMonthlySummary
  CarbonEmissionTopItemsSummaryData: CarbonEmissionTopItemsSummary
  CategoryTypeEnum: CarbonEmissionCategoryType
  DateRange: CarbonEmissionQueryDateRange
  DateRange.start: StartOn
  DateRange.end: EndOn
  EmissionScopeEnum: CarbonEmissionQueryScope
  QueryFilter: CarbonEmissionQueryContent
  ResourceCarbonEmissionItemDetailData: ResourceCarbonEmissionItemDetail
  ResourceCarbonEmissionItemDetailData.resourceId: -|arm-id
  ResourceCarbonEmissionItemDetailData.resourceType: -|resource-type
  ResourceCarbonEmissionTopItemMonthlySummaryData: ResourceCarbonEmissionTopItemMonthlySummary
  ResourceCarbonEmissionTopItemsSummaryData: ResourceCarbonEmissionTopItemsSummary
  ResourceGroupCarbonEmissionItemDetailData: ResourceGroupCarbonEmissionItemDetail
  ResourceGroupCarbonEmissionTopItemMonthlySummaryData: ResourceGroupCarbonEmissionTopItemMonthlySummary
  ResourceGroupCarbonEmissionTopItemsSummaryData: ResourceGroupCarbonEmissionTopItemsSummary
  ResourceTypeCarbonEmissionItemDetailData: ResourceTypeCarbonEmissionItemDetail
  AccessDecisionEnum: SubscriptionAccessDecisionType
  ItemDetailsQueryFilter: ItemDetailsQueryContent
  MonthlySummaryReportQueryFilter: MonthlySummaryReportQueryContent
  OverallSummaryReportQueryFilter: OverallSummaryReportQueryContent
  TopItemsMonthlySummaryReportQueryFilter: TopItemsMonthlySummaryReportQueryContent
  TopItemsSummaryReportQueryFilter: TopItemsSummaryReportQueryContent

override-operation-name:
  CarbonService_QueryCarbonEmissionDataAvailableDateRange: QueryCarbonEmissionAvailableDateRange
  CarbonService_ListCarbonEmissionReports: GetCarbonEmissionReports

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
  - remove-operation: Operations_List
```
