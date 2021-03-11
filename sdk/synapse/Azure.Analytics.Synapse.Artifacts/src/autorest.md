# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-artifacts-2019-06-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/85fc0666743639c4a1c864eae466ef950e7bc61b/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Artifacts
public-clients: true
credential-types: TokenCredential
credential-scopes: https://dev.azuresynapse.net/.default
modelerfour:
  lenient-model-deduplication: true
```