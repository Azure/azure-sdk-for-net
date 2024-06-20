# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ConfidentialLedger
namespace: Azure.ResourceManager.ConfidentialLedger
require: https://github.com/Azure/azure-rest-api-specs/blob/de1bc645b4c91e6cb3fddb5588c102ca050dd4da/specification/confidentialledger/resource-manager/readme.md
#tag: package-preview-2023-06
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

override-operation-name:
  CheckNameAvailability: CheckConfidentialLedgerNameAvailability

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'principalId': 'uuid'

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
  AAD: Aad
  CCF: Ccf

prepend-rp-prefix:
  - DeploymentType
  - LanguageRuntime
  - RunningState
  - MemberIdentityCertificate

rename-mapping:
  CheckNameAvailabilityRequest: ConfidentialLedgerNameAvailabilityContent
  CheckNameAvailabilityRequest.type: -|resource-type
  CheckNameAvailabilityResponse: ConfidentialLedgerNameAvailabilityResult
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityReason: ConfidentialLedgerNameUnavailableReason
  LedgerProperties: ConfidentialLedgerProperties
  LedgerRoleName: ConfidentialLedgerRoleName
  LedgerType: ConfidentialLedgerType
  ProvisioningState: ConfidentialLedgerProvisioningState
  ConfidentialLedgerBackup: ConfidentialLedgerBackupContent
  ConfidentialLedgerBackupResponse: ConfidentialLedgerBackupResult
  ConfidentialLedgerRestore: ConfidentialLedgerRestoreContent
  ConfidentialLedgerRestoreResponse: ConfidentialLedgerRestoreResult
  ManagedCCFBackup: ManagedCcfBackupContent
  ManagedCCFBackupResponse: ManagedCcfBackupResult
  ManagedCCFRestore: ManagedCcfRestoreContent
  ManagedCCFRestoreResponse: ManagedCcfRestoreResult
  LedgerSku: ConfidentialLedgerSku

```
