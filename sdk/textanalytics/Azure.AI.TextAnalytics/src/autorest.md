# Azure.AI.TextAnalytics

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/2c66a689c610dbef623d6c4e4c4e913446d5ac68/specification/cognitiveservices/data-plane/Language/preview/2022-02-01-preview/textanalytics.json
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

### Make taskName non-required
This should be deleted in service v3.2 when service enables taskName again
``` yaml
directive:
  from: swagger-document
  where: $.definitions.TaskState
  transform: >
    $["required"] = ["status", "lastUpdateDateTime"]
```
