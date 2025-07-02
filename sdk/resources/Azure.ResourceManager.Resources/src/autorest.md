# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Resources
namespace: Azure.ResourceManager.Resources
title: ResourceManagementClient
tag: package-resources-2025-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
model-namespace: true
public-clients: false
head-as-boolean: false
modelerfour:
  lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

# mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  DecompileOperationSuccessResponse: DecompileOperationSuccessResult
  FileDefinition: DecompiledFileDefinition
  DataBoundary: DataBoundaryRegion
  DataBoundaryDefinition: DataBoundary
  DefaultName: DataBoundaryName
  ArmDeploymentPropertiesExtended.outputResources: OutputResourceDetails
  ArmDeploymentPropertiesExtended.validatedResources: ValidatedResourceDetails
  ResourceReference: ArmResourceReference
  DeploymentExtensionDefinition: ArmDeploymentExtensionDefinition
  DeploymentExtensionConfigItem: ArmDeploymentExtensionConfigItem
  DeploymentExternalInput: ArmDeploymentExternalInput
  DeploymentExternalInputDefinition: ArmDeploymentExternalInputDefinition
  ContainerConfiguration: ScriptContainerConfiguration
  ContainerGroupSubnetId: ScriptContainerGroupSubnet

patch-initializer-customization:
  ArmDeploymentContent:
    Properties: 'new ArmDeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : ArmDeploymentMode.Incremental)'

request-path-to-parent:
  # setting these to the same parent will automatically merge these operations
  /providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentScripts/{scriptName}/logs: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentScripts/{scriptName}
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}:
    - subscriptions
    - resourceGroups
    - managementGroups
    - tenant
  /{scope}/providers/Microsoft.Resources/deployments:
    - subscriptions
    - resourceGroups
    - managementGroups
    - tenant
  /{scope}/providers/Microsoft.Resources/deploymentStacks:
    - subscriptions
    - resourceGroups
    - managementGroups
  /{scope}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}:
    - subscriptions
    - resourceGroups
    - managementGroups
  /{scope}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}/exportTemplate:
    - subscriptions
    - resourceGroups
    - managementGroups

override-operation-name:
  DeploymentOperations_ListAtScope: GetDeploymentOperations
  DeploymentOperations_GetAtScope: GetDeploymentOperation
  Deployments_CancelAtScope: Cancel
  Deployments_ValidateAtScope: Validate
  Deployments_ExportTemplateAtScope: ExportTemplate
  Deployments_WhatIf: WhatIf
  Deployments_WhatIfAtManagementGroupScope: WhatIf
  Deployments_WhatIfAtSubscriptionScope: WhatIf
  Deployments_WhatIfAtTenantScope: WhatIf
  Deployments_CheckExistenceAtScope: CheckExistence
  jitRequests_ListBySubscription: GetJitRequestDefinitions
  Deployments_CalculateTemplateHash: CalculateDeploymentTemplateHash
  DeploymentStacks_ExportTemplateAtScope: ExportTemplate
  DeploymentStacks_ValidateStackAtScope: ValidateStack

operation-groups-to-omit:
   Providers;ProviderResourceTypes;Resources;ResourceGroups;Tags;Subscriptions;Tenants

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

keep-plural-enums:
  - ScriptCleanupOptions

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Urls: Uris

models-to-treat-empty-string-as-null:
  - ArmApplicationPackageSupportUris

suppress-abstract-base-class:
  - ArmDeploymentScriptData

