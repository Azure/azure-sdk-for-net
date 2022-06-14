# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ConfidentialLedger
namespace: Azure.ResourceManager.ConfidentialLedger
require: https://github.com/Azure/azure-rest-api-specs/blob/c943ce5e08690d4b0c840245a6f6f3ed28e56886/specification/confidentialledger/resource-manager/readme.md
tag: package-2022-05-13
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
override-operation-name:
  CheckNameAvailability: CheckLedgerNameAvailability

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
  AAD: Aad

directive:
  - from: confidentialledger.json
    where: $.definitions
    transform: >
      $.ResourceLocation.properties.location['x-ms-format'] = 'azure-location';
      $.ProvisioningState['x-ms-enum']['name'] = 'LedgerProvisioningState';
      $.AADBasedSecurityPrincipal.properties.tenantId['format'] = 'uuid';
  - from: types.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityRequest['x-ms-client-name'] = 'LedgerNameAvailabilityRequest';
      $.CheckNameAvailabilityResponse['x-ms-client-name'] = 'LedgerNameAvailabilityResult';

```
