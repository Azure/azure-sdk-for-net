# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EdgeOrder
namespace: Azure.ResourceManager.EdgeOrder
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/edgeorder/resource-manager/readme.md
tag: package-2021-12
output-folder: Generated/
clear-output-folder: true
list-exception:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/locations/{location}/orders/{orderName}

modelerfour:
  flatten-payloads: false
rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
directive:
  - remove-operation: ListOperations
  - rename-model:
      from: Configuration
      to: ProductConfiguration
  - rename-model:
      from: Configurations
      to: ProductConfigurations
  - rename-model:
      from: Description
      to: ProductDescription
  - rename-model:
      from: Dimensions
      to: ProductDimensions
  - rename-model:
      from: Link
      to: ProductLink
  - rename-model:
      from: Preferences
      to: OrderItemPreferences
  - rename-model:
      from: Product
      to: EdgeOrderProduct
  - rename-model:
      from: Specification
      to: ProductSpecification

```
