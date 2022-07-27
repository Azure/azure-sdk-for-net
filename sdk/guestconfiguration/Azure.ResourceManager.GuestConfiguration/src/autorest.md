# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: GuestConfiguration
namespace: Azure.ResourceManager.GuestConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/58a1320584b1d26bf7dab969a2593cd22b39caec/specification/guestconfiguration/resource-manager/readme.md
tag: package-2022-01-25
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}: GuestConfigurationAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}: GuestConfigurationAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}: GuestConfigurationAssignment
  
rename-mapping:
  'VmssvmInfo': 'VmssVmInfo'

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

directive:
  - from: guestconfiguration.json
    where: $.definitions
    transform: >
      $.GuestConfigurationNavigation.properties.configurationSetting['x-nullable'] = true;
      $.GuestConfigurationNavigation.properties.kind['x-nullable'] = true;
      $.GuestConfigurationAssignmentProperties.properties.vmssVMList['x-nullable'] = true;
```
