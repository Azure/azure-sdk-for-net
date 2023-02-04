# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-spark-2020-12-01
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/c9992af7235a6550087d4fed8f081ed35019f605/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Spark
generation1-convenience-client: true
public-clients: true
security: AADToken
security-scopes: https://dev.azuresynapse.net/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```
