# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ConfidentialLedger
namespace: Azure.ResourceManager.ConfidentialLedger
require: https://github.com/Azure/azure-rest-api-specs/blob/61001b68a8aa743f0dd890224c6b5cb130ef006e/specification/confidentialledger/resource-manager/readme.md
tag: package-2022-05-13
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

override-operation-name:
  CheckNameAvailability: CheckLedgerNameAvailability

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
      $.ProvisioningState['x-ms-enum']['name'] = 'LedgerProvisioningState';
  - from: types.json
    where: $.definitions
    transform: >
      $.CheckNameAvailabilityRequest['x-ms-client-name'] = 'LedgerNameAvailabilityRequest';
      $.CheckNameAvailabilityResponse['x-ms-client-name'] = 'LedgerNameAvailabilityResult';

```