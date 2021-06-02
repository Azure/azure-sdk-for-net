# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: MachineLearningServices
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ecc8630f732fe34ef6bd963ef0834a6b85307582/specification/machinelearningservices/resource-manager/readme.md
tag: package-2021-03-01-preview
clear-output-folder: true
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
  WorkspaceFeatures: NonResource # no PUT
  Usages: NonResource
  VirtualMachineSizes: NonResource
  Quotas: NonResource
  WorkspaceSkus: NonResource # no PUT
  PrivateLinkResources: NonResource # no PUT
  Notebooks: NonResource
  StorageAccount: NonResource
  MachineLearningServices: ServiceResource # PUT req/res mismatch
  WorkspaceConnections: WorkspaceConnection # PUT req/res mismatch
operation-group-to-parent:
  Usages: Locations
  VirtualMachineSizes: Locations
  Quotas: Locations
  Notebooks: Workspaces
  StorageAccount: Workspaces
  WorkspaceFeatures: Workspaces
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
```
