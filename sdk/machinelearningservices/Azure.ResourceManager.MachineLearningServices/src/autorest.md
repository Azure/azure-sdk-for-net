# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: MachineLearningServices
namespace: Azure.ResourceManager.MachineLearningServices
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/3bae02c450bf1ee6350a0c24d81923387bdafe57/specification/machinelearningservices/resource-manager/readme.md
tag: package-2021-03-01-preview

modelerfour:
  lenient-model-deduplication: true
clear-output-folder: true
skip-csproj: true
payload-flattening-threshold: 2

operation-group-to-resource-type:
  WorkspaceFeatures: Microsoft.MachineLearningServices/workspaces/features
  Usages: Microsoft.MachineLearningServices/locations/usages
  VirtualMachineSizes: Microsoft.MachineLearningServices/locations/vmSizes
  Quotas: Microsoft.MachineLearningServices/locations/quotas
  WorkspaceSkus: Microsoft.MachineLearningServices/workspaces/skus
  PrivateLinkResources: Microsoft.MachineLearningServices/workspaces/privateLinkResources
  StorageAccount: Microsoft.MachineLearningServices/workspaces/storageAccounts
operation-group-to-resource:
  Quotas: NonResource # POST and GET
  Usages: NonResource
  VirtualMachineSizes: NonResource
operation-group-to-parent:
  Quotas: subscriptions
  Usages: subscriptions
  VirtualMachineSizes: subscriptions
directive:
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
  - from: swagger-document
    where: $.definitions.Compute.properties.provisioningErrors
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.subnet
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.errors
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.virtualMachineImage
    transform: >
        $["x-nullable"] = true;
#BUG: Patch does not return scaledown time PATCH
  - from: swagger-document
    where: $.definitions.ScaleSettings.properties.nodeIdleTimeBeforeScaleDown
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.currentNodeCount
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.targetNodeCount
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.nodeStateCounts
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AmlCompute.allOf[?(@.type=="object")].properties.properties.properties.allocationState
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.EnvironmentContainerResource.properties.systemData
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.DatastoreProperties.properties.properties
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ComputeInstance.allOf[?(@.type=="object")].properties.properties.properties.setupScripts
    transform: >
        $["x-nullable"] = true;
# TEMP Disable XXContainer's CUD
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/codes/{name}"].delete
    transform: >
        $["x-accessibility"] = "internal"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}"].delete
    transform: >
        $["x-accessibility"] = "internal"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/models/{name}"].delete
    transform: >
        $["x-accessibility"] = "internal"
```
