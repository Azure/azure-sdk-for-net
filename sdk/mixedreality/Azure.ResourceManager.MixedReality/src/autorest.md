# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: MixedReality
namespace: Azure.ResourceManager.MixedReality
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/mixedreality/resource-manager/readme.md
tag: package-2021-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  AccountKeyRegenerateRequest: MixedRealityAccountKeyRegenerateContent
  AccountKeys: MixedRealityAccountKeys
  CheckNameAvailabilityRequest: MixedRealityNameAvailabilityContent
  CheckNameAvailabilityResponse: MixedRealityNameAvailabilityResult
  NameUnavailableReason: MixedRealityNameUnavailableReason
  RemoteRenderingAccountPage: RemoteRenderingAccountListResult
  SpatialAnchorsAccountPage: SpatialAnchorsAccountListResult
  Serial: MixedRealityAccountKeySerial
  SpatialAnchorsAccount.properties.accountId: -|uuid
  RemoteRenderingAccount.properties.accountId: -|uuid
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable

override-operation-name:
  CheckNameAvailabilityLocal: CheckMixedRealityNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
