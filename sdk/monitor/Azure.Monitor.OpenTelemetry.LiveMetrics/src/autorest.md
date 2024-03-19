# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/06f159b1e3ecf993331d542b75118736f3eab274/specification/applicationinsights/data-plane/LiveMetrics/preview/2024-04-01-preview/livemetrics.json
generation1-convenience-client: true
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"]="internal"
```
