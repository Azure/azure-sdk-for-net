# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
title: DeploymentsClient
namespace: Azure.ResourceManager.Resources
require: https://github.com/Azure/azure-rest-api-specs/blob/30b7aff12bd945cc154ba66eeb1592507926331f/specification/resources/resource-manager/Microsoft.Resources/deployments/readme.md
#tag: package-2025-04
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

rename-mapping:
  ArmDeploymentPropertiesExtended.outputResources: OutputResourceDetails
  ArmDeploymentPropertiesExtended.validatedResources: ValidatedResourceDetails
  ResourceReference: ArmResourceReference
  DeploymentExtensionDefinition: ArmDeploymentExtensionDefinition
  DeploymentExtensionConfigItem: ArmDeploymentExtensionConfigItem
  DeploymentExternalInput: ArmDeploymentExternalInput
  DeploymentExternalInputDefinition: ArmDeploymentExternalInputDefinition

patch-initializer-customization:
  ArmDeploymentContent:
    Properties: 'new ArmDeploymentProperties(current.Properties.Mode.HasValue ? current.Properties.Mode.Value : ArmDeploymentMode.Incremental)'

request-path-to-parent:
  # setting these to the same parent will automatically merge these operations
  /providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
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
  Deployments_CalculateTemplateHash: CalculateDeploymentTemplateHash

operation-groups-to-omit:
   Providers;ProviderResourceTypes;Resources;ResourceGroups;Tags;Subscriptions;Tenants

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

directive:
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

  - rename-operation:
      from: ListOperations
      to: Operations_ListOps
  - from: deployments.json
    where: $.definitions.DeploymentOperationProperties
    transform: >
      $.properties.statusMessage['x-nullable'] = true;
  - from: deployments.json
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
  - from: deployments.json
    where: $.paths['/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post.parameters[1].schema
    transform: $['$ref'] = '#/definitions/DeploymentWhatIf'
  - from: deployments.json
    where: $.paths['/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post.parameters[2].schema
    transform: $['$ref'] = '#/definitions/DeploymentWhatIf'
  - from: deployments.json
    where: $.definitions.DeploymentWhatIf.properties.location
    transform: $['description'] = 'The location to store the deployment data, only required at the tenant and management group scope.'
  - from: deployments.json
    where: $.definitions.Alias
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAlias';
  - from: deployments.json
    where: $.definitions.AliasPath
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPath';
  - from: deployments.json
    where: $.definitions.AliasPathMetadata.properties.attributes['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPathAttributes';
  - from: deployments.json
    where: $.definitions.AliasPathMetadata
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPathMetadata';
  - from: deployments.json
    where: $.definitions.AliasPathMetadata.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPathTokenType';
  - from: deployments.json
    where: $.definitions.AliasPattern
    transform:
      $['x-ms-client-name'] = 'ResourceTypeAliasPattern';
  - from: deployments.json
    where: $.definitions.AliasPattern.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasPatternType';
  - from: deployments.json
    where: $.definitions.Alias.properties.type['x-ms-enum']
    transform:
      $['name'] = 'ResourceTypeAliasType';
  - from: deployments.json
    where: $.definitions.DeploymentProperties.properties.expressionEvaluationOptions
    transform: >
      $['x-ms-client-name'] = 'ExpressionEvaluation'
  - from: deployments.json
    where: $.definitions.DeploymentProperties.properties.onErrorDeployment
    transform: >
      $['x-ms-client-name'] = 'ErrorDeployment'
  # Avoid breaking change
  - from: deployments.json
    where: $.definitions.DeploymentProperties
    transform:
      delete $.properties.parameters.additionalProperties
  - from: deployments.json
    where: $.paths['/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf'].post
    transform: >
      $['x-ms-examples'] = {
        "Predict template changes at tenant scope": {
          "$ref": "./examples/PostDeploymentWhatIfOnTenant.json"
        }
      }
```
