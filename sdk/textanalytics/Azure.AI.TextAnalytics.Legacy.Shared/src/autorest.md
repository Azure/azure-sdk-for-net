# Azure.AI.TextAnalytics.Legacy.Shared

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

### Old Swagger

``` yaml
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1646226d874de6e8d36ebd3ad088c6c5f6cc6ed0/specification/cognitiveservices/data-plane/TextAnalytics/stable/v3.1/TextAnalytics.json
generation1-convenience-client: true
namespace: Azure.AI.TextAnalytics.Legacy
title: TextAnalyticsClient
modelerfour:
    seal-single-value-enum-by-default: true
    lenient-model-deduplication: true
```

### Update definitions' namespace to Azure.AI.TextAnalytics.Legacy
```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.AI.TextAnalytics.Legacy"
```

### Update operations' namespace to Azure.AI.TextAnalytics.Legacy
```yaml
directive:
  from: swagger-document
  where: $.operations.*
  transform: >
    $["x-namespace"] = "Azure.AI.TextAnalytics.Legacy"

```
### Make types internal

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
- from: swagger-document
  where: $.operations.*
  transform: >
    $["x-accessibility"] = "internal"
- from: swagger-document
  where: $.definitions..properties.*
  transform: >
    $["x-accessibility"] = "internal"
```

### Add nullable annotations
This is to guarantee that we don't introduce breaking changes now that we autogenerate the code.
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
