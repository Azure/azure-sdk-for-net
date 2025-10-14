# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: TrustedSigning
namespace: Azure.ResourceManager.TrustedSigning
require: https://github.com/Azure/azure-rest-api-specs/blob/47da73f25423b00212169444bda8d05964cf8d22/specification/codesigning/resource-manager/readme.md
#tag: package-2025-10-13
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  CheckNameAvailability: TrustedSigningAccountNameAvailabilityContent
  CheckNameAvailabilityResult: TrustedSigningAccountNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  NameUnavailabilityReason: TrustedSigningAccountNameUnavailabilityReason
  Certificate.createdDate: CreateOn | datetime
  Certificate.expiryDate: ExpireOn | datetime
  CodeSigningAccount: TrustedSigningAccount
  ProfileType: CertificateProfileType
  ProfileType.VBSEnclave: VbsEnclave
  RevocationStatus: CertificateRevocationStatus
  RevokeCertificate: RevokeCertificateContent

override-operation-name:
  CodeSigningAccounts_CheckNameAvailability: CheckTrustedSigningAccountNameAvailability

prepend-rp-prefix:
  - AccountSku
  - Certificate
  - CertificateProfile
  - CertificateStatus
  - ProvisioningState

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

directive:
  # Fix the missing `type` property for CheckTrustedSigningAccountNameAvailability
  - from: codeSigningAccount.json
    where: $.definitions
    transform: >
      $.CheckNameAvailability.properties['type'] = {
          'type': 'string',
          'description': 'The type of the resource, \"Microsoft.CodeSigning/codeSigningAccounts\".',
          'x-ms-format': 'resource-type'
        };
      $.CheckNameAvailability['required'] = [
          'type',
          'name'
        ];
```
