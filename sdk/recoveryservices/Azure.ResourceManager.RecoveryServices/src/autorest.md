# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: RecoveryServices
namespace: Azure.ResourceManager.RecoveryServices
require: https://github.com/Azure/azure-rest-api-specs/blob/7b47689d4efc098f25f46781f05f22179c153314/specification/recoveryservices/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  CertificateRequest: RecoveryServicesCertificateContent
  DNSZoneResponse: DnsZoneResult
  CapabilitiesResponseProperties: CapabilitiesResultProperties
  CapabilitiesResponse: CapabilitiesResult
  CheckNameAvailabilityParameters: RecoveryServicesNameAvailabilityContent
  CheckNameAvailabilityResult: RecoveryServicesNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  JobsSummary: ReplicationJobSummary
  MonitoringSettings: VaultMonitoringSettings
  MonitoringSummary: VaultMonitoringSummary
  NameInfo: VaultUsageNameInfo
  ProvisioningState: PrivateEndpointConnectionProvisioningState
  PublicNetworkAccess: VaultPublicNetworkAccess
  ReplicationUsageList: ReplicationUsageListResult
  TriggerType: VaultUpgradeTriggerType
  UpgradeDetails: VaultUpgradeDetails
  UsagesUnit: VaultUsageUnit
  VaultCertificateResponse: VaultCertificateResult
  VaultList: RecoveryServicesVaultListResult
  VaultUsageList: VaultUsageListResult
  RecoveryServicesPrivateLinkResources: PrivateLinkResourceListResult
  CmkKekIdentity.userAssignedIdentity: -|arm-id
  CheckNameAvailabilityParameters.type: -|resource-type
  ResourceCapabilitiesBase.type: -|resource-type
  ResourceCertificateAndAadDetails.aadTenantId: -|uuid
  ResourceCertificateDetails.thumbprint: -|any
  ResourceCertificateDetails.validFrom: ValidStartOn
  ResourceCertificateDetails.validTo: ValidEndOn
  VaultPropertiesMoveDetails.startTimeUtc: StartOn
  VaultPropertiesMoveDetails.completionTimeUtc: CompletedOn
  UpgradeDetails.startTimeUtc: StartOn
  UpgradeDetails.lastUpdatedTimeUtc: LastUpdatedOn
  UpgradeDetails.endTimeUtc: EndOn
  ResourceCertificateAndAadDetails.serviceResourceId: -|arm-id
  VaultPropertiesMoveDetails.sourceResourceId: -|arm-id
  VaultPropertiesMoveDetails.targetResourceId: -|arm-id
  UpgradeDetails.upgradedResourceId: -|arm-id
  UpgradeDetails.previousResourceId: -|arm-id

prepend-rp-prefix:
  - Vault
  - VaultProperties
  - AlertsState
  - AuthType
  - PrivateEndpointConnectionStatus
  - PrivateEndpointConnectionVaultProperties

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'SubscriptionIdParameter': 'object'

rename-rules:
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
  ACS: Acs
  AAD: Aad

override-operation-name:
  RecoveryServices_Capabilities: GetRecoveryServiceCapabilities
  RecoveryServices_CheckNameAvailability: CheckRecoveryServicesNameAvailability

directive:
  - remove-operation: GetOperationStatus
  - remove-operation: GetOperationResult
  - from: vaults.json
    where: $.definitions
    transform: >
      $.VaultExtendedInfo['x-ms-client-name'] = 'VaultExtendedInfoProperties';
      $.VaultExtendedInfoResource['x-ms-client-name'] = 'RecoveryServicesVaultExtendedInfo';
```
