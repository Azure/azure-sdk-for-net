# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

version: 3.4.1
use: https://github.com/Azure/autorest.csharp/releases/download/v3.0.0-beta.20210524.2/autorest-csharp-3.0.0-beta.20210524.2.tgz
azure-arm: true
library-name: MachineLearningServices
input-file:
- ./machineLearningServices.json
save-inputs: true
clear-output-folder: true
namespace: Azure.ResourceManager.MachineLearningServices
modelerfour:
    lenient-model-deduplication: true
skip-csproj-packagereference: true

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
  Workspace: Microsoft.MachineLearningServices/workspaces/skus
  PrivateLinkResources: Microsoft.MachineLearningServices/workspaces/privateLinkResources
  Notebooks: Microsoft.MachineLearningServices/workspaces
  StorageAccount: NonResourceMicrosoft.MachineLearningServices/workspaces/listStorageAccountKeys
operation-group-to-resource:
  Operations: NonResource
  WorkspaceFeatures: AmlUserFeature # no PUT
  Usages: NonResource
  VirtualMachineSizes: NonResource
  Quotas: NonResource
  Workspace: WorkspaceSku # no PUT
  PrivateLinkResources: PrivateLinkResource # no PUT
  Notebooks: NonResource
  StorageAccount: NonResource
  MachineLearningCompute: ComputeResource
  MachineLearningService: ServiceResource # PUT req/res mismatch
  WorkspaceConnections: WorkspaceConnection # PUT req/res mismatch
operation-group-to-parent:
  Usages: Locations
  VirtualMachineSizes: Locations
  Quotas: Locations
  Notebooks: Workspaces
  StorageAccount: Workspaces
directive:
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
```
