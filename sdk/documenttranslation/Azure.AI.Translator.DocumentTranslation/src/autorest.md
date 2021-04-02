# Azure.AI.Translator.DocumentTranslation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_1_0_preview.1
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/0edc3016898fd5f964358e7b323f5d41b06a5662/specification/cognitiveservices/data-plane/TranslatorText/readme.md
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