directive:
  - remove-operation: checkResourceName
  # Use AtScope methods to replace the following operations
  # Keep the get method at each scope so that generator can know the possible values of container's parent
  - remove-operation: Deployments_DeleteAtTenantScope
  - remove-operation: Deployments_CheckExistenceAtTenantScope
  - remove-operation: Deployments_CreateOrUpdateAtTenantScope
  - remove-operation: Deployments_GetAtTenantScope
  - remove-operation: Deployments_CancelAtTenantScope
  - remove-operation: Deployments_ValidateAtTenantScope
  - remove-operation: Deployments_ExportTemplateAtTenantScope
  - remove-operation: Deployments_ListAtTenantScope
  - remove-operation: Deployments_DeleteAtManagementGroupScope
  - remove-operation: Deployments_CheckExistenceAtManagementGroupScope
  - remove-operation: Deployments_CreateOrUpdateAtManagementGroupScope
  - remove-operation: Deployments_GetAtManagementGroupScope
  - remove-operation: Deployments_CancelAtManagementGroupScope
  - remove-operation: Deployments_ValidateAtManagementGroupScope
  - remove-operation: Deployments_ExportTemplateAtManagementGroupScope
  - remove-operation: Deployments_ListAtManagementGroupScope
  - remove-operation: Deployments_DeleteAtSubscriptionScope
  - remove-operation: Deployments_CheckExistenceAtSubscriptionScope
  - remove-operation: Deployments_CreateOrUpdateAtSubscriptionScope
  - remove-operation: Deployments_GetAtSubscriptionScope
  - remove-operation: Deployments_CancelAtSubscriptionScope
  - remove-operation: Deployments_ValidateAtSubscriptionScope
  - remove-operation: Deployments_ExportTemplateAtSubscriptionScope
  - remove-operation: Deployments_ListAtSubscriptionScope
  - remove-operation: Deployments_Delete
  - remove-operation: Deployments_CheckExistence
  - remove-operation: Deployments_CreateOrUpdate
  - remove-operation: Deployments_Get
  - remove-operation: Deployments_Cancel
  - remove-operation: Deployments_Validate
  - remove-operation: Deployments_ExportTemplate
  - remove-operation: Deployments_ListByResourceGroup
  - remove-operation: DeploymentOperations_GetAtTenantScope
  - remove-operation: DeploymentOperations_ListAtTenantScope
  - remove-operation: DeploymentOperations_GetAtManagementGroupScope
  - remove-operation: DeploymentOperations_ListAtManagementGroupScope
  - remove-operation: DeploymentOperations_GetAtSubscriptionScope
  - remove-operation: DeploymentOperations_ListAtSubscriptionScope
  - remove-operation: DeploymentOperations_Get
  - remove-operation: DeploymentOperations_List
  - remove-operation: Applications_GetById
  - remove-operation: Applications_DeleteById
  - remove-operation: Applications_CreateOrUpdateById
  - remove-operation: Applications_UpdateById
  - remove-operation: DeploymentStacks_ExportTemplateAtSubscription
  - remove-operation: DeploymentStacks_ExportTemplateAtResourceGroup
  - remove-operation: DeploymentStacks_ExportTemplateAtManagementGroup
  - remove-operation: DeploymentStacks_ValidateStackAtResourceGroup
  - remove-operation: DeploymentStacks_ValidateStackAtSubscription
  - remove-operation: DeploymentStacks_ValidateStackAtManagementGroup
  - remove-operation: DeploymentStacks_ListAtResourceGroup
  - remove-operation: DeploymentStacks_ListAtSubscription
  - remove-operation: DeploymentStacks_ListAtManagementGroup
  - remove-operation: DeploymentStacks_CreateOrUpdateAtResourceGroup
  - remove-operation: DeploymentStacks_GetAtResourceGroup
  - remove-operation: DeploymentStacks_DeleteAtResourceGroup
  - remove-operation: DeploymentStacks_CreateOrUpdateAtSubscription
  - remove-operation: DeploymentStacks_GetAtSubscription
  - remove-operation: DeploymentStacks_DeleteAtSubscription
  - remove-operation: DeploymentStacks_CreateOrUpdateAtManagementGroup
  - remove-operation: DeploymentStacks_GetAtManagementGroup
  - remove-operation: DeploymentStacks_DeleteAtManagementGroup
  - remove-operation: Operations_List

  - from: managedapplications.json
    where: $['x-ms-paths']
    transform: delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}?disambiguation_dummy']
    reason: The operations duplicate with the ones in /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
  - rename-operation:
      from: ListOperations
      to: Operations_ListOps
  - from: resources.json
    where: $.definitions.DeploymentOperationProperties
    transform: >
      $.properties.statusMessage['x-nullable'] = true;

  - from: deploymentScripts.json
    where: $.definitions.ManagedServiceIdentity.properties.type['x-ms-enum']
    transform: >
      $.name = 'ArmDeploymentScriptManagedIdentityType'
  - from: deploymentScripts.json
    where: $.definitions
    transform: >
      $.ManagedServiceIdentity['x-ms-client-name'] = 'ArmDeploymentScriptManagedIdentity';
      $.AzureResourceBase['x-ms-client-name'] = 'ArmDeploymentScriptResourceBase';
      $.DeploymentScriptPropertiesBase['x-ms-client-name'] = 'ArmDeploymentScriptPropertiesBase';
      $.DeploymentScriptsError['x-ms-client-name'] = 'ArmDeploymentScriptsError';
      $.DeploymentScript['x-ms-client-name'] = 'ArmDeploymentScript';
      $.DeploymentScriptListResult['x-ms-client-name'] = 'ArmDeploymentScriptListResult';
      $.DeploymentScriptPropertiesBase.properties.cleanupPreference['x-ms-enum'].name = 'scriptCleanupOptions';
      $.EnvironmentVariable['x-ms-client-name'] = 'ScriptEnvironmentVariable';
      $.StorageAccountConfiguration['x-ms-client-name'] = 'ScriptStorageConfiguration';

  - from: managedapplications.json
    where: $.definitions
    transform: >
      $.Identity['x-ms-client-name'] = 'ArmApplicationManagedIdentity';
      $.Identity.properties.type['x-ms-enum']['name'] = 'ArmApplicationManagedIdentityType';
      $.Identity.properties.principalId['format'] = 'uuid';
      $.JitRequestProperties.properties.publisherTenantId['format'] = 'uuid';
      $.ApplicationProperties.properties.publisherTenantId['format'] = 'uuid';
      $.GenericResource['x-ms-client-name'] = 'ArmApplicationResourceData';
      $.Resource['x-ms-client-name'] = 'ArmApplicationResourceBase';
      $.Plan['x-ms-client-name'] = 'ArmApplicationPlan';
      $.Sku['x-ms-client-name'] = 'ArmApplicationSku';
      $.Operation['x-ms-client-name'] = 'ArmApplicationOperation';
      $.Operation.properties.displayOfApplication = $.Operation.properties.display;
      $.Operation.properties['display'] = undefined;
      $.JitRequestDefinition['x-ms-client-name'] = 'JitRequest';
      $.JitRequestDefinitionListResult['x-ms-client-name'] = 'JitRequestListResult';
      $.Application['x-ms-client-name'] = 'ArmApplication';
      $.ApplicationPackageLockingPolicyDefinition['x-ms-client-name'] = 'ApplicationPackageLockingPolicy';
      $.ApplicationBillingDetailsDefinition['x-ms-client-name'] = 'ApplicationBillingDetails';
      $.JitApproverDefinition['x-ms-client-name'] = 'JitApprover';
      $.DeploymentMode['x-ms-enum']['name'] = 'ArmApplicationDeploymentMode';
      $.Application['x-ms-client-name'] = 'ArmApplication';
      $.ApplicationDefinition['x-ms-client-name'] = 'ArmApplicationDefinition';
      $.ApplicationPackageLockingPolicyDefinition['x-ms-client-name'] = 'ArmApplicationPackageLockingPolicy';
      $.ApplicationBillingDetailsDefinition['x-ms-client-name'] = 'ArmApplicationBillingDetails';
      $.ApplicationArtifact['x-ms-client-name'] = 'ArmApplicationArtifact';
      $.ApplicationAuthorization['x-ms-client-name'] = 'ArmApplicationAuthorization';
      $.ApplicationAuthorization.properties.principalId.format = 'uuid';
      $.JitAuthorizationPolicies.properties.principalId.format = 'uuid';
      $.ApplicationClientDetails['x-ms-client-name'] = 'ArmApplicationDetails';
      $.ApplicationClientDetails.properties.oid['x-ms-client-name'] = 'ObjectId';
      $.ApplicationClientDetails.properties.oid.format = 'uuid';
      $.ApplicationClientDetails.properties.applicationId.format = 'uuid';
      $.ApplicationDefinitionArtifact['x-ms-client-name'] = 'ArmApplicationDefinitionArtifact';
      $.ApplicationDefinitionListResult['x-ms-client-name'] = 'ArmApplicationDefinitionListResult';
      $.ApplicationDeploymentPolicy['x-ms-client-name'] = 'ArmApplicationDeploymentPolicy';
      $.ApplicationJitAccessPolicy['x-ms-client-name'] = 'ArmApplicationJitAccessPolicy';
      $.ApplicationListResult['x-ms-client-name'] = 'ArmApplicationListResult';
      $.ApplicationManagementPolicy['x-ms-client-name'] = 'ArmApplicationManagementPolicy';
      $.ApplicationNotificationEndpoint['x-ms-client-name'] = 'ArmApplicationNotificationEndpoint';
      $.ApplicationNotificationPolicy['x-ms-client-name'] = 'ArmApplicationNotificationPolicy';
      $.ApplicationPackageContact['x-ms-client-name'] = 'ArmApplicationPackageContact';
      $.ApplicationPackageSupportUrls['x-ms-client-name'] = 'ArmApplicationPackageSupportUrls';
      $.ApplicationPackageSupportUrls.properties.governmentCloud['x-ms-client-name'] = 'AzureGovernmentUri';
      $.ApplicationPackageSupportUrls.properties.publicAzure['x-ms-client-name'] = 'AzurePublicCloudUri';
      $.ApplicationPolicy['x-ms-client-name'] = 'ArmApplicationPolicy';
      $.ApplicationPropertiesPatchable['x-ms-client-name'] = 'ArmApplicationPropertiesPatchable';
      $.ApplicationArtifactName['x-ms-enum'].name = 'ArmApplicationArtifactName';
      $.ApplicationArtifactType['x-ms-enum'].name = 'ArmApplicationArtifactType';
      $.ApplicationDefinitionArtifactName['x-ms-enum'].name = 'ArmApplicationDefinitionArtifactName';
      $.ApplicationLockLevel['x-ms-enum'].name = 'ArmApplicationLockLevel';
      $.ApplicationManagementMode['x-ms-enum'].name = 'ArmApplicationManagementMode';
      $.ApplicationJitAccessPolicy.properties.maximumJitAccessDuration['format'] = 'duration';
      $.JitSchedulingPolicy.properties.duration['format'] = 'duration';
      $.ProvisioningState['x-ms-enum'].name = 'ResourcesProvisioningState';
      $.ProvisioningState['x-ms-client-name'] = 'ResourcesProvisioningState';
      $.userAssignedResourceIdentity.properties.principalId.format = 'uuid';
      $.userAssignedResourceIdentity['x-ms-client-name'] = 'ArmApplicationUserAssignedIdentity';
      $.ApplicationProperties.properties.applicationDefinitionId['x-ms-format'] = 'arm-id';
      $.ApplicationProperties.properties.managedResourceGroupId['x-ms-format'] = 'arm-id';
      $.ApplicationPropertiesPatchable.properties.applicationDefinitionId['x-ms-format'] = 'arm-id';
      $.ApplicationPropertiesPatchable.properties.managedResourceGroupId['x-ms-format'] = 'arm-id';
  - from: resources.json
    where: $.definitions
    transform: >
      $.DeploymentProperties.properties.mode['x-ms-enum'].name = 'ArmDeploymentMode';
      $.DeploymentPropertiesExtended.properties.mode['x-ms-enum'].name = 'ArmDeploymentMode';
      $.DeploymentExtended['x-ms-client-name'] = 'ArmDeployment';
      $.Deployment['x-ms-client-name'] = 'ArmDeploymentContent';
      $.DeploymentExportResult['x-ms-client-name'] = 'ArmDeploymentExportResult';
      $.DeploymentExtendedFilter['x-ms-client-name'] = 'ArmDeploymentExtendedFilter';
      $.DeploymentListResult['x-ms-client-name'] = 'ArmDeploymentListResult';
      $.DeploymentOperation['x-ms-client-name'] = 'ArmDeploymentOperation';
      $.DeploymentOperationProperties['x-ms-client-name'] = 'ArmDeploymentOperationProperties';
      $.DeploymentOperationProperties.properties.provisioningOperation['x-ms-enum'].name = 'ProvisioningOperationKind';
      $.DeploymentOperationsListResult['x-ms-client-name'] = 'ArmDeploymentOperationsListResult';
      $.DeploymentValidateResult['x-ms-client-name'] = 'ArmDeploymentValidateResult';
      $.DeploymentWhatIf['x-ms-client-name'] = 'ArmDeploymentWhatIfContent';
      $.DeploymentWhatIfSettings['x-ms-client-name'] = 'ArmDeploymentWhatIfSettings';
      $.DeploymentWhatIfProperties['x-ms-client-name'] = 'ArmDeploymentWhatIfProperties';
      $.DeploymentProperties['x-ms-client-name'] = 'ArmDeploymentProperties';
      $.DeploymentPropertiesExtended['x-ms-client-name'] = 'ArmDeploymentPropertiesExtended';
      $.Dependency['x-ms-client-name'] = 'ArmDependency';
      $.BasicDependency['x-ms-client-name'] = 'BasicArmDependency';
      $.Dependency.properties.resourceType['x-ms-format'] = 'resource-type';
      $.BasicDependency.properties.resourceType['x-ms-format'] = 'resource-type';
      $.TargetResource.properties.resourceType['x-ms-format'] = 'resource-type';
      $.DeploymentPropertiesExtended.properties.provisioningState['x-ms-enum'].name = 'ResourcesProvisioningState';
      $.DeploymentPropertiesExtended.properties.duration['format'] = 'duration';
      $.DeploymentPropertiesExtended.properties.onErrorDeployment['x-ms-client-name'] = 'ErrorDeployment';
      $.DeploymentOperationProperties.properties.duration['format'] = 'duration';
      $.ExpressionEvaluationOptions.properties.scope['x-ms-enum']['name'] = 'ExpressionEvaluationScope';
      $.OnErrorDeployment['x-ms-client-name'] = 'ErrorDeployment';
      $.OnErrorDeployment.properties.type['x-ms-enum'].name = 'ErrorDeploymentType';
      $.OnErrorDeploymentExtended['x-ms-client-name'] = 'ErrorDeploymentExtended';
      $.OnErrorDeploymentExtended.properties.type['x-ms-enum'].name = 'ErrorDeploymentType';
      $.ParametersLink['x-ms-client-name'] = 'ArmDeploymentParametersLink';
      $.TemplateLink['x-ms-client-name'] = 'ArmDeploymentTemplateLink';
      $.WhatIfChange.properties.changeType['x-ms-enum'].name = 'WhatIfChangeType';
      $.WhatIfPropertyChange.properties.propertyChangeType['x-ms-enum'].name = 'WhatIfPropertyChangeType';
      $.ResourceReference.properties.id["x-ms-format"] = "arm-id";
  - from: dataBoundaries.json
    where: $.definitions
    transform: >
      $.DataBoundaryProperties.properties.provisioningState['x-ms-enum'].name = 'DataBoundaryProvisioningState';
  - from: dataBoundaries.json
    where: $.paths..parameters[?(@.name === 'default')]
    transform: >
      $['x-ms-client-name'] = 'name';
  - from: resources.json
    where: $.paths['/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post.parameters[1].schema
    transform: $['$ref'] = '#/definitions/DeploymentWhatIf'
  - from: resources.json
    where: $.paths['/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post.parameters[2].schema
    transform: $['$ref'] = '#/definitions/DeploymentWhatIf'
  - from: resources.json
    where: $.definitions.DeploymentWhatIf.properties.location
    transform: $['description'] = 'The location to store the deployment data, only required at the tenant and management group scope.'
  - from: resources.json
    where: $.definitions.Alias
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAlias';
  - from: resources.json
    where: $.definitions.AliasPath
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPath';
  - from: resources.json
    where: $.definitions.AliasPathMetadata.properties.attributes['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPathAttributes';
  - from: resources.json
    where: $.definitions.AliasPathMetadata
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPathMetadata';
  - from: resources.json
    where: $.definitions.AliasPathMetadata.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPathTokenType';
  - from: resources.json
    where: $.definitions.AliasPattern
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPattern';
  - from: resources.json
    where: $.definitions.AliasPattern.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPatternType';
  - from: resources.json
    where: $.definitions.Alias.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasType';
  - from: resources.json
    where: $.definitions.DeploymentProperties.properties.expressionEvaluationOptions
    transform: >
      $['x-ms-client-name'] = 'ExpressionEvaluation'
  - from: resources.json
    where: $.definitions.DeploymentProperties.properties.onErrorDeployment
    transform: >
      $['x-ms-client-name'] = 'ErrorDeployment'
  - from: deploymentScripts.json
    where: $.definitions.DeploymentScriptPropertiesBase.properties.outputs
    transform: >
      $.additionalProperties = undefined
  # Avoid breaking change
  - from: resources.json
    where: $.definitions.DeploymentProperties
    transform:
      delete $.properties.parameters.additionalProperties
  # Specify the duration format
  - from: deploymentStacks.json
    where: $.definitions
    transform: >
      $.DeploymentStackProperties.properties.duration['format'] = 'duration';
  - from: resources.json
    where: $.paths['/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post
    transform: >
      $['x-ms-examples'] = {
        "Predict template changes at tenant scope": {
          "$ref": "./examples/PostDeploymentWhatIfOnTenant.json"
        }
      }
  - from: resources.json
    where: $.definitions.DeploymentExtensionConfigItem
    transform: >
      $.properties.keyVaultReference["$ref"] = "../2024-03-01/deploymentStacks.json#/definitions/KeyVaultParameterReference"
  # Add scope operations
  - from: deploymentStacks.json
    where: $.paths
    transform: >
      $['/{scope}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}/exportTemplate'] = {
        "post": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_ExportTemplateAtScope",
          "description": "Exports the template used to create the Deployment stack.",
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "#/parameters/DeploymentStackNameParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Returns the Template or TemplateLink payload of the deployment stack.",
              "schema": {
                "$ref": "#/definitions/DeploymentStackTemplateDefinition"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          }
        }
      };
      $['/{scope}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}/validate'] = {
        "post": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_ValidateStackAtScope",
          "description": "Runs preflight validation on the specific scoped Deployment stack template to verify its acceptance to Azure Resource Manager.",
          "x-ms-long-running-operation": true,
          "x-ms-long-running-operation-options": {
            "final-state-via": "location"
          },
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "#/parameters/DeploymentStackNameParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            },
            {
              "name": "deploymentStack",
              "in": "body",
              "required": true,
              "schema": {
                "$ref": "#/definitions/DeploymentStack"
              },
              "description": "Deployment stack to validate."
            }
          ],
          "responses": {
            "200": {
              "description": "OK - The validation operation result.",
              "schema": {
                "$ref": "#/definitions/DeploymentStackValidateResult"
              }
            },
            "202": {
              "description": "Accepted - The validation request has been accepted for processing and the operation will complete asynchronously.",
              "headers": {
                "Location": {
                  "type": "string"
                },
                "Retry-After": {
                  "type": "string",
                  "description": "Number of seconds to wait before polling for status."
                }
              }
            },
            "400": {
              "description": "Failed - The validation operation result.",
              "x-ms-error-response": false,
              "schema": {
                "$ref": "#/definitions/DeploymentStackValidateResult"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          }
        }
      };
      $['/{scope}/providers/Microsoft.Resources/deploymentStacks'] = {
        "get": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_ListAtScope",
          "description": "Lists all the Deployment stacks within the specified scope.",
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Returns an array of Deployment stacks.",
              "schema": {
                "$ref": "#/definitions/DeploymentStackListResult"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": "nextLink"
          }
        }
      };
      $['/{scope}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}'] = {
        "put": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_CreateOrUpdateAtScope",
          "x-ms-long-running-operation": true,
          "x-ms-long-running-operation-options": {
            "final-state-via": "azure-async-operation"
          },
          "description": "Creates or updates a Deployment stack at specific scope.",
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "#/parameters/DeploymentStackNameParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            },
            {
              "name": "deploymentStack",
              "in": "body",
              "required": true,
              "schema": {
                "$ref": "#/definitions/DeploymentStack"
              },
              "description": "Deployment stack supplied to the operation."
            }
          ],
          "responses": {
            "200": {
              "description": "OK - The Deployment stack update request has succeeded.",
              "schema": {
                "$ref": "#/definitions/DeploymentStack"
              }
            },
            "201": {
              "description": "Deployment stack created.",
              "schema": {
                "$ref": "#/definitions/DeploymentStack"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          }
        },
        "get": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_GetAtScope",
          "description": "Gets a Deployment stack with a given name at specific scope.",
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "#/parameters/DeploymentStackNameParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Returns information about the Deployment stack.",
              "schema": {
                "$ref": "#/definitions/DeploymentStack"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          }
        },
        "delete": {
          "tags": [
            "DeploymentStacks"
          ],
          "operationId": "DeploymentStacks_DeleteAtScope",
          "description": "Deletes a Deployment stack by name at specific scope. When operation completes, status code 200 returned without content.",
          "x-ms-long-running-operation": true,
          "x-ms-long-running-operation-options": {
            "final-state-via": "location"
          },
          "parameters": [
            {
              "$ref": "../2025-04-01/resources.json#/parameters/ScopeParameter"
            },
            {
              "$ref": "#/parameters/DeploymentStackNameParameter"
            },
            {
              "$ref": "#/parameters/DeleteResourceParameter"
            },
            {
              "$ref": "#/parameters/DeleteResourceGroupParameter"
            },
            {
              "$ref": "#/parameters/DeleteManagementGroupParameter"
            },
            {
              "$ref": "#/parameters/BypassStackOutOfSyncErrorParameter"
            },
            {
              "$ref": "../../../../../common-types/resource-management/v5/types.json#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Deployment stack deleted."
            },
            "202": {
              "description": "Accepted - Check location header for deletion status.",
              "headers": {
                "Location": {
                  "type": "string"
                }
              }
            },
            "204": {
              "description": "Deployment stack does not exist."
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/DeploymentStacksError"
              }
            }
          }
        }
      };
```

### Tag: package-resources-2025-04

These settings apply only when `--tag=package-resources-2025-04` is specified on the command line.


```yaml $(tag) == 'package-resources-2025-04'
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2021-05-01/templateSpecs.json
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2023-08-01/deploymentScripts.json
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2025-04-01/resources.json
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Solutions/stable/2019-07-01/managedapplications.json
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2023-11-01/bicepClient.json#
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2024-03-01/deploymentStacks.json
    - https://github.com/Azure/azure-rest-api-specs/blob/778b6f8c84f4d62e66f054e3876acff30e5bd4f9/specification/resources/resource-manager/Microsoft.Resources/stable/2024-08-01/dataBoundaries.json
```
