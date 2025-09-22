# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: true
csharp: true
library-name: DevCenter
namespace: Azure.ResourceManager.DevCenter
require: https://github.com/Azure/azure-rest-api-specs/blob/c0ba17235b00917bf1b734b7b537bf532fe7fce0/specification/devcenter/resource-manager/readme.md
# tag: package-preview-2025-07-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#   show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

prepend-rp-prefix:
  - Capability
  - CatalogListResult
  - Catalog
  - EndpointDetail
  - EnvironmentRole
  - EnvironmentType
  - Gallery
  - GitCatalog
  - HealthCheck
  - HealthCheckStatus
  - HealthStatus
  - HealthStatusDetail
  - HibernateSupport
  - Image
  - ImageListResult
  - ImageReference
  - LicenseType
  - NetworkConnection
  - OperationStatus
  - Pool
  - Project
  - ProvisioningState
  - ResourceRange
  - Schedule
  - ScheduledType
  - ScheduledFrequency
  - ScheduleEnableStatus
  - TrackedResourceUpdate
  - UsageName
  - UsageUnit
  - CatalogSyncState

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  VCPU: vCpu
  VCPUs: vCpus
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
  DevCenterSku: DevCenterSkuDetails
  Gallery.properties.galleryResourceId: -|arm-id
  AttachedNetworkConnection.properties.networkConnectionId: -|arm-id
  NetworkConnectionUpdate.properties.subnetId: -|arm-id
  NetworkConnection.properties.subnetId: -|arm-id
  Project.properties.devCenterId: -|arm-id
  ProjectUpdate.properties.devCenterId: -|arm-id
  ProjectEnvironmentType.properties.deploymentTargetId: -|arm-id
  ProjectEnvironmentTypeUpdate.properties.deploymentTargetId: -|arm-id
  ImageReference.id: -|arm-id
  #OperationStatus.resourceId: -|arm-id
  DevCenterSku.resourceType: -|resource-type
  CheckNameAvailabilityRequest.type: -|resource-type
  EnvironmentTypeEnableStatus.Enabled: IsEnabled
  EnvironmentTypeEnableStatus.Disabled: IsDisabled
  HibernateSupport.Enabled: IsEnabled
  HibernateSupport.Disabled: IsDisabled
  LocalAdminStatus.Enabled: IsEnabled
  LocalAdminStatus.Disabled: IsDisabled
  ScheduleEnableStatus.Enabled: IsEnabled
  ScheduleEnableStatus.Disabled: IsDisabled
  StopOnDisconnectEnableStatus.Enabled: IsEnabled
  StopOnDisconnectEnableStatus.Disabled: IsDisabled
  AttachedNetworkConnection.properties.networkConnectionLocation: -|azure-location
  UserRoleAssignment: DevCenterUserRoleAssignments
  DomainJoinType.HybridAzureADJoin: HybridAadJoin
  DomainJoinType.AzureADJoin: AadJoin
  CheckNameAvailabilityResponse.nameAvailable: IsNameAvailable
  CheckNameAvailabilityRequest: DevCenterNameAvailabilityContent
  CheckNameAvailabilityResponse: DevCenterNameAvailabilityResult
  CheckNameAvailabilityReason: DevCenterNameUnavailableReason
  ProjectEnvironmentType: DevCenterProjectEnvironment
  ImageVersion.properties.osDiskImageSizeInGb: OsDiskImageSizeInGB
  ImageVersion.properties.excludeFromLatest: IsExcludedFromLatest
  EnvironmentDefinitionParameter: EnvironmentDefinitionContent
  EnvironmentDefinitionParameter.id: -|uuid
  EnvironmentDefinitionParameter.readOnly: IsReadOnly
  EnvironmentDefinitionParameter.required: IsRequired
  ParameterType: EnvironmentDefinitionParameterType
  PoolDevBoxDefinition: PoolDevBox
  CatalogUpdate: DevCenterCatalogPatch
  CheckScopedNameAvailabilityRequest.type: -|resource-type
  CustomizationTaskInput.required: IsRequired
  Usage.id: -|arm-id
  SyncStats: CatalogSyncStats
  SyncErrorDetails: CatalogSyncErrorDetails
  SingleSignOnStatus: PoolUpdateSingleSignOnStatus
  ResourcePolicy: ProjectPolicyUpdateResourcePolicy
  EnvironmentDefinition: DevCenterEnvironmentDefinition
  ImageDefinitionBuild: DevCenterImageDefinitionBuild
  ImageDefinition: DevCenterImageDefinition

