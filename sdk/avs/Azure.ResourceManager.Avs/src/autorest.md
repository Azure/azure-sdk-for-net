# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Avs
namespace: Azure.ResourceManager.Avs
require: https://github.com/Azure/azure-rest-api-specs/blob/a032c2413b49d297196a0c64393e862433fccbb1/specification/vmware/resource-manager/readme.md
#tag: package-2023-03-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

override-operation-name:
  Locations_CheckQuotaAvailability: CheckAvsQuotaAvailability
  Locations_CheckTrialAvailability: CheckAvsTrialAvailability
  PrivateClouds_RotateVcenterPassword: RotateVCenterPassword

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

rename-mapping:
  Addon: AvsPrivateCloudAddon
  AddonProperties: AvsPrivateCloudAddonProperties
  CloudLink.properties.linkedCloud: -|arm-id
  Cluster: AvsPrivateCloudCluster
  Datastore: AvsPrivateCloudDatastore
  ExpressRouteAuthorization.properties.expressRouteAuthorizationId: -|arm-id
  ExpressRouteAuthorization.properties.expressRouteId: -|arm-id
  GlobalReachConnection.properties.expressRouteId: -|arm-id
  GlobalReachConnection.properties.peerExpressRouteCircuit: -|arm-id
  AvailabilityProperties: PrivateCloudAvailabilityProperties
  Circuit: ExpressRouteCircuit
  Encryption: CustomerManagedEncryption
  Endpoints: AvsPrivateCloudEndpoints
  IdentitySource: SingleSignOnIdentitySource
  IdentitySource.primaryServer: -|Uri
  IdentitySource.secondaryServer: -|Uri
  InternetEnum: InternetConnectivityState
  ScriptExecutionParameter: ScriptExecutionParameterDetails
  PSCredentialExecutionParameter: PSCredentialExecutionParameterDetails
  ScriptSecureStringExecutionParameter: ScriptSecureStringExecutionParameterDetails
  ScriptStringExecutionParameter: ScriptStringExecutionParameterDetails
  ScriptExecution.properties.scriptCmdletId: -|arm-id
  VirtualMachine: AvsPrivateCloudClusterVirtualMachine
  WorkloadNetworkDnsService.properties.dnsServiceIp: -|ip-address
  DnsServiceLogLevelEnum: DnsServiceLogLevel
  DnsServiceStatusEnum: DnsServiceStatus
  WorkloadNetworkDnsZone.properties.sourceIp: -|ip-address
  WorkloadNetworkPortMirroring: WorkloadNetworkPortMirroringProfile
  PortMirroringDirectionEnum: PortMirroringProfileDirection
  WorkloadNetworkPortMirroringProvisioningState: WorkloadNetworkPortMirroringProfileProvisioningState
  PortMirroringStatusEnum: PortMirroringProfileStatus
  SegmentStatusEnum: WorkloadNetworkSegmentStatus
  VMTypeEnum: WorkloadNetworkVmType
  VMGroupStatusEnum: WorkloadNetworkVmGroupStatus
  Quota: AvsSubscriptionQuotaAvailabilityResult
  QuotaEnabled: AvsSubscriptionQuotaEnabled
  Trial: AvsSubscriptionTrialAvailabilityResult
  TrialStatus: AvsSubscriptionTrialStatus
  Circuit.expressRouteID: -|arm-id
  Circuit.expressRoutePrivatePeeringID: -|arm-id
  MountOptionEnum: LunMountMode
  SslEnum: SslCertificateStatus
  OptionalParamEnum: ParameterOptionalityStatus
  VisibilityParameterEnum: ParameterVisibilityStatus
  ClusterProvisioningState: AvsPrivateCloudClusterProvisioningState
  DatastoreProvisioningState: AvsPrivateCloudDatastoreProvisioningState
  VirtualMachineRestrictMovement: AvsPrivateCloudClusterVirtualMachineRestrictMovement
  PrivateCloud.properties.vmotionNetwork: VMotionNetwork
  PrivateCloud.properties.vcenterPassword: VCenterPassword
  PrivateCloud.properties.vcenterCertificateThumbprint: VCenterCertificateThumbprint
  AdminCredentials.vcenterUsername: VCenterUsername
  AdminCredentials.vcenterPassword: VCenterPassword
  AffinityType: AvsPlacementPolicyAffinityType
  DiskPoolVolume.targetId: -|arm-id
  EncryptionState: AvsEncryptionState
  EncryptionVersionType: AvsEncryptionVersionType
  ManagementCluster: AvsManagementCluster
  NsxPublicIPQuotaRaisedEnum: NsxPublicIPQuotaRaisedStatus
  AffinityStrength: VmHostPlacementPolicyAffinityStrength
  ClusterZone: AvsClusterZone

prepend-rp-prefix:
- CloudLink
- CloudLinkStatus
- PrivateCloud
- PrivateCloudProvisioningState
- EncryptionKeyStatus
- EncryptionKeyVaultProperties

directive:
  - from: vmware.json
    where: $.definitions
    transform: >
      $.PrivateCloudProperties.properties.externalCloudLinks.items['x-ms-format'] = 'arm-id';
      $.WorkloadNetworkDnsZoneProperties.properties.dnsServerIps.items['x-ms-format'] = 'ip-address';
      delete $.ScriptExecutionProperties.properties.namedOutputs.additionalProperties;
      $.PlacementPolicyUpdateProperties.properties.vmMembers.items['x-ms-format'] = 'arm-id';
      $.VmHostPlacementPolicyProperties.properties.vmMembers.items['x-ms-format'] = 'arm-id';
      $.VmVmPlacementPolicyProperties.properties.vmMembers.items['x-ms-format'] = 'arm-id';
      $.ScriptCmdletProperties.properties.timeout['format'] = 'duration';
  - from: vmware.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/clusters/{clusterName}/listZones'].post
    transform: >
      $['x-ms-pageable'] = {
          'nextLinkName': null,
          'itemName': 'zones'
      }
    reason: add this directive so that the return type could become pageable with flattening the item inside ClusterZoneList.
```
