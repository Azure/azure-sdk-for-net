# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: MachineLearningServices
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a2792ff53ed316c367d77b622ba59cf9a6c88da4/specification/machinelearningservices/resource-manager/readme.md
tag: package-2021-03-01-preview
clear-output-folder: true
skip-csproj: true
namespace: Azure.ResourceManager.MachineLearningServices
modelerfour:
  lenient-model-deduplication: true

model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
  Operations: Microsoft.MachineLearningServices/operations
  WorkspaceFeatures: Microsoft.MachineLearningServices/workspaces/features
  Usages: Microsoft.MachineLearningServices/locations/usages
  VirtualMachineSizes: Microsoft.MachineLearningServices/locations/vmSizes
  Quotas: Microsoft.MachineLearningServices/locations/quotas
  WorkspaceSkus: Microsoft.MachineLearningServices/workspaces/skus
  PrivateLinkResources: Microsoft.MachineLearningServices/workspaces/privateLinkResources
  Notebooks: Microsoft.MachineLearningServices/workspaces
  StorageAccount: Microsoft.MachineLearningServices/workspaces/storageAccounts
operation-group-to-resource:
  Operations: NonResource
  Quotas: NonResource # POST and GET
operation-group-to-parent:
  Operations: tenant
  Quotas: subscriptions
directive:
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
  - rename-model:
      from: Operation
      to: RestApi
# Following two transforms are temporary due to non-nullable properties (properties that do not declare x-nullable: true) being null in service response
  - from: swagger-document
    where: $.definitions.NotebookResourceInfo.properties.notebookPreparationError
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Workspace.properties.tags
    transform: >
        $["x-nullable"] = true;
```
