# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: IotHub
namespace: Azure.ResourceManager.IotHub
require: https://github.com/Azure/azure-rest-api-specs/blob/0f9df940977c680c39938c8b8bd5baf893737ed0/specification/iothub/resource-manager/readme.md
tag: package-2021-07-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

 

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
  - from: iothub.json
    where: $.definitions
    transform: >
      $.TestAllRoutesResult['x-ms-client-name'] = 'IotHubTestAllRoutesResult';
      $.TestRouteInput['x-ms-client-name'] = 'IotHubTestRouteInput';
      $.TestRouteResult.properties.result['x-ms-enum']['name'] = 'IotHubTestResultStatus';
      $.TestRouteResult['x-ms-client-name'] = 'IotHubTestRouteResult';
      $.TestRouteResultDetails['x-ms-client-name'] = 'IotHubTestRouteResultDetails';

  - from: iothub.json
    where: $.definitions.EventHubConsumerGroupInfo.properties.etag
    transform: $["x-nullable"] = true

  - from: iothub.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}"].delete
    transform: $.description = "Foo"
  - from: iothub.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}"].delete
    transform: $.responses.202.schema = {}
  - from: iothub.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/IotHubs/{resourceName}"].delete
    transform: $.responses.200.schema = {}


```
