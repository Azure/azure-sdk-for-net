# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
title: communication
namespace: Azure.ResourceManager.Communication
require: https://github.com/Azure/azure-rest-api-specs/blob/7168ecde052e9797d31d74c40ad00ac68c74ec6a/specification/communication/resource-manager/readme.md
tag: package-2021-10-01-preview

skip-csproj: true
output-folder: Generated/
override-operation-name:
  CommunicationServices_CheckNameAvailability: CheckCommunicationNameAvailability

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
  Vmos: VmOS
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
  SPF: Spf

directive:
  - rename-model:
      from: DomainResource
      to: CommunicationDomainResource
  - rename-model:
      from: VerificationParameter
      to: VerificationContent
  - from: types.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityRequest["x-ms-client-name"] = "CheckNameAvailabilityRequestBody";
      $.CheckNameAvailabilityResponse["x-ms-client-name"] = "CommunicationServiceNameAvailabilityResult";
  - from: CommunicationServices.json
    where: $.definitions
    transform: >
      $.NameAvailabilityParameters["x-ms-client-name"] = "CommunicationServiceNameAvailabilityContent"; 
      $.TaggedResource["x-ms-client-name"] = "AcceptTags";          
```