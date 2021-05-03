# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: Scanning
input-file: https://github.com/Azure/azure-rest-api-specs/blob/8478d2280c54d0065ac6271e39321849c090c659/specification/purview/data-plane/Azure.Data.Purview.Scanning/preview/2018-12-01-preview/scanningService.json
namespace: Azure.Analytics.Purview.Scanning
low-level-client: true
credential-types: TokenCredential
credential-scopes:  https://purview.azure.net/.default
modelerfour:
  lenient-model-deduplication: true
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