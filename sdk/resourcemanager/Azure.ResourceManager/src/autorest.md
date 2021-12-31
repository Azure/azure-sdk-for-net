# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
# csharpgen:
#   attach: true
azure-arm: true
arm-core: true
clear-output-folder: true
modelerfour:
  lenient-model-deduplication: true
skip-csproj: true
model-namespace: false
public-clients: false
head-as-boolean: false
mgmt-debug:
  show-request-path: true
batch:
  - tag: package-common-type
  - tag: package-resources
  - tag: package-management
```

### Tag: package-common-type

These settings apply only when `--tag=package-common-type` is specified on the command line.

``` yaml $(tag) == 'package-common-type'
output-folder: $(this-folder)/Common/Generated
namespace: Azure.ResourceManager
input-file:
# temporarily using a local file to work around an autorest bug that loses extensions during deduplication of schemas: https://github.com/Azure/autorest/issues/4267
#  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac3be41ee22ada179ab7b970e98f1289188b3bae/specification/common-types/resource-management/v2/types.json
  - $(this-folder)/types.json
directive:
  - remove-model: "AzureEntityResource"
  - remove-model: "ProxyResource"
  - remove-model: "ResourceModelWithAllowedPropertySet"
  - remove-model: "Identity"
  - remove-model: "Operation"
  - remove-model: "OperationListResult"
  - remove-model: "OperationStatusResult"
  - remove-model: "locationData"
  - from: types.json
    where: $.definitions['Resource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions['TrackedResource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-ms-mgmt-propertyReferenceType"] = true
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-accessibility"] = "public"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-csharp-formats"] = "json"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-csharp-usage"] = "model,input,output"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-accessibility"] = "public"
# Workaround for the issue that SystemData lost readonly attribute: https://github.com/Azure/autorest/issues/4269
  - from: types.json
    where: $.definitions.systemData.properties.*
    transform: >
      $["readOnly"] = true
```

### Tag: package-resources

These settings apply only when `--tag=package-resources` is specified on the command line.

``` yaml $(tag) == 'package-resources'
output-folder: $(this-folder)/Resources/Generated
namespace: Azure.ResourceManager.Resources
title: ResourceManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
list-exception:
  - /{linkId}
request-path-to-resource-data:
  # model of ResourceLink has id, type and name, but its type has the type of `object` instead of `string`
  /{linkId}: ResourceLink
  # subscription does not have name and type
  /subscriptions/{subscriptionId}: Subscription
  # tenant does not have name and type
  /: Tenant
#   /subscriptions/{subscriptionId}/tagNames/{tagName}: PredefinedTag # TODO: this should be a non-resource
#   /subscriptions/{subscriptionId}/tagNames/{tagName}/tagValues/{tagValue}: PredefinedTagValue
request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/locations
request-path-to-parent:
  /{scope}/providers/Microsoft.Resources/links: /{linkId}
  /subscriptions: /subscriptions/{subscriptionId}
  /tenants: /
  /subscriptions/{subscriptionId}/locations: /subscriptions/{subscriptionId}
request-path-to-resource-type:
  /{linkId}: Microsoft.Resources/links
  /subscriptions/{subscriptionId}/locations: Microsoft.Resources/locations
  /tenants: Microsoft.Resources/tenants
  /: Microsoft.Resources/tenants
  /subscriptions: Microsoft.Resources/subscriptions
  /subscriptions/{subscriptionId}/resourcegroups: Microsoft.Resources/resourceGroups
#   /subscriptions/{subscriptionId}/tagNames/{tagName}: Microsoft.Resources/tagNames
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Authorization/locks/{lockName}:
    - subscriptions
    - resourceGroups
    - "*"
operation-groups-to-omit:
  - Deployments
  - DeploymentOperations
  - AuthorizationOperations
  - ResourceCheck
  - Providers
  - Resources
override-operation-name:
  ResourceLinks_ListAtSourceScope: GetAll
  Tags_List: GetAllPredefinedTags
  Tags_DeleteValue: DeletePredefinedTagValue
  Tags_CreateOrUpdateValue: CreateOrUpdatePredefinedTagValue
  Tags_CreateOrUpdate: CreateOrUpdatePredefinedTag
  Tags_Delete: DeletePredefinedTag
