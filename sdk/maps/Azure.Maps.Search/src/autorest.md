# Azure.Maps.Search Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- https://raw.githubusercontent.com/ambientlight/azure-rest-api-specs/c3d63b309c40735f1be9fa2ef2e88ca9f7b6d9bf/specification/maps/data-plane/Search/preview/1.0/search.json
title: SearchClient
openapi-type: data-plane
tag: 1.0-preview
add-credentials: true
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default

sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Search
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true

# modelerfour:
#   lenient-model-deduplication: true
```
