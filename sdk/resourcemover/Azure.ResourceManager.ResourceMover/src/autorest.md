# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ResourceMover
namespace: Azure.ResourceManager.ResourceMover
require: https://github.com/Azure/azure-rest-api-specs/blob/bab2f4389eb5ca73cdf366ec0a4af3f3eb6e1f6d/specification/resourcemover/resource-manager/readme.md
tag: package-2021-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  AffectedMoveResource.id: -|arm-id
  AutomaticResolutionProperties.moveResourceId: -|arm-id
  AzureResourceReference.sourceArmResourceId: -|arm-id
  LBFrontendIPConfigurationResourceSettings.privateIpAddress: -|ip-address
  ManualResolutionProperties.targetId: -|arm-id
  BulkRemoveRequest.validateOnly: IsValidateOnly
  CommitRequest.validateOnly: IsValidateOnly
  DiscardRequest.validateOnly: IsValidateOnly
  MoveResourceDependency.id: -|arm-id
  MoveResourceDependency.isOptional: -|boolean
  MoveResourceDependencyOverride.id: -|arm-id
  MoveResourceDependencyOverride.targetId: -|arm-id
  MoveResourceProperties.targetId: -|arm-id
  MoveResourceProperties.existingTargetId: -|arm-id
  NicIpConfigurationResourceSettings.primary: IsValidateOnly
  NicIpConfigurationResourceSettings.privateIpAddress: -|ip-address
  OperationStatus.endTime: EndOn|datetime
  OperationStatus.id: -|arm-id
  OperationStatus.startTime: startOn|datetime
  PrepareRequest.validateOnly: IsValidateOnly
  ResourceMoveRequest.validateOnly: IsValidateOnly
  UnresolvedDependency.id: -|arm-id
  #ResourceSettings.resourceType: -|resource-type, One value is here https://github.com/Azure/azure-rest-api-specs/blob/1b3b9c1dd4d2c875997ea0b392dc71418fb1f28d/specification/resourcemover/resource-manager/Microsoft.Migrate/stable/2021-08-01/resourcemovercollection.json#L2418 is not a valid ResourceType, so can't change this property's format to ResourceType
  VirtualMachineResourceSettings.targetAvailabilitySetId: -|arm-id
  AffectedMoveResource: MoverAffectedMoveResourceInfo
  AvailabilitySetResourceSettings: MoverAvailabilitySetResourceSettings
  AzureResourceReference: MoverAzureResourceReferenceInfo
  BulkRemoveRequest: MoverBulkRemoveContent
  CommitRequest: MoverCommitContent
  DependencyLevel: MoverDependencyLevel
  DependencyType: MoverDependencyType
  DiscardRequest: MoverDiscardContent
  Display: MoverDisplayInfo
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

override-operation-name:
  MoveCollections_ListRequiredFor: GetRequiredForResources

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'sourceId': 'arm-id'

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
      $.PrepareRequest.properties.moveResources.items['x-ms-format'] = 'arm-id';
      $.ResourceMoveRequest.properties.moveResources.items['x-ms-format'] = 'arm-id';
      $.CommitRequest.properties.moveResources.items['x-ms-format'] = 'arm-id';
      $.DiscardRequest.properties.moveResources.items['x-ms-format'] = 'arm-id';
      $.BulkRemoveRequest.properties.moveResources.items['x-ms-format'] = 'arm-id';
      $.VirtualMachineResourceSettings.properties.userManagedIdentities.items['x-ms-format'] = 'arm-id';

```
