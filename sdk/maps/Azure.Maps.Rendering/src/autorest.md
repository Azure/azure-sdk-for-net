# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/maps/data-plane/Render/preview/1.0/render.json
title: MapsRenderClient
openapi-type: data-plane
tag: 1.0
add-credentials: true
# at some point those credentials will move away to Swagger according to [this](https://github.com/Azure/autorest/issues/3718)
credential-default-policy-type: BearerTokenCredentialPolicy
credential-scopes: https://atlas.microsoft.com/.default
use-extension:
  "@autorest/modelerfour": "4.22.3"

generation1-convenience-client: true
model-namespace: false
sync-methods: None
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Azure.Maps.Rendering
public-clients: false
clear-output-folder: true
data-plane: true
skip-csproj: true
```

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
```
