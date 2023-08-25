# Azure.AI.FormRecognizer

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
deserialize-null-collection-as-null-value: true
batch:
  - tag: release_2_1
  - tag: 2023-02-28-preview
```

### AutoRest Configuration
> see https://aka.ms/autorest

### Release 2.1

These settings apply only when `--tag=release_2_1` is specified on the command line.

``` yaml $(tag) == 'release_2_1'
require:
  - https://github.com/Azure/azure-rest-api-specs/blob/64484dc8760571a2de7f5cfbc96861e4a0985a54/specification/cognitiveservices/data-plane/FormRecognizer/readme.md

generate-model-factory: false
generation1-convenience-client: true

directive:
# Make the API version parameterized so we generate a multi-versioned API
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

# Prevent the creation of single-value extensible enums in generated code. The following single-value enums will be generated as string constants.
  - from: swagger-document
    where: $["x-ms-paths"]["/custom/models?op=full"]["get"]["parameters"][0]
    transform: >
      $["x-ms-enum"] = {
        "modelAsString": false
      }
  - from: swagger-document
    where: $["x-ms-paths"]["/custom/models?op=summary"]["get"]["parameters"][0]
    transform: >
      $["x-ms-enum"] = {
        "modelAsString": false
      }

# Make AnalyzeResult.readResult optional
  - from: swagger-document
    where: $.definitions.AnalyzeResult
    transform: $.required = ["version"];

# Add nullable annotations
  - from: swagger-document
    where: $.definitions.AnalyzeResult
    transform: >
      $.properties.readResults["x-nullable"] = true;
      $.properties.pageResults["x-nullable"] = true;
      $.properties.documentResults["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ReadResult
    transform: >
      $.properties.selectionMarks["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AnalyzeOperationResult
    transform: >
      $.properties.analyzeResult["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.KeyValueElement
    transform: >
      $.properties.boundingBox["x-nullable"] = true;
      $.properties.elements["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.PageResult
    transform: >
      $.properties.clusterId["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.DocumentResult
    transform: >
      $.properties.fields.additionalProperties["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FieldValue
    transform: >
      $.properties.valueObject.additionalProperties["x-nullable"] = true;

# Rename duplicated types
  - from: swagger-document
    where: $.definitions.AnalyzeResult
    transform: >
      $["x-ms-client-name"] = "V2AnalyzeResult"

# Make generated models internal by default
  - from: swagger-document
    where: $.definitions.*
    transform: >
      $["x-accessibility"] = "internal"
```

### Release 2023-07-31

These settings apply only when `--tag=2023-02-28-preview` is specified on the command line.

``` yaml $(tag) == '2023-02-28-preview'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/f6bf6555a71cb3167dcff04cc7964bda9ae36a88/specification/cognitiveservices/data-plane/FormRecognizer/stable/2023-07-31/FormRecognizer.json

generate-model-factory: false
generation1-convenience-client: true
suppress-abstract-base-class: OperationDetails

directive:
# Move generated models to the DocumentAnalysis namespace
  - from: swagger-document
    where: $.definitions.*
    transform: >
      $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"

# Rename operationIds
  - from: swagger-document
    where: $.paths.*
    transform: >
      const prefix = "DocumentAnalysis_";
      for (var op of Object.values($)) {
          if (op["operationId"]) {
            op["operationId"] = prefix + op["operationId"]
          }
      }

# Rename duplicated types
  - from: swagger-document
    where: $.definitions.ModelInfo
    transform: >
      $["x-ms-client-name"] = "DocumentModel"
  - from: swagger-document
    where: $.definitions.ErrorResponse
    transform: >
      $["x-ms-client-name"] = "DocumentErrorResponse"
  - from: swagger-document
    where: $.definitions.OperationStatus
    transform: >
      $["x-ms-enum"].name = "DocumentOperationStatus";

# Split identical V2 and V3 enums
  - from: swagger-document
    where: $.definitions.DocumentPage.properties.unit
    transform: >
      $["x-ms-enum"].name = "V3LengthUnit";
  - from: swagger-document
    where: $.definitions.DocumentSelectionMarkState
    transform: >
      $["x-ms-enum"].name = "V3SelectionMarkState";

# Move enums to the DocumentAnalysis namespace
  - from: swagger-document
    where: $.definitions..properties.*
    transform: >
      if ($.enum) {
        $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"
      }

# Move QueryStringIndexType to the DocumentAnalysis namespace
  - from: swagger-document
    where: $.parameters.QueryStringIndexType
    transform: >
      $["x-namespace"] = "Azure.AI.FormRecognizer.DocumentAnalysis"

# Setting these input IDs' formats to `uuid` moves the format validation to the client side, changing the type of the Exception thrown in case of error (breaking change).
  - from: swagger-document
    where: $.parameters
    transform: >
      $.PathOperationId.format = undefined;
      $.PathResultId.format = undefined;

# Setting the Operation-Location format to `uuid` produces code that fails during runtime. The extracted header (a string) cannot be converted to `Uri` directly.
  - from: swagger-document
    where: $.paths..Operation-Location
    transform: >
      $.format = undefined;

# Removing new property 'customNeuralDocumentModelBuilds' in ResourceDetails from the list of required properties, otherwise deserialization breaks when calling older service versions.
  - from: swagger-document
    where: $.definitions.ResourceDetails.required
    transform: >
      $.splice($.indexOf("customNeuralDocumentModelBuilds"), 1);
      return $;
```
