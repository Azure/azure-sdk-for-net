# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/665e7c3b6f26b148b3c05e55602621bc293cc0a4/specification/applicationinsights/data-plane/LiveMetrics/preview/2024-04-01-preview/livemetrics.json
generation1-convenience-client: true
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"]="internal"
```
