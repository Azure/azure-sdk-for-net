# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Qumulo
namespace: Azure.ResourceManager.Qumulo
require: https://github.com/Azure/azure-rest-api-specs/blob/b73e2d320f1ae530ea5e78625dfe14a921dcf011/specification/liftrqumulo/resource-manager/readme.md
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

directive:
  - from: Qumulo.Storage.json
    where: $.definitions
    transform: delete $.UserDetails.required

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

prepend-rp-prefix:
  - ProvisionState
  - OperationStatus
  - ProvisioningState
  - UserDetails
  - FileSystemResource
  - FileSystemResourceListResult
  - FileSystemsRestOperations

rename-mapping:
    Agent: QumuloAgent
    Endpoint: QumuloEndpoint
    JobDefinitionData: QumuloJobDefinitionData
    JobRun: QumuloJobRun
    Project: QumuloProject
    StorageMover: QumuloStorageMover
    AzureStorageBlobContainerEndpointProperties: StorageBlobContainerEndpointProperties
    AgentData.ArcResourceId: -|arm-id
    AgentData.ArcVmUuid: -|uuid
    JobDefinitionData.AgentResourceId: -|arm-id
    JobDefinitionData.LatestJobRunResourceId: -|arm-id
    JobDefinitionData.SourceResourceId: -|arm-id
    JobDefinitionData.TargetResourceId: -|arm-id
    JobRunData.AgentResourceId: -|arm-id
    JobRunData.SourceResourceId: -|arm-id
    QumuloAgentData.LocalIPAddress: -|ip-address
    AzureStorageBlobContainerQumuloEndpointProperties.StorageAccountResourceId: -|arm-id
    FileSystemResourceUpdateProperties.delegatedSubnetId: -|arm-id
    FileSystemResource.properties.privateIPs: -|ip-address

```
