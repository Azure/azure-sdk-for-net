# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: FarmBeats
input-file: https://github.com/Azure/azure-rest-api-specs/blob/683e3f4849ee1d84629d0d0fa17789e80a9cee08/specification/agfood/data-plane/Microsoft.AgFoodPlatform/preview/2021-03-31-preview/agfood.json
namespace: Azure.Verticals.AgriFood.Farming
data-plane: true
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
