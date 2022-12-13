# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1be09531e4c6edeafde41d6562371566d39669e8/specification/applicationinsights/data-plane/Monitor.Exporters/preview/v2.1/swagger.json
generation1-convenience-client: true
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"]="internal"
```
