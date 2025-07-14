# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HardwareSecurityModules
namespace: Azure.ResourceManager.HardwareSecurityModules
require: https://github.com/Azure/azure-rest-api-specs/blob/d87c0a3d1abbd1d1aa1b487d99e77769b6895ef4/specification/hardwaresecuritymodules/resource-manager/readme.md
#tag: package-2024-06-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  ActivationState: SecurityDomainActivationState
  BackupRequestProperties: CloudHsmClusterBackupContent
  BackupResult: CloudHsmClusterBackupResult
  BackupResultProperties: CloudHsmClusterBackupResultProperties
  EndpointDetail: DedicatedHsmEndpointDetail
  EndpointDependency: DedicatedHsmEndpointDependency
  JsonWebKeyType: DedicatedHsmJsonWebKeyType
  NetworkInterface: DedicatedHsmNetworkInterface
  NetworkProfile: DedicatedHsmNetworkProfile
  OutboundEnvironmentEndpoint: DedicatedHsmEgressEndpoint
  OutboundEnvironmentEndpointCollection: DedicatedHsmEgressEndpointListResult
  PrivateEndpointConnection: CloudHsmClusterPrivateEndpointConnection
  PrivateEndpointConnectionListResult: CloudHsmClusterPrivateEndpointConnectionListResult
  PrivateEndpointConnectionProperties: CloudHsmClusterPrivateEndpointConnectionProperties
  PrivateEndpointConnectionProvisioningState: CloudHsmClusterPrivateEndpointConnectionProvisioningState
  PrivateEndpointServiceConnectionStatus: CloudHsmClusterPrivateEndpointServiceConnectionStatus
  PrivateLinkResource: CloudHsmClusterPrivateLinkData
  PrivateLinkResourceListResult: CloudHsmClusterPrivateLinkResourceListResult
  PrivateLinkResourceProperties: CloudHsmClusterPrivateLinkResourceProperties
  PrivateLinkServiceConnectionState: CloudHsmClusterPrivateLinkServiceConnectionState
  ProvisioningState: CloudHsmClusterProvisioningState
  PublicNetworkAccess: CloudHsmClusterPublicNetworkAccess
  RestoreRequestProperties: CloudHsmClusterRestoreContent
  RestoreResult: CloudHsmClusterRestoreResult
  Sku: DedicatedHsmSku
  SkuName: DedicatedHsmSkuName
  SkuName.SafeNet_Luna_Network_HSM_A790: SafeNetLunaNetworkHsmA790
  SkuName.payShield10K_LMK1_CPS60: PayShield10KLmk1Cps60
  SkuName.payShield10K_LMK1_CPS250: PayShield10KLmk1Cps250
  SkuName.payShield10K_LMK1_CPS2500: PayShield10KLmk1Cps2500
  SkuName.payShield10K_LMK2_CPS60: PayShield10KLmk2Cps60
  SkuName.payShield10K_LMK2_CPS250: PayShield10KLmk2Cps250
  SkuName.payShield10K_LMK2_CPS2500: PayShield10KLmk2Cps2500

override-operation-name:
  CloudHsmClusterBackupStatus_Get: GetCloudHsmClusterBackupStatus
  CloudHsmClusterRestoreStatus_Get: GetCloudHsmClusterRestoreStatus

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
  # CodeGen don't support some definitions in v4 & v5 common types, here is an issue https://github.com/Azure/autorest.csharp/issues/3537 opened to fix this problem
  - from: v4/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  - from: v5/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  # CodeGen doesn't support `x-ms-client-default`, here is an issue https://github.com/Azure/autorest.csharp/issues/3475 opened to eliminate this attribute
  - from: cloudhsm.json
    where: $.definitions
    transform: >
      delete $.CloudHsmClusterSku.properties.family['x-ms-client-default'];
  # Enum value name must not contain spaces
  - from: dedicatedhsm.json
    where: $.definitions
    transform: >
      $.Sku.properties.name['x-ms-enum']['values'][0]['value'] = 'SafeNet_Luna_Network_HSM_A790';
```
