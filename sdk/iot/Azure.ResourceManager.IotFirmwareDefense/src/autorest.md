# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IotFirmwareDefense
namespace: Azure.ResourceManager.IotFirmwareDefense
require: https://github.com/Azure/azure-rest-api-specs/blob/ef348fed285ae01b78cf6afd394ad2c4c8b6da7e/specification/fist/resource-manager/readme.md
#tag: package-2024-01-10
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
  Url: Uri
  Etag: ETag|etag

override-operation-name:
  BinaryHardening_ListByFirmware: GetBinaryHardeningResults

rename-mapping:
  GenerateUploadUrlRequest: FirmwareUploadUrlRequest
  Workspace: IotFirmwareWorkspace
  BinaryHardeningResource: BinaryHardeningResult
  BinaryHardeningSummaryResource: BinaryHardeningSummary
  CveResource: CveResult
  PasswordHashResource: FirmwarePasswordHashResult
  SbomComponentResource: SbomComponentResult
  SummaryName: FirmwareSummaryName
  SummaryName.CVE: Cve
  SummaryName.CryptoCertificate: FirmwareCryptoCertificate
  SummaryName.CryptoKey: FirmwareCryptoKey
  SummaryType: FirmwareSummaryType
  SummaryType.CVE: Cve
  SummaryType.CryptoCertificate: FirmwareCryptoCertificate
  SummaryType.CryptoKey: FirmwareCryptoKey
  CryptoCertificateEntity: FirmwareCryptoCertificateEntity
  CryptoCertificateListResult: FirmwareCryptoCertificateListResult
  CryptoCertificateResource: FirmwareCryptoCertificateResult
  CryptoCertificateSummaryResource: FirmwareCryptoCertificateSummary
  CryptoKeyListResult: FirmwareCryptoKeyListResult
  CryptoKeyResource: FirmwareCryptoKeyResult
  CryptoKeyResource.properties.cryptoKeyId: FirmwareCryptoKeyId
  CryptoKeySummaryResource: FirmwareCryptoKeySummary
  Firmware: IotFirmware
  ProvisioningState: IotFirmwareProvisioningState
  SummaryResource: IotFirmwareSummary
  SummaryResourceProperties: IotFirmwareSummaryProperties
  BinaryHardeningResource.properties.features.nx: NXFlag
  BinaryHardeningResource.properties.features.pie: PieFlag
  BinaryHardeningResource.properties.features.relro: RelroFlag
  BinaryHardeningResource.properties.features.canary: CanaryFlag
  BinaryHardeningResource.properties.features.stripped: StrippedFlag
  BinaryHardeningSummaryResource.nx: NXPercentage
  BinaryHardeningSummaryResource.pie: PiePercentage
  BinaryHardeningSummaryResource.relro: RelroPercentage
  BinaryHardeningSummaryResource.canary: CanaryPercentage
  BinaryHardeningSummaryResource.stripped: StrippedPercentage
  Status: FirmwareScanStatus
  StatusMessage: FirmwareAnalysisStatusMessage
  PairedKey: FirmwarePairedKey
  UrlToken: FirmwareUrlToken

```
