# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: Chaos
namespace: Azure.ResourceManager.Chaos
require: https://github.com/Azure/azure-rest-api-specs-pr/blob/1535397ba63c2148189f6c65bb4fcc076dbe1e19/specification/chaos/resource-manager/readme.md
input-file:
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/1535397ba63c2148189f6c65bb4fcc076dbe1e19/specification/chaos/resource-manager/Microsoft.Chaos/Chaos/preview/2026-02-01-preview/openapi.json
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
  ActionStatus: ChaosExperimentRunActionStatus
  BranchStatus: ChaosExperimentRunBranchStatus
  StepStatus: ChaosExperimentRunStepStatus
  TargetReference.id: -|arm-id
  CapabilityTypePropertiesRuntimeProperties: ChaosCapabilityTypeRuntimeProperties
  ExperimentExecutionDetailsPropertiesRunInformation: ChaosExperimentRunInformation
  Workspace: ChaosWorkspace
  Scenario: ChaosScenario
  ScenarioRun: ChaosScenarioRun
  ScenarioConfiguration: ChaosScenarioConfiguration
  DiscoveredResource: ChaosDiscoveredResource
  ScenarioParameter: ChaosScenarioParameterInfo

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
  # Fix duration properties that don't have the format set in the OpenAPI spec for ScenarioAction
  - from: swagger-document
    where: $.definitions.ScenarioAction.properties.duration
    transform: >
      $["format"] = "duration";
      return $;
  - from: swagger-document
    where: $.definitions.ScenarioAction.properties.waitBefore
    transform: >
      $["format"] = "duration";
      return $;
  - from: swagger-document
    where: $.definitions.ScenarioAction.properties.timeout
    transform: >
      $["format"] = "duration";
      return $;
