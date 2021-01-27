# Azure.AI.MetricsAdvisor

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/3cbc984fcf0fab278b9c28175319f65db1b9162a/specification/cognitiveservices/data-plane/MetricsAdvisor/preview/v1.0/MetricsAdvisor.json
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

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DataFeedDetail
  transform: >
    $.properties.granularityAmount["x-nullable"] = true
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DataFeedIngestionProgress
  transform: >
    $.properties.latestSuccessTimestamp["x-nullable"] = true;
    $.properties.latestActiveTimestamp["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.CommentFeedback
  transform: >
    $.allOf[1].properties.startTime["x-nullable"] = true
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.CommentFeedback
  transform: >
    $.allOf[1].properties.endTime["x-nullable"] = true
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AnomalyFeedback
  transform: >
    $.allOf[1].properties.anomalyDetectionConfigurationId["x-nullable"] = true
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AnomalyFeedback
  transform: >
    $.allOf[1].properties.anomalyDetectionConfigurationSnapshot["x-nullable"] = true
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SeriesResult
  transform: >
    $.properties.isAnomalyList.items["x-nullable"] = true;
    $.properties.periodList.items["x-nullable"] = true;
    $.properties.expectedValueList.items["x-nullable"] = true;
    $.properties.lowerBoundaryList.items["x-nullable"] = true;
    $.properties.upperBoundaryList.items["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AzureApplicationInsightsParameter
  transform: >
    $.properties.apiKey["x-nullable"] = true;
    $.properties.applicationId["x-nullable"] = true;
    $.properties.azureCloud["x-nullable"] = true;
    $.properties.query["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AzureBlobParameter
  transform: >
    $.properties.connectionString["x-nullable"] = true;
    $.properties.container["x-nullable"] = true;
    $.properties.blobTemplate["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AzureCosmosDBParameter
  transform: >
    $.properties.collectionId["x-nullable"] = true;
    $.properties.connectionString["x-nullable"] = true;
    $.properties.database["x-nullable"] = true;
    $.properties.sqlQuery["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AzureDataLakeStorageGen2Parameter
  transform: >
    $.properties.accountKey["x-nullable"] = true;
    $.properties.accountName["x-nullable"] = true;
    $.properties.directoryTemplate["x-nullable"] = true;
    $.properties.fileSystemName["x-nullable"] = true;
    $.properties.fileTemplate["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AzureTableParameter
  transform: >
    $.properties.connectionString["x-nullable"] = true;
    $.properties.query["x-nullable"] = true;
    $.properties.table["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ElasticsearchParameter
  transform: >
    $.properties.authHeader["x-nullable"] = true;
    $.properties.host["x-nullable"] = true;
    $.properties.port["x-nullable"] = true;
    $.properties.query["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.HttpRequestParameter
  transform: >
    $.properties.httpHeader["x-nullable"] = true;
    $.properties.httpMethod["x-nullable"] = true;
    $.properties.payload["x-nullable"] = true;
    $.properties.url["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.InfluxDBParameter
  transform: >
    $.properties.connectionString["x-nullable"] = true;
    $.properties.database["x-nullable"] = true;
    $.properties.password["x-nullable"] = true;
    $.properties.query["x-nullable"] = true;
    $.properties.userName["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.MongoDBParameter
  transform: >
    $.properties.command["x-nullable"] = true;
    $.properties.connectionString["x-nullable"] = true;
    $.properties.database["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SqlSourceParameter
  transform: >
    $.properties.connectionString["x-nullable"] = true;
    $.properties.query["x-nullable"] = true;
```

### Add required properties

``` yaml
directive:
  from: swagger-document
  where: $.definitions.IngestionStatus
  transform: >
    $["required"] = ["timestamp", "status", "message"]
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.EnrichmentStatus
  transform: >
    $["required"] = ["timestamp", "status", "message"]
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.MetricSeriesItem
  transform: >
    $["required"] = ["metricId", "dimension"]
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.MetricDataItem
  transform: >
    $["required"] = ["id", "timestampList", "valueList"]
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AlertResult
  transform: >
    $["required"] = ["alertId", "createdTime", "modifiedTime", "timestamp"]
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.IncidentProperty
  transform: >
    $["required"] = ["maxSeverity", "incidentStatus"]
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

### Enable Post based pagination for AlertsByAnomalyAlertingConfiguration.

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/alert/anomaly/configurations/{configurationId}/alerts/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getAlertsByAnomalyAlertingConfigurationNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getAlertsByAnomalyAlertingConfigurationNext"] = {
        "post": {
          "tags": [
            "AnomalyAlerting"
          ],
          "summary": "Query alerts under anomaly alerting configuration",
          "operationId": "getAlertsByAnomalyAlertingConfigurationNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "query alerting result request",
              "required": true,
              "schema": {
                "$ref": "#/definitions/AlertingResultQuery"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/AlertResultList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for AnomaliesByAnomalyDetectionConfiguration

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/enrichment/anomalyDetection/configurations/{configurationId}/anomalies/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getAnomaliesByAnomalyDetectionConfigurationNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getAnomaliesByAnomalyDetectionConfigurationNext"] = {
        "post": {
          "tags": [
            "AnomalyDetection"
          ],
          "summary": "Query anomalies under anomaly detection configuration",
          "operationId": "getAnomaliesByAnomalyDetectionConfigurationNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "query detection anomaly result request",
              "required": true,
              "schema": {
                "$ref": "#/definitions/DetectionAnomalyResultQuery"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/AnomalyResultList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination DimensionOfAnomaliesByAnomalyDetectionConfiguration

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/enrichment/anomalyDetection/configurations/{configurationId}/anomalies/dimension/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getDimensionOfAnomaliesByAnomalyDetectionConfigurationNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getDimensionOfAnomaliesByAnomalyDetectionConfigurationNext"] = {
        "post": {
          "tags": [
            "AnomalyDetection"
          ],
          "summary": "Query dimension values of anomalies",
          "operationId": "getDimensionOfAnomaliesByAnomalyDetectionConfigurationNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "query dimension values request",
              "required": true,
              "schema": {
                "$ref": "#/definitions/AnomalyDimensionQuery"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/AnomalyDimensionList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for MetricFeedbacks

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/feedback/metric/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "listMetricFeedbacksNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?listMetricFeedbacksNext"] = {
        "post": {
          "tags": [
            "Feedback"
          ],
          "summary": "List feedback on the given metric",
          "operationId": "listMetricFeedbacksNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "metric feedback filter",
              "required": true,
              "schema": {
                "$ref": "#/definitions/MetricFeedbackFilter"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/MetricFeedbackList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for DataFeedIngestionStatus

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/dataFeeds/{dataFeedId}/ingestionStatus/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getDataFeedIngestionStatusNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getDataFeedIngestionStatusNext"] = {
        "post": {
          "tags": [
            "IngestionStatus"
          ],
          "summary": "Get data ingestion status by data feed",
          "operationId": "getDataFeedIngestionStatusNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "The query time range",
              "required": true,
              "schema": {
                "$ref": "#/definitions/IngestionStatusQueryOptions"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/IngestionStatusList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for MetricSeries

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/metrics/{metricId}/series/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getMetricSeriesNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getMetricSeriesNext"] = {
        "post": {
          "tags": [
            "Metric"
          ],
          "summary": "List series (dimension combinations) from metric",
          "operationId": "getMetricSeriesNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "filter to query series",
              "required": true,
              "schema": {
                "$ref": "#/definitions/MetricSeriesQueryOptions"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/MetricSeriesList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for MetricDimension

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/metrics/{metricId}/dimension/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getMetricDimensionNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getMetricDimensionNext"] = {
        "post": {
          "tags": [
            "Metric"
          ],
          "summary": "List dimension from certain metric",
          "operationId": "getMetricDimensionNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "query dimension option",
              "required": true,
              "schema": {
                "$ref": "#/definitions/MetricDimensionQueryOptions"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/MetricDimensionList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```

### Enable Post based pagination for EnrichmentStatusByMetric

```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/metrics/{metricId}/status/enrichment/anomalyDetection/query"]
    transform: >
      let pageExt = $.post["x-ms-pageable"];
      if (!pageExt) {
        pageExt["operationName"] = "getEnrichmentStatusByMetricNext"
        $.post["x-ms-pageable"] = pageExt
      }
```

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-paths"]
    transform: >
      $["/{nextLink}?getEnrichmentStatusByMetricNext"] = {
        "post": {
          "tags": [
            "Metric"
          ],
          "summary": "Query anomaly detection status",
          "operationId": "getEnrichmentStatusByMetricNext",
          "consumes": [
            "application/json"
          ],
          "produces": [
            "application/json"
          ],
          "parameters": [
            {
              "in": "path",
              "name": "nextLink",
              "description": "the next link",
              "required": true,
              "type": "string",
              "x-ms-skip-url-encoding": true
            },
            {
              "in": "body",
              "name": "body",
              "description": "query options",
              "required": true,
              "schema": {
                "$ref": "#/definitions/EnrichmentStatusQueryOption"
              }
            }
          ],
          "responses": {
            "200": {
              "description": "Success",
              "schema": {
                "$ref": "#/definitions/EnrichmentStatusList"
              }
            },
            "default": {
              "description": "Client error or server error (4xx or 5xx)",
              "schema": {
                "$ref": "#/definitions/ErrorCode"
              }
            }
          },
          "x-ms-pageable": {
            "nextLinkName": null
          }
        }
      }
```
