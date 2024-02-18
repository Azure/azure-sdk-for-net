# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Batch
namespace: Azure.ResourceManager.Batch   
require: https://github.com/Azure/azure-rest-api-specs/blob/408db257fe67fc66d8c66c10881be8d414d5e5f3/specification/batch/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

# mgmt-debug:
#   show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'ifMatch': 'etag'
  'locationName': 'azure-location'

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
  AAD: Aad
  LRS: Lrs
  TCP: Tcp
  UDP: Udp
  NFS: Nfs

prepend-rp-prefix:
- StorageAccountType
- ProvisioningState

override-operation-name:
  Location_CheckNameAvailability: CheckBatchNameAvailability
  Location_GetQuotas: GetBatchQuotas
  Location_ListSupportedCloudServiceSkus: GetBatchSupportedCloudServiceSkus
  Location_ListSupportedVirtualMachineSkus: GetBatchSupportedVirtualMachineSkus

rename-mapping:
  CachingType: BatchDiskCachingType
  Application: BatchApplication
  ApplicationPackage: BatchApplicationPackage
  ApplicationPackage.properties.lastActivationTime: LastActivatedOn
  PublicNetworkAccessType: BatchPublicNetworkAccess
  BatchAccount.properties.dedicatedCoreQuotaPerVMFamilyEnforced: IsDedicatedCoreQuotaPerVmFamilyEnforced
  DetectorResponse: BatchAccountDetector
  OutboundEnvironmentEndpoint: BatchAccountOutboundEnvironmentEndpoint
  EndpointDependency: BatchAccountEndpointDependency
  EndpointDetail: BatchEndpointDetail
  Pool: BatchAccountPool
  Pool.properties.lastModified: LastModifiedOn
  Pool.properties.provisioningStateTransitionTime: provisioningStateTransitOn
  PoolAllocationMode: BatchAccountPoolAllocationMode
  AutoScaleRun: BatchAccountPoolAutoScaleRun
  ResizeOperationStatus: BatchResizeOperationStatus
  ComputeNodeDeallocationOption: BatchNodeDeallocationOption
  Certificate: BatchAccountCertificate
  CertificateCreateOrUpdateParameters: BatchAccountCertificateCreateOrUpdateContent
  CertificateFormat: BatchAccountCertificateFormat
  CertificateProvisioningState: BatchAccountCertificateProvisioningState
  Certificate.properties.provisioningStateTransitionTime: provisioningStateTransitOn
  Certificate.properties.previousProvisioningStateTransitionTime: previousProvisioningStateTransitOn
  CertificateStoreLocation: BatchCertificateStoreLocation
  CertificateVisibility: BatchCertificateVisibility
  PoolProvisioningState: BatchAccountPoolProvisioningState
  DeploymentConfiguration: BatchDeploymentConfiguration
  DeploymentConfiguration.virtualMachineConfiguration: vmConfiguration
  CloudServiceConfiguration: BatchCloudServiceConfiguration
  VirtualMachineConfiguration: BatchVmConfiguration
  DataDisk: BatchVmDataDisk
  DataDisk.diskSizeGB: DiskSizeInGB
  VMExtension: BatchVmExtension
  VMExtension.type: ExtensionType
  ContainerConfiguration: BatchVmContainerConfiguration
  ContainerType: BatchVmContainerType
  ContainerRegistry: BatchVmContainerRegistry
  WindowsConfiguration.enableAutomaticUpdates: IsAutomaticUpdateEnabled
  ContainerRegistry.identityReference: Identity
  NetworkProfile: BatchNetworkProfile
  EndpointAccessProfile: BatchEndpointAccessProfile
  EndpointAccessDefaultAction: BatchEndpointAccessDefaultAction
  AllocationState: BatchAccountPoolAllocationState
  ApplicationPackageReference: BatchApplicationPackageReference
  ApplicationPackageReference.id: -|arm-id
  CertificateReference: BatchCertificateReference
  CertificateReference.id: -|arm-id
  MetadataItem: BatchAccountPoolMetadataItem
  MountConfiguration: BatchMountConfiguration
  AzureBlobFileSystemConfiguration: BatchBlobFileSystemConfiguration
  AzureBlobFileSystemConfiguration.identityReference: Identity
  AzureFileShareConfiguration: BatchFileShareConfiguration
  ComputeNodeIdentityReference.resourceId: -|arm-id
  AutoStorageProperties: BatchAccountAutoStorageConfiguration
  AutoStorageProperties.lastKeySync: LastKeySyncedOn
  AutoStorageBaseProperties: BatchAccountAutoStorageBaseConfiguration
  AutoStorageBaseProperties.storageAccountId: -|arm-id
  AutoStorageAuthenticationMode: BatchAutoStorageAuthenticationMode
  AutoStorageBaseProperties.nodeIdentityReference: NodeIdentity
  KeyVaultReference: BatchKeyVaultReference
  KeyVaultReference.id: -|arm-id
  AuthenticationMode: BatchAuthenticationMode
  EncryptionProperties: BatchAccountEncryptionConfiguration
  KeySource: BatchAccountKeySource
  IPRule: BatchIPRule
  ResourceFile.identityReference: Identity
  VirtualMachineFamilyCoreQuota: BatchVmFamilyCoreQuota
  ScaleSettings: BatchAccountPoolScaleSettings
  AutoScaleSettings: BatchAccountAutoScaleSettings
  FixedScaleSettings: BatchAccountFixedScaleSettings
  StartTask: BatchAccountPoolStartTask
  ResourceFile: BatchResourceFile
  EnvironmentSetting: BatchEnvironmentSetting
  TaskContainerSettings: BatchTaskContainerSettings
  ComputeNodeFillType: BatchNodeFillType
  UserAccount: BatchUserAccount
  ElevationLevel: BatchUserAccountElevationLevel
  AutoUserScope: BatchAutoUserScope
  AutoUserSpecification: BatchAutoUserSpecification
  LinuxUserConfiguration: BatchLinuxUserConfiguration
  WindowsUserConfiguration: BatchWindowsUserConfiguration
  LoginMode: BatchWindowsLoginMode
  ApplicationPackage.properties.storageUrlExpiry: StorageUriExpireOn
  SupportedSku: BatchSupportedSku
  ActivateApplicationPackageParameters: BatchApplicationPackageActivateContent
  CheckNameAvailabilityParameters: BatchNameAvailabilityContent
  CheckNameAvailabilityParameters.type: -|resource-type
  CheckNameAvailabilityResult: BatchNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  NameAvailabilityReason: BatchNameUnavailableReason
  CifsMountConfiguration: BatchCifsMountConfiguration
  CifsMountConfiguration.userName: username
  NFSMountConfiguration: BatchNFSMountConfiguration
  ContainerWorkingDirectory: BatchContainerWorkingDirectory
  DiffDiskPlacement: BatchDiffDiskPlacement
  DiskEncryptionTarget: BatchDiskEncryptionTarget
  InboundEndpointProtocol: BatchInboundEndpointProtocol
  InboundNatPool: BatchInboundNatPool
  IPAddressProvisioningType: BatchIPAddressProvisioningType
  IPRuleAction: BatchIPRuleAction
  NetworkConfiguration: BatchNetworkConfiguration
  NetworkConfiguration.dynamicVnetAssignmentScope: dynamicVNetAssignmentScope
  NetworkConfiguration.subnetId: -|arm-id
  NetworkSecurityGroupRule: BatchNetworkSecurityGroupRule
  NetworkSecurityGroupRuleAccess: BatchNetworkSecurityGroupRuleAccess
  NodePlacementPolicyType: BatchNodePlacementPolicyType
  PackageState: BatchApplicationPackageState
  PrivateLinkServiceConnectionStatus: BatchPrivateLinkServiceConnectionStatus
  PrivateLinkServiceConnectionState.actionsRequired: actionRequired
  PublicIPAddressConfiguration: BatchPublicIPAddressConfiguration
  SkuCapability: BatchSkuCapability
  UserIdentity: BatchUserIdentity
  ImageReference: BatchImageReference
  ImageReference.id: -|arm-id
  CertificateCreateOrUpdateParameters.properties.data: -|any
  KeyVaultProperties.keyIdentifier: -|uri
  AzureFileShareConfiguration.azureFileUrl: FileUrl
  MountConfiguration.azureBlobFileSystemConfiguration: BlobFileSystemConfiguration
  MountConfiguration.azureFileShareConfiguration: FileShareConfiguration
  ResourceFile.storageContainerUrl: BlobContainerUri
  ResourceFile.autoStorageContainerName: AutoBlobContainerName
  AccountKeyType: BatchAccountKeyType
  BatchAccountRegenerateKeyParameters.keyName: KeyType
  Certificate.properties.thumbprint: ThumbprintString
  CertificateCreateOrUpdateParameters.properties.thumbprint: ThumbprintString
  OSDisk: BatchOSDisk
  OSDisk.writeAcceleratorEnabled: IsWriteAcceleratorEnabled
  SecurityProfile: BatchSecurityProfile
  UefiSettings: BatchUefiSettings
  UefiSettings.secureBootEnabled: IsSecureBootEnabled
  UefiSettings.vTpmEnabled: IsVTpmEnabled
  SecurityTypes: BatchSecurityType
  StorageAccountType.StandardSSD_LRS: StandardSsdLrs

