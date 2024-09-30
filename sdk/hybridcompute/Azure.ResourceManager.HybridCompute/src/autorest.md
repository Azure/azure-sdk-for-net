# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: HybridCompute
namespace: Azure.ResourceManager.HybridCompute
require: https://github.com/Azure/azure-rest-api-specs/blob/b48d5d72073a296514d3d4db77887d8711526ccc/specification/hybridcompute/resource-manager/readme.md
#tag: package-preview-2024-05
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  # Mitigate the duplication schema named 'ErrorDetail'
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true
use-write-core: true

#mgmt-debug:
#  show-serialized-names: true

prepend-rp-prefix:
  - CloudMetadata
  - ConfigurationExtension
  - ConnectionDetail
  - ExecutionState
  - ExtensionValue
  - IpAddress
  - License
  - LicenseDetails
  - LicenseEdition
  - LicenseState
  - LicenseStatus
  - LicenseTarget
  - LicenseType
  - LinuxParameters
  - Machine
  - MachineExtension
  - NetworkInterface
  - NetworkProfile
  - OSProfile
  - OsType
  - PrivateEndpointConnectionProperties
  - ProductFeature
  - ProvisioningState
  - PublicNetworkAccessType
  - ResourceUpdate
  - Subnet
  - ServiceStatus
  - ServiceStatuses
  - WindowsParameters
  - AccessMode
  - ResourceAssociation
  - AccessRule
  - AccessRuleDirection
  - ProgramYear
  - ProvisioningIssue
  - ProvisioningIssueSeverity
  - ProvisioningIssueType
  - Gateway
  - GatewayUpdate
  - GatewayType

list-exception: 
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{baseProvider}/{baseResourceType}/{baseResourceName}/providers/Microsoft.HybridCompute/settings/{settingsResourceName}

rename-mapping:
  AgentUpgrade.enableAutomaticUpgrade: IsAutomaticUpgradeEnabled
  AgentUpgrade.lastAttemptTimestamp: LastAttemptedOn
  ArcKindEnum.AVS: Avs
  ArcKindEnum.HCI: Hci
  ArcKindEnum.SCVMM: ScVmm
  ArcKindEnum.EPS: Eps
  ArcKindEnum.GCP: Gcp
  ArcKindEnum.AWS: Aws
  EsuServerType.Datacenter: DataCenter
  ConnectionDetail.id: -|arm-id
  LocationData: HybridComputeLocation
  LicenseEdition.Datacenter: DataCenter
  LicenseStatus.OOBGrace: OobGrace
  LicenseStatus.OOTGrace: OotGrace
  LicenseType.ESU: Esu
  LicenseProfileMachineInstanceView.softwareAssurance.softwareAssuranceCustomer: IsSoftwareAssuranceCustomer
  LicenseProfileProductType.WindowsIoTEnterprise: WindowsIotEnterprise
  LicenseProfileStorageModelEsuProperties.assignedLicenseImmutableId: -|uuid
  Machine.properties.adFqdn: ADFqdn
  Machine.properties.mssqlDiscovered: MSSqlDiscovered
  MachineAssessPatchesResult.rebootPending: IsRebootPending
  OSProfileLinuxConfiguration: HybridComputeLinuxConfiguration
  OSProfileWindowsConfiguration: HybridComputeWindowsConfiguration
  PatchOperationStatus: MachineOperationStatus
  PatchServiceUsed.YUM: Yum
  PatchServiceUsed.APT: Apt
  PrivateLinkScopeValidationDetails.id: -|arm-id
  RunCommandManagedIdentity.clientId: -|uuid
  RunCommandManagedIdentity.objectId: -|uuid
  StatusLevelTypes: HybridComputeStatusLevelType
  StatusTypes: HybridComputeStatusType
  OSProfileWindowsConfiguration.patchSettings.enableHotpatching: IsHotpatchingEnabled
  PatchSettingsStatus: HybridComputePatchSettingsStatus
  Settings: HybridComputeTargetResourceSettings
  OSProfileLinuxConfiguration.patchSettings.enableHotpatching: IsHotpatchingEnabled

override-operation-name:
  Settings_Update: UpdateTargetResourceSetting

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

models-to-treat-empty-string-as-null:
  - AgentConfiguration

directive:
  - from: HybridCompute.json
    where: $.definitions.MachineInstallPatchesParameters.properties.maximumDuration
    transform: $['format'] = 'duration'

  - from: HybridCompute.json
    where: $.definitions.MachineUpdateProperties.properties.privateLinkScopeResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.privateLinkScopeResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.AgentUpgrade.properties.correlationId
    transform: $['format'] = 'uuid'

  - from: HybridCompute.json
    where: $.definitions.AgentUpgrade.properties.lastAttemptTimestamp
    transform: $['format'] = 'date-time'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.vmUuid
    transform: $['format'] = 'uuid'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.vmId
    transform: $['format'] = 'uuid'

  - from: HybridCompute.json
    where: $.definitions.MachineUpdateProperties.properties.parentClusterResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineProperties.properties.parentClusterResourceId
    transform: $['format'] = 'arm-id'

  - from: HybridCompute.json
    where: $.definitions.MachineAssessPatchesResult.properties.assessmentActivityId
    transform: $['format'] = 'uuid'

  # set expand property of list and show to be both strings
  - from: HybridCompute.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}"].get.parameters
    transform: >-
      return [
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "name": "machineName",
            "in": "path",
            "required": true,
            "type": "string",
            "pattern": "^[a-zA-Z0-9-_\\.]{1,54}$",
            "minLength": 1,
            "maxLength": 54,
            "description": "The name of the hybrid machine."
          },
          {
            "name": "$expand",
            "in": "query",
            "required": false,
            "type": "string",
            "description": "The expand expression to apply on the operation.",
          }
        ]

  # add 200 response to run-command delete
  - from: HybridCompute.json
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/runCommands/{runCommandName}"].delete.responses
    transform: >-
      return {
        "200": {
          "description": "OK"
        },
        "202": {
          "description": "Accepted",
          "headers": {
            "Location": {
              "description": "The URL of the resource used to check the status of the asynchronous operation.",
              "type": "string"
            },
            "Retry-After": {
              "description": "The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation.",
              "type": "integer",
              "format": "int32"
            },
            "Azure-AsyncOperation": {
              "description": "The URI to poll for completion status.",
              "type": "string"
            }
          }
        },
        "204": {
          "description": "No Content"
        },
        "default": {
          "description": "Error response describing why the operation failed.",
          "schema": {
            "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/f6278b35fb38d62aadb7a4327a876544d5d7e1e4/specification/common-types/resource-management/v3/types.json#/definitions/ErrorResponse"
          }
        }
      }

  # we don't want user to interact with them / we don't support some operations
  - remove-operation: MachineRunCommands_Update #PATCH
  # internal operations
  - remove-operation: AgentVersion_List
  - remove-operation: AgentVersion_Get
  # we don't use them, pending to remove in the future
  - remove-operation: HybridIdentityMetadata_Get
  - remove-operation: HybridIdentityMetadata_ListByMachines
  # we don't want user to interact with them
  - remove-operation: Settings_Get
  - remove-operation: Settings_Patch
  # adding it will remove HybridComputeLicenseData resource and create HybridComputeLicensePatch resouce and cause other ESU commands to fail  
  - remove-operation: Licenses_Update #PATCH

```
