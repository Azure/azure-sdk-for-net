# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Migrate
namespace: Azure.ResourceManager.Migrate
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/resourcemover/resource-manager/readme.md
tag: package-2021-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

rename-mapping:
  AffectedMoveResource.id: -|arm-id
  AffectedMoveResource.sourceId: -|arm-id
  ManualResolutionProperties.targetId: -|arm-id
  MoveResourceDependencyOverride.id: -|arm-id
  MoveResourceDependencyOverride.targetId: -|arm-id
  MoveResourceProperties.sourceId: -|arm-id
  VirtualMachineResourceSettings.targetAvailabilitySetId: -|arm-id
  #ResourceSettings.resourceType: -|resource-type
  AffectedMoveResource: MoverAffectedMoveResourceInfo
  AvailabilitySetResourceSettings: MoverAvailabilitySetResourceSettings
  AzureResourceReference: MoverAzureResourceReferenceInfo
  BulkRemoveRequest: MoverBulkRemoveContent
  CommitRequest: MoverCommitContent
  DependencyLevel: MoverDependencyLevel
  DependencyType: MoverDependencyType
  DiscardRequest: MoverDiscardContent
  Display: MoverDisplayInfo
  #Identity: MoveCollectionIdentityProperties
  JobName: MoveResourceJobName
  JobStatus: MoveResourceJobStatus
  LBBackendAddressPoolResourceSettings: LoadBalancerBackendAddressPoolResourceSettings
  LBFrontendIPConfigurationResourceSettings: LoadBalancerFrontendIPConfigurationResourceSettings
  LoadBalancerBackendAddressPoolReference: LoadBalancerBackendAddressPoolReferenceInfo
  LoadBalancerNatRuleReference: LoadBalancerNatRuleReferenceInfo
  MoveResourceCollection: MoveResourceList
  MoveState: MoveResourceState
  NsgReference: NetworkSecurityGroupResourceReferenceInfo
  NsgSecurityRule: NetworkSecurityGroupSecurityRule
  OperationErrorAdditionalInfo: MoverOperationErrorAdditionalInfo
  OperationsDiscovery: MoverOperationsDiscovery
  OperationsDiscoveryCollection: MoverOperationsDiscoveryList
  OperationStatus: MoverOperationStatus
  OperationStatusError: MoverOperationStatusError
  PrepareRequest: MoverPrepareRequest
  ProvisioningState: MoverProvisioningState
  ProxyResourceReference: ProxyResourceReferenceInfo
  PublicIpReference: PublicIpReferenceInfo
  RequiredForResourcesCollection: RequiredForResourcesList
  ResolutionType: MoveResourceResolutionType
  ResourceMoveRequest: MoverResourceMoveRequest
  ResourceSettings: MoverResourceSettings
  SubnetReference: SubnetReferenceInfo
  Summary: MoverSummaryItemInfo
  SummaryCollection: MoverSummaryList
  TargetAvailabilityZone: MoverTargetAvailabilityZone
  UnresolvedDependency: MoverUnresolvedDependency
  UnresolvedDependencyCollection: MoverUnresolvedDependencyList
  ZoneRedundant: ResourceZoneRedundantSetting

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'resourceType': 'resource-type'
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

directive:
  - from: resourcemovercollection.json
    where: $.definitions
    transform: >
      $.Identity.properties.principalId['readOnly'] = true;
      $.Identity.properties.tenantId['readOnly'] = true;

```
