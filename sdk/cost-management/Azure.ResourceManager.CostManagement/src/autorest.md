# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: CostManagement
namespace: Azure.ResourceManager.CostManagement
require: https://github.com/Azure/azure-rest-api-specs/blob/25bfafa4fc73bb7e876dd5ef00f19b9aa9ba628a/specification/cost-management/resource-manager/readme.md
tag: package-2022-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# override-operation-name: 
#   Alerts_ListExternal: ListExternalAlerts

list-exception:
- /providers/Microsoft.CostManagement/views/{viewName}
- /{scope}/providers/Microsoft.CostManagement/costDetailsOperationResults/{operationId}
- /{scope}/providers/Microsoft.CostManagement/operationResults/{operationId}
- /{scope}/providers/Microsoft.CostManagement/operationStatus/{operationId}
- /providers/Microsoft.CostManagement/scheduledActions/{name}

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

directive:
  # [Error] Found more than 1 candidate for XX 
  - remove-operation: Views_List
  - remove-operation: ScheduledActions_List
  # [Error] Not a constant
  - remove-operation: Alerts_ListExternal
  - remove-operation: Forecast_ExternalCloudProviderUsage
  - remove-operation: Dimensions_ByExternalCloudProviderType
  - remove-operation: Query_UsageByExternalCloudProviderType

  # [Build Error] Return 'Response' instead of 'Response<Foo>'
  - remove-operation: GenerateCostDetailsReport_CreateOperation
  - remove-operation: GenerateCostDetailsReport_GetOperationResults

  - remove-operation: GenerateDetailedCostReport_CreateOperation
  - remove-operation: GenerateDetailedCostReportOperationResults_Get
  - remove-operation: GenerateDetailedCostReportOperationStatus_Get

  # Could not set ResourceTypeSegment for request path /{scope}
  - from: scheduledActions.json
    where: $.parameters.scopeParameter
    transform: $['x-ms-skip-url-encoding'] = true;
  - from: costmanagement.json
    where: $.parameters.scopeViewParameter
    transform: $['x-ms-skip-url-encoding'] = true;

```