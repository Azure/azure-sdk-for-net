# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Azure.ResourceManager.ManagedNetworkFabric
namespace: Azure.ResourceManager.ManagedNetworkFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/4f4073bdb028bc84bc3e6405c1cbaf8e89b83caf/specification/managednetworkfabric/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

rename-mapping:
  Components1Qbx3T1SchemasRoutepolicypropertiesPropertiesConditionsItemsPropertiesActionPropertiesSet: RoutePolicySetManipulations
  Components1Qbx3T1SchemasRoutepolicypropertiesPropertiesConditionsItemsPropertiesActionPropertiesSet.set: Sets
  RoutePolicyPropertiesConditionsItemAction: RoutePolicyConditionsItemAction

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
  - remove-operation: NetworkDevices_getStaticInterfaceMaps
  - remove-operation: NetworkDevices_getDynamicInterfaceMaps
  - from: NetworkFabrics.json
    where: $.definitions
    transform: >
      $.Layer3IpPrefixProperties['x-ms-client-name'] = 'NetworkFabricLayer3IpPrefixProperties';
      $.OptionAProperties['x-ms-client-name'] = 'NetworkFabricOptionAProperties';
      $.OptionBProperties['x-ms-client-name'] = 'NetworkFabricOptionBProperties';

```