# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-monitoring-2019-11-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/8245419814abe72d2e2c5e79dc4cba8825d65e63/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Monitoring
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