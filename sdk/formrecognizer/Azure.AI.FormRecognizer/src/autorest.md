# Azure.AI.FormRecognizer

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_2_1_preview.2
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/788507c386197b1ba7878fa00fe30871b8b01f22/specification/cognitiveservices/data-plane/FormRecognizer/readme.md
```


### Make AnalyzeResult.readResult optional
This is a temporary work-around
``` yaml
directive:
- from: swagger-document
  where: $.definitions.AnalyzeResult
  transform: $.required = ["version"];
```

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AnalyzeResult
  transform: >
    $.properties.readResults["x-nullable"] = true;
    $.properties.pageResults["x-nullable"] = true;
    $.properties.documentResults["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ReadResult
  transform: >
    $.properties.selectionMarks["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.KeyValueType
  transform: >
    $["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AnalyzeOperationResult
  transform: >
    $.properties.analyzeResult["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.KeyValueElement
  transform: >
    $.properties.boundingBox["x-nullable"] = true;
    $.properties.elements["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.PageResult
  transform: >
    $.properties.clusterId["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DocumentResult
  transform: >
    $.properties.fields.additionalProperties["x-nullable"] = true;
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
