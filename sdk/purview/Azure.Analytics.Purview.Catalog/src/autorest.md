# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: PurviewCatalog
input-file: https://github.com/Azure/azure-rest-api-specs/blob/57b326de1cb57a447ab4bd0555e70de2adbb3f7d/specification/purview/data-plane/Azure.Purview.Catalog/preview/2021-05-01-preview/purviewcatalog.json
namespace: Azure.Analytics.Purview.Catalog
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

# Add `Purview` To Sub Clients

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >
      if ($.operationId.includes("_")) {
          $.operationId = "Purview" + $.operationId;
      }
```

# Change List -> Get in operation names

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >
      $.operationId = $.operationId.replace("_List", "_Get");
```