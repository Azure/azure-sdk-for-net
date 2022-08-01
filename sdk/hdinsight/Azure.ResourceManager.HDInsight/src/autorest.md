# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HDInsight
namespace: Azure.ResourceManager.HDInsight
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/hdinsight/resource-manager/readme.md
tag: package-2021-06
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug:
  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
  RSA: Rsa
  RSA15: Rsa15
  Autoscale: AutoScale

override-operation-name:
  Locations_CheckNameAvailability: CheckHDInsightNameAvailability
  Locations_ListBillingSpecs: GetHDInsightBillingSpecs
  Locations_GetCapabilities: GetHDInsightCapabilities
  Locations_ListUsages: GetHDInsightUsages
  Locations_ValidateClusterCreateRequest: ValidateHDInsightClusterCreation


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
  ClusterConfigurations: HDInsightClusterConfigurations
  ClusterCreateProperties: HDInsightClusterCreateOrUpdateProperties
  ClusterGetProperties: HDInsightClusterProperties
  ClusterDefinition: HDInsightClusterDefinition
  ClusterDiskEncryptionParameters: HDInsightClusterDiskEncryptionContent
  ClusterResizeParameters: HDInsightClusterResizeContent
  DataDisksGroups: HDInsightClusterDataDisksGroup
  DiskBillingMeters: HDInsightDiskBillingMeters
  Tier: HDInsightTier

directive:
  - remove-operation: Locations_GetAzureAsyncOperationStatus # this operation is an LRO polling operation. Remove it here since our SDK provided LRO polling in a native way
  - from: cluster.json
    where: $.definitions
    transform: >
      $.Resource["x-ms-client-name"] = 'HDInsightClusterResponseData';
# this model has an extra property which prevents the generator to replace it with the type provided by resourcemanager
  - from: swagger-document
    where: $.definitions.UserAssignedIdentity.properties
    transform: $["tenantId"] = undefined
# mark it as input so that the getter of its properties will still preseve the setter
  - from: swagger-document
    where: $.definitions.Cluster
    transform: $["x-csharp-usage"] = "model,input,output"
```
