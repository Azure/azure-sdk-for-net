# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ResourceMover
namespace: Azure.ResourceManager.ResourceMover
require: https://github.com/Azure/azure-rest-api-specs/blob/bf2585e9f0696cc8d5f230481612a37eac542f39/specification/resourcemover/resource-manager/readme.md
#tag: package-2023-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

rename-mapping:
  AffectedMoveResource.id: -|arm-id
  AffectedMoveResource.moveResources: MoverResources
  AutomaticResolutionProperties.moveResourceId: ResourceId|arm-id
  AzureResourceReference.sourceArmResourceId: -|arm-id
  BulkRemoveRequest.moveResourceInputType: MoverResourceInputType
  BulkRemoveRequest.moveResources: MoverResources
  CommitRequest.moveResourceInputType: MoverResourceInputType
  CommitRequest.moveResources: MoverResources
  DiscardRequest.moveResourceInputType: MoverResourceInputType
  DiscardRequest.moveResources: MoverResources
  LBFrontendIPConfigurationResourceSettings.privateIpAddress: PrivateIPAddressStringValue
  ManualResolutionProperties.targetId: -|arm-id
  MoveErrorInfo.moveResources: InfoMoverResources
  MoveResourceDependency.id: -|arm-id
  MoveResourceDependency.isOptional: IsDependencyOptional
  MoveResourceDependencyOverride.id: -|arm-id
  MoveResourceDependencyOverride.targetId: -|arm-id
  MoveResourceProperties.targetId: -|arm-id
  MoveResourceProperties.existingTargetId: -|arm-id
  MoveResourceInputType.MoveResourceId: MoverResourceId
  MoveResourceInputType.MoveResourceSourceId: MoverResourceSourceId
  NicIpConfigurationResourceSettings.primary: IsPrimary
  NicIpConfigurationResourceSettings.privateIpAddress: PrivateIPAddressStringValue
  OperationStatus.endTime: EndOn
  OperationStatus.id: -|arm-id
  OperationStatus.startTime: startOn
  PrepareRequest.moveResourceInputType: MoverResourceInputType
  PrepareRequest.moveResources: MoverResources
  ResourceMoveRequest.moveResourceInputType: MoverResourceInputType
  ResourceMoveRequest.moveResources: MoverResources
  UnresolvedDependency.id: -|arm-id
  #ResourceSettings.resourceType: -|resource-type, One value is here https://github.com/Azure/azure-rest-api-specs/blob/1b3b9c1dd4d2c875997ea0b392dc71418fb1f28d/specification/resourcemover/resource-manager/Microsoft.Migrate/stable/2021-08-01/resourcemovercollection.json#L2418 is not a valid ResourceType, so can't change this property's format to ResourceType
  VirtualMachineResourceSettings.targetAvailabilitySetId: -|arm-id
  AffectedMoveResource: AffectedMoverResourceInfo
  AvailabilitySetResourceSettings: MoverAvailabilitySetResourceSettings
  AzureResourceReference: MoverResourceReferenceInfo
  BulkRemoveRequest: MoverBulkRemoveContent
  CommitRequest: MoverCommitContent
  DependencyLevel: MoverDependencyLevel
  DependencyType: MoverDependencyType
  DiscardRequest: MoverDiscardContent
  Display: MoverDisplayInfo
  JobName: MoverResourceJobName
  JobStatus: MoverResourceJobStatus
  LBBackendAddressPoolResourceSettings: LoadBalancerBackendAddressPoolResourceSettings
  LBFrontendIPConfigurationResourceSettings: LoadBalancerFrontendIPConfigurationResourceSettings
  LoadBalancerBackendAddressPoolReference: LoadBalancerBackendAddressPoolReferenceInfo
  LoadBalancerNatRuleReference: LoadBalancerNatRuleReferenceInfo
  MoveCollection: MoverResourceSet
  MoveCollectionProperties.sourceRegion: sourceLocation|azure-location
  MoveCollectionProperties.targetRegion: targetLocation|azure-location
  MoveCollectionProperties.moveRegion: moveLocation|azure-location
  MoveCollectionProperties: MoverResourceSetProperties
  MoveResource: MoverResource
  MoveResourceCollection: MoverResourceList
  MoveResourceDependency: MoverResourceDependency
  MoveResourceDependencyOverride: MoverResourceDependencyOverride
  MoveResourceInputType: MoverResourceInputType
  MoveResourceProperties: MoverResourceProperties
  MoveResourcePropertiesMoveStatus: MoverResourcePropertiesMoveStatus
  MoveResourceStatus: MoverResourceStatus
  MoveState: MoverResourceMoveState
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
  ResolutionType: MoverResourceResolutionType
  ResourceMoveRequest: MoverResourceMoveRequest
  ResourceSettings: MoverResourceSettings
  SubnetReference: SubnetReferenceInfo
  Summary: MoverSummaryItemInfo
  SummaryCollection: MoverSummaryList
  TargetAvailabilityZone: MoverTargetAvailabilityZone
  UnresolvedDependency: MoverUnresolvedDependency
  UnresolvedDependencyCollection: MoverUnresolvedDependencyList
  ZoneRedundant: ResourceZoneRedundantSetting
  VirtualNetworkResourceSettings: MoverVirtualNetworkResourceSettings

override-operation-name:
  MoveCollections_ListRequiredFor: GetRequiredForResources

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'sourceId': 'arm-id'

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
      $.MoveCollectionProperties.properties.errors['x-nullable'] = true;
      $.MoveResourceProperties.properties.targetId['x-nullable'] = true;
      $.MoveResourceProperties.properties.existingTargetId['x-nullable'] = true;
      $.MoveResourceProperties.properties.errors['x-nullable'] = true;
      $.VirtualNetworkResourceSettings.properties.addressSpace['x-nullable'] = true;
      $.VirtualNetworkResourceSettings.properties.dnsServers['x-nullable'] = true;
      $.VirtualNetworkResourceSettings.properties.subnets['x-nullable'] = true;
      $.VirtualNetworkResourceSettings.properties.tags['x-nullable'] = true;
      $.MoveResourceStatus.properties.jobStatus['x-nullable'] = true;
      $.MoveResourceStatus.properties.errors['x-nullable'] = true;
      $.SubnetResourceSettings.properties.networkSecurityGroup['x-nullable'] = true;
      $.MoveResourceCollection.properties.summaryCollection['x-nullable'] = true;
      $.OperationStatus.properties.error['x-nullable'] = true;
      $.OperationStatusError.properties.additionalInfo['x-nullable'] = true;
      $.MoveResourceProperties.properties.resourceSettings['x-nullable'] = true;
      $.MoveResourceProperties.properties.sourceResourceSettings['x-nullable'] = true;
      $.OperationStatus.properties.startTime['format'] = 'date-time';
      $.OperationStatus.properties.endTime['format'] = 'date-time';
  - from: resourcemovercollection.json
    where: $.parameters
    transform: >
      $.moveResourceName['x-ms-client-name'] = 'moverResourceName';
      $.moveCollectionName['x-ms-client-name'] = 'moverResourceSetName';
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'moveCollectionName')]
    transform: >
      $['x-ms-client-name'] = 'moverResourceSetName';
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'moveResourceName')]
    transform: >
      $['x-ms-client-name'] = 'moverResourceName';
```
