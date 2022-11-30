# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ServiceFabricManagedClusters
namespace: Azure.ResourceManager.ServiceFabricManagedClusters
require: https://github.com/Azure/azure-rest-api-specs/blob/53b1affe357b3bfbb53721d0a2002382a046d3b0/specification/servicefabricmanagedclusters/resource-manager/readme.md
tag: package-2022-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/environments/{environment}/managedClusterVersions/{clusterVersion}
- /subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedClusterVersions/{clusterVersion}
- /subscriptions/{subscriptionId}/providers/Microsoft.ServiceFabric/locations/{location}/managedUnsupportedVMSizes/{vmSize}

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
  LRS: Lrs
  SSD: Ssd

override-operation-name:
  managedAzResiliencyStatus_get: GetManagedAzResiliencyStatus
  NodeTypeSkus_List: GetAvailableSkus
  managedUnsupportedVMSizes_Get: GetManagedUnsupportedVmSize
  managedUnsupportedVMSizes_List: GetManagedUnsupportedVmSizes
  ManagedClusterVersion_GetByEnvironment: GetManagedClusterVersionByEnvironment

rename-mapping:
  ApplicationResource: ServiceFabricManagedApplication
  ApplicationTypeResource: ServiceFabricManagedApplicationType
  ApplicationTypeVersionResource: ServiceFabricManagedApplicationTypeVersion
  ApplicationUserAssignedIdentity: ApplicationUserAssignedIdentityInfo
  ManagedClusterCodeVersionResult: ServiceFabricManagedClusterVersion
  ManagedClusterCodeVersionResult.properties.supportExpiryUtc: VersionSupportExpireOn
  OsType: ServiceFabricManagedClusterOSType
  ManagedCluster: ServiceFabricManagedCluster
  ManagedCluster.properties.addonFeatures: AddOnFeatures
  ManagedCluster.properties.allowRdpAccess: IsRdpAccessAllowed
  ManagedCluster.properties.clusterCertificateThumbprints: -|any
  ManagedCluster.properties.clusterId: -|uuid
  ManagedCluster.properties.enableAutoOSUpgrade: IsAutoOSUpgradeEnabled
  ManagedCluster.properties.enableIpv6: IsIPv6Enabled
  ManagedCluster.properties.enableServicePublicIP: IsServicePublicIPEnabled
  ManagedCluster.properties.ipv4Address: -|ip-address
  ManagedCluster.properties.ipv6Address: -|ip-address
  ManagedCluster.properties.zonalResiliency: HasZoneResiliency
  Subnet: ManagedClusterSubnet
  Subnet.enableIpv6: IsIPv6Enabled
  Subnet.networkSecurityGroupId: -|arm-id
  AzureActiveDirectory: ManagedClusterAzureActiveDirectory
  ClientCertificate: ManagedClusterClientCertificate
  ClientCertificate.thumbprint: -|any
  ClientCertificate.issuerThumbprint: -|any
  ClusterState: ServiceFabricManagedClusterState
  ClusterUpgradeCadence: ManagedClusterUpgradeCadence
  ClusterUpgradeMode: ManagedClusterUpgradeMode
  SettingsSectionDescription: ClusterFabricSettingsSection
  SettingsParameterDescription: ClusterFabricSettingsParameterDescription
  IPTag: ManagedClusterIPTag
  LoadBalancingRule: ManagedClusterLoadBalancingRule
  NetworkSecurityRule: ServiceFabricManagedNetworkSecurityRule
  Direction: ServiceFabricManagedNetworkSecurityRuleDirection
  Access: ServiceFabricManagedNetworkTrafficAccess
  ManagedResourceProvisioningState: ServiceFabricManagedResourceProvisioningState
  ServiceEndpoint: ManagedClusterServiceEndpoint
  ServiceEndpoint.locations: -|azure-location
  NodeType: ServiceFabricManagedNodeType
  NodeType.properties.dataDiskSizeGB: DataDiskSizeInGB
  NodeType.properties.enableAcceleratedNetworking: IsAcceleratedNetworkingEnabled
  NodeType.properties.enableEncryptionAtHost: IsEncryptionAtHostEnabled
  NodeType.properties.enableOverProvisioning: IsOverProvisioningEnabled
  NodeType.properties.multiplePlacementGroups: HasMultiplePlacementGroups
  VmssDataDisk: NodeTypeVmssDataDisk
  VmssDataDisk.diskSizeGB: DiskSizeInGB
  VmssExtension: NodeTypeVmssExtension
  VmssExtension.properties.enableAutomaticUpgrade: IsAutomaticUpgradeEnabled
  VaultSecretGroup: NodeTypeVaultSecretGroup
  VaultCertificate: NodeTypeVaultCertificate
  DiskType: ServiceFabricManagedDataDiskType
  FrontendConfiguration: NodeTypeFrontendConfiguration
  FrontendConfiguration.loadBalancerBackendAddressPoolId: -|arm-id
  FrontendConfiguration.loadBalancerInboundNatPoolId: -|arm-id
  VmManagedIdentity.userAssignedIdentities: -|arm-id
  NodeTypeActionParameters: NodeTypeActionContent
  NodeTypeActionParameters.force: IsForced
  ServiceResource: ServiceFabricManagedService
  ServiceResourceProperties: ManagedServiceProperties
  ServiceResourcePropertiesBase: ManagedServiceBaseProperties
  ServiceCorrelation: ManagedServiceCorrelation
  ServiceCorrelationScheme: ManagedServiceCorrelationScheme
  ScalingPolicy: ManagedServiceScalingPolicy
  ScalingMechanism: ManagedServiceScalingMechanism
  ScalingTrigger: ManagedServiceScalingTrigger
  MoveCost: ServiceFabricManagedServiceMoveCost
  ApplicationUpgradePolicy.instanceCloseDelayDuration: InstanceCloseDelayDurationInSeconds
  FailureAction: PolicyViolationCompensationAction
  IPAddressType: NodeTypeFrontendConfigurationIPAddressType
  ProbeProtocol: ManagedClusterLoadBalanceProbeProtocol
  Protocol: ManagedClusterLoadBalancingRuleTransportProtocol
  Partition: ManagedServicePartitionScheme
  NsgProtocol: ServiceFabricManagedNsgProtocol
  NsgProtocol.ah: AH
  NodeTypeAvailableSku.resourceType: -|resource-type
  PartitionInstanceCountScaleMechanism: PartitionInstanceCountScalingMechanism
  PrivateEndpointNetworkPolicies: ManagedClusterSubnetPrivateEndpointNetworkPoliciesState
  PrivateLinkServiceNetworkPolicies: ManagedClusterSubnetPrivateLinkServiceNetworkPoliciesState
  ServiceLoadMetric: ManagedServiceLoadMetric
  ServiceLoadMetricWeight: ManagedServiceLoadMetricWeight
  ServicePackageActivationMode: ManagedServicePackageActivationMode
  ServicePlacementPolicy: ManagedServicePlacementPolicy
  ManagedVMSize: ServiceFabricManagedUnsupportedVmSize
  AddRemoveIncrementalNamedPartitionScalingMechanism: NamedPartitionAddOrRemoveScalingMechanism

directive:
  - remove-operation: OperationStatus_Get
  - remove-operation: OperationResults_Get
  - from: managedapplication.json
    where: $.definitions
    transform: >
      $.HealthCheckWaitDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckStableDuration['x-ms-format'] = 'duration-constant';
      $.HealthCheckRetryTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeDomainTimeout['x-ms-format'] = 'duration-constant';
      $.UpgradeTimeout['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.replicaRestartWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.quorumLossWaitDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.standByReplicaKeepDuration['x-ms-format'] = 'duration-constant';
      $.StatefulServiceProperties.properties.servicePlacementTimeLimit['x-ms-format'] = 'duration-constant';
  - from: managedcluster.json
    where: $.definitions
    transform: >
      $.ManagedClusterVersionDetails.properties.supportExpiryUtc['format'] = 'date-time';

```
