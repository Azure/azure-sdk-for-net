# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: MonitorQuery
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/dba6ed1f03bda88ac6884c0a883246446cc72495/specification/operationalinsights/data-plane/Microsoft.OperationalInsights/preview/2021-05-19_Preview/OperationalInsights.json
    - https://github.com/Azure/azure-rest-api-specs/blob/dba6ed1f03bda88ac6884c0a883246446cc72495/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/dba6ed1f03bda88ac6884c0a883246446cc72495/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metrics_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/dba6ed1f03bda88ac6884c0a883246446cc72495/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
modelerfour:
    lenient-model-deduplication: true
    seal-single-value-enum-by-default: true
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
