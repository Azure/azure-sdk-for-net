# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: MachineLearningServices
require: https://raw.githubusercontent.com/forteddyt/azure-rest-api-specs/3b1ac1f420a939a22e125869b16e6381001d291d/specification/machinelearningservices/resource-manager/readme.md
tag: package-2022-02-01-preview
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
  - from: swagger-document
    where: $.definitions.DataSettings.properties.trainingData
    transform: >
        $["x-ms-client-name"] = "trainingDataSettings";
  - from: swagger-document
    where: $.definitions.ComputeInstanceProperties.properties.setupScripts
    transform: >
        $["x-ms-client-name"] = "setupScriptsSettings";
```