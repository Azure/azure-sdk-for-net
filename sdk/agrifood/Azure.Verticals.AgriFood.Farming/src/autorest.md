# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: FarmBeats
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/23574586aa74cb440da64baa95c9a1e78ca84374/specification/agrifood/data-plane/Microsoft.AgFoodPlatform/preview/2022-11-01-preview/agfood.json

namespace: Azure.Verticals.AgriFood.Farming
security: AADToken
security-scopes: https://farmbeats.azure.net/.default
single-top-level-client: true
```

# Model endpoint parameter as a url, not a string.

```yaml
directive:
  - from: swagger-document
    where: $.parameters.Endpoint
    transform: >
      if ($.format === undefined) {
        $.format = "url";
      }
  - rename-operation:
      from: "FarmOperations_CreateDataIngestionJob"
      to: "FarmOperationsDataIngestion_CreateJob"
  - rename-operation:
      from: "FarmOperations_GetDataIngestionJobDetails"
      to: "FarmOperationsDataIngestion_GetJobDetails"
  - rename-operation:
      from: "OAuthTokens_List"
      to: "FarmerOAuthTokens_ListAuthenticatedFarmersDetails"
  - rename-operation:
      from: "OAuthTokens_GetOAuthConnectionLink"
      to: "FarmerOAuthTokens_GetOAuthConnectionLink"
  - rename-operation:
      from: "OAuthTokens_GetCascadeDeleteJobDetails"
      to: "FarmerOAuthTokens_GetCascadeDeleteJobDetails"
  - rename-operation:
      from: "OAuthTokens_CreateCascadeDeleteJob"
      to: "FarmerOAuthTokens_CreateCascadeDeleteJob"
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/application-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "applicationIds";
  - from: swagger-document
    where: '$.paths["/application-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "applicationIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/attachments"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "attachmentIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/boundaries"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "boundaryIds";
  - from: swagger-document
    where: '$.paths["/boundaries"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "boundaryIds";
  - from: swagger-document
    where: '$.paths["/crops"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "cropIds";
  - from: swagger-document
    where: '$.paths["/crops/{cropId}/crop-varieties"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "cropVarietyIds";
  - from: swagger-document
    where: '$.paths["/crop-varieties"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "cropVarietyIds";
  - from: swagger-document
    where: '$.paths["/farmers"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "farmerIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/farms"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "farmIds";
  - from: swagger-document
    where: '$.paths["/farms"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "farmIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/fields"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "fieldIds";
  - from: swagger-document
    where: '$.paths["/fields"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "fieldIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/harvest-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "harvestDataIds";
  - from: swagger-document
    where: '$.paths["/harvest-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "harvestDataIds";
  - from: swagger-document
    where: '$.paths["/oauth/providers"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "providerIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/planting-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "plantingDataIds";
  - from: swagger-document
    where: '$.paths["/planting-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "plantingDataIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/seasonal-fields"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "seasonalFieldIds";
  - from: swagger-document
    where: '$.paths["/seasonal-fields"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "seasonalFieldIds";
  - from: swagger-document
    where: '$.paths["/seasons"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "seasonIds";
  - from: swagger-document
    where: '$.paths["/farmers/{farmerId}/tillage-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "tillageDataIds";
  - from: swagger-document
    where: '$.paths["/tillage-data"].get.parameters[?(@["name"] == "ids")]'
    transform: >
      $["x-ms-client-name"] = "tillageDataIds";
```