override-operation-name:
  OperationStatuses_Get: GetDevCenterOperationStatus
  Usages_ListByLocation: GetDevCenterUsagesByLocation
  CheckNameAvailability_Execute: CheckDevCenterNameAvailability
  Skus_ListBySubscription: GetDevCenterSkusBySubscription
  NetworkConnections_ListOutboundNetworkDependenciesEndpoints: GetOutboundEnvironmentEndpoints
  Images_ListByDevCenter: GetImagesByDevCenter

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/attachednetworks/{attachedNetworkConnectionName}: AttachedNetworkConnection  # It is originally called AttachedNetworkConnection and cannot be renamed to DevCenterAttachedNetworkConnection.
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/attachednetworks/{attachedNetworkConnectionName}: ProjectAttachedNetworkConnection  # It is originally called ProjectAttachedNetworkConnection and cannot be renamed to DevCenterProjectAttachedNetworkConnection.
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/devboxdefinitions/{devBoxDefinitionName}: DevBoxDefinition  # It is originally called DevBoxDefinition and cannot be renamed to DevCenterDevBoxDefinition.
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/devboxdefinitions/{devBoxDefinitionName}: ProjectDevBoxDefinition  # It is originally called ProjectDevBoxDefinition and cannot be renamed to DevCenterProjectDevBoxDefinition.
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}: DevCenterCatalog
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/galleries/{galleryName}/images/{imageName}: DevCenterImage
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/galleries/{galleryName}/images/{imageName}/versions/{versionName}: ImageVersion  # It is originally called ImageVersion and cannot be renamed to DevCenterImageVersion.
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}: DevCenterProjectCatalog
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/environmentDefinitions/{environmentDefinitionName}: DevCenterCatalogEnvironmentDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/imageDefinitions/{imageDefinitionName}: DevCenterCatalogImageDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/catalogs/{catalogName}/imageDefinitions/{imageDefinitionName}/builds/{buildName}: DevCenterCatalogImageDefinitionBuild
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/environmentDefinitions/{environmentDefinitionName}: DevCenterProjectCatalogEnvironmentDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/imageDefinitions/{imageDefinitionName}/builds/{buildName}: DevCenterProjectCatalogImageDefinitionBuild
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/catalogs/{catalogName}/imageDefinitions/{imageDefinitionName}: DevCenterProjectCatalogImageDefinition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/images/{imageName}: DevCenterProjectImage
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/images/{imageName}/versions/{versionName}: DevCenterProjectImageVersion
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/projectPolicies/{projectPolicyName}: DevCenterProjectPolicy

directive:
  # Add missing parameters
  - from: swagger-document
    where: $.parameters
    transform: >
      $.TopParameter = {
        "name": "$top",
        "in": "query",
        "description": "The maximum number of resources to return from the operation. Example: '$top=10'.",
        "type": "integer",
        "format": "int32",
        "required": false,
        "x-ms-parameter-location": "method"
      }
  # Add missing definitions
  - from: swagger-document
    where: $.definitions
    transform: >
      $.Tags = {
        "type": "object",
        "additionalProperties": {
          "type": "string"
        },
        "x-ms-mutability": [
          "read",
          "create",
          "update"
        ],
        "description": "Resource tags."
      };
      $.TrackedResourceUpdate = {
        "description": "Base tracked resource type for PATCH updates",
        "type": "object",
        "properties": {
          "tags": {
            "$ref": "#/definitions/Tags",
            "description": "Resource tags."
          },
          "location": {
            "type": "string",
            "x-ms-mutability": [
              "read",
              "create"
            ],
            "description": "The geo-location where the resource lives"
          }
        }
      };
      $.TrackedResourceUpdate['x-ms-client-name'] = "DevCenterTrackedResourceUpdate";
  # The following adds the newly added TrackedResourceUpdate to the allof of the corresponding model
  # Solved the issue of no inheritance class
  # Unwanted properties need to be deleted.
  - from: swagger-document
    where: $.definitions.DevBoxDefinitionUpdate
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.NetworkConnectionUpdate
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.DevCenterUpdate
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
      delete $.properties.properties;
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.PoolUpdate
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.ProjectUpdate
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
      delete $.properties.identity;
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.ScheduleUpdate
    transform: >
      $.allOf = $.allOf || [];
      $.allOf.push({"$ref": "#/definitions/TrackedResourceUpdate"});
  - from: swagger-document
    where: $.definitions.ScheduleUpdateProperties
    transform: >
      delete $.properties.location;
      delete $.properties.tags;
  # Add missing parameters to specific operations
  - from: swagger-document
    where: "$.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}/pools/{poolName}/schedules/{scheduleName}'].get.parameters"
    transform: >
      $.push({
        "$ref": "#/parameters/TopParameter"
      });
  # Directive renaming "type" property of ScheduleUpdateProperties to "ScheduledType" (to avoid it being generated as TypePropertiesType)
  - from: swagger-document
    where: "$.definitions.ScheduleUpdateProperties.properties.type"
    transform: >
      $["x-ms-client-name"] = "ScheduledType";
  - from: types.json
    where: $.definitions.OperationStatusResult
    transform: >
      $.properties.id['x-ms-format'] = 'arm-id';
  - from: swagger-document
    where: "$.definitions.ScheduleProperties.properties.type"
    transform: >
      $["x-ms-client-name"] = "ScheduledType";
  # Add missing attributes
  - from: swagger-document
    where: "$.definitions.OperationStatus"
    transform: >
      $.properties.resourceId = {
          "type": "string",
          "description": "The resource ID of the resource being operated on.",
          "x-ms-format": "arm-id"
        };
      $.properties.properties['additionalProperties'] = false;
  # Rename operations to solve the problem of generating duplicate code
  - rename-operation:
      from: ProjectCatalogImageDefinitionBuilds_ListByImageDefinition
      to: ProjectCatalogImageDefinitionBuild_ListByImageDefinition
  - rename-operation:
      from: DevCenterCatalogImageDefinitionBuilds_ListByImageDefinition
      to: DevCenterCatalogImageDefinitionBuild_ListByImageDefinition
    
```
