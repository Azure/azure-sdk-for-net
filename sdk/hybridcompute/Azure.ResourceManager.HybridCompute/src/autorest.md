# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridCompute
namespace: Azure.ResourceManager.HybridCompute
require: https://github.com/Azure/azure-rest-api-specs/blob/a29126ca8200a6c981a4e908e41fe55730df4cad/specification/hybridcompute/resource-manager/readme.md
tag: package-2022-12
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  # Mitigate the duplication schema named 'ErrorDetail'
  lenient-model-deduplication: true

prepend-rp-prefix:
  - Location
  - Machine
  - MachineExtension
  - ResourceUpdate

rename-mapping:
  StatusLevelTypes: HybridComputeStatusLevelType
  StatusTypes: HybridComputeStatusType
  ServiceStatus: HybridComputeServiceStatus
  ServiceStatuses: HybridComputeServiceStatuses

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

models-to-treat-empty-string-as-null:
  - AgentConfiguration

directive:  
  - from: HybridCompute.json
    where: $.definitions.MachineInstallPatchesParameters.properties.maximumDuration
    transform: $['format'] = 'duration'

  - from: HybridCompute.json
    where: $.definitions.MachineUpdateProperties.properties.privateLinkScopeResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.privateLinkScopeResourceId
    transform: $['format'] = 'arm-id'
  
  - from: HybridCompute.json
    where: $.definitions.AgentUpgrade.properties.correlationId
    transform: $['format'] = 'uuid'
  
  - from: HybridCompute.json
    where: $.definitions.AgentUpgrade.properties.lastAttemptTimestamp
    transform: $['format'] = 'date-time'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.vmUuid
    transform: $['format'] = 'uuid'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.vmId
    transform: $['format'] = 'uuid'

  - from: HybridCompute.json
    where: $.definitions.MachineUpdateProperties.properties.parentClusterResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.parentClusterResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineAssessPatchesResult.properties.assessmentActivityId
    transform: $['format'] = 'uuid'
  
```
