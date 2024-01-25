# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ContainerServiceFleet
namespace: Azure.ResourceManager.ContainerServiceFleet
require: https://github.com/Azure/azure-rest-api-specs/blob/9837baba3ca259b4f2a3f736593311f445c35c63/specification/containerservice/resource-manager/Microsoft.ContainerService/fleet/readme.md
#tag: package-2023-10
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
  Fleet: ContainerServiceFleet
  FleetListResult: ContainerServiceFleetListResult
  FleetMember: ContainerServiceFleetMember
  FleetMemberListResult: ContainerServiceFleetMemberListResult
  MemberUpdateStatus.clusterResourceId: -|arm-id

prepend-rp-prefix:
  - AgentProfile
  - APIServerAccessProfile
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

models-to-treat-empty-string-as-null:
- SubnetResourceId
```
