# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
namespace: Azure.ResourceManager.ConnectedVMwarevSphere
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/connectedvmware/resource-manager/readme.md
clear-output-folder: true
output-folder: Generated/
skip-csproj: true
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
  - rename-model:
      from: Identity
      to: VMwareIdentity
  - rename-model:
      from: Datastore
      to: VMwareDatastore
  - rename-model:
      from: Cluster
      to: VMwareCluster
  - rename-model:
      from: Host
      to: VMwareHost
  - from: connectedvmware.json
    where: $.definitions.MachineExtensionUpdateProperties.properties.type
    transform: $["x-ms-client-name"] = "MachineExtensionType"
  - from: connectedvmware.json
    where: $.definitions.MachineExtensionProperties.properties.type
    transform: $["x-ms-client-name"] = "MachineExtensionType"
```
