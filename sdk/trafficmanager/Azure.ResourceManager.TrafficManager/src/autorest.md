# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: TrafficManager
namespace: Azure.ResourceManager.TrafficManager
require: https://github.com/Azure/azure-rest-api-specs/blob/75042a240749256fb2728fb5c555ca5e603ce190/specification/trafficmanager/resource-manager/readme.md
# tag: package-2022-04  nochanged
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
use-model-reader-writer: true

rename-mapping:
  CheckTrafficManagerRelativeDnsNameAvailabilityParameters: TrafficManagerRelativeDnsNameAvailabilityContent
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

acronym-mapping:
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
  Profiles_CheckTrafficManagerNameAvailabilityV2: CheckTrafficManagerNameAvailabilityV2

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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficmanagerprofiles/{profileName}/{endpointType}/{endpointName}"]..parameters[4]
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
