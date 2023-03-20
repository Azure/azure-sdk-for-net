# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: TrafficManager
namespace: Azure.ResourceManager.TrafficManager
require: https://github.com/Azure/azure-rest-api-specs/blob/5fc05d0f0b15cbf16de942cadce464b495c66a58/specification/trafficmanager/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true

rename-mapping:
  CheckTrafficManagerRelativeDnsNameAvailabilityParameters: TrafficManagerRelativeDnsNameAvailabilityParameters
  CheckTrafficManagerRelativeDnsNameAvailabilityParameters.type: -|resource-type
  Endpoint.properties.targetResourceId: -|arm-id
  EndpointPropertiesCustomHeadersItem: TrafficManagerEndpointCustomHeaderInfo
  EndpointPropertiesSubnetsItem: TrafficManagerEndpointSubnetInfo
  EndpointPropertiesSubnetsItem.first: -|ip-address
  EndpointPropertiesSubnetsItem.last: -|ip-address
  HeatMapEndpoint.resourceId: -|arm-id
  HeatMapModel: TrafficManagerHeatMap
  MonitorConfigCustomHeadersItem: TrafficManagerMonitorConfigCustomHeaderInfo
  MonitorConfigExpectedStatusCodeRangesItem: ExpectedStatusCodeRangeInfo
  QueryExperience: TrafficManagerHeatMapQueryExperience
  ProxyResource: TrafficManagerProxyResourceData
  Resource.id: -|arm-id
  Resource.type: -|resource-type
  TrafficFlow: TrafficManagerHeatMapTrafficFlow
  TrafficFlow.sourceIp: -|ip-address
  TrackedResource: TrafficManagerTrackedResourceData
  TrackedResource.location: -|azure-location
  TrafficManagerNameAvailability: TrafficManagerNameAvailabilityResult
  TrafficManagerNameAvailability.nameAvailable: IsNameAvailable
  TrafficManagerNameAvailability.reason: UnavailableReason
  TrafficManagerNameAvailability.type: -|resource-type
  UserMetricsModel: TrafficManagerUserMetrics
  AlwaysServe: TrafficManagerEndpointAlwaysServeStatus

prepend-rp-prefix:
  - DnsConfig
  - Endpoint
  - EndpointMonitorStatus
  - EndpointStatus
  - HeatMapType
  - HeatMapEndpoint
  - MonitorConfig
  - MonitorProtocol
  - Profile
  - ProfileListResult
  - ProfileMonitorStatus
  - ProfileStatus
  - Region

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
  TCP: Tcp

override-operation-name:
  Profiles_CheckTrafficManagerRelativeDnsNameAvailability: CheckTrafficManagerRelativeDnsNameAvailability

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
  - from: trafficmanager.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}"]..parameters[2]
    transform:
      delete $["enum"];
      delete $["x-ms-enum"];
      $["description"] = $["description"] + " Only AzureEndpoints, ExternalEndpoints and NestedEndpoints are allowed here."
    reason: The path parameter endpointType is defined as string in stable version, we can't change it to an enumeration.
     
#TODO: excluding since the following REST endpoints do not have GetAll method.
#TODO: e.g. The EndpointCollection (RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}) does not have a GetAll method
list-exception:
 - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName} 
 - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/heatMaps/{heatMapType}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.Network/trafficManagerUserMetricsKeys/default: TrafficManagerUserMetrics

```
