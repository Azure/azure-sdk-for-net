# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Resources
c-sharp: true
namespace: Azure.ResourceManager.Resources
title: ResourceManagementClient
tag: package-track2-preview

output-folder: Generated/
clear-output-folder: true

modelerfour:
    lenient-model-deduplication: true
skip-csproj: true
model-namespace: true
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2

operation-group-to-resource-type:
  DeploymentOperations: Microsoft.Resources/deployments/operations
  Deployments: Microsoft.Resources/deployments
  DeploymentScriptLogs: Microsoft.Resources/deploymentScripts/logs
operation-group-to-resource:
  DeploymentOperations: DeploymentOperation
  Deployments: Deployment
  DeploymentScripts: DeploymentScript
  ApplicationDefinitions: ApplicationDefinition
  DeploymentScriptLogs: ScriptLog
operation-group-to-parent:
  Deployments: tenant
  DeploymentScripts: resourceGroups
operation-groups-to-omit:
   Providers;ProviderResourceTypes;Resources;ResourceGroups;Tags;Subscriptions;Tenants
merge-operations:
  WhatIf: Deployments_WhatIf_POST;Deployments_WhatIfAtTenantScope_POST;Deployments_WhatIfAtManagementGroupScope_POST;Deployments_WhatIfAtSubscriptionScope_POST
directive:
  - from: resources.json
    where: $.definitions.DeploymentExtended
    transform: $['x-ms-client-name'] = 'Deployment'
  - from: resources.json
    where: $.definitions.Deployment
    transform: $['x-ms-client-name'] = 'DeploymentInput'
  - remove-operation: checkResourceName
  # Use AtScope methods to replace the following operations
  # Keep the get method at each scope so that generator can know the possible values of collection's parent
  - remove-operation: Deployments_DeleteAtTenantScope
  - remove-operation: Deployments_CheckExistenceAtTenantScope
  - remove-operation: Deployments_CreateOrUpdateAtTenantScope
#   - remove-operation: Deployments_GetAtTenantScope
  - remove-operation: Deployments_CancelAtTenantScope
  - remove-operation: Deployments_ValidateAtTenantScope
  - remove-operation: Deployments_ExportTemplateAtTenantScope
  - remove-operation: Deployments_ListAtTenantScope
  - remove-operation: Deployments_DeleteAtManagementGroupScope
  - remove-operation: Deployments_CheckExistenceAtManagementGroupScope
  - remove-operation: Deployments_CreateOrUpdateAtManagementGroupScope
#   - remove-operation: Deployments_GetAtManagementGroupScope
  - remove-operation: Deployments_CancelAtManagementGroupScope
  - remove-operation: Deployments_ValidateAtManagementGroupScope
  - remove-operation: Deployments_ExportTemplateAtManagementGroupScope
  - remove-operation: Deployments_ListAtManagementGroupScope
  - remove-operation: Deployments_DeleteAtSubscriptionScope
  - remove-operation: Deployments_CheckExistenceAtSubscriptionScope
  - remove-operation: Deployments_CreateOrUpdateAtSubscriptionScope
#   - remove-operation: Deployments_GetAtSubscriptionScope
  - remove-operation: Deployments_CancelAtSubscriptionScope
  - remove-operation: Deployments_ValidateAtSubscriptionScope
  - remove-operation: Deployments_ExportTemplateAtSubscriptionScope
  - remove-operation: Deployments_ListAtSubscriptionScope
  - remove-operation: Deployments_Delete
  - remove-operation: Deployments_CheckExistence
  - remove-operation: Deployments_CreateOrUpdate
#   - remove-operation: Deployments_Get
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

  - from: managedapplications.json
    where: $["x-ms-paths"]
    transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}?disambiguation_dummy"]
    reason: The operations duplicate with the ones in /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
  - rename-operation:
      from: ListOperations
      to: Operations_ListOps

  - rename-operation:
      from: DeploymentScripts_GetLogs
      to: DeploymentScriptLogs_GetLogs
  - rename-operation:
      from: DeploymentScripts_GetLogsDefault
      to: DeploymentScriptLogs_GetLogsDefault
  - from: resources.json
    where: $.definitions.DeploymentOperationProperties
    transform: >
      $.properties.statusMessage["x-nullable"] = true;
```

### Tag: package-track2-preview

These settings apply only when `--tag=package-track2-preview` is specified on the command line.

```yaml $(tag) == 'package-track2-preview'
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Solutions/stable/2019-07-01/managedapplications.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2020-10-01/deploymentScripts.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-05-01/templateSpecs.json
```
