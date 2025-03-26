# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IotFirmwareDefense
namespace: Azure.ResourceManager.IotFirmwareDefense
require: https://github.com/Azure/azure-rest-api-specs/blob/9b3e29902644a7bb9317d68f249c7cb8b11d82cf/specification/fist/resource-manager/readme.md
#require: file:///C:/Users/mikekennedy/git/github/Azure/azure-rest-api-specs-pr/specification/fist/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

mgmt-debug: 
  show-serialized-names: true

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
  Workspace: FirmwareAnalysisWorkspace
  # BinaryHardeningResult: BinaryHardeningResultProperties
  # BinaryHardeningResource: BinaryHardeningResult
  BinaryHardeningSummaryResource: BinaryHardeningSummary
  # CveResult: CveResultProperties
  # CveResource: CveResult
  # PasswordHashResource: PasswordHashResult
  # SbomComponentResource: SbomComponentResult
  SummaryType: FirmwareAnalysisSummaryType
  SummaryType.CVE: Cve
  # CryptoCertificateResource: CryptoCertificateResult
  CryptoCertificateSummaryResource: CryptoCertificateSummary
  # CryptoKeyResource: CryptoKeyResult
  CryptoKeyResource.properties.cryptoKeyId: CryptoKeyId
  CryptoKeySummaryResource: CryptoKeySummary
  Firmware: IotFirmware
  ProvisioningState: FirmwareProvisioningState
  SummaryResource: FirmwareAnalysisSummary
  SummaryResourceProperties: FirmwareAnalysisSummaryProperties
  # BinaryHardeningResource.properties.features.nx: NXFlag
  # BinaryHardeningResource.properties.features.pie: PieFlag
  # BinaryHardeningResource.properties.features.relro: RelroFlag
  # BinaryHardeningResource.properties.features.canary: CanaryFlag
  # BinaryHardeningResource.properties.features.stripped: StrippedFlag
  # BinaryHardeningSummaryResource.nx: NXPercentage
  # BinaryHardeningSummaryResource.pie: PiePercentage
  # BinaryHardeningSummaryResource.relro: RelroPercentage
  # BinaryHardeningSummaryResource.canary: CanaryPercentage
  # BinaryHardeningSummaryResource.stripped: StrippedPercentage
  Status: FirmwareAnalysisStatus
  StatusMessage: FirmwareAnalysisStatusMessage
  PairedKey: CryptoPairedKey
  UrlToken: FirmwareUrlToken

```
