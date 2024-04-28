# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: PlaywrightTesting
namespace: Azure.ResourceManager.PlaywrightTesting
require: https://github.com/Azure/azure-rest-api-specs/blob/92c409d93f895a30d51603b2fda78a49b3a2cd60/specification/playwrighttesting/resource-manager/readme.md
#tag: package-2024-02-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  Quota: PlaywrightTestingQuotas
  AccountQuota: PlaywrightTestingAccountQuotas
  CheckNameAvailabilityResponse: PlaywrightTestingNameAvailabilityResult
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityRequest: PlaywrightTestingNameAvailabilityContent
  CheckNameAvailabilityReason: PlaywrightTestingNameUnavailableReason
  AccountFreeTrialProperties.expiryAt: ExpireOn
  CheckNameAvailabilityRequest.type: -|resource-type

prepend-rp-prefix:
  - QuotaNames
  - Account
  - AccountProperties 
  - ProvisioningState
  - AccountQuotaProperties 
  - AccountFreeTrialProperties
  - AccountUpdateProperties
  - QuotaProperties
  - FreeTrialProperties
  - FreeTrialState
  - EnablementStatus

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

override-operation-name:
  Accounts_CheckNameAvailability: CheckPlaywrightTestingNameAvailability

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
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
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

```