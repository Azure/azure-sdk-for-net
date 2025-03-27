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
  Cves_ListByFirmware: GetCommonVulnerabilitiesAndExposures

parameter-rename-mapping:
  Workspaces_Create:
    resource: WorkspaceResource

rename-mapping:
  Workspace: FirmwareAnalysisWorkspace

  Firmware: IotFirmware
  FirmwareListResult: IotFirmwareCollection
  ProvisioningState: FirmwareProvisioningState
  Status: FirmwareAnalysisStatus

  SummaryType: FirmwareAnalysisSummaryType
  SummaryResource: FirmwareAnalysisSummary
  SummaryResourceProperties: FirmwareAnalysisSummaryProperties

  GetFirmwareAnalysisSummaryResource: GetFirmwareAnalysisSummary

  BinaryHardeningSummaryResource: BinaryHardeningSummary
  CryptoCertificateSummaryResource: CryptoCertificateSummary
  CryptoKeySummaryResource: CryptoKeySummary

  PairedKey: CryptoPairedKey
  UrlToken: FirmwareUrlToken

```
