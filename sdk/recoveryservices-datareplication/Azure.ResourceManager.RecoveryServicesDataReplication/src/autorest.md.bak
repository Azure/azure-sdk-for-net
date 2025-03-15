# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: RecoveryServicesDataReplication
namespace: Azure.ResourceManager.RecoveryServicesDataReplication
require: https://github.com/Azure/azure-rest-api-specs/blob/64cddc58b25ae7d6e50cc0dfb5bc19af4ea23f65/specification/recoveryservicesdatareplication/resource-manager/readme.md
#tag: package-2021-02-16-preview
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

rename-mapping:
  AzStackHCIFabricModelCustomProperties.azStackHciSiteId: -|arm-id
  AzStackHCIFabricModelCustomProperties.fabricResourceId: -|arm-id
  AzStackHCIFabricModelCustomProperties.migrationSolutionId: -|arm-id
  DraModelProperties.lastHeartbeat: LastHeartbeatOn
  CheckNameAvailabilityModel: DataReplicationNameAvailabilityContent
  CheckNameAvailabilityModel.type: -|resource-type
  CheckNameAvailabilityResponseModel: DataReplicationNameAvailabilityResult
  CheckNameAvailabilityResponseModel.nameAvailable: IsNameAvailable
  DeploymentPreflightResource: DeploymentPreflightResourceInfo
  DeploymentPreflightResource.type: -|resource-type
  DraModel: DataReplicationDra
  DraModelCollection: DataReplicationDraListResult
  DraModelProperties: DataReplicationDraProperties
  EmailConfigurationModel: DataReplicationEmailConfiguration
  EmailConfigurationModelCollection: DataReplicationEmailConfigurationListResult
  EmailConfigurationModelProperties: DataReplicationEmailConfigurationProperties
  ErrorModel: DataReplicationErrorInfo
  EventModel: DataReplicationEvent
  EventModelCollection: DataReplicationEventListResult
  EventModelProperties: DataReplicationEventProperties
  EventModelProperties.resourceType: -|resource-type
  EventModelProperties.timeOfOccurrence: OccurredOn
  FabricModel: DataReplicationFabric
  FabricModelCollection: DataReplicationFabricListResult
  FabricModelProperties: DataReplicationFabricProperties
  FabricModelProperties.serviceResourceId: -|arm-id
  HealthErrorModel: DataReplicationHealthErrorInfo
  HealthStatus: DataReplicationHealthStatus
  HyperVMigrateFabricModelCustomProperties.hyperVSiteId: -|arm-id
  HyperVMigrateFabricModelCustomProperties.fabricResourceId: -|arm-id
  HyperVMigrateFabricModelCustomProperties.migrationSolutionId: -|arm-id
  HyperVToAzStackHCIDiskInput.storageContainerId: -|arm-id
  HyperVToAzStackHCIProtectedDiskProperties.storageContainerId: -|arm-id
  HyperVToAzStackHCIProtectedItemModelCustomProperties.targetHciClusterId: -|arm-id
  HyperVToAzStackHCIProtectedItemModelCustomProperties.targetArcClusterCustomLocationId: -|arm-id
  HyperVToAzStackHCIProtectedItemModelCustomProperties.fabricDiscoveryMachineId: -|arm-id
  HyperVToAzStackHCIProtectedItemModelCustomProperties.targetResourceGroupId: -|arm-id
  HyperVToAzStackHCIProtectedItemModelCustomProperties.storageContainerId: -|arm-id
  HyperVToAzStackHCIReplicationExtensionModelCustomProperties.hyperVFabricArmId: -|arm-id
  HyperVToAzStackHCIReplicationExtensionModelCustomProperties.hyperVSiteId: -|arm-id
  HyperVToAzStackHCIReplicationExtensionModelCustomProperties.azStackHciFabricArmId: -|arm-id
  HyperVToAzStackHCIReplicationExtensionModelCustomProperties.azStackHciSiteId: -|arm-id
  IdentityModel: DataReplicationIdentity
  InnerHealthErrorModel: DataReplicationInnerHealthErrorInfo
  PolicyModel: DataReplicationPolicy
  PolicyModelCollection: DataReplicationPolicyListResult
  PolicyModelProperties: DataReplicationPolicyProperties
  ProtectedItemModel: DataReplicationProtectedItem
  ProtectedItemModelCollection: DataReplicationProtectedItemListResult
  ProtectedItemModelProperties: DataReplicationProtectedItemProperties
  ProtectedItemModelProperties.resyncRequired: IsResyncRequired
  ProtectionState: DataReplicationProtectionState
  ProvisioningState: DataReplicationProvisioningState
  RecoveryPointModel: DataReplicationRecoveryPoint
  RecoveryPointModelCollection: DataReplicationRecoveryPointListResult
  RecoveryPointModelProperties: DataReplicationRecoveryPointProperties
  RecoveryPointType: DataReplicationRecoveryPointType
  ReplicationExtensionModel: DataReplicationReplicationExtension
  ReplicationExtensionModelCollection: DataReplicationReplicationExtensionListResult
  ReplicationExtensionModelProperties: DataReplicationReplicationExtensionProperties
  ReplicationVaultType: DataReplicationReplicationVaultType
  ResynchronizationState: DataReplicationResynchronizationState
  TaskModel: DataReplicationTask
  TaskState: DataReplicationTaskState
  TestFailoverState: DataReplicationTestFailoverState
  VaultModel: DataReplicationVault
  VaultModelCollection: DataReplicationVaultListResult
  VaultModelProperties: DataReplicationVaultProperties
  VaultModelProperties.serviceResourceId: -|arm-id
  VMwareMigrateFabricModelCustomProperties.vmwareSiteId: VMwareSiteId|arm-id
  VMwareMigrateFabricModelCustomProperties.migrationSolutionId: -|arm-id
  VMwareToAzStackHCIProtectedDiskProperties.storageContainerId: -|arm-id
  VMwareToAzStackHCIProtectedItemModelCustomProperties.targetHciClusterId: -|arm-id
  VMwareToAzStackHCIProtectedItemModelCustomProperties.targetArcClusterCustomLocationId: -|arm-id
  VMwareToAzStackHCIProtectedItemModelCustomProperties.storageContainerId: -|arm-id
  VMwareToAzStackHCIProtectedItemModelCustomProperties.targetResourceGroupId: -|arm-id
  VMwareToAzStackHCIProtectedItemModelCustomProperties.fabricDiscoveryMachineId: -|arm-id
  VMwareToAzStackHCIReplicationExtensionModelCustomProperties.vmwareFabricArmId: -|arm-id
  VMwareToAzStackHCIReplicationExtensionModelCustomProperties.vmwareSiteId: -|arm-id
  VMwareToAzStackHCIReplicationExtensionModelCustomProperties.azStackHciFabricArmId: -|arm-id
  VMwareToAzStackHCIReplicationExtensionModelCustomProperties.azStackHciSiteId: -|arm-id
  VMwareToAzStackHCIReplicationExtensionModelCustomProperties.storageAccountId: -|arm-id
  WorkflowModel: DataReplicationWorkflow
  WorkflowModelCollection: DataReplicationWorkflowListResult
  WorkflowModelProperties: DataReplicationWorkflowProperties
  WorkflowState: DataReplicationWorkflowState

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
  HCI: Hci

