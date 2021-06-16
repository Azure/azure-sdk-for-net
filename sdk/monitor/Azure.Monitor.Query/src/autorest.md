# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Query
input-file:
    - https://github.com/srnagar/azure-rest-api-specs/blob/a40aabf76646f487ba90350e3e489358d8ab135d/specification/operationalinsights/data-plane/Microsoft.OperationalInsights/preview/2021-05-19_Preview/OperationalInsights.json
    - https://github.com/Azure/azure-sdk-for-java/blob/1d14101ba93c6e616899c2ded93fbecb54699f84/sdk/monitor/azure-monitor-query/swagger/metrics_definitions.json
    - https://github.com/Azure/azure-sdk-for-java/blob/1d14101ba93c6e616899c2ded93fbecb54699f84/sdk/monitor/azure-monitor-query/swagger/metrics_namespaces.json
    - https://github.com/Azure/azure-sdk-for-java/blob/1d14101ba93c6e616899c2ded93fbecb54699f84/sdk/monitor/azure-monitor-query/swagger/metrics_swagger.json
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