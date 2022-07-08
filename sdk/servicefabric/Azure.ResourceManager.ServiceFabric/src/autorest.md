# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ServiceFabric
namespace: Azure.ResourceManager.ServiceFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/servicefabric/resource-manager/readme.md
tag: package-2021-06
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
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

rename-mapping:
  UpgradeMode: ClusterUpgradeMode

directive:
  - from: application.json
    where: $.definitions
    transform: >
      $.HealthCheckStableDuration["x-ms-format"] = 'duration-constant';
      $.HealthCheckWaitDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceProperties.properties.replicaRestartWaitDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceProperties.properties.quorumLossWaitDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceProperties.properties.standByReplicaKeepDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.replicaRestartWaitDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.quorumLossWaitDuration["x-ms-format"] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.standByReplicaKeepDuration["x-ms-format"] = 'duration-constant';
      $.StatelessServiceProperties.properties.instanceCloseDelayDuration["x-ms-format"] = 'duration-constant';
      $.StatelessServiceUpdateProperties.properties.instanceCloseDelayDuration["x-ms-format"] = 'duration-constant';
  - from: cluster.json
    where: $.definitions
    transform: >
      $.ClusterUpgradePolicy.properties.healthCheckWaitDuration["x-ms-format"] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.healthCheckStableDuration["x-ms-format"] = 'duration-constant';
```
