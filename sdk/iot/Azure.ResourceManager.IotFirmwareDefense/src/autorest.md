# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IotFirmwareDefense
namespace: Azure.ResourceManager.IotFirmwareDefense
require: https://github.com/Azure/azure-rest-api-specs/blob/cf5ad1932d00c7d15497705ad6b71171d3d68b1e/specification/fist/resource-manager/readme.md
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
  Workspace: FirmwareAnalysisWorkspace
  BinaryHardeningResource: BinaryHardeningResult
  BinaryHardeningSummaryResource: BinaryHardeningSummary
  CveResource: CveResult
  PasswordHashResource: PasswordHashResult
  SbomComponentResource: SbomComponentResult
  SummaryName: FirmwareAnalysisSummaryName
  SummaryName.CVE: Cve
  SummaryType: FirmwareAnalysisSummaryType
  SummaryType.CVE: Cve
  CryptoCertificateResource: CryptoCertificateResult
  CryptoCertificateSummaryResource: CryptoCertificateSummary
  CryptoKeyResource: CryptoKeyResult
  CryptoKeyResource.properties.cryptoKeyId: CryptoKeyId
  CryptoKeySummaryResource: CryptoKeySummary
  Firmware: IotFirmware
  ProvisioningState: FirmwareProvisioningState
  SummaryResource: FirmwareAnalysisSummary
  SummaryResourceProperties: FirmwareAnalysisSummaryProperties
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
  Status: FirmwareAnalysisStatus
  StatusMessage: FirmwareAnalysisStatusMessage
  PairedKey: CryptoPairedKey
  UrlToken: FirmwareUrlToken

```
