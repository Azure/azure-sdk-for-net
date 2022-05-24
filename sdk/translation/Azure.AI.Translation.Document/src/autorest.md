# Azure.AI.Translation.Document

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_1_0
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/988d42ee7d8ca3243df17bfbc134e0c1f21b481e/specification/cognitiveservices/data-plane/TranslatorText/readme.md
generation1-convenience-client: true
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
