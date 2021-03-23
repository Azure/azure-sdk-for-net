# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-vnet-2019-06-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/aa19725fe79aea2a9dc580f3c66f77f89cc34563/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.ManagedPrivateEndpoints
public-clients: true
credential-types: TokenCredential
credential-scopes: https://dev.azuresynapse.net/.default
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```