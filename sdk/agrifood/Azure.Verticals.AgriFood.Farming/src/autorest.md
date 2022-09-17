# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: FarmBeats
input-file: https://github.com/Azure/azure-rest-api-specs/blob/2969d7b53325b54b61fa827f2dfb85a0df9f82d0/specification/agrifood/data-plane/Microsoft.AgFoodPlatform/preview/2021-07-31-preview/agfood.json
namespace: Azure.Verticals.AgriFood.Farming
security: AADToken
security-scopes: https://farmbeats.azure.net/.default
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
```
