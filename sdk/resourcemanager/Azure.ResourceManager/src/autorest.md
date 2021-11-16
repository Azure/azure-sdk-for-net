# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
arm-core: true
clear-output-folder: true
use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
modelerfour:
  lenient-model-deduplication: true
skip-csproj: true
batch:
  - tag: package-common-type
  - tag: package-resources
```

### Tag: package-common-type

These settings apply only when `--tag=package-common-type` is specified on the command line.

``` yaml $(tag) == 'package-common-type'
output-folder: $(this-folder)/Generated
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
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
  ResourceLinks: Microsoft.Resources/links
  DataPolicyManifests: Microsoft.Authorization/dataPolicyManifests
#   Providers: Microsoft.Resources/providers
operation-group-to-resource:
  ResourceLinks: ResourceLink
  DataPolicyManifests: DataPolicyManifest
operation-group-to-parent:
  PolicyAssignments: tenant
  PolicyDefinitions: tenant
  PolicySetDefinitions: tenant
  PolicyExemptions: tenant
  ManagementLocks: tenant
  ResourceLinks: tenant
operation-groups-to-omit:
  Deployments;DeploymentOperations;AuthorizationOperations
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
  - remove-operation: ResourceLinks_ListAtSubscription
  - from: policyAssignments.json
    where: $.definitions.Identity.properties.type["x-ms-enum"]
    transform: $["name"] = "PolicyAssignmentIdentityType"
  - rename-model:
      from: Identity
      to: PolicyAssignmentIdentity
```
