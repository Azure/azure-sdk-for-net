# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: MonitorQuery
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/9a46bdbfea7730a3521ac11f5ea1120007d67f79/specification/operationalinsights/data-plane/Microsoft.OperationalInsights/stable/2022-10-27/OperationalInsights.json
    - https://github.com/Azure/azure-rest-api-specs/blob/fc3c409825d6a31ba909a88ea34dcc13165edc9c/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/fc3c409825d6a31ba909a88ea34dcc13165edc9c/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metrics_API.json
    - https://github.com/Azure/azure-rest-api-specs/blob/fc3c409825d6a31ba909a88ea34dcc13165edc9c/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
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
