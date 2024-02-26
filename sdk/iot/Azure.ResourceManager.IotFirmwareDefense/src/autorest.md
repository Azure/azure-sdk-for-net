# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IotFirmwareDefense
namespace: Azure.ResourceManager.IotFirmwareDefense
require: https://github.com/Azure/azure-rest-api-specs/blob/7500ca3c02f84eb7524da5affe25b12924fd764e/specification/fist/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
# mgmt-debug:
#   show-serialized-names: true

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
  FirmwareId: FirmwareName
  UrlToken: UriToken
  CryptoKey: FirmwareCryptoKey
  CryptoCertificate: FirmwareCryptoCertificate
  GetGenerate: Get
  GenerateBinaryHardeningList: BinaryHardeningResults
  GenerateComponentList: SbomComponents
  GenerateCryptoCertificateList: CryptoCertificates
  GenerateCryptoKeyList: CryptoKeys
  GenerateCveList: Cves
  GeneratePasswordHashList: PasswordHashes
  GenerateBinaryHardeningDetails: GetBinaryHardeningDetails
  GenerateBinaryHardeningSummary: GetBinaryHardeningSummary
  GenerateComponentDetails: GetComponentDetails
  GenerateCveSummary: GetCveSummary
  GenerateCryptoCertificateSummary: GetCryptoCertificateSummary
  GenerateCryptoKeySummary: GetCryptoKeySummary
  GenerateSummary: GetFirmwareSummary

rename-mapping:
  GenerateUploadUrlRequest: UploadUrlRequest
  Models.Status: AnalysisStatus
  Component: SbomComponent
  Workspace: FirmwareWorkspace
  Cve: FirmwareCve
  BinaryHardeningResource: BinaryHardeningResourceData
  BinaryHardeningResource.properties.binaryHardeningId: -|uuid
  BinaryHardeningResource.properties.features.canary: IsCanary
  BinaryHardeningResource.properties.features.nx: IsNx
  BinaryHardeningResource.properties.features.pie: IsPie
  BinaryHardeningResource.properties.features.relro: IsRelro
  BinaryHardeningResource.properties.features.stripped: IsStripped
  BinaryHardeningSummaryResource: BinaryHardeningSummaryResourceInfo
  CveResource: CveResourceData
  CveResource.properties.cveId: -|uuid
  FirmwareCryptoCertificateResource: FirmwareCryptoCertificateResourceData
  FirmwareCryptoCertificateResource.properties.cryptoCertId: -|uuid
  FirmwareCryptoCertificateSummaryResource: FirmwareCryptoCertificateSummaryResourceInfo
  FirmwareCryptoKeyResource: FirmwareCryptoKeyResourceData
  FirmwareCryptoKeyResource.properties.cryptoKeyId: -|uuid
  FirmwareCryptoKeySummaryResource: FirmwareCryptoKeySummaryResourceInfo
  PairedKey.id: -|uuid
  PasswordHashResource: PasswordHashResourceData
  SbomComponentResource: SbomComponentResourceData

```
