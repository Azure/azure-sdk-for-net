# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/c6d856b6ca7f079e96ed8680bd867b8d6c197669/specification/monitor/data-plane/ingestion/preview/2021-11-01-preview/DataCollectionRules.json
namespace: Azure.Monitor.Ingestion
security: AADToken
security-scopes: https://monitor.azure.com//.default
```

### todo: rename streamName
``` yaml
directive:
- from: swagger-document
  where: $.paths["/dataCollectionRules/{ruleId}/streams/{stream}"].post.parameters[1]
  transform: $["x-ms-client-name"] = "streamName";
```
### todo: change type of string uri
``` yaml
directive:
- from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url";
```
