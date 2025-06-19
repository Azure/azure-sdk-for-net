# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: StorageActions
namespace: Azure.ResourceManager.StorageActions
require: https://github.com/Azure/azure-rest-api-specs/blob/c3a3fd40087fde8e462a210bc086f26877aa1a78/specification/storageactions/resource-manager/readme.md
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

rename-mapping:
  StorageTaskOperation: StorageTaskOperationInfo
  ElseCondition: StorageTaskElseCondition
  IfCondition: StorageTaskIfCondition
  OnFailure: OnFailureAction
  OnSuccess: OnSuccessAction
  ProvisioningState: StorageTaskProvisioningState
  RunResult: StorageTaskRunResult
  RunStatusEnum: StorageTaskRunStatus
  StorageTaskProperties.enabled: IsEnabled

override-operation-name:
  StorageTasks_PreviewActions: PreviewActions

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

```
