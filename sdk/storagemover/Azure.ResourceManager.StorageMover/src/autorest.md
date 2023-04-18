# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: StorageMover
namespace: Azure.ResourceManager.StorageMover
require: D:\Works\Codespace\Azure\tem\azure-rest-api-specs-pr\specification\storagemover\resource-manager\readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  Agent: StorageMoverAgent
  Endpoint: StorageMoverEndpoint
  Project: StorageMoverProject
  AgentPropertiesErrorDetails: StorageMoverAgentPropertiesErrorDetails
  AgentStatus: StorageMoverAgentStatus
  CopyMode: StorageMoverCopyMode
  ProvisioningState: StorageMoverProvisioningState
  JobDefinition.properties.agentResourceId: -|arm-id
  JobDefinition.properties.latestJobRunResourceId: -|arm-id
  JobDefinition.properties.targetResourceId: -|arm-id
  JobDefinition.properties.sourceResourceId: -|arm-id
  JobRun.properties.agentResourceId: -|arm-id
  JobRun.properties.sourceResourceId: -|arm-id
  JobRun.properties.targetResourceId: -|arm-id
  JobRunResourceId.jobRunResourceId: -|arm-id
  AzureStorageBlobContainerEndpointProperties.storageAccountResourceId: -|string

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

```