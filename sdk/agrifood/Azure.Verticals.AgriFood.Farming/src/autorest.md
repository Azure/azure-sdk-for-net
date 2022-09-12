# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: FarmBeats
input-file: C:\Users\bhkansag\bhargav-kansagara\azure-rest-api-specs-pr\specification\agrifood\data-plane\Microsoft.AgFoodPlatform\preview\2021-07-31-preview\agfood.json
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
