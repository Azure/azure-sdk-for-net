# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Newrelic
namespace: Azure.ResourceManager.NewRelicObservability
require: https://github.com/Azure/azure-rest-api-specs/blob/fd0b301360d7f83dee9dec5afe3fff77b90b79f6/specification/newrelic/resource-manager/readme.md
tag: package-2022-07-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
generate-model-factory: false
modelerfour:
  flatten-payloads: false

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

rename-mapping:
    Agent: NewrelicAgent
    Endpoint: NewrelicEndpoint
    JobDefinitionData: NewrelicJobDefinitionData
    JobRun: NewrelicJobRun
    ProvisioningState: NewrelicProvisioningState
    Project: NewrelicProject
    StorageMover: NewrelicStorageMover
    AzureStorageBlobContainerEndpointProperties: StorageBlobContainerEndpointProperties
    AgentData.ArcResourceId: -|arm-id
    AgentData.ArcVmUuid: -|uuid
    JobDefinitionData.AgentResourceId: -|arm-id
    JobDefinitionData.LatestJobRunResourceId: -|arm-id
    JobDefinitionData.SourceResourceId: -|arm-id
    JobDefinitionData.TargetResourceId: -|arm-id
    JobRunData.AgentResourceId: -|arm-id
    JobRunData.SourceResourceId: -|arm-id
    NewrelicAgentData.LocalIPAddress: -|ip-address
    AzureStorageBlobContainerNewrelicEndpointProperties.StorageAccountResourceId: -|arm-id

```