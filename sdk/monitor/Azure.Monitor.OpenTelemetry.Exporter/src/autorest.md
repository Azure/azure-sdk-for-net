# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0ae35fd0c27e0f06004d820e75a13c615b9c2e96/specification/applicationinsights/data-plane/Monitor.Exporters/preview/2020-09-15_Preview/swagger.json
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"]="internal"
```
