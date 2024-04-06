# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HDInsight
namespace: Azure.ResourceManager.HDInsight
require: https://github.com/Azure/azure-rest-api-specs/blob/de37c47a625de64c0ac5bf76cf531527ba2feb77/specification/hdinsight/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'privateIPAddress': 'ip-address'

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
  RSA: Rsa
  RSA15: Rsa15
  Autoscale: AutoScale
  Mb: MB

override-operation-name:
  Locations_CheckNameAvailability: CheckHDInsightNameAvailability
  Locations_ListBillingSpecs: GetHDInsightBillingSpecs
  Locations_GetCapabilities: GetHDInsightCapabilities
  Locations_ListUsages: GetHDInsightUsages
  Locations_ValidateClusterCreateRequest: ValidateHDInsightClusterCreation
  Clusters_GetAzureAsyncOperationStatus: GetAsyncOperationStatus
  Extensions_GetAzureAsyncOperationStatus: GetExtensionAsyncOperationStatus
  Extensions_EnableMonitoring: EnableClusterMonitoringExtension
  Extensions_GetMonitoringStatus: GetClusterMonitoringExtensionStatus
  Extensions_DisableMonitoring: DisableClusterMonitoringExtension
  Extensions_EnableAzureMonitor: EnableAzureMonitorExtension
  Extensions_GetAzureMonitorStatus: GetAzureMonitorExtensionStatus
  Extensions_DisableAzureMonitor: DisableAzureMonitorExtension
  ScriptActions_GetExecutionDetail: GetScriptActionExecutionDetail
  ScriptActions_GetExecutionAsyncOperationStatus: GetScriptActionExecutionAsyncOperationStatus
  VirtualMachines_ListHosts: GetVirtualMachineHosts
  VirtualMachines_RestartHosts: RestartVirtualMachineHosts
  VirtualMachines_GetAsyncOperationStatus: GetVirtualMachineAsyncOperationStatus

rename-mapping:
  StorageAccount.saskey: SasKey
  Application: HDInsightApplication
  Cluster: HDInsightCluster
  NameAvailabilityCheckRequestParameters: HDInsightNameAvailabilityContent
  NameAvailabilityCheckResult: HDInsightNameAvailabilityResult
  ClusterCreateValidationResult: HDInsightClusterCreationValidateResult
  ClusterCreateRequestValidationParameters: HDInsightClusterCreationValidateContent
  AaddsResourceDetails: HDInsightClusterAaddsDetail
  ValidationErrorInfo: HDInsightClusterValidationErrorInfo
  AaddsResourceDetails.initialSyncComplete: IsInitialSyncComplete
  AaddsResourceDetails.ldapsEnabled: IsLdapsEnabled
  AaddsResourceDetails.resourceId: -|arm-id
  AaddsResourceDetails.subnetId: -|arm-id
  AsyncOperationResult: HDInsightAsyncOperationResult
  AsyncOperationState: HDInsightAsyncOperationState
  ApplicationProperties: HDInsightApplicationProperties
  ApplicationGetEndpoint: HDInsightApplicationEndpoint
  ApplicationGetHttpsEndpoint: HDInsightApplicationHttpsEndpoint
  Role: HDInsightClusterRole
  Autoscale: HDInsightAutoscaleConfiguration
  AutoscaleCapacity: HDInsightAutoscaleCapacity
  AutoscaleRecurrence: HDInsightAutoscaleRecurrence
  AutoscaleSchedule: HDInsightAutoscaleSchedule
  AutoscaleTimeAndCapacity: HDInsightAutoscaleTimeAndCapacity
  AutoscaleConfigurationUpdateParameter: HDInsightAutoscaleConfigurationUpdateContent
  BillingResponseListResult: HDInsightBillingSpecsListResult
  CapabilitiesResult: HDInsightCapabilitiesResult
  BillingMeters: HDInsightBillingMeters
  BillingResources: HDInsightBillingResources
  BillingResources.region: -|azure-location
  ClusterConfigurations: HDInsightClusterConfigurations
  ClusterCreateProperties: HDInsightClusterCreateOrUpdateProperties
  ClusterGetProperties: HDInsightClusterProperties
  ClusterDefinition: HDInsightClusterDefinition
  ClusterDiskEncryptionParameters: HDInsightClusterDiskEncryptionContent
  ClusterResizeParameters: HDInsightClusterResizeContent
  DataDisksGroups: HDInsightClusterDataDiskGroup
  DataDisksGroups.diskSizeGB: DiskSizeInGB
  DiskBillingMeters: HDInsightDiskBillingMeters
  Tier: HDInsightTier
  AzureMonitorRequest: HDInsightAzureMonitorExtensionEnableContent
  AzureMonitorResponse: HDInsightAzureMonitorExtensionStatus
  AzureMonitorResponse.clusterMonitoringEnabled: IsClusterMonitoringEnabled
  ClusterMonitoringRequest: HDInsightClusterEnableClusterMonitoringContent
  ClusterMonitoringResponse: HDInsightClusterExtensionStatus
  ClusterMonitoringResponse.clusterMonitoringEnabled: IsClusterMonitoringEnabled
  Extension: HDInsightClusterCreateExtensionContent
  AzureMonitorSelectedConfigurations: HDInsightAzureMonitorSelectedConfigurations
  AzureMonitorTableConfiguration: HDInsightAzureMonitorTableConfiguration
  SecurityProfile.msiResourceId: -|arm-id
  StorageAccount: HDInsightStorageAccountInfo
  StorageProfile.storageaccounts: StorageAccounts
  StorageAccount.resourceId: -|arm-id
  StorageAccount.msiResourceId: -|arm-id
  ComputeIsolationProperties: HDInsightComputeIsolationProperties
  DiskEncryptionProperties: HDInsightDiskEncryptionProperties
  DiskEncryptionProperties.msiResourceId: -|arm-id
  VirtualNetworkProfile: HDInsightVirtualNetworkProfile
  VirtualNetworkProfile.id: -|arm-id
  UpdateGatewaySettingsParameters: HDInsightClusterUpdateGatewaySettingsContent
  UpdateClusterIdentityCertificateParameters: HDInsightClusterUpdateIdentityCertificateContent
  PrivateLink: HDInsightPrivateLinkState
  NetworkProperties: HDInsightClusterNetworkProperties
  LinuxOperatingSystemProfile: HDInsightLinuxOSProfile
  OsProfile.linuxOperatingSystemProfile: LinuxProfile
  HostInfo: HDInsightClusterHostInfo
  GatewaySettings: HDInsightClusterGatewaySettings
  IPConfiguration.id: -|arm-id
  IPConfiguration.type: -|resource-type
  IPConfiguration.properties.primary: IsPrimary
  NameAvailabilityCheckRequestParameters.type: -|resource-type
  NameAvailabilityCheckResult.nameAvailable: IsNameAvailable
  RuntimeScriptActionDetail.startTime: -|date-time
  RuntimeScriptActionDetail.endTime: -|date-time
  DaysOfWeek: HDInsightDayOfWeek
  DiskEncryptionProperties.encryptionAtHost: IsEncryptionAtHostEnabled
  DirectoryType: AuthenticationDirectoryType
  ConnectivityEndpoint.location: EndpointLocation
  ApplicationGetEndpoint.location: EndpointLocation
  ApplicationGetHttpsEndpoint.location: EndpointLocation
  SecurityProfile.aaddsResourceId: -|arm-id
  PrivateLinkConfiguration.type: ResourceType|resource-type
  RegionalQuotaCapability.regionName: region|azure-location
  VmSizeProperty.supportedByVirtualMachines: IsSupportedByVirtualMachines
  VmSizeProperty.supportedByWebWorkerRoles: IsSupportedByWebWorkerRoles
  VmSizeCompatibilityFilterV2.computeIsolationSupported: IsComputeIsolationSupported
  SecurityProfile.ldapsUrls: LdapUris|uri
  ApplicationProperties.createdDate: CreatedOn|date-time
  ClusterGetProperties.createdDate: CreatedOn|date-time

