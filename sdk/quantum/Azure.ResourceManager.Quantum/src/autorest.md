# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Quantum
namespace: Azure.ResourceManager.Quantum
require: https://github.com/Azure/azure-rest-api-specs/blob/d6fcc46341f274b8af42a4cdcfa14e1f8d472619/specification/quantum/resource-manager/readme.md
#tag: package-2023-11-13-preview
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

rename-mapping:
  UsableStatus: WorkspaceUsableStatus
  QuantumWorkspace.properties.apiKeyEnabled: IsApiKeyEnabled
  ApiKey: WorkspaceApiKey
  APIKeys: WorkspaceApiKeys
  CheckNameAvailabilityParameters: WorkspaceNameAvailabilityContent
  CheckNameAvailabilityParameters.type: -|resource-type
  CheckNameAvailabilityResult: WorkspaceNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  KeyType: WorkspaceKeyType
  ListKeysResult: WorkspaceKeyListResult
  ListKeysResult.apiKeyEnabled: IsApiKeyEnabled
  PricingDimension: ProviderPricingDimension
  Status: ProviderProvisioningStatus
  ProviderPropertiesAad: ProviderAadInfo
  ProviderPropertiesManagedApplication: ProviderApplicationInfo
  SkuDescription: ProviderSkuDescription
  TargetDescription: ProviderTargetDescription

prepend-rp-prefix:
  - ProvisioningStatus
  - PricingDetail
  - Provider
  - ProviderDescription
  - ProviderProperties
  - QuotaDimension

override-operation-name:
  Workspace_CheckNameAvailability: CheckWorkspaceNameAvailability

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
