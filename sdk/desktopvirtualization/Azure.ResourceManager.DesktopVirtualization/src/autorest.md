# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: true
csharp: true
library-name: DesktopVirtualization
namespace: Azure.ResourceManager.DesktopVirtualization
require: https://github.com/Azure/azure-rest-api-specs/blob/9d449f35c2a8707d446a86d80c3732c909b1872f/specification/desktopvirtualization/resource-manager/readme.md
# tag: package-2023-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

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
  Application: VirtualApplication
  Application.properties.iconContent: -|any
  ApplicationType: VirtualApplicationType
  ApplicationGroup: VirtualApplicationGroup
  ApplicationGroup.properties.cloudPcResource: IsCloudPcResource
  ApplicationGroup.properties.hostPoolArmPath: HostPoolId|arm-id
  ApplicationGroup.properties.workspaceArmPath: WorkspaceId|arm-id
  ApplicationGroupType: VirtualApplicationGroupType
  CommandLineSetting: VirtualApplicationCommandLineSetting
  Desktop: VirtualDesktop
  Desktop.properties.iconContent: -|any
  DesktopGroup: VirtualDesktopGroup
  Workspace: VirtualWorkspace
  HostPool.properties.cloudPcResource: IsCloudPcResource
  HostPool.properties.ssoadfsAuthority: SsoAdfsAuthority
  HostPool.properties.validationEnvironment: IsValidationEnvironment
  HostPoolPatch.properties.ssoadfsAuthority: SsoAdfsAuthority
  HostPoolPatch.properties.validationEnvironment: IsValidationEnvironment
  HostPoolType.BYODesktop: BringYourOwnDesktop
  MsixPackage.properties.lastUpdated: LastUpdatedOn
  ResourceModelWithAllowedPropertySet.managedBy: -|arm-id
  SessionHost.properties.lastUpdateTime: LastUpdatedOn
  SessionHost.properties.lastHeartBeat: LastHeartBeatOn
  SessionHost.properties.resourceId: -|arm-id
  SessionHost.properties.virtualMachineId: VmId
  Workspace.properties.cloudPcResource: IsCloudPcResource
  Status: SessionHostStatus
  Operation: MigrationOperation
  ExpandMsixImage.properties.lastUpdated: LastUpdatedOn
  HealthCheckName: SessionHostHealthCheckName
  HealthCheckResult: SessionHostHealthCheckResult
  SSOSecretType: HostPoolSsoSecretType
  LoadBalancerType: HostPoolLoadBalancerType
  MigrationRequestProperties: DesktopVirtualizationMigrationProperties
  RegistrationInfo: HostPoolRegistrationInfo
  RegistrationInfoPatch: HostPoolRegistrationInfoPatch
  RegistrationTokenOperation: HostPoolRegistrationTokenOperation
  ScalingHostPoolReference.hostPoolArmPath: HostPoolId|arm-id
  ScalingHostPoolReference.scalingPlanEnabled: IsScalingPlanEnabled
  SendMessage: UserSessionMessage
  SessionState: UserSessionState
  StartMenuItem: DesktopVirtualizationStartMenuItem
  StopHostsWhen: DesktopVirtualizationStopHostsWhen
  UpdateState: SessionHostUpdateState
  MsixPackageApplications.rawIcon: -|any
  MsixPackageApplications.rawPng: -|any
  ScalingPlan.properties.hostPoolType: ScalingHostPoolType
  Time: ScalingActionTime
  AgentUpdateProperties: SessionHostAgentUpdateProperties
  AgentUpdateProperties.useSessionHostLocalTime: DoesUseSessionHostLocalTime
  AgentUpdatePatchProperties: SessionHostAgentUpdatePatchProperties
  AgentUpdatePatchProperties.useSessionHostLocalTime: DoesUseSessionHostLocalTime
  MaintenanceWindowProperties: SessionHostMaintenanceWindowProperties
  HostpoolPublicNetworkAccess: HostPoolPublicNetworkAccess
  PrivateLinkResource: DesktopVirtualizationPrivateLinkResourceData
  PrivateEndpointConnectionWithSystemData: DesktopVirtualizationPrivateEndpointConnectionData
  PublicNetworkAccess: DesktopVirtualizationPublicNetworkAccess

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
