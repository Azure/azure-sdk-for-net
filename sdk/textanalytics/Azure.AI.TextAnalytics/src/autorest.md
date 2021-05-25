# Azure.AI.TextAnalytics

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: release_3_1_preview.5
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/5e1ad2fb49b88b1a17a941228f5238aba74992a6/specification/cognitiveservices/data-plane/TextAnalytics/readme.md
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

### Enable Get based pagination for analyze.
```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/analyze/jobs/{jobId}"]
    transform: >
      if (! $.get["x-ms-pageable"]) {
        $.get["x-ms-pageable"] = {}
      }
      $.get["x-ms-pageable"].operationName = "AnalyzeStatusNextPage";
      $.get["x-ms-pageable"].nextLink;
      $.get["x-ms-pageable"].values;
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/analyze/jobs/{nextLink}"] = {
        "get": {
          "x-ms-pageable": {
            "nextLinkName": "nextLink",
            "itemName": "values"
          },
          "produces": [
            "application/json",
            "text/json"
          ],
          "description": "Get the status of an analysis job.  A job may consist of one or more tasks.  Once all tasks are completed, the job will transition to the completed state and results will be available for each task.",
          "operationId": "AnalyzeStatusNextPage",
          "summary": "Get analysis status and results",
          "parameters": [
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
              "description": "Analysis job status and metadata.",
              "schema": {
                "$ref": "#/definitions/AnalyzeJobState"
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