prepend-rp-prefix:
- VmSizeCompatibilityFilterV2
- VmSizeProperty
- FilterMode
- OSType
- SshPublicKey
- SecurityProfile
- VersionSpec
- VersionsCapability
- RoleName
- PrivateLinkConfiguration
- PrivateLinkConfigurationProvisioningState
- PrivateLinkServiceConnectionStatus
- PrivateIPAllocationMethod
- LocalizedName
- ResourceProviderConnection
- IPConfiguration

directive:
  - remove-operation: Locations_GetAzureAsyncOperationStatus # this operation is an LRO polling operation. Remove it here since our SDK provided LRO polling in a native way
  - from: cluster.json
    where: $.definitions
    transform: >
      $.Resource['x-ms-client-name'] = 'HDInsightClusterResponseData';
      $.GatewaySettings.properties['restAuthCredential.isEnabled']['type'] = 'boolean';
# this model has an extra property which prevents the generator to replace it with the type provided by resourcemanager
  - from: swagger-document
    where: $.definitions.UserAssignedIdentity.properties
    transform: $['tenantId'] = undefined
# mark it as input so that the getter of its properties will still preseve the setter
  - from: swagger-document
    where: $.definitions.Cluster
    transform: $['x-csharp-usage'] = 'model,input,output'
# fix some attributes in Errors so that it could be replaced by Azure.ResponseError
  - from: swagger-document
    where: $.definitions.Errors.properties
    transform: >
      return {
        'code': {
          'readOnly': true,
          'type': 'string',
          'description': 'The error code.'
        },
        'message': {
          'readOnly': true,
          'type': 'string',
          'description': 'The error message.'
        },
        'target': {
          'readOnly': true,
          'type': 'string',
          'description': 'The error target.'
        },
        'details': {
          'readOnly': true,
          'type': 'array',
          'items': {
            '$ref': '#/definitions/Errors'
          },
          'x-ms-identifiers': [
            'message',
            'target'
          ],
          'description': 'The error details.'
        }
      };
# nullable
  - from: cluster.json
    where: $.definitions
    transform: >
      $.StorageAccount.properties.msiResourceId['x-nullable'] = true;
      $.StorageAccount.properties.resourceId['x-nullable'] = true;
      $.DiskEncryptionProperties.properties.encryptionAlgorithm['x-nullable'] = true;
      $.DiskEncryptionProperties.properties.msiResourceId['x-nullable'] = true;

```
