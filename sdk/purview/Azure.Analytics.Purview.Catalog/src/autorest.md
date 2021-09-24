# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
title: PurviewCatalog
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a09d5d31b42228a9cbec47c266c89f1028a1c17f/specification/purview/data-plane/Azure.Analytics.Purview.Catalog/preview/2021-09-01/purviewcatalog.json
namespace: Azure.Analytics.Purview.Catalog
low-level-client: true
security: AADToken
security-scopes:  https://purview.azure.net/.default
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

# Rename operation names in Collection
```yaml
directive:
  - rename-operation:
      from: Collection_CreateOrUpdate
      to: Collection_CreateOrUpdateEntity
  - rename-operation:
      from: Collection_CreateOrUpdateBulk
      to: Collection_CreateOrUpdateEntityInBulk
```

# Promote Discovery members to PurviewCatalogClient

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId !== undefined)]
    transform: >
      if ($.operationId.startsWith("Discovery_")) {
        $.operationId = $.operationId.replace("Discovery_", "");
      }
```

# Rename Query to Search (to follow .NET Naming Conventions)

```yaml
directive:
  - from: swagger-document
    where: $..[?(@.operationId === "Query")]
    transform: >
        $.operationId = "Search";
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
