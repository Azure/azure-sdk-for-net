# Microsoft.Azure.Synapse

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-vnet-2019-06-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/ba2d430b967bc6299fbedb8dc16ff039e08e1388/specification/synapse/data-plane/readme.md
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