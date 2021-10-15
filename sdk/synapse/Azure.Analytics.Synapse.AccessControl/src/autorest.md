# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-access-control-2020-12-01
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/19f27ab5dd8a39f13ad147e686263b465e93d4f0/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.AccessControl
public-clients: true
low-level-client: true
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
