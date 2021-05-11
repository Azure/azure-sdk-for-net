# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Query
input-file:
    - https://github.com/Azure/azure-sdk-for-java/blob/1d14101ba93c6e616899c2ded93fbecb54699f84/sdk/monitor/azure-monitor-query/swagger/log_query_swagger.json
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

### Rename errors property and add statistics

``` yaml
directive:
- from: swagger-document
  where: $.definitions.queryResults
  transform: >
    $.properties["statistics"] = { "type": "object" };
    $.properties["error"] = $.properties["errors"];
    delete $.properties["errors"];
```
