# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/d0188b838d6d338a688707c714803fdb3c1384ec/specification/monitor/data-plane/ingestion/stable/2023-01-01/DataCollectionRules.json
namespace: Azure.Monitor.Ingestion
security: AADToken
security-scopes: https://monitor.azure.com//.default
```

### Renames parameter in Upload methods to streamName
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
### Updates parameter description in DPG Upload/UploadAsync methods
``` yaml
directive:
- from: swagger-document
  where: $.paths["/dataCollectionRules/{ruleId}/streams/{stream}"].post.parameters[3]
  transform: $["description"] = "If content is already gzipped, put \"gzip\". Default behavior is to gzip all input";
```
