# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/c94569d116a82ee11a94c5dfb190650dd675a1bf/specification/networkcloud/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# `delete` transformations are to remove APIs/methods that result in Access Denied for end users.
directive:
  - from: swagger-document
    where: "$.definitions.ClusterAvailableUpgradeVersion.properties.expectedDuration"
    transform:
      $["x-ms-format"] = "duration"
  - from: swagger-document
    where: "$.definitions.ConsolePatchProperties.properties.duration"
    transform:
      $["x-ms-format"] = "duration"
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}]"
    transform: delete $.put
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}]"
    transform: delete $.delete
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/hybridAksClusters/{hybridAksClusterName}]"
    transform: delete $.put
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/hybridAksClusters/{hybridAksClusterName}]"
    transform: delete $.delete
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/racks/{rackName}]"
    transform: delete $.put
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/racks/{rackName}]"
    transform: delete $.delete
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}]"
    transform: delete $.put
  - from: swagger-document
    where: "$.paths[/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}]"
    transform: delete $.delete
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
