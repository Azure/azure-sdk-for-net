# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IntegrationSpaces
namespace: Azure.ResourceManager.IntegrationSpaces
require: https://github.com/Azure/azure-rest-api-specs/blob/58e92dd03733bc175e6a9540f4bc53703b57fcc9/specification/azureintegrationspaces/resource-manager/readme.md
#tag: package-2023-11-14-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  Application: IntegrationSpaceApplication
  ApplicationResource: IntegrationSpaceResource
  TrackingProfileDefinition: TrackingProfile
  TrackingEventDefinition: TrackingEvent
  FlowTrackingDefinition: WorkflowTracking
  ListBusinessProcessDevelopmentArtifactsResponse: BusinessProcessDevelopmentArtifactListResult
  SaveOrGetBusinessProcessDevelopmentArtifactResponse: BusinessProcessDevelopmentArtifactResult

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