# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ServiceFabric
namespace: Azure.ResourceManager.ServiceFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/784dcbc568c61801a33dfe197cb785ffe22a9dec/specification/servicefabric/resource-manager/readme.md
tag: package-2023-11-preview
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

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'clusterId': 'uuid'
  'principalId': 'uuid'
  '*Thumbprint': 'any'

rename-mapping:
  Cluster.properties.eventStoreServiceEnabled: IsEventStoreServiceEnabled
  Cluster.properties.infrastructureServiceManager: IsInfrastructureServiceManagerEnabled
  Cluster.properties.waveUpgradePaused: IsWaveUpgradePaused
  Cluster.properties.enableHttpGatewayExclusiveAuthMode: IsHttpGatewayExclusiveAuthModeEnabled
  ClusterUpdateParameters.properties.eventStoreServiceEnabled: IsEventStoreServiceEnabled
  ClusterUpdateParameters.properties.infrastructureServiceManager: IsInfrastructureServiceManagerEnabled
  ClusterUpdateParameters.properties.waveUpgradePaused: IsWaveUpgradePaused
  ClusterUpdateParameters.properties.enableHttpGatewayExclusiveAuthMode: IsHttpGatewayExclusiveAuthModeEnabled
  ClusterCodeVersionsResult.properties.supportExpiryUtc: SupportExpireOn
  ClusterVersionDetails.supportExpiryUtc: SupportExpireOn
  NodeTypeDescription.multipleAvailabilityZones: IsMultipleAvailabilityZonesSupported
  Cluster.properties.sfZonalUpgradeMode: ServiceFabricZonalUpgradeMode
  Cluster.properties.clusterEndpoint: -|uri
  Cluster.properties.managementEndpoint: -|uri
  Cluster.properties.upgradePauseEndTimestampUtc: upgradePauseEndOn
  Cluster.properties.upgradePauseStartTimestampUtc: upgradePauseStartOn
  ClusterUpdateParameters.properties.upgradePauseEndTimestampUtc: upgradePauseEndOn
  ClusterUpdateParameters.properties.upgradePauseStartTimestampUtc: upgradePauseStartOn
  DiagnosticsStorageAccountConfig.blobEndpoint: -|uri
  DiagnosticsStorageAccountConfig.queueEndpoint: -|uri
  DiagnosticsStorageAccountConfig.tableEndpoint: -|uri
  AddOnFeatures: ClusterAddOnFeatures
  ApplicationResource: ServiceFabricApplication
  ApplicationResourceList: ServiceFabricApplicationList
  ApplicationTypeResource: ServiceFabricApplicationType
  ApplicationTypeResourceList: ServiceFabricApplicationTypeList
  ApplicationTypeVersionResource: ServiceFabricApplicationTypeVersion
  ApplicationTypeVersionResourceList: ServiceFabricApplicationTypeVersionList
  AzureActiveDirectory: ClusterAadSetting
  CertificateDescription: ClusterCertificateDescription
  ClientCertificateCommonName: ClusterClientCertificateCommonName
  ClientCertificateThumbprint: ClusterClientCertificateThumbprint
  DurabilityLevel: ClusterDurabilityLevel
  EndpointRangeDescription: ClusterEndpointRangeDescription
  MoveCost: ApplicationMoveCost
  NodeTypeDescription: ClusterNodeTypeDescription
  Notification: ClusterNotification
  NotificationCategory: ClusterNotificationCategory
  NotificationChannel: ClusterNotificationChannel
  NotificationLevel: ClusterNotificationLevel
  NotificationTarget: ClusterNotificationTarget
  PartitionScheme: ApplicationPartitionScheme
  ReliabilityLevel: ClusterReliabilityLevel
  RollingUpgradeMode: ApplicationRollingUpgradeMode
  ServerCertificateCommonName: ClusterServerCertificateCommonName
  ServerCertificateCommonNames: ClusterServerCertificateCommonNames
  ServiceKind: ApplicationServiceKind
  ServiceResource: ServiceFabricService
  StoreName: ClusterCertificateStoreName
  UpgradeMode: ClusterUpgradeMode

prepend-rp-prefix:
  - Cluster
  - ClusterListResult
  - ClusterState
  - ProvisioningState
  - ServiceResource
  - VMSizeResource

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
  - from: application.json
    where: $.definitions
    transform: >
      $.HealthCheckStableDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckWaitDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckRetryTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeDomainTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeTimeout['x-ms-format'] = 'duration-constant';
      $.ApplicationUpgradePolicy.properties.upgradeReplicaSetCheckTimeout['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.replicaRestartWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.quorumLossWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.standByReplicaKeepDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.replicaRestartWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.quorumLossWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceUpdateProperties.properties.standByReplicaKeepDuration['x-ms-format'] = 'duration-constant';
      $.StatelessServiceProperties.properties.instanceCloseDelayDuration['x-ms-format'] = 'duration-constant';
      $.StatelessServiceUpdateProperties.properties.instanceCloseDelayDuration['x-ms-format'] = 'duration-constant';
  - from: cluster.json
    where: $.definitions
    transform: >
      $.ClusterUpgradePolicy.properties.upgradeReplicaSetCheckTimeout['x-ms-format'] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.healthCheckWaitDuration['x-ms-format'] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.healthCheckStableDuration['x-ms-format'] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.healthCheckRetryTimeout['x-ms-format'] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.upgradeDomainTimeout['x-ms-format'] = 'duration-constant';
      $.ClusterUpgradePolicy.properties.upgradeTimeout['x-ms-format'] = 'duration-constant';
      $.ClusterVersionDetails.properties.supportExpiryUtc['format'] = 'date-time';

```
