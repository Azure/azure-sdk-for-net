# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AppPlatform
namespace: Azure.ResourceManager.AppPlatform
require: https://github.com/Azure/azure-rest-api-specs/blob/688cfd36391115f70ea9276a8e526caea6a5c8ad/specification/appplatform/resource-manager/readme.md
output-folder: $(this-folder)/Generated
tag: package-preview-2022-03
clear-output-folder: true
skip-csproj: true
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
  - from: swagger-document
    where: $.definitions..location
    transform: >
      $['x-ms-format'] = 'azure-location';
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'location')]
    transform: >
      $['x-ms-format'] = 'azure-location';
  - from: swagger-document
    where: $.definitions
    transform: >
      $.CustomPersistentDiskProperties.properties.type['x-ms-enum']['name'] = 'UnderlyingResourceType';
      $.DiagnosticParameters.properties.duration['x-ms-client-name'] = 'DurationValue';
      $.LoadedCertificate.properties.resourceId['x-ms-format'] = 'arm-id';
      $.BindingResourceProperties.properties.resourceId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.serviceRuntimeSubnetId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.appSubnetId['x-ms-format'] = 'arm-id';
```