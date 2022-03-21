# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
title: communication
namespace: Azure.ResourceManager.Communication
input-file:  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/54a98083200e56d88fe1182f2741a61aea91c788/specification/communication/resource-manager/Microsoft.Communication/stable/2020-08-20/CommunicationService.json
skip-csproj: true
modelerfour:
  flatten-payloads: false
override-operation-name:
  CommunicationService_CheckNameAvailability: CheckCommunicationNameAvailability

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

directive:
  - rename-model:
      from: CommunicationServiceResource
      to: CommunicationService
  - rename-model:
      from: RegenerateKeyParameters
      to: RegenerateKeyOptions
  - rename-model:
      from: NameAvailabilityParameters
      to: NameAvailabilityOptions
  - rename-model:
      from: LinkNotificationHubParameters
      to: LinkNotificationHubOptions

```
