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
generation1-convenience-client: true
```

## Suppress Abstract Base Class

``` yaml
suppress-abstract-base-class: OperationDetails
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

## Seal single value enums

Prevents the creation of single-value extensible enums in generated code. The following single-value enums will be generated as string constants.

``` yaml
directive:
- from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $["x-ms-paths"]["/custom/models?op=full"]["get"]["parameters"][0]
  transform: >
    $["x-ms-enum"] = {
      "modelAsString": false
    }
```

``` yaml
directive:
- from: https://github.com/Azure/azure-rest-api-specs/blob/7043b48f4be1fdd40757b9ef372b65f054daf48f/specification/cognitiveservices/data-plane/FormRecognizer/stable/v2.1/FormRecognizer.json
  where: $["x-ms-paths"]["/custom/models?op=summary"]["get"]["parameters"][0]
  transform: >
    $["x-ms-enum"] = {
      "modelAsString": false
    }
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
  -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
```

## Move generated models to the DocumentAnalysis namespace
``` yaml
directive:
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
```

## Rename operationIds
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
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
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.ModelInfo
  transform: >
    $["x-ms-client-name"] = "DocumentModel"
```

``` yaml
directive:
  from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.ErrorResponse
  transform: >
    $["x-ms-client-name"] = "DocumentErrorResponse"
```

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.OperationStatus
  transform: >
    $["x-ms-enum"].name = "DocumentOperationStatus";
```

## Split identical V2 and V3 enums

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.DocumentPage.properties.unit
  transform: >
    $["x-ms-enum"].name = "V3LengthUnit";
```

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.DocumentSelectionMarkState
  transform: >
    $["x-ms-enum"].name = "V3SelectionMarkState";
```

## Move enums to the DocumentAnalysis namespace
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions..properties.*
  transform: >
    if ($.enum) {
        $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
    }
```

## Rename QueryStringIndexType
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.parameters.QueryStringIndexType
  transform: >
    $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
```

``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.definitions.AnalyzeDocumentRequest.properties.urlSource
  transform: >
    $["x-ms-client-name"] = "uriSource";
```

## Remove uuid format restrictions
Setting these input IDs' formats to `uuid` moves the format validation to the client side, chaging the type of the Exception thrown in case of error (breaking change).
``` yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.parameters
  transform: >
    $.PathOperationId.format = undefined;
    $.PathResultId.format = undefined;
```

Setting the Operation-Location format to `uuid` produces code that fails during runtime. The extracted header (a string) cannot be converted to `Uri` directly.
```yaml
directive:
- from: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/6e47de70bfbfa1124728808335571898c123d3fe/specification/cognitiveservices/data-plane/FormRecognizer/preview/2023-02-28-preview/FormRecognizer.json?token=GHSAT0AAAAAAB5R7LXBO4TEYHCSVVFEHA5YZAHJZSA
  where: $.paths..Operation-Location
  transform: >
    $.format = undefined;
```
