# Azure.AI.FormRecognizer

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_2_1_preview.3
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/5a260d47021d8278c26dd6f946f4e6b97e0cd023/specification/cognitiveservices/data-plane/FormRecognizer/readme.md
```

### Make the API version parameterized so we generate a multi-versioned API

This should be fixed in the swagger, but we're working around it locally for now.
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-parameterized-host"]
  transform: >
    $.hostTemplate = "{endpoint}/formrecognizer/{apiVersion}";
    $.parameters.push({
      "name": "apiVersion",
      "description": "Form Recognizer API version (for example: v2.0).",
      "x-ms-parameter-location": "client",
      "required": true,
      "type": "string",
      "in": "path",
      "x-ms-skip-url-encoding": true
    });
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

``` yaml
directive:
  from: swagger-document
  where: $.definitions.FieldValue
  transform: >
    $.properties.valueObject.additionalProperties["x-nullable"] = true;
```

### Make generated models internal by default

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```
