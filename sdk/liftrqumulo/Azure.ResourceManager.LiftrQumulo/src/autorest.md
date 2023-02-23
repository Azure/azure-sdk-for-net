# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: LiftrQumulo
namespace: Azure.ResourceManager.LiftrQumulo
require: https://github.com/Azure/azure-rest-api-specs/blob/e99a45d498a1c7fadc18229ecba5d84a471a8771/specification/storagemover/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
    flatten-payloads: false

format-by-name-rules:
    "tenantId": "uuid"
    "ETag": "etag"
    "location": "azure-location"
    "*Uri": "Uri"
    "*Uris": "Uri"

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
    Agent: QumuloAgent
    Endpoint: QumuloEndpoint
    JobDefinitionData: QumuloJobDefinitionData
    JobRun: QumuloJobRun
    Project: QumuloProject
    StorageMover: QumuloStorageMover

rename-mapping:
    AgentData.ArcResourceId: -|uuid
    AgentData.ArcVmUuid: -|uuid
    JobDefinitionData.AgentResourceId: -|uuid
    JobDefinitionData.LatestJobRunResourceId: -|uuid
    JobDefinitionData.SourceResourceId: -|uuid
    JobDefinitionData.TargetResourceId: -|uuid
    JobRunData.AgentResourceId: -|uuid
    JobRunData.SourceResourceId: -|uuid
```
