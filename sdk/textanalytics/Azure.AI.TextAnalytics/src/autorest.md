# Azure.AI.TextAnalytics

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/9b2689fe79302577b843f1cdf40f42330a67de08/specification/cognitiveservices/data-plane/TextAnalytics/preview/v3.1-preview.3/TextAnalytics.json
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```

### Add nullable annotations
This is to guarantee that we don't introduce breaking changes now that we autogerate the code.
``` yaml
directive:
  from: swagger-document
  where: $.definitions.DetectedLanguage
  transform: >
    $.properties.name["x-nullable"] = true;
    $.properties.iso6391Name["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.LanguageInput
  transform: >
    $.properties.id["x-nullable"] = true;
    $.properties.text["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.MultiLanguageInput
  transform: >
    $.properties.id["x-nullable"] = true;
    $.properties.text["x-nullable"] = true;
```