directive:
# TODO -- remove this and use rename-mapping when it is supported
  - from: swagger-document
    where: $.definitions.PublicIPAddressConfiguration.properties.ipAddressIds.items
    transform: $["x-ms-format"] = "arm-id"
# resume the setter on tags of BatchAccountData
  - from: swagger-document
    where: $.definitions.BatchAccount
    transform: $["x-csharp-usage"] = "model,input,output"
  - from: swagger-document
    where: $.definitions.Resource.properties.tags
    transform: $["readOnly"] = undefined
# change the type to extensible so that the BatchPoolIdentity could be replaced
  - from: swagger-document
    where: $.definitions.BatchPoolIdentity.properties
    transform: >
      $.type["x-ms-enum"].modelAsString = true;
      $["principalId"] = {
        "type": "string",
        "readOnly": true
      };
      $["tenantId"] = {
        "type": "string",
        "readOnly": true
      };
# make provisioning state enumerations all extensible because they are meant to be extensible
  - from: swagger-document
    where: $.definitions
    transform: >
      $.BatchAccountProperties.properties.provisioningState["x-ms-enum"].modelAsString = true;
      $.CertificateProperties.properties.provisioningState["x-ms-enum"].modelAsString = true;
      $.PrivateEndpointConnectionProperties.properties.provisioningState["x-ms-enum"].modelAsString = true;
      $.PoolProperties.properties.provisioningState["x-ms-enum"].modelAsString = true;
# add some missing properties to ResizeError so that it could be replaced by Azure.ResponseError
  - from: swagger-document
    where: $.definitions.ResizeError.properties
    transform: >
      $.code["readOnly"] = true;
      $.message["readOnly"] = true;
      $.details["readOnly"] = true;
      $["target"] = {
          "readOnly": true,
          "type": "string",
          "description": "The error target."
        };
# add some missing properties to AutoScaleRunError so that it could be replaced by Azure.ResponseError
  - from: swagger-document
    where: $.definitions.AutoScaleRunError.properties
    transform: >
      $.code["readOnly"] = true;
      $.message["readOnly"] = true;
      $.details["readOnly"] = true;
      $["target"] = {
          "readOnly": true,
          "type": "string",
          "description": "The error target."
        };
  - from: swagger-document
    where: $.definitions.CheckNameAvailabilityParameters.properties.type
    transform: $["x-ms-constant"] = true;
```
