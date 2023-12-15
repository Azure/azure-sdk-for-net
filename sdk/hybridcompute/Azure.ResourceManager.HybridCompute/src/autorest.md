# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridCompute
namespace: Azure.ResourceManager.HybridCompute
require: https://github.com/Azure/azure-rest-api-specs/blob/e8bd7afbc95be92f48f1b0763189f6d9118ee29d/specification/hybridcompute/resource-manager/readme.md
#tag: package-preview-2023-10
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

prepend-rp-prefix:
  - AccessMode
  - AccessRule
  - AccessRuleDirection
  - AgentConfiguration
  - AgentUpgrade
  - AgentVersion
  - ConfigurationExtension
  - ExtensionValue
  - ExecutionState
  - IpAddress
  - KeyDetails
  - KeyProperties
  - License
  - LicenseCoreType
  - LicenseDetails
  - LicenseEdition
  - LicenseProfile
  - LicenseState
  - LicenseStatus
  - LicenseTarget
  - LicenseType
  - LinuxParameters
  - Machine
  - MachineExtension
  - NetworkInterface
  - NetworkProfile
  - OSProfile
  - OsType
  - ProductFeature
  - ProductFeatureUpdate
  - ProvisioningIssue
  - ProvisioningIssueSeverity
  - ProvisioningIssueType
  - ProvisioningState
  - PublicNetworkAccessType
  - ResourceAssociation
  - ResourceUpdate
  - RunCommandInputParameter
  - RunCommandManagedIdentity
  - Subnet
  - WindowsParameters

rename-mapping:
  StatusLevelTypes: HybridComputeStatusLevelType
  StatusTypes: HybridComputeStatusType
  ServiceStatus: HybridComputeServiceStatus
  ServiceStatuses: HybridComputeServiceStatuses
  MachineInstallPatchesParameters.maximumDuration: -|duration
  Machine.properties.vmId: -|uuid
  Machine.properties.vmUuid: -|uuid
  Machine.properties.privateLinkScopeResourceId: -|arm-id
  Machine.properties.parentClusterResourceId: -|arm-id
  AgentUpgrade.correlationId: -|uuid
  AgentUpgrade.lastAttemptTimestamp: -|date-time
  MachineUpdate.properties.parentClusterResourceId: -|arm-id
  MachineUpdate.properties.privateLinkScopeResourceId: -|arm-id
  MachineAssessPatchesResult.assessmentActivityId: -|uuid
  ArcKindEnum.AVS: Avs
  ArcKindEnum.HCI: Hci
  ArcKindEnum.SCVMM: ScVmm
  ArcKindEnum.EPS: Eps
  ArcKindEnum.GCP: Gcp
  ConnectionDetail: PrivateEndpointConnectionDetail
  LocationData: HybridComputeLocation
  NetworkSecurityPerimeter.id: -|arm-id
  ConnectionDetail.id: -|arm-id
  PrivateLinkScopeValidationDetails.id: -|arm-id
  AgentConfiguration.guestConfigurationEnabled: IsGuestConfigurationEnabled
  KeyDetails.notAfter: NotAfterOn
  KeyDetails.renewAfter: RenewAfterOn
  LicenseStatus.OOBGrace: OobGrace
  LicenseStatus.OOTGrace: OotGrace
  LicenseType.ESU: Esu
  HybridComputePrivateLinkScopeProperties.privateLinkScopeId: -|uuid
  ProvisioningIssue.properties.suggestedResourceIds: -|arm-id
  RunCommandManagedIdentity.clientId: -|uuid
  RunCommandManagedIdentity.objectId: -|uuid
  LicenseProfileStorageModelEsuProperties.assignedLicenseImmutableId: -|uuid
  NetworkSecurityPerimeter.perimeterGuid: -|uuid
  PatchServiceUsed.YUM: Yum
  PatchServiceUsed.APT: Apt
  Machine.properties.adFqdn: ADFqdn
  HybridIdentityMetadata.properties.vmId: -|uuid

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

models-to-treat-empty-string-as-null:
  - AgentConfiguration

directive:
  # Mitigate the duplication schema named 'ErrorDetail'
  - from: HybridCompute.json
    where: $.paths
    transform: >
      $['/providers/Microsoft.HybridCompute/osType/{osType}/agentVersions'].get.responses.default.schema['$ref'] = '../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse';
      $['/providers/Microsoft.HybridCompute/osType/{osType}/agentVersions/{version}'].get.responses.default.schema['$ref'] = '../../../../../common-types/resource-management/v3/types.json#/definitions/ErrorResponse';
  # Add the missing flatten attribute
  - from: HybridCompute.json
    where: $.definitions
    transform: >
      $.MachineExtension.properties.properties['x-ms-client-flatten'] = true;
```
