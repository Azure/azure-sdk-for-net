# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: MonitorQuery
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/21f5332f2dc7437d1446edf240e9a3d4c90c6431/specification/operationalinsights/data-plane/Microsoft.OperationalInsights/stable/2022-10-27/OperationalInsights.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/21f5332f2dc7437d1446edf240e9a3d4c90c6431/specification/monitor/data-plane/Microsoft.Insights/preview/2023-05-01-preview/metricBatch.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/21f5332f2dc7437d1446edf240e9a3d4c90c6431/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/21f5332f2dc7437d1446edf240e9a3d4c90c6431/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/21f5332f2dc7437d1446edf240e9a3d4c90c6431/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metrics_API.json
generation1-convenience-client: true
modelerfour:
    lenient-model-deduplication: true
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
