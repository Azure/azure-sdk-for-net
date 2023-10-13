# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: CodeSigning
namespace: Azure.ResourceManager.CodeSigning
require: https://github.com/ashutak84/azure-rest-api-specs/blob/640c21a0319de4474c6c63ee9a447eb90ddad31d/specification/codesigning/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

rename-mapping:
  Certificate.createdDate: CreatedOn|date-time
  Certificate.expiryDate: ExpireOn|date-time
  CertificateProfile.properties.includeStreetAddress: DoesIncludeStreetAddress
  CertificateProfile.properties.includeState: DoesIncludeState
  CertificateProfile.properties.includeCity: DoesIncludeCity
  CertificateProfile.properties.includePostalCode: DoesIncludePostalCode
  CertificateProfile.properties.includeCountry: DoesIncludeCountry
  CertificateProfiles: CodeSigningCertificateProfileListResult
  CheckNameAvailability: CodeSigningNameAvailabilityContent
  CheckNameAvailabilityResult: CodeSigningNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  CodeSigningAccounts: CodeSigningAccountListResult
  ProfileType: CertificateProfileType
  ProfileType.VBSEnclave: VbsEnclave
  Reason: CodeSigningNameUnavailableReason
  Revocation: CertificateRevocation
  Revocation.requestedAt: RequestedOn|date-time
  Revocation.revokedAt: RevokedOn|date-time
  RotationPolicy: CertificateRotationPolicy

override-operation-name:
  CodeSigningAccount_CheckNameAvailability: CheckCodeSigningNameAvailability

prepend-rp-prefix:
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

```