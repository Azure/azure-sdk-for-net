# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: true
csharp: true
library-name: DesktopVirtualization
namespace: Azure.ResourceManager.DesktopVirtualization
require: https://github.com/Azure/azure-rest-api-specs/blob/ec07fc78c6c25b68107f8ff419d137ffecced005/specification/desktopvirtualization/resource-manager/readme.md
# tag: package-2024-04
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
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

models-to-treat-empty-string-as-null:
  - SessionHostData

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
  Pc: PC|pc
  SxS: Sxs
  RTC: Rtc

rename-mapping:
  AgentUpdatePatchProperties.useSessionHostLocalTime: DoesUseSessionHostLocalTime
  AgentUpdatePatchProperties: SessionHostAgentUpdatePatchProperties
  AgentUpdateProperties.useSessionHostLocalTime: DoesUseSessionHostLocalTime
  AgentUpdateProperties: SessionHostAgentUpdateProperties
  AppAttachPackageArchitectures.ALL: All
  AppAttachPackageArchitectures.ARM: Arm
  AppAttachPackageArchitectures.ARM64: Arm64
  AppAttachPackageInfoProperties.certificateExpiry: CertificateExpireOn
  AppAttachPackageInfoProperties.lastUpdated: LastUpdatedOn
  AppAttachPackagePatchProperties.keyVaultURL: KeyVaultUri|uri
  AppAttachPackageProperties.keyVaultURL: KeyVaultUri|uri
  Application.properties.iconContent: -|any
  Application: VirtualApplication
  ApplicationGroup.properties.cloudPcResource: IsCloudPcResource
  ApplicationGroup.properties.hostPoolArmPath: HostPoolId|arm-id
  ApplicationGroup.properties.workspaceArmPath: WorkspaceId|arm-id
  ApplicationGroup: VirtualApplicationGroup
  ApplicationGroupType: VirtualApplicationGroupType
  ApplicationType: VirtualApplicationType
  CommandLineSetting: VirtualApplicationCommandLineSetting
  Desktop.properties.iconContent: -|any
  Desktop: VirtualDesktop
  ExpandMsixImage.properties.lastUpdated: LastUpdatedOn
  HealthCheckName: SessionHostHealthCheckName
  HealthCheckResult: SessionHostHealthCheckResult
  HostPool.properties.cloudPcResource: IsCloudPcResource
  HostPool.properties.ssoadfsAuthority: SsoAdfsAuthority
  HostPool.properties.validationEnvironment: IsValidationEnvironment
  HostPoolPatch.properties.ssoadfsAuthority: SsoAdfsAuthority
  HostPoolPatch.properties.validationEnvironment: IsValidationEnvironment
  HostpoolPublicNetworkAccess: HostPoolPublicNetworkAccess
  HostPoolType.BYODesktop: BringYourOwnDesktop
  LoadBalancerType: HostPoolLoadBalancerType
  MaintenanceWindowProperties: SessionHostMaintenanceWindowProperties
  MsixPackage.properties.lastUpdated: LastUpdatedOn
  MsixPackageApplications.rawIcon: -|any
  MsixPackageApplications.rawPng: -|any
  PrivateEndpointConnectionWithSystemData: DesktopVirtualizationPrivateEndpointConnectionData
  PrivateLinkResource: DesktopVirtualizationPrivateLinkResourceData
  ProvisioningState: AppAttachPackageProvisioningState
  PublicNetworkAccess: DesktopVirtualizationPublicNetworkAccess
  RegistrationInfo: HostPoolRegistrationInfo
  RegistrationInfoPatch: HostPoolRegistrationInfoPatch
  RegistrationTokenOperation: HostPoolRegistrationTokenOperation
  ResourceModelWithAllowedPropertySet.managedBy: -|arm-id
  ScalingHostPoolReference.hostPoolArmPath: HostPoolId|arm-id
  ScalingHostPoolReference.scalingPlanEnabled: IsScalingPlanEnabled
  ScalingPlan.properties.hostPoolType: ScalingHostPoolType
  SendMessage: UserSessionMessage
  SessionHost.properties.lastHeartBeat: LastHeartBeatOn
  SessionHost.properties.lastUpdateTime: LastUpdatedOn
  SessionHost.properties.resourceId: -|arm-id
  SessionHost.properties.virtualMachineId: VmId
  SessionState: UserSessionState
  SSOSecretType: HostPoolSsoSecretType
  StartMenuItem: DesktopVirtualizationStartMenuItem
  Status: SessionHostStatus
  StopHostsWhen: DesktopVirtualizationStopHostsWhen
  Time: ScalingActionTime
  UpdateState: SessionHostUpdateState
  Workspace.properties.cloudPcResource: IsCloudPcResource
  Workspace: VirtualWorkspace

prepend-rp-prefix:
  - DayOfWeek

directive:
# remove this useless allOf so that we will not have a `ResourceModelWithAllowedPropertySetSku` type
  - from: types.json
    where: $.definitions.ResourceModelWithAllowedPropertySet.properties.sku
    transform: >
      return {
          "$ref": "#/definitions/Sku"
        }
# nullable issue
  - from: desktopvirtualization.json
    where: $.definitions.ApplicationGroupProperties.properties.workspaceArmPath
    transform: $["x-nullable"] = true
# remove the format so that we can use rename-mapping to change the property type to BinaryData
  - from: desktopvirtualization.json
    where: $.definitions
    transform: >
      delete $.MsixPackageApplications.properties.rawIcon['format'];
      delete $.MsixPackageApplications.properties.rawPng['format'];
      delete $.ApplicationProperties.properties.iconContent['format'];
      delete $.DesktopProperties.properties.iconContent['format'];
```
