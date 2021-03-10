# Microsoft.Azure.Synapse.Artifacts

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-artifacts-2019-06-01-preview
require:
    - D:\code\AzureSDK\azure-rest-api-specs\specification\synapse\data-plane\readme.md
namespace: Azure.Analytics.Synapse.Artifacts
public-clients: true
credential-types: TokenCredential
credential-scopes: https://dev.azuresynapse.net/.default
modelerfour:
  lenient-model-deduplication: true
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
directive:
```

### Expose serialization and deserialization methods

``` yaml
- from: swagger-document
  where: $.definitions
  transform: >
    for (var path in $)
    {
      $[path]["x-csharp-usage"] = "converter";
    }
```