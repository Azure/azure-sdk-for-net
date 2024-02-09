# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: StorageMover
namespace: Azure.ResourceManager.StorageMover
require: https://github.com/Azure/azure-rest-api-specs/blob/9c7b8d71061df7e308f1776d558fc56f4a6247a2/specification/storagemover/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  Agent: StorageMoverAgent
  Endpoint: StorageMoverEndpoint
  Project: StorageMoverProject
  AgentPropertiesErrorDetails: StorageMoverAgentPropertiesErrorDetails
  AgentStatus: StorageMoverAgentStatus
  CopyMode: StorageMoverCopyMode
  ProvisioningState: StorageMoverProvisioningState
  Credentials : StorageMoverCredentials
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
  PasswordUri: PasswordUriString
  UsernameUri: UsernameUriString
```
