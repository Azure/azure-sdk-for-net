# Microsoft.Azure.Synapse

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-artifacts-2019-06-01-preview
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/aa19725fe79aea2a9dc580f3c66f77f89cc34563/specification/synapse/data-plane/readme.md
namespace: Azure.Analytics.Synapse.Artifacts
public-clients: true
modelerfour:
  lenient-model-deduplication: true
```