# Generated code configuration

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
title: communication
namespace: Azure.ResourceManager.Communication
require: https://github.com/Azure/azure-rest-api-specs/blob/4716fb039c67e1bee1d5448af9ce57e4942832fe/specification/communication/resource-manager/readme.md
tag: package-preview-2021-10

skip-csproj: true
output-folder: Generated/
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
  - remove-operation: CommunicationServices_Update
  - remove-operation: Domains_Update
  - remove-operation: EmailServices_Update
#   - rename-model:
#       from: CommunicationServiceResource
#       to: CommunicationService
#   - rename-model:
#       from: RegenerateKeyParameters
#       to: RegenerateKeyOptions
#   - rename-model:
#       from: NameAvailabilityParameters
#       to: NameAvailabilityOptions
#   - rename-model:
#       from: LinkNotificationHubParameters
#       to: LinkNotificationHubOptions

```

### Tag: package-preview-2021-10

These settings apply only when `--tag=package-preview-2021-10` is specified on the command line.

```yaml $(tag) == 'package-preview-2021-10'
input-file:  
  - ../REST/CommunicationServices.json
  - ../REST/Domains.json
  - ../REST/EmailServices.json
```