# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: TrafficManager
namespace: Azure.ResourceManager.TrafficManager
require: https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/trafficmanager/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
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
  - from: trafficmanager.json
    where: $.definitions
    transform: >
      $.ProfileProperties.properties.maxReturn['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpoints['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpointsIPv4['x-nullable'] = true;
      $.EndpointProperties.properties.minChildEndpointsIPv6['x-nullable'] = true;
  - from: trafficmanager.json
    where: $.paths..parameters[?(@.name === "heatMapType")]
    transform: >
      $['x-ms-enum'] = {
        "name": "HeatMapType",
        "modelAsString": true
      }
  - from: trafficmanager.json
    where: $.paths..delete.responses["200"]
    transform: >
      delete $["schema"]
     
#TODO: excluding since the following REST endpoints do not have GetAll method.
#TODO: e.g. The EndpointCollection (RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}) does not have a GetAll method
list-exception:
 - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName} 
 - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/heatMaps/{heatMapType}

```
