# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: DefenderEasm
namespace: Azure.ResourceManager.DefenderEasm
require: https://github.com/Azure/azure-rest-api-specs/blob/23d88533ddfde4d1565a897fe95d42fb0d9333e5/specification/riskiq/resource-manager/readme.md
#tag: package-preview-2023-04
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
    LabelResource: EasmLabel
    LabelResourceList: EasmLabelListResult
    ResourceState: EasmResourceProvisioningState
    TaskResource: EasmTask
    WorkspaceResource: EasmWorkspace
    WorkspaceResourceList: EasmWorkspaceListResult

override-operation-name:
    Tasks_GetByWorkspace: GetTaskByWorkspace

format-by-name-rules:
    "tenantId": "uuid"
    "ETag": "etag"
    "location": "azure-location"
    "*Uri": "Uri"
    "*Uris": "Uri"

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

request-path-is-non-resource:
    - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Easm/workspaces/{workspaceName}/tasks/{taskId}
```
