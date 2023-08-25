# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: HDInsightContainers
namespace: Azure.ResourceManager.HDInsight.Containers
require: https://github.com/Azure/azure-rest-api-specs/blob/5372f410f6af3de9559b63defbd556a7b10c4e65/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md
# tag: package-2023-06-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  Action: FlinkJobAction
  Action.NEW: New
  AutoscaleProfile: ClusterAutoscaleProfile
  Cluster: HDInsightCluster
  ClusterPool: HDInsightClusterPool
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
  Db: DB|db

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
