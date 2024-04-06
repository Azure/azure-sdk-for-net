# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: KubernetesConfiguration
namespace: Azure.ResourceManager.KubernetesConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/e812b54127fad6c9bc2407b33980b0fe385b7717/specification/kubernetesconfiguration/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

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

prepend-rp-prefix:
  - ProvisioningState
  - ProvisioningStateType

rename-mapping:
  Extension: KubernetesClusterExtension
  Scope: KubernetesClusterExtensionScope
  ScopeType: KubernetesConfigurationScope
  SourceKindType: KubernetesConfigurationSourceKind
  ExtensionStatus: KubernetesClusterExtensionStatus
  LevelType: KubernetesClusterExtensionStatusLevel
  SourceControlConfiguration: KubernetesSourceControlConfiguration
  FluxConfiguration: KubernetesFluxConfiguration
  FluxConfiguration.properties.suspend: IsReconciliationSuspended
  FluxComplianceState: KubernetesFluxComplianceState
  SourceControlConfiguration.properties.enableHelmOperator: IsHelmOperatorEnabled
  AzureBlobDefinition: KubernetesAzureBlob
  GitRepositoryDefinition: KubernetesGitRepository
  BucketDefinition: KubernetesBucket
  ManagedIdentityDefinition.clientId: -|uuid
  BucketDefinition.insecure: UseInsecureCommunication
  BucketPatchDefinition: KubernetesBucketUpdateContent
  BucketPatchDefinition.insecure: UseInsecureCommunication
  GitRepositoryPatchDefinition: KubernetesGitRepositoryUpdateContent
  AzureBlobPatchDefinition: KubernetesAzureBlobUpdateContent
  KustomizationPatchDefinition: KustomizationUpdateContent
  ComplianceStatus: KubernetesConfigurationComplianceStatus
  ComplianceStatus.lastConfigApplied: LastConfigAppliedOn
  ComplianceStateType: KubernetesConfigurationComplianceStateType
  ServicePrincipalDefinition.clientId: -|uuid
  ServicePrincipalPatchDefinition.clientId: -|uuid
  ServicePrincipalDefinition: KubernetesServicePrincipal
  ServicePrincipalPatchDefinition: KubernetesServicePrincipalUpdateContent
  ManagedIdentityDefinition: KubernetesAzureBlobManagedIdentity
  ManagedIdentityPatchDefinition: KubernetesAzureBlobManagedIdentityUpdateContent
  MessageLevelType: KubernetesConfigurationMesageLevel
  ObjectReferenceDefinition: KubernetesObjectReference
  ObjectStatusConditionDefinition: KubernetesObjectStatusCondition
  ObjectStatusDefinition: KubernetesObjectStatus
  OperatorScopeType: KubernetesOperatorScope
  OperatorType: KubernetesOperator
  RepositoryRefDefinition: KubernetesGitRepositoryRef
  HelmReleasePropertiesDefinition: HelmReleaseProperties
  KustomizationDefinition: Kustomization

directive:
  - remove-operation: OperationStatus_Get
  - remove-operation: OperationStatus_List
  - remove-operation: FluxConfigOperationStatus_Get

```