directive:
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceGroupLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtSubscriptionLevel
  - remove-operation: ManagementLocks_DeleteAtResourceGroupLevel
  - remove-operation: ManagementLocks_DeleteAtResourceLevel
  - remove-operation: ManagementLocks_DeleteAtSubscriptionLevel
  - remove-operation: ManagementLocks_GetAtResourceGroupLevel
  - remove-operation: ManagementLocks_GetAtResourceLevel
  - remove-operation: ManagementLocks_GetAtSubscriptionLevel
  - remove-operation: ManagementLocks_ListAtResourceGroupLevel
  - remove-operation: ManagementLocks_ListAtResourceLevel
  - remove-operation: ManagementLocks_ListAtSubscriptionLevel
  - from: subscriptions.json
    where: '$.paths["/providers/Microsoft.Resources/operations"].get'
    transform: >
      $["operationId"] = "Operations_ListSubscriptionOperations";
    reason: Rename duplicate operation Id
  - from: resources.json
    where: '$.paths["/providers/Microsoft.Resources/operations"].get'
    transform: >
      $["operationId"] = "Operations_ListResourcesOperations";
    reason: Rename duplicate operation Id
#   - remove-operation: ResourceLinks_ListAtSubscription # The filter values are different, so keep this operation.
  - rename-operation:
      from: checkResourceName
      to: ResourceCheck_CheckResourceName
  - rename-model:
      from: Location
      to: LocationExpanded
  - rename-model:
      from: TenantIdDescription
      to: Tenant
  - rename-model:
      from: Tags
      to: Tag
  - rename-model:
      from: TagsResource
      to: TagResource
  - rename-model:
      from: TagsPatchResource
      to: TagPatchResource
  - rename-model:
      from: TagCount
      to: PredefinedTagCount
  - rename-model:
      from: TagValue
      to: PredefinedTagValue
  - rename-model:
      from: TagDetails
      to: PredefinedTag
  - rename-model:
      from: TagsListResult
      to: PredefinedTagsListResult
  - remove-model: DeploymentExtendedFilter
  - remove-model: ResourceProviderOperationDisplayProperties
  - from: subscriptions.json
    where: $.paths
    transform: >
      $["/"] = {
        "get": {
          "tags": [
            "Tenants"
          ],
          "operationId": "Tenants_Get",
          "description": "Gets details about the default tenant.",
          "parameters": [
            {
              "$ref": "#/parameters/ApiVersionParameter"
            }
          ],
          "responses": {
            "200": {
              "description": "OK - Returns information about the tenant.",
              "schema": {
                "$ref": "#/definitions/Tenant"
              }
            },
            "default": {
              "description": "Error response describing why the operation failed.",
              "schema": {
                "$ref": "#/definitions/CloudError"
              }
            }
          }
        }
      }
  - from: policyAssignments.json
    where: $.definitions.Identity.properties.type["x-ms-enum"]
    transform: $["name"] = "PolicyAssignmentIdentityType"
  - from: resources.json,
    where: $.definitions.Identity
    transform: 'return undefined'
  - rename-model:
      from: Identity
      to: PolicyAssignmentIdentity
  - from: locks.json
    where: $.paths..parameters[?(@.name === "scope")]
    transform: >
      $["x-ms-skip-url-encoding"] = true
```

### Tag: package-management

These settings apply only when `--tag=package-management` is specified on the command line.

``` yaml $(tag) == 'package-management'
output-folder: $(this-folder)/ManagementGroup/Generated
namespace: Azure.ResourceManager.Management
title: ManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/94a37114e8f4067410b52d3b1c75aa6e09180658/specification/managementgroups/resource-manager/Microsoft.Management/stable/2021-04-01/management.json
list-exception:
  - /providers/Microsoft.Management/managementGroups/{groupId} # the list method returns a different schema.
request-path-to-parent:
  /providers/Microsoft.Management/managementGroups: /providers/Microsoft.Management/managementGroups/{groupId}
operation-groups-to-omit:
  - ManagementCheck
directive:
  - rename-operation:
      from: CheckNameAvailability
      to: ManagementCheck_CheckNameAvailability
```
