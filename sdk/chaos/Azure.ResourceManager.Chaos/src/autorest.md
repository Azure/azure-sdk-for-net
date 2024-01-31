# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: Chaos
namespace: Azure.ResourceManager.Chaos
#tag: package-2023-11
require: https://github.com/Azure/azure-rest-api-specs/blob/4af52aaac2c3b4af4a0e61378d33c5bc050e65e2/specification/chaos/resource-manager/readme.md
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
  ActionStatus: ChaosExperimentRunActionStatus
  BranchStatus: ChaosExperimentRunBranchStatus
  StepStatus: ChaosExperimentRunStepStatus
  TargetReference.id: -|arm-id
  CapabilityTypePropertiesRuntimeProperties: ChaosCapabilityTypeRuntimeProperties
  ExperimentExecutionDetailsPropertiesRunInformation: ChaosExperimentRunInformation

prepend-rp-prefix:
  - Capability
  - CapabilityType
  - Experiment
  - ExperimentExecution
  - Target
  - TargetType
  - ProvisioningState
  - ContinuousAction
  - DelayAction
  - DiscreteAction
  - KeyValuePair
  - TargetReference
  - TargetReferenceType

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
  - remove-operation: 'OperationStatuses_Get'

```
