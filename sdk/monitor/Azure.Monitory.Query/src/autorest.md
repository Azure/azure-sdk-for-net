# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Query
input-file:
    - https://github.com/srnagar/swagger/blob/10342704d989c644c15cb888a4b7cfe7c343e58b/log-query-swagger.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ca0869b49176e7bc3866debbab9d32999661c4cb/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metrics_API.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/cf33826d06605cde127d2241e54dd6df55e9145f/specification/monitor/resource-manager/Microsoft.Insights/stable/2018-01-01/metricDefinitions_API.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/cf33826d06605cde127d2241e54dd6df55e9145f/specification/monitor/resource-manager/Microsoft.Insights/preview/2017-12-01-preview/metricNamespaces_API.json
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