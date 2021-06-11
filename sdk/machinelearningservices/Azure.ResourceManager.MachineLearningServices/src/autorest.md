# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: MachineLearningServices
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/readme.md
tag: package-2021-03-01-preview-without-services # should use official tag after ML team delete services.json from default tag
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
  # WorkspaceFeatures: NonResource # no PUT
  # Usages: NonResource
  VirtualMachineSizes: NonResource # list only, but value is not value
  Quotas: NonResource # POST and GET
  # WorkspaceSkus: NonResource # no PUT, Sub level
  # PrivateLinkResources: NonResource # no PUT
operation-group-to-parent:
  Operations: tenant
  WorkspaceFeatures: Workspaces
  Usages: Subscriptions
  VirtualMachineSizes: Locations
  Quotas: Locations
  Notebooks: Workspaces
  WorkspaceSkus: Workspaces
  PrivateLinkResources: Workspaces
directive:
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
  - rename-model:
      from: Operation
      to: RestApi
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/prepareNotebook'].post.operationId
    transform: return "Workspaces_PrepareNotebook";
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/listNotebookKeys'].post.operationId
    transform: return "Workspaces_ListNotebookKeys";
# Following two transform are temporary, waiting on ML team to fix swagger.
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/connections/{connectionName}'].put.parameters[5].schema
    transform: >
        $["$ref"] = "#/definitions/WorkspaceConnection";
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/services/{serviceName}'].put.parameters[5].schema
    transform: >
        $["$ref"] = "#/definitions/ServiceResource";
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

### Tag: package-2021-03-01-preview-without-services

These settings apply only when `--tag=package-2021-03-01-preview-without-services` is specified on the command line.

```yaml $(tag) == 'package-2021-03-01-preview-without-services'
input-file:
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/preview/2021-03-01-preview/machineLearningServices.json
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/preview/2021-03-01-preview/mfe.json
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/preview/2021-03-01-preview/workspaceFeatures.json
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/Microsoft.MachineLearningServices/preview/2021-03-01-preview/workspaceSkus.json
```