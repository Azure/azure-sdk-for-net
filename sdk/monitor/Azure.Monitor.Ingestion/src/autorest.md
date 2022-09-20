# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/d0188b838d6d338a688707c714803fdb3c1384ec/specification/monitor/data-plane/ingestion/preview/2021-11-01-preview/DataCollectionRules.json
namespace: Azure.Monitor.Ingestion
security: AADToken
security-scopes: https://monitor.azure.com//.default
```

### Renames paramter in Upload methods to streamName
``` yaml
directive:
- from: swagger-document
  where: $.paths["/dataCollectionRules/{ruleId}/streams/{stream}"].post.parameters[1]
  transform: $["x-ms-client-name"] = "streamName";
```
### Updates type of endpoint in LogsIngestionClient to Uri
``` yaml
directive:
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url";
```
### Updates default parameter contentEncoding value from null to gzip in Upload method
``` yaml
directive:
- from: swagger-document
  where: $.paths["/dataCollectionRules/{ruleId}/streams/{stream}"].post.parameters[3]
  transform: $["x-ms-client-default"] = "gzip";
```
