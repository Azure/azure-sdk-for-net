# Azure.AI.DocumentTranslation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/a23007d37fda10c8faada14ac960a49a39501803/specification/cognitiveservices/data-plane/TranslatorText/preview/v1.0-preview.1/TranslatorBatch.json
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
