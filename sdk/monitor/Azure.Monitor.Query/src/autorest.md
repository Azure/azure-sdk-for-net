# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: MonitorQuery
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/0373f0edc4414fd402603fac51d0df93f1f70507/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metricDefinitions_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/0373f0edc4414fd402603fac51d0df93f1f70507/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metrics_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/0b64ca7cbe3af8cd13228dfb783a16b8272b8be2/specification/monitor/resource-manager/Microsoft.Insights/stable/2024-02-01/metricNamespaces_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/0550754fb421cd3a5859abf6713a542b682f626c/specification/monitor/data-plane/Microsoft.Insights/stable/2023-10-01/metricBatch.json
    - https://github.com/Azure/azure-rest-api-specs/blob/72427ef3ff5875bd8409ef112ef5e6f3cf2b8795/specification/operationalinsights/data-plane/Microsoft.OperationalInsights/stable/2022-10-27/OperationalInsights.json
generation1-convenience-client: true
modelerfour:
    lenient-model-deduplication: true
use-model-reader-writer: true
```

### Remove metadata operations

``` yaml
directive:
- from: swagger-document
  where: $
  transform: >
    delete $.securityDefinitions
```

``` yaml
directive:
- from: swagger-document
  where: $.paths
  transform: >
    for (var path in $)
    {
        if ($[path].get?.operationId.startsWith("Metadata_"))
        {
            delete $[path];
        }
    }
```

### Add statistics and render

``` yaml
directive:
- from: swagger-document
  where: $.definitions.logQueryResult
  transform: >
    $.properties["statistics"] = { "type": "object" };
    $.properties["render"] = { "type": "object" };
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.queryResults
  transform: >
    $.properties["error"] = { "type": "object" };
    $.properties["statistics"] = { "type": "object" };
    $.properties["render"] = { "type": "object" };
```

### Make properties required

``` yaml
directive:
- from: swagger-document
  where: $.definitions.column
  transform: >
    $.required = ["name", "type"]
```

``` yaml
directive:
- from: swagger-document
  where: $.parameters.ResourceIdParameter
  transform:
    $["x-ms-format"] = "arm-id"
```

### Keep previous constant behavior

Adding these two properties into required keeps the generator to generate the assignment of this property in ctor.

Adding the `x-ms-constant` extension prevents the generator from wrapping the type into an extensible enum

``` yaml
directive:
- from: swagger-document
  where: $.definitions.batchQueryRequest
  transform: >
    $.required.push("path");
    $.required.push("method");
    $.properties.path["x-ms-constant"] = true;
    $.properties.method["x-ms-constant"] = true;
```

### Change Interval to type 'Duration'

```yaml
directive:
- from: swagger-document
  where: $.definitions.MetricsResponse.properties.interval
  transform: >
    $["format"] = "duration";
```

```yaml
directive:
- from: swagger-document
  where: $.parameters.IntervalParameter
  transform: >
    $["format"] = "duration";
```

```yaml
directive:
- from: swagger-document
  where: $.definitions.Response.properties.interval
  transform: >
    $["format"] = "duration";
```

### Remove subscription scoped operations

``` yaml
directive:
  - remove-operation: MetricDefinitions_ListAtSubscriptionScope
  - remove-operation: Metrics_ListAtSubscriptionScope
  - remove-operation: Metrics_ListAtSubscriptionScopePost
```

### Convert guid/uuid format of subscriptionId to string

``` yaml
directive:
- from: swagger-document
  where: $.parameters.SubscriptionIdParameter
  transform: >
    $["format"] = "string";
```
