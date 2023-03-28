# Azure.ResourceManager.Resources
### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
azure-arm: true
arm-core: true
# clear-output-folder: true
use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/net6.0/
output-folder: $(this-folder)/../src/PsuedoGenerated/Resources
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
namespace: Azure.ResourceManager.Resources
model-namespace: false
public-clients: false
head-as-boolean: false
skip-csproj: true
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
