# Azure.Maps.Search Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
directive:
- from: swagger-document
  where: $.securityDefinitions
  transform: |
    $["azure_auth"] = $["AADToken"];
    delete $["AADToken"];
- from: swagger-document
  where: '$.security[0]'
  transform: |
    $["azure_auth"] = $["AADToken"];
    delete $["AADToken"];
- from: swagger-document
  where: $.securityDefinitions
  transform: |
    $["SharedKey"]["in"] = "header";
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c1260c7a90d503c18b0aeaf29968dfc0b4bf9e11/specification/maps/data-plane/Search/preview/1.0/search.json
title: SearchClient
openapi-type: data-plane
tag: 1.0-preview
add-credentials: true
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default
generation1-convenience-client: true
sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Search
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true
```
