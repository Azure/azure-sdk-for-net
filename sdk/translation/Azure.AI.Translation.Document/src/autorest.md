# Azure.AI.Translation.Document

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_1_0
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/cde7f150e8d3bf3af2418cc347cae0fb2baed6a7/specification/cognitiveservices/data-plane/TranslatorText/readme.md
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
