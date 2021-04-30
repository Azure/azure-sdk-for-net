# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: Scanning
input-file: https://github.com/parvsaxena/azure-rest-api-specs/blob/03bf267a86a7bc253b1a96a25425e1768f2a0002/specification/purview/data-plane/Azure.Data.Purview.Scanning/preview/2018-12-01-preview/scanningService.json
namespace: Azure.Data.Purview.Scanning
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