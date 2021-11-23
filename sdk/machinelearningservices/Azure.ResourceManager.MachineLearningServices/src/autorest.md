# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: MachineLearningServices
require: https://raw.githubusercontent.com/zhaomuzhi/azure-rest-api-specs/b0e720851e7f0071dd653c6430af6be844975f8e/specification/machinelearningservices/resource-manager/readme.md
modelerfour:
    lenient-model-deduplication: true
clear-output-folder: true
namespace: Azure.ResourceManager.MachineLearningServices
skip-csproj: true
payload-flattening-threshold: 2
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
```