override-operation-name:
  CheckNameAvailability: CheckDataReplicationNameAvailability

directive:
  # Remove all operation methods that already exist in core
  - remove-operation: DraOperationStatus_Get
  - remove-operation: FabricOperationsStatus_Get
  - remove-operation: PolicyOperationStatus_Get
  - remove-operation: ProtectedItemOperationStatus_Get
  - remove-operation: ReplicationExtensionOperationStatus_Get
  - remove-operation: VaultOperationStatus_Get
  - remove-operation: WorkflowOperationStatus_Get
  # Remove anonymous models
  - from: recoveryservicesdatareplication.json
    where: $.definitions
    transform: >
      delete $.ProtectedItemModelProperties.properties.currentJob.allOf;
      $.ProtectedItemModelProperties.properties.currentJob['$ref'] = '#/definitions/ProtectedItemJobProperties';
      delete $.ProtectedItemModelProperties.properties.lastFailedEnableProtectionJob.allOf;
      $.ProtectedItemModelProperties.properties.lastFailedEnableProtectionJob['$ref'] = '#/definitions/ProtectedItemJobProperties';
      delete $.ProtectedItemModelProperties.properties.lastFailedPlannedFailoverJob.allOf;
      $.ProtectedItemModelProperties.properties.lastFailedPlannedFailoverJob['$ref'] = '#/definitions/ProtectedItemJobProperties';
      delete $.ProtectedItemModelProperties.properties.lastTestFailoverJob.allOf;
      $.ProtectedItemModelProperties.properties.lastTestFailoverJob['$ref'] = '#/definitions/ProtectedItemJobProperties';
  # There are incorrect x-ms-discriminator-value in examples, should fix in the later
  - from: recoveryservicesdatareplication.json
    where: $.definitions
    transform: >
      $.GeneralDraModelCustomProperties = {
        "description": "General DRA model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/DraModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "DraModelCustomProperties"
      };
      $.GeneralFabricModelCustomProperties = {
        "description": "General fabric model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/FabricModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "FabricModelCustomProperties"
      };
      $.GeneralPolicyModelCustomProperties = {
        "description": "General Policy model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/PolicyModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "PolicyModelCustomProperties"
      };
      $.GeneralProtectedItemModelCustomProperties = {
        "description": "General Protected item model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/ProtectedItemModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "ProtectedItemModelCustomProperties"
      };
      $.GeneralPlannedFailoverModelCustomProperties = {
        "description": "General planned failover model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/PlannedFailoverModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "PlannedFailoverModelCustomProperties"
      };
      $.GeneralReplicationExtensionModelCustomProperties = {
        "description": "General Replication extension model custom properties.",
        "type": "object",
        "allOf": [
          {
            "$ref": "#/definitions/ReplicationExtensionModelCustomProperties"
          }
        ],
        "x-ms-discriminator-value": "ReplicationExtensionModelCustomProperties"
      };
```
