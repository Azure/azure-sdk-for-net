# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Hci
namespace: Azure.ResourceManager.Hci
tag: package-preview-2023-09
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
  '*TenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ClientId': 'uuid'
  '*ApplicationObjectId': 'uuid'
  '*ServicePrincipalObjectId': 'uuid'

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

prepend-rp-prefix:
  - Cluster
  - ProvisioningState
  - ClusterDesiredProperties
  - ClusterNode
  - ClusterReportedProperties
  - AvailabilityType
  - HealthState
  - ManagedServiceIdentityType
  - OfferList
  - PackageVersionInfo
  - PrecheckResult
  - PrecheckResultTags
  - PublisherList
  - SkuList
  - SkuMappings
  - UpdateList
  - PublisherCollection
  - ExtensionInstanceView
  - StatusLevelTypes

rename-mapping:
  Extension: ArcExtension
  Extension.properties.extensionParameters.autoUpgradeMinorVersion: ShouldAutoUpgradeMinorVersion
  Extension.properties.extensionParameters.type: ArcExtensionType
  Status: HciClusterStatus
  ClusterReportedProperties.clusterId: -|uuid
  Cluster.properties.cloudId: -|uuid
  ArcIdentityResponse: ArcIdentityResult
  ClusterIdentityResponse: HciClusterIdentityResult
  ClusterReportedProperties.lastUpdated: LastUpdatedOn
  ClusterList: HciClusterListResult
  DiagnosticLevel: HciClusterDiagnosticLevel
  ExtensionAggregateState: ArcExtensionAggregateState
  ExtensionList: ArcExtensionListResult
  ImdsAttestation: ImdsAttestationState
  PasswordCredential: ArcPasswordCredential
  UploadCertificateRequest: HciClusterCertificateContent
  RawCertificateData: HciClusterRawCertificate
  PerNodeState: PerNodeArcState
  RebootRequirement: HciNodeRebootRequirement
  Severity: UpdateSeverity
  State: HciUpdateState
  Step: HciUpdateStep
  OfferCollection: HciOfferCollection
  OfferData: HciOfferData
  ClusterPatch.identity.type: ManagedServiceIdentityType
  ExtensionPatchParameters: ExtensionPatchContent
  ExtendedLocation: ArcVmExtendedLocation
  ExtendedLocationTypes: ArcVmExtendedLocationTypes

directive:
  - from: swagger-document
    where: $.definitions..systemData
    transform: $["x-ms-client-flatten"] = false
  - from: updateRuns.json
    where: $.definitions.UpdateRunProperties.properties
    transform: >
      $.duration['x-ms-format'] = 'string';
```
### Tag: package-preview-2023-09

These settings apply only when `--tag=package-preview-2023-09` is specified on the command line.

```yaml $(tag) == 'package-preview-2023-09'
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/galleryImages.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/logicalNetworks.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/common.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/marketplaceGalleryImages.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/networkInterfaces.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/storageContainers.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/virtualHardDisks.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/preview/2023-09-01-preview/virtualMachineInstances.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/arcSettings.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/clusters.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/extensions.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/offers.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/publishers.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/skus.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/updateRuns.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/updateSummaries.json
    - https://github.com/Azure/azure-rest-api-specs/blob/784f4a4080974c9270fedf1dd24d81223a70a8f4/specification/azurestackhci/resource-manager/Microsoft.AzureStackHCI/stable/2023-02-01/updates.json
```