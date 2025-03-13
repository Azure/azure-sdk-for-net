# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ComputeSchedule
namespace: Azure.ResourceManager.ComputeSchedule
require: https://github.com/Azure/azure-rest-api-specs/blob/e8a00d5eb5252d05521a7ef34edcc7d99fff6b3c/specification/computeschedule/resource-manager/readme.md
#tag: package-2024-08-15-preview
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

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

override-operation-name:
  ScheduledActions_VirtualMachinesCancelOperations: CancelVirtualMachineOperations
  ScheduledActions_VirtualMachinesExecuteDeallocate: ExecuteVirtualMachineDeallocate
  ScheduledActions_VirtualMachinesExecuteHibernate: ExecuteVirtualMachineHibernate
  ScheduledActions_VirtualMachinesExecuteStart: ExecuteVirtualMachineStart
  ScheduledActions_VirtualMachinesGetOperationErrors: GetVirtualMachineOperationErrors
  ScheduledActions_VirtualMachinesGetOperationStatus: GetVirtualMachineOperationStatus
  ScheduledActions_VirtualMachinesSubmitDeallocate: SubmitVirtualMachineDeallocate
  ScheduledActions_VirtualMachinesSubmitHibernate: SubmitVirtualMachineHibernate
  ScheduledActions_VirtualMachinesSubmitStart: SubmitVirtualMachineStart

rename-mapping:
  CancelOperationsResponse: CancelOperationsResult
  DeadlineType: ScheduledActionDeadlineType
  DeallocateResourceOperationResponse: DeallocateResourceOperationResult
  DeallocateResourceOperationResponse.type: ResourceType
  ExecutionParameters: ScheduledActionExecutionParameterDetail
  GetOperationErrorsResponse: GetOperationErrorsResult
  GetOperationStatusResponse: GetOperationStatusResult
  HibernateResourceOperationResponse: HibernateResourceOperationResult
  HibernateResourceOperationResponse.type: ResourceType
  OperationState: ScheduledActionOperationState
  OptimizationPreference: ScheduledActionOptimizationPreference
  ResourceOperation: ResourceOperationResult
  Resources: UserRequestResources
  RetryPolicy: UserRequestRetryPolicy
  Schedule: UserRequestSchedule
  StartResourceOperationResponse: StartResourceOperationResult
  StartResourceOperationResponse.type: ResourceType

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

```

