# Azure.AI.FormRecognizer

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/40008a6fae4c614cfed5f401a635462eb4e93a93/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.0/FormRecognizer.json
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
