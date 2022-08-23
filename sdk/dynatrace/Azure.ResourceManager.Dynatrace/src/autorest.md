# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Dynatrace
namespace: Azure.ResourceManager.Dynatrace
require: https://github.com/Azure/azure-rest-api-specs/blob/c767823fdfd9d5e96bad245e3ea4d14d94a716bb/specification/dynatrace/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  URL: Uri
  PRE: Pre

directive:
  - from: dynatrace.json
    where: $.definitions
    transform: >
      $.LinkableEnvironmentResponse['x-ms-client-name'] = 'LinkableEnvironmentResult';
      $.SSODetailsResponse['x-ms-client-name'] = 'SsoDetailsResult';
      $.MonitoredResource['x-ms-client-name'] = 'MonitoredResourceDetails';
      $.MonitoredResource.properties.sendingMetrics['x-ms-client-name'] = 'sendingMetricsStatus';
      $.MonitoredResource.properties.sendingLogs['x-ms-client-name'] = 'sendingLogsStatus';
      $.DynatraceSingleSignOnProperties.properties.enterpriseAppId['format'] = 'uuid';
      $.LinkableEnvironmentRequest.properties.region['x-ms-format'] = 'azure-location';
```
