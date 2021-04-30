# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: Catalog
input-file: https://github.com/Azure/azure-rest-api-specs/tree/6201f0ba800aae592e3efe70d73338787b674efe/specification/purview/data-plane/Azure.Purview.Catalog/preview/2020-12-01-preview/purviewcatalog.json
namespace: Azure.Data.Purview.Catalog
low-level-client: true
credential-types: TokenCredential
credential-scopes:  https://purview.azure.net/.default
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
