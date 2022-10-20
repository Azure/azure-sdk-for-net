# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DevTestLabs
namespace: Azure.ResourceManager.DevTestLabs
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/devtestlabs/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug:
  show-serialized-names: true

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/costs/{name}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/servicerunners/{name}

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

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}: DevTestLabSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules/{name}: DevTestLabGlobalSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/servicefabrics/{serviceFabricName}/schedules/{name}: DevTestLabServiceFabricSchedule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualmachines/{virtualMachineName}/schedules/{name}: DevTestLabVmSchedule

rename-mapping:
  ArmTemplate: DevTestLabArmTemplate
  Artifact: DevTestLabArtifact
  ArtifactSource: DevTestLabArtifactSource
  CustomImage: DevTestLabCustomImage
  Disk: DevTestLabDisk
  DtlEnvironment: DevTestLabEnvironment
  Formula: DevTestLabFormula
  Lab: DevTestLab
  LabCost: DevTestLabCost
  Schedule: DevTestLabSchedule
  LabVirtualMachine: DevTestLabVm
  LabVirtualMachine.properties.computeId: -|arm-id
  LabVirtualMachine.properties.labVirtualNetworkId: -|arm-id
  LabVirtualMachine.properties.environmentId: -|arm-id
  NotificationChannel: DevTestLabNotificationChannel
  Policy: DevTestLabPolicy
  Secret: DevTestLabSecret
  ServiceFabric: DevTestLabServiceFabric
  ServiceRunner: DevTestLabServiceRunner
  User: DevTestLabUser
  VirtualNetwork: DevTestLabVirtualNetwork
```
