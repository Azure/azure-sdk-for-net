# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerServiceFleet
namespace: Azure.ResourceManager.ContainerServiceFleet
require: https://github.com/Azure/azure-rest-api-specs/blob/d19d4d8c69cf37c355ee55095b335ca92643120e/specification/containerservice/resource-manager/Microsoft.ContainerService/fleet/readme.md
#tag: package-2025-04-01-preview
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
  Fleet: ContainerServiceFleet
  FleetListResult: ContainerServiceFleetListResult
  FleetMember: ContainerServiceFleetMember
  FleetMemberListResult: ContainerServiceFleetMemberListResult
  MemberUpdateStatus.clusterResourceId: -|arm-id
  SkipProperties: ContainerServiceFleetSkipProperties
  SkipTarget: ContainerServiceFleetSkipTarget
  TargetType: ContainerServiceFleetTargetType
  UpgradeChannel: ContainerServiceFleetUpgradeChannel
  GenerateResponse: AutoUpgradeProfileGenerateResult
  FleetMemberStatus: ContainerServiceFleetMemberStatus
  FleetStatus: ContainerServiceFleetStatus
  Timing: ContainerServiceFleetGateTiming 

prepend-rp-prefix:
  - AgentProfile
  - APIServerAccessProfile
  - Gate
  - GateConfiguration
  - GateProvisioningState
  - GateState
  - GateTarget
  - GateType
  - ManagedClusterUpdate
  - ManagedClusterUpgradeSpec
  - ManagedClusterUpgradeType
  - UpdateGroup
  - UpdateGroupStatus
  - UpdateRun
  - UpdateRunListResult
  - UpdateRunProvisioningState
  - UpdateRunStatus
  - UpdateRunStrategy
  - UpdateStage
  - UpdateStageStatus
  - UpdateState
  - UpdateStatus
  - WaitStatus

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

operations-to-lro-api-version-override:
  Fleets_CreateOrUpdate: "2016-03-30"
  Fleets_Update: "2016-03-30"
  Fleets_Delete: "2016-03-30"
  FleetMembers_Create: "2016-03-30"
  FleetMembers_Update: "2016-03-30"
  FleetMembers_Delete: "2016-03-30"
  UpdateRuns_CreateOrUpdate: "2016-03-30"
  UpdateRuns_Delete: "2016-03-30"
  FleetUpdateStrategies_CreateOrUpdate: "2016-03-30"
  FleetUpdateStrategies_Delete: "2016-03-30"

override-operation-name:
  AutoUpgradeProfileOperations_GenerateUpdateRun: GenerateUpdateRun

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
  ETag: ETag|eTag

models-to-treat-empty-string-as-null:
- SubnetResourceId
```
