# Azure.AI.TextAnalytics

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/6c9d4fe7445b78db8336271895924379d95fbc6c/specification/cognitiveservices/data-plane/TextAnalytics/preview/v3.1-preview.4/TextAnalytics.json
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

### Add x-ms-paths section if not exists

```yaml
directive:
  - from: swagger-document
    where: $
    transform: >
      if (!$["x-ms-paths"]) {
        $["x-ms-paths"] = {}
      }
```

### Enable Get based pagination for health.
```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/entities/health/jobs/{jobId}"]
    transform: >
      if (! $.get["x-ms-pageable"]) {
        $.get["x-ms-pageable"] = {}
      }
      $.get["x-ms-pageable"].operationName = "HealthStatusNextPage";
      $.get["x-ms-pageable"].nextLink;
      $.get["x-ms-pageable"].values;
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/entities/health/jobs/{nextLink}"] = {
        "get": {
          "x-ms-pageable": {
            "nextLinkName": "nextLink",
            "itemName": "values"
          },
          "produces": [
            "application/json",
            "text/json"
          ],
          "description": "Get details of the healthcare prediction job specified by the jobId.",
          "operationId": "HealthStatusNextPage",
          "summary": "Get healthcare analysis job status and results",
          "parameters": [
            {
              "$ref": "#/parameters/ShowStats"
            },
            {
              "name": "nextLink",
              "in": "path",
              "required": true,
              "type": "string",
              "description": "Next link for list operation.",
              "x-ms-skip-url-encoding": true
            }
          ],
          "responses": {
            "200": {
              "description": "OK",
              "schema": {
                "$ref": "#/definitions/HealthcareJobState"
              }
            },
            "404": {
              "description": "Job ID not found.",
              "schema": {
                "$ref": "#/definitions/ErrorResponse"
              },
              "x-ms-error-response": true
            },
            "500": {
              "description": "Internal error response",
              "schema": {
                "$ref": "#/definitions/ErrorResponse"
              },
              "x-ms-error-response": true
            }
          },
          "deprecated": false
        }
      }
```