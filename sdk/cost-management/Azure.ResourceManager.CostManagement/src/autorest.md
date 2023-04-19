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

mgmt-debug:
  suppress-list-exception: true

override-operation-name: 
  Alerts_ListExternal: Foo

list-exception:
- /providers/Microsoft.CostManagement/views/{viewName}

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
  - remove-operation: Views_List
  - remove-operation: ScheduledActions_List
  # - remove-operation: GenerateCostDetailsReport_GetOperationResults
  # - remove-operation: GenerateDetailedCostReportOperationResults_Get
  # - remove-operation: GenerateDetailedCostReportOperationStatus_Get
  
```