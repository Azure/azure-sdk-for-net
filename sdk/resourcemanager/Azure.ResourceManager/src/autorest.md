# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
arm-core: true
namespace: Azure.ResourceManager
input-file:
# temporarily using a local file to work around an autorest bug that loses extensions during deduplication of schemas
#  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac3be41ee22ada179ab7b970e98f1289188b3bae/specification/common-types/resource-management/v2/types.json
  - $(this-folder)/types.json
#  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac3be41ee22ada179ab7b970e98f1289188b3bae/specification/common-types/resource-management/v2/privatelinks.json
  - $(this-folder)/privatelinks.json

modelerfour:
  lenient-model-deduplication: true
skip-csproj: true

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
# work around CheckNameAvailabilityResponse readonly property issue
  - from: types.json
    where: $.definitions["CheckNameAvailabilityResponse"]["x-csharp-usage"]
    transform: return "model,output"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-accessibility"] = "public"
  - from: types.json
    where: $.definitions.systemData.properties.*
    transform: >
      $["readOnly"] = true
# Below are for privatelinks.json      
  - from: privatelinks.json
    where: $.definitions.*
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models";
      $["x-accessibility"] = "public";
      $["x-csharp-formats"] = "json";
      $["x-csharp-usage"] = "model,input,output";
      $["x-ms-mgmt-classReferenceType"] = true;
  - from: privatelinks.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Models";
      $["x-accessibility"] = "public";
  - rename-model:
      from: PrivateLinkResource
      to: PrivateLinkResourceData
  - rename-model:
      from: PrivateEndpointConnection
      to: PrivateEndpointConnectionData
  - rename-model:
      from: PrivateEndpointConnectionListResult
      to: PrivateEndpointConnectionList
  - rename-model:
      from: PrivateLinkResourceListResult
      to: PrivateLinkResourceList
```
