# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
version: 3.4.1
use: https://github.com/Azure/autorest.csharp/releases/download/v3.0.0-beta.20210622.6/autorest-csharp-3.0.0-beta.20210622.6.tgz
azure-arm: true
title: ResourceManagementClient
library-name: ResourcesManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Authorization/stable/2019-09-01/policySetDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Resources/preview/2019-10-01-preview/deploymentScripts.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Features/stable/2015-12-01/features.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/67528b3e539b96ccaaf82c360f5715184e467e21/specification/resources/resource-manager/Microsoft.Solutions/stable/2018-06-01/managedapplications.json
save-inputs: true
clear-output-folder: true
namespace: Azure.ResourceManager.Resources
modelerfour:
    lenient-model-deduplication: true
skip-csproj-packagereference: true
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
  DeploymentOperations: Microsoft.Resources/deployments/operations
  ResourceLinks: NonResource
  Deployments: Microsoft.Resources/deployments
operation-group-to-resource:
  DeploymentOperations: NonResource
  ResourceLinks: NonResource
  Deployments: DeploymentExtended
  DeploymentScripts: DeploymentScript
  ApplicationDefinitions: ApplicationDefinition
operation-group-to-parent:
  Deployments: tenant
  PolicyAssignments: tenant
  PolicyDefinitions: tenant
  PolicySetDefinitions: tenant
  DeploymentScripts: resourceGroups
  ManagementLocks: resourceGroups
  ResourceLinks: tenant
directive:
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Resources/operations"]
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Authorization/operations"]
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Solutions/operations"]
  - from: features.json
    where: $.paths
    transform: delete $["/providers/Microsoft.Features/operations"]
  # Below operations are already in the Core SDK.
  - remove-operation: Providers_Unregister
  - remove-operation: Providers_Register
  - remove-operation: Providers_List
  - remove-operation: Providers_ListAtTenantScope
  - remove-operation: Providers_Get
  - remove-operation: Providers_GetAtTenantScope
  - remove-operation: Providers_RegisterAtManagementGroupScope
  - remove-operation: Providers_ProviderPermissions

  - remove-operation: ProviderResourceTypes_List

  - remove-operation: Resources_MoveResources
  - remove-operation: Resources_ValidateMoveResources
  - remove-operation: Resources_List
  - remove-operation: Resources_CheckExistence
  - remove-operation: Resources_Delete
  - remove-operation: Resources_CreateOrUpdate
  - remove-operation: Resources_Update
  - remove-operation: Resources_Get
  - remove-operation: Resources_CheckExistenceById
  - remove-operation: Resources_CreateOrUpdateById
  - remove-operation: Resources_UpdateById
  - remove-operation: Resources_GetById
  - remove-operation: Resources_DeleteById

  - remove-operation: Resources_ListByResourceGroup
  - remove-operation: ResourceGroups_CheckExistence
  - remove-operation: ResourceGroups_CreateOrUpdate
  - remove-operation: ResourceGroups_Delete
  - remove-operation: ResourceGroups_Get
  - remove-operation: ResourceGroups_Update
  - remove-operation: ResourceGroups_List
  - remove-operation: ResourceGroups_ExportTemplate

  - remove-operation: Tags_DeleteValue
  - remove-operation: Tags_CreateOrUpdateValue
  - remove-operation: Tags_CreateOrUpdate
  - remove-operation: Tags_Delete
  - remove-operation: Tags_List
  - remove-operation: Tags_CreateOrUpdateAtScope
  - remove-operation: Tags_UpdateAtScope
  - remove-operation: Tags_GetAtScope
  - remove-operation: Tags_DeleteAtScope

  - remove-operation: Subscriptions_ListLocations
  - remove-operation: Subscriptions_Get
  - remove-operation: Subscriptions_List

  - remove-operation: Tenants_List
  - remove-operation: checkResourceName

  - remove-operation: Features_ListAll
  - remove-operation: Features_List
  - remove-operation: Features_Get
  - remove-operation: Features_Register
  - remove-operation: Features_Unregister
```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DeploymentOperationProperties
  transform: >
    $.properties.statusMessage["x-nullable"] = true;
````
