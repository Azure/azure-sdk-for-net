# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: MobileNetwork
namespace: Azure.ResourceManager.MobileNetwork
require: https://github.com/Azure/azure-rest-api-specs/blob/45ed7d13be79760a39301ff85cc0937f017329de/specification/mobilenetwork/resource-manager/readme.md
#tag: package-2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
use-model-reader-writer: true
client-side-validation: false
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-resource-name:
  /providers/Microsoft.MobileNetwork/packetCoreControlPlaneVersions/{versionName}: TenantPacketCoreControlPlaneVersion
  /subscriptions/{subscriptionId}/providers/Microsoft.MobileNetwork/packetCoreControlPlaneVersions/{versionName}: SubscriptionPacketCoreControlPlaneVersion

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
  AAD: Aad
  EPC: Epc
  EPC5GC: Epc5GC
  Ue: UE|ue

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/packetCoreControlPlanes/{packetCoreControlPlaneName}/ues/{ueId}/extendedInformation/default

rename-mapping:
  ManagedServiceIdentity: MobileNetworkManagedServiceIdentity
  SimGroup.identity: UserAssignedIdentity
  IdentityAndTagsObject: MobileNetworkResourcePatch
  IdentityAndTagsObject.identity: UserAssignedIdentity
  PacketCoreControlPlane.identity: UserAssignedIdentity
  CoreNetworkType: MobileNetworkCoreNetworkType
  VersionState: MobileNetworkVersionState
  TrafficControlPermission: MobileNetworkTrafficControlPermission
  TagsObject: MobileNetworkTagsPatch
  SliceConfiguration: MobileNetworkSliceConfiguration
  SiteProvisioningState: MobileNetworkSiteProvisioningState
  SimState: MobileNetworkSimState
  ServiceDataFlowTemplate: MobileNetworkServiceDataFlowTemplate
  SdfDirection: MobileNetworkSdfDirectionS
  ReinstallRequired: MobileNetworkReinstallRequired
  RecommendedVersion: MobileNetworkRecommendedVersion
  QosPolicy: MobileNetworkQosPolicy
  ProvisioningState: MobileNetworkProvisioningState
  PreemptionVulnerability: MobileNetworkPreemptionVulnerability
  PreemptionCapability: MobileNetworkPreemptionCapability
  PortReuseHoldTimes: MobileNetworkPortReuseHoldTimes
  PortRange: MobileNetworkPortRange
  PlmnId: MobileNetworkPlmnId
  PlatformType: MobileNetworkPlatformType
  PlatformConfiguration: MobileNetworkPlatformConfiguration
  Platform: MobileNetworkPlatform
  PduSessionType: MobileNetworkPduSessionType
  PacketCaptureStatus: MobileNetworkPacketCaptureStatus
  ObsoleteVersion: MobileNetworkObsoleteVersion
  NaptEnabled: NaptState
  ManagedServiceIdentityType: MobileNetworkManagedServiceIdentityType
  LocalDiagnosticsAccessConfiguration: MobileNetworkLocalDiagnosticsAccessConfiguration
  InterfaceProperties: MobileNetworkInterfaceProperties
  InstallationState: MobileNetworkInstallationState
  InstallationReason: MobileNetworkInstallationReason
  Installation: MobileNetworkInstallation
  HttpsServerCertificate: MobileNetworkHttpsServerCertificate
  DiagnosticsPackageStatus: MobileNetworkDiagnosticsPackageStatus
  CertificateProvisioning: MobileNetworkCertificateProvisioning
  BillingSku: MobileNetworkBillingSku
  AuthenticationType: MobileNetworkAuthenticationType
  Slice: MobileNetworkSlice
  Site: MobileNetworkSite
  SimPolicy: MobileNetworkSimPolicy
  SimGroup: MobileNetworkSimGroup
  Sim: MobileNetworkSim
  Service: MobileNetworkService
  PacketCapture: MobileNetworkPacketCapture
  DiagnosticsPackage: MobileNetworkDiagnosticsPackage
  DataNetwork: MobileDataNetwork
  AttachedDataNetwork: MobileAttachedDataNetwork
  EventHubConfiguration: MobileNetworkEventHubConfiguration
  EventHubConfiguration.id: -|arm-id
  RrcEstablishmentCause.SMS: Sms
  UeQOSFlow: UEQosFlow
  RoutingInfoModel: MobileNetworkRoutingInfo
  SimMove: SimMoveContent
  SimClone: SimCloneContent
  SignalingConfiguration: PacketCoreSignalingConfiguration
  PlatformType.AKS-HCI: AksHci

prepend-rp-prefix:
  - Ipv4Route
  - Ipv4RouteNextHop
  - NasEncryptionType

directive:
  # CodeGen don't support some definitions in v4 & v5 common types, here is an issue https://github.com/Azure/autorest.csharp/issues/3537 opened to fix this problem
  - from: v5/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;
  # CodeGen don't support some definitions in v4 & v5 common types, in v4 and v5 subscriptionId has the format of uuid, but the generator is not correctly handling it right now
  - from: v5/types.json
    where: $.parameters.SubscriptionIdParameter
    transform: >
      delete $.format;
```
