# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkAnalytics
namespace: Azure.ResourceManager.NetworkAnalytics
require: https://github.com/Azure/azure-rest-api-specs/blob/c67016198d67ef0d833f12fe867b1adbad513315/specification/networkanalytics/resource-manager/readme.md
#tag: package-2023-11-15
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  AccountSas: AccountSasContent
  ControlState: DataProductControlState
  DataType: DataProductDataType
  DataTypeState: DataProductDataTypeState
  DefaultAction: NetworkAclDefaultAction
  ListRoleAssignments: RoleAssignmentListResult

prepend-rp-prefix:
  - IPRules
  - KeyVaultInfo
  - ManagedResourceGroupConfiguration
  - ProvisioningState
  - VirtualNetworkRule

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

directive:
  - remove-operation: 'DataTypes_Get'
  - remove-operation: 'DataTypes_Create'
  - remove-operation: 'DataTypes_Update'
  - remove-operation: 'DataTypes_Delete'
  - remove-operation: 'DataTypes_DeleteData'
  - remove-operation: 'DataTypes_GenerateStorageContainerSasToken'
```
