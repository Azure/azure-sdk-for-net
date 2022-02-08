# Azure.AI.FormRecognizer

Run `dotnet build /t:GenerateCode` to generate code. Notice how there are two main swaggers use to generate this client library:
- Service V2.x
- Service V3 

### AutoRest Configuration
> see https://aka.ms/autorest

# Service V2.x swagger

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
modelerfour:
    seal-single-value-enum-by-default: true
```

## Make the API version parameterized so we generate a multi-versioned API

``` yaml
directive:
- from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
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

## Make AnalyzeResult.readResult optional
This is a temporary work-around
``` yaml
directive:
- from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.AnalyzeResult
  transform: $.required = ["version"];
```

## Add nullable annotations

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.AnalyzeResult
  transform: >
    $.properties.readResults["x-nullable"] = true;
    $.properties.pageResults["x-nullable"] = true;
    $.properties.documentResults["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.ReadResult
  transform: >
    $.properties.selectionMarks["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.AnalyzeOperationResult
  transform: >
    $.properties.analyzeResult["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.KeyValueElement
  transform: >
    $.properties.boundingBox["x-nullable"] = true;
    $.properties.elements["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.PageResult
  transform: >
    $.properties.clusterId["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.DocumentResult
  transform: >
    $.properties.fields.additionalProperties["x-nullable"] = true;
```

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.FieldValue
  transform: >
    $.properties.valueObject.additionalProperties["x-nullable"] = true;
```

## Rename duplicated types
``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.AnalyzeResult
  transform: >
    $["x-ms-client-name"] = "V2AnalyzeResult"
```

## Make generated models internal by default

``` yaml
directive:
  from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```

# Service V3 swagger
``` yaml
input-file:
  -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
```

## Make generated models internal by default
``` yaml
directive:
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal";
    $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
```

## Rename operationIds
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.paths.*
  transform: >
    const prefix = "DocumentAnalysis_";
    for (var op of Object.values($)) {
        if (op["operationId"]) {
            op["operationId"] = prefix + op["operationId"]
        }
    }
```

## Rename duplicated types
``` yaml
directive:
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions.ModelInfo
  transform: >
    $["x-ms-client-name"] = "DocumentModel"
```

``` yaml
directive:
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions.ErrorResponse
  transform: >
    $["x-ms-client-name"] = "DocumentErrorResponse"
```

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions..properties.*
  transform: >
    if ($.enum &&  $["x-ms-enum"].name == "OperationStatus") {
        $["x-ms-enum"].name = "OperationInfoStatus";
        $["x-accessibility"] = "internal";
    }
```

## Split identical V2 and V3 enums

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions.DocumentPage.properties.unit
  transform: >
    $["x-ms-enum"].name = "V3LengthUnit";
```

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions.DocumentSelectionMarkState
  transform: >
    $["x-ms-enum"].name = "V3SelectionMarkState";
```

## Make enums internal and in the right namespace
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.definitions..properties.*
  transform: >
    if ($.enum) {
        $["x-accessibility"] = "internal";
        $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
    }
```

## Rename QueryStringIndexType
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8e73bccfad3f6873b9f91d3920ce0f96af554378/specification/cognitiveservices/data-plane/FormRecognizer/preview/2022-01-30-preview/FormRecognizer.json
  where: $.parameters.QueryStringIndexType
  transform: >
    $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
```
