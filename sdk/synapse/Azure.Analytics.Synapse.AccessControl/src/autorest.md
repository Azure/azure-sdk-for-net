# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-access-control-2020-08-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/f953424dd168e71373bc52edb9713d2d86a14ada/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.AccessControl
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