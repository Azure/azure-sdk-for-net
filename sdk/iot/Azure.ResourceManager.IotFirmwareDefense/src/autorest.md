# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: IotFirmwareDefense
namespace: Azure.ResourceManager.IotFirmwareDefense
require: https://github.com/Azure/azure-rest-api-specs/blob/0490f6e57b3d0c8bd60d8bf237ddb6308e89ebd3/specification/fist/resource-manager/readme.md
tag: package-2025-08-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  flatten-models: true
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
  SummaryType: FirmwareAnalysisSummaryType
  CryptoCertificateResource: CryptoCertificateResult
  CryptoCertificateSummaryResource: CryptoCertificateSummary
  CryptoKeyResource.properties.keyType: CryptoKeyType
  CryptoKeyResource.properties.usage: CryptoKeyUsage
  CryptoKeyResource.properties.cryptoKeyId: CryptoKeyId
  CryptoKeyResource: CryptoKeyResult
  CryptoKeySummaryResource: CryptoKeySummary
  Firmware: IotFirmware
  ProvisioningState: FirmwareProvisioningState
  SummaryResource: FirmwareAnalysisSummary
  SummaryResourceProperties: FirmwareAnalysisSummaryProperties
  Status: FirmwareAnalysisStatus
  StatusMessage: FirmwareAnalysisStatusMessage
  PairedKey: CryptoPairedKey
  UrlToken: FirmwareUrlToken
  AzureResourceManagerCommonTypesSkuUpdate: IotFirmwareDefenseSkuUpdate

directive:
  - from: iotfirmwaredefense.json
    where: $.definitions
    transform: >
      $.BinaryHardeningResource.properties.properties["x-ms-client-flatten"] = true;
      $.CryptoCertificateResource.properties.properties["x-ms-client-flatten"] = true;
      $.CryptoKeyResource.properties.properties["x-ms-client-flatten"] = true;
      $.CveResource.properties.properties["x-ms-client-flatten"] = true;
      $.PasswordHashResource.properties.properties["x-ms-client-flatten"] = true;
      $.SbomComponentResource.properties.properties["x-ms-client-flatten"] = true;
      $.Workspace.properties.properties["x-ms-client-flatten"] = true;
      $.Firmware.properties.properties["x-ms-client-flatten"] = true;
      $.FirmwareUpdateDefinition.properties.properties["x-ms-client-flatten"] = true;

```
