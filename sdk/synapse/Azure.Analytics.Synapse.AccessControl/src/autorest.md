# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-access-control-2020-12-01
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/37c4ff1612668f5acec62dea729ca3a66b591d7f/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.AccessControl
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
