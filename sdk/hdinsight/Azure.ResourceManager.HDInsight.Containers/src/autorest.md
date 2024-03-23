# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HDInsightContainers
namespace: Azure.ResourceManager.HDInsight.Containers
require: https://github.com/Azure/azure-rest-api-specs/blob/a434a5a7ee851abc96218443e66a5ebb57911fee/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md
# tag: package-preview-2023-11
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
  Action: FlinkJobAction
  Action.NEW: New
  AutoscaleProfile: ClusterAutoscaleProfile
  AutoscaleProfile.enabled: IsEnabled
  AutoscaleType: ClusterAutoscaleType
  Cluster: HDInsightCluster
  ClusterPool: HDInsightClusterPool
  ClusterComponentsItem: ClusterComponentItem
  ClusterInstanceViewsResult: ClusterInstanceViewListResult
  ClusterJobList: ClusterJobListResult
  ClusterListResult: HDInsightClusterListResult
  ClusterLogAnalyticsApplicationLogs.stdOutEnabled: IsStdOutEnabled
  ClusterLogAnalyticsApplicationLogs.stdErrorEnabled: IsStdErrorEnabled
  ClusterLogAnalyticsProfile.enabled: IsEnabled
  ClusterLogAnalyticsProfile.metricsEnabled: IsMetricsEnabled
  ClusterPoolListResult: HDInsightClusterPoolListData
  ClusterPoolLogAnalyticsProfile.enabled: IsEnabled
  ClusterPoolVersionsListResult: ClusterPoolVersionListResult
  ClusterPrometheusProfile.enabled: IsEnabled
  ClusterResizeData: ClusterResizeContent
  ClusterVersion: HDInsightClusterVersion
  ClusterVersionsListResult: HDInsightClusterVersionListResult
  ComparisonOperator: HDInsightComparisonOperator
  ComparisonRule: HDInsightComparisonRule
  ComputeResourceDefinition: ComputeResourceRequirement
  ConnectivityProfile: ClusterConnectivityProfile
  ContentEncoding: HDInsightContentEncoding
  IdentityProfile: HDInsightIdentityProfile
  JobType: ClusterJobType
  LoadBasedConfig: LoadBasedConfig
  LoadBasedConfig.pollInterval: PollIntervalInSeconds
  NameAvailabilityParameters: HDInsightNameAvailabilityContent
  NameAvailabilityResult: HDInsightNameAvailabilityResult
  NameAvailabilityResult.nameAvailable: IsNameAvailable
  NodeProfile: ClusterComputeNodeProfile
  ProvisioningStatus: HDInsightProvisioningStatus
  ScaleActionType.scaleup: ScaleUp
  ScaleActionType.scaledown: ScaleDown
  Schedule: AutoscaleSchedule
  Schedule.startTime: StartOn
  Schedule.endTime: EndOn
  ScheduleDay: AutoscaleScheduleDay
  SecretReference: ClusterSecretReference
  SecretsProfile: ClusterSecretsProfile
  ServiceConfigListResult: ClusterServiceConfigListResult
  ServiceConfigListResultValueEntity: ClusterServiceConfigValueEntity
  ServiceConfigResult: ClusterServiceConfigResult
  ServiceStatus: HDInsightServiceStatus
  SparkUserPlugins: SparkUserPluginListResult
  SshProfile: ClusterSshProfile
  TrinoCoordinator.debug.enable: IsEnabled
  TrinoUserPlugin.enabled: IsEnabled
  TrinoUserPlugins: TrinoUserPluginListResult
  TrinoWorker.debug.enable: IsEnabled
  # TODO, remove these when service fix the Uri format before GA
  FlinkHiveCatalogOption.metastoreDbConnectionURL: MetastoreDBConnectionUriString
  FlinkStorageProfile.storageUri: StorageUriString
  HiveCatalogOption.metastoreDbConnectionURL: MetastoreDBConnectionUriString
  ScriptActionProfile.url: UriString
  SparkMetastoreSpec.thriftUrl: ThriftUriString
  SparkProfile.defaultStorageUrl: DefaultStorageUriString

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
  Db: DB|db

override-operation-name:
  Locations_CheckNameAvailability: CheckHDInsightNameAvailability

directive:
  - from: hdinsight.json
    where: $.definitions
    transform: >
      delete $.AksClusterProfile.properties.aksClusterAgentPoolIdentityProfile.allOf;
      $.AksClusterProfile.properties.aksClusterAgentPoolIdentityProfile['$ref'] = '#/definitions/IdentityProfile';
      delete $.ClusterPoolResourceProperties.properties.clusterPoolProfile.allOf;
      $.ClusterPoolResourceProperties.properties.clusterPoolProfile['$ref'] = '#/definitions/ClusterPoolProfile';
      delete $.ClusterPoolResourceProperties.properties.computeProfile.allOf;
      $.ClusterPoolResourceProperties.properties.computeProfile['$ref'] = '#/definitions/ClusterPoolComputeProfile';
      delete $.ClusterPoolResourceProperties.properties.aksClusterProfile.allOf;
      $.ClusterPoolResourceProperties.properties.aksClusterProfile['$ref'] = '#/definitions/AksClusterProfile';
      delete $.ClusterPoolResourceProperties.properties.networkProfile.allOf;
      $.ClusterPoolResourceProperties.properties.networkProfile['$ref'] = '#/definitions/ClusterPoolNetworkProfile';
      delete $.ClusterPoolResourceProperties.properties.logAnalyticsProfile.allOf;
      $.ClusterPoolResourceProperties.properties.logAnalyticsProfile['$ref'] = '#/definitions/ClusterPoolLogAnalyticsProfile';
      delete $.ConnectivityProfile.properties.web.allOf;
      $.ConnectivityProfile.properties.web['$ref'] = '#/definitions/WebConnectivityEndpoint';
      delete $.ClusterInstanceViewProperties.properties.status.allOf;
      $.ClusterInstanceViewProperties.properties.status['$ref'] = '#/definitions/ClusterInstanceViewStatus';